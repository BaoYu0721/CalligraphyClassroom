#include "execution.h"
using namespace std;
#ifndef __VIDEO_PUSH_CPP
#define __VIDEO_PUSH_CPP

int initVideoPush(VideoPush ** ppVP)
{
	*ppVP = new VideoPush();
	InitializeCriticalSection(&(*ppVP)->csque);
	(*ppVP)->hPacketEvent = CreateEvent(NULL, FALSE, FALSE, NULL);
}

void destroyVideoPush(VideoPush ** ppVP)
{
	if (*ppVP)
	{
		VideoPush *pVD = *ppVP;
		if (pVD->outputContext)
		{
			avformat_free_context(pVD->outputContext);
		}

		while (!pVD->que.empty())
		{
			av_free_packet(pVD->que.front());
			pVD->que.pop();
		}
		LeaveCriticalSection(&pVD->csque);

		DeleteCriticalSection(&pVD->csque);
		CloseHandle(pVD->hPacketEvent);

		delete pVD;
	}
	ppVP = NULL;
}

int OpenOutput(AVFormatContext ** outputContext, string outUrl, AVFormatContext * inputContext)
{

	int ret = avformat_alloc_output_context2(outputContext, nullptr, "flv", outUrl.c_str());
	if (ret < 0)
	{
		av_log(NULL, AV_LOG_ERROR, "open output context failed\n");
		return ret;
	}

	ret = avio_open2(&(*outputContext)->pb, outUrl.c_str(), AVIO_FLAG_READ_WRITE, nullptr, nullptr);
	if (ret < 0)
	{
		av_log(NULL, AV_LOG_ERROR, "open avio failed");
		return ret;
	}
	//复制输入流通道到输出流通道
	for (int i = 0; i < inputContext->nb_streams; i++)
	{
		AVStream * stream = avformat_new_stream(*outputContext, inputContext->streams[i]->codec->codec);
		ret = avcodec_copy_context(stream->codec, inputContext->streams[i]->codec);
		if (ret < 0)
		{
			av_log(NULL, AV_LOG_ERROR, "copy coddec context failed");
			return ret;
		}
	}

	ret = avformat_write_header(*outputContext, nullptr);
	if (ret < 0)
	{
		av_log(NULL, AV_LOG_ERROR, "format write header failed");
		return ret;
	}

	av_log(NULL, AV_LOG_FATAL, " Open output file success %s\n", outUrl.c_str());
	return ret;
}

int destroyOutput(AVFormatContext ** outputContext)
{
	if (outputContext && *outputContext)
	{
		for (int i = 0; i < (*outputContext)->nb_streams; i++)
		{
			avcodec_close((*outputContext)->streams[i]->codec);
		}
		avformat_close_input(outputContext);
		*outputContext = NULL;
	}
	outputContext = NULL;
	return 0;
}

DWORD WINAPI pushThreadFunc(LPVOID lpParameter)
{
	VideoPush * pVD = (VideoPush *)lpParameter;
	//csque
	while (true)
	{
		if (pVD->que.empty())
		{
			WaitForSingleObject(pVD->hPacketEvent, INFINITE);//等待
		}
		if (!pVD->que.empty())
		{
			int ret = 0;
			AVPacket * pkt = NULL;

			EnterCriticalSection(&pVD->csque);
			pkt = pVD->que.front();
			pVD->que.pop();
			LeaveCriticalSection(&pVD->csque);
			ret = av_interleaved_write_frame(pVD->outputContext, pkt);//这个方法在网络较好的情况下，一般是几个毫秒就返回发送成功。在网络较差的情况下，会一直卡在这里，没有返回。。。
			av_free_packet(pkt);
			if (ret < 0) {
				g_onErrorCall(EEROR_CODE_WRITE_PACKET_ABNORMAL);
				//fprintf(stderr, "Error av_interleaved_write_frame\n");
				return ret;
			}
		}
	}
	return 0;
}


int startPush(AVFormatContext * inputContext, string outUrl, onPushStop onPushStop)
{
	initVideoPush(&g_pVideoPush);
	g_pVideoPush->onPushStop = onPushStop;
	int ret = OpenOutput(&(g_pVideoPush->outputContext), outUrl, inputContext);
	if (ret != 0)
	{
		//error
		return ret;
	}
		
	if (g_pVideoPush)
	{
		g_liveSatatus = 1;
		g_pVideoPush->thread = CreateThread(NULL, 0, pushThreadFunc, (void*)g_pVideoPush, NULL, 0);
		return ERROR_CODE_NONE_ERR;
	}
}

int stopPush()
{
	g_liveSatatus = 0;
	CloseHandle(g_pVideoPush->thread);
	destroyOutput(&(g_pVideoPush->outputContext));
	g_pVideoPush->onPushStop(ERROR_CODE_NONE_ERR);
	destroyVideoPush(&g_pVideoPush);

}

#endif