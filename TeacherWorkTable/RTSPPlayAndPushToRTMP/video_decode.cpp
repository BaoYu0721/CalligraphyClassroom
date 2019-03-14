#include "include.h"
#include "execution.h"
using namespace std;
#ifndef __VIDEO_DECODE_CPP
#define __VIDEO_DECODE_CPP

int initVideoDecode(VideoDecode ** ppVD, AVFormatContext * inputContext)
{
	VideoDecode * pVD = *ppVD = new VideoDecode();
	int ret = 0;
	int errCode = 0;
	//查找视频流和对应的解码器
	AVCodec *dec = NULL;
	pVD->video_stream_idx = av_find_best_stream(inputContext, AVMEDIA_TYPE_VIDEO, -1, -1, NULL, 0);//查找文件中视频的流信息
	if (pVD->video_stream_idx < 0) {
		fprintf(stderr, "Could not find %s stream in input file \n", av_get_media_type_string(AVMEDIA_TYPE_VIDEO));
		goto Error;
	}
	else {

		/* find decoder for the stream */
		pVD->video_dec_ctx = inputContext->streams[pVD->video_stream_idx]->codec;
		dec = avcodec_find_decoder(pVD->video_dec_ctx->codec_id); //在库里面查找支持该格式的解码器
		if (!dec) {
			fprintf(stderr, "Failed to find %s codec\n", av_get_media_type_string(AVMEDIA_TYPE_VIDEO));
			goto Error;
		}

		if ((ret = avcodec_open2(pVD->video_dec_ctx, dec, NULL)) < 0) //打开解码器 or 初始化一个视音频编解码器的AVCodecContext
		{
			fprintf(stderr, "Failed to open %s codec\n", av_get_media_type_string(AVMEDIA_TYPE_VIDEO));
			goto Error;
		}
	}
	pVD->frame = av_frame_alloc();

	//初始化转码后的图片存放空间，不做缩放
	/* allocate image where the decoded image will be put */
	pVD->video_dst_bufsize = av_image_alloc(pVD->video_dst_data, pVD->video_dst_linesize, pVD->video_dec_ctx->width, pVD->video_dec_ctx->height,
		AV_PIX_FMT_RGB24, 1);
	if (pVD->video_dst_bufsize < 0)
	{
		fprintf(stderr, "Could not allocate raw video buffer\n");
		goto Error;
	}
	//初始化帧格式转换器
	pVD->sws_cxt = sws_getContext(
		pVD->video_dec_ctx->width, pVD->video_dec_ctx->height, pVD->video_dec_ctx->pix_fmt,
		pVD->video_dec_ctx->width, pVD->video_dec_ctx->height, AV_PIX_FMT_BGR24, SWS_BILINEAR, NULL, NULL, NULL);

	InitializeCriticalSection(&pVD->csque);
	pVD->hPacketEvent = CreateEvent(NULL, FALSE, FALSE, NULL);

	return errCode;

Error:
	delete pVD;
	ppVD = NULL;
	return errCode;
}

void destroyVideoDecode(VideoDecode **ppVD)
{
	if (*ppVD)
	{
		VideoDecode* pVD = *ppVD;
		if (pVD->video_dec_ctx)
		{
			avcodec_close(pVD->video_dec_ctx);
			pVD->video_dec_ctx = NULL;
		}
		if (pVD->frame)
		{
			av_free(pVD->frame);
			pVD->frame = NULL;
		}
		if (pVD->video_dst_data[0])
		{
			av_free(pVD->video_dst_data[0]);
			pVD->video_dst_data[0] = NULL;
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
	ppVD = NULL;
}

void ContructBhh(int nWidth, int nHeight, BITMAPFILEHEADER& bhh) //add 2010-9-04
{
	int widthStep = (((nWidth * 24) + 31) & (~31)) / 8; //每行实际占用的大小（每行都被填充到一个4字节边界）
	bhh.bfType = ((unsigned short)('M' << 8) | 'B');  //'BM'
	bhh.bfSize = (DWORD)sizeof(BITMAPFILEHEADER) + (DWORD)sizeof(BITMAPINFOHEADER) + widthStep * nHeight;
	bhh.bfReserved1 = 0;
	bhh.bfReserved2 = 0;
	bhh.bfOffBits = (DWORD)sizeof(BITMAPFILEHEADER) + (DWORD)sizeof(BITMAPINFOHEADER);
}


void ConstructBih(int nWidth, int nHeight, BITMAPINFOHEADER& bih)
{
	int widthStep = (((nWidth * 24) + 31) & (~31)) / 8;

	bih.biSize = 40;       // header size
	bih.biWidth = nWidth;
	bih.biHeight = nHeight;
	bih.biPlanes = 1;
	bih.biBitCount = 24;     // RGB encoded, 24 bit
	bih.biCompression = BI_RGB;   // no compression 非压缩
	bih.biSizeImage = widthStep*nHeight;
	bih.biXPelsPerMeter = 0;
	bih.biYPelsPerMeter = 0;
	bih.biClrUsed = 0;
	bih.biClrImportant = 0;

}

int outputData( VideoDecode * pVD)
{
	char* data = (char*)pVD->video_dst_data[0];
	int w = pVD->video_dec_ctx->width;
	int h = pVD->video_dec_ctx->height;
	int widthStep = (((w * 24) + 31) & (~31)) / 8;
	char* bmp = new char[pVD->video_dst_bufsize];
	for (int i = 0; i< h; i++)
	{
		memcpy(bmp + i*widthStep, data + (h - i - 1)*widthStep, widthStep);
	}
	string str;
	BITMAPFILEHEADER bitmapHeader = { 0 };
	ContructBhh(w, h, bitmapHeader);
	str.append((char*)&bitmapHeader, sizeof(BITMAPFILEHEADER));
	BITMAPINFOHEADER infoHeader = { 0 };
	ConstructBih(w, h, infoHeader);
	str.append((char*)&infoHeader, sizeof(BITMAPINFOHEADER));
	str.append(bmp, pVD->video_dst_bufsize);
	delete[] bmp;

	if (pVD->onFrameDataCall)
	{
		pVD->onFrameDataCall((char*)str.data(), str.size());
	}
}

DWORD WINAPI decodeThreadFunc(LPVOID lpParameter)
{
	VideoDecode * pVD = (VideoDecode *)lpParameter;

	int ret = 0;
	AVPacket * pkt = NULL;
	int got_frame = 0;

	while (g_decodeStatus)
	{
		if (pVD->que.empty())
		{
			WaitForSingleObject(pVD->hPacketEvent, INFINITE);//等待
		}
		if (!pVD->que.empty())
		{
			EnterCriticalSection(&pVD->csque);
			pkt = pVD->que.front();
			pVD->que.pop();
			LeaveCriticalSection(&pVD->csque);
			/* decode video frame */
			ret = avcodec_decode_video2(pVD->video_dec_ctx, pVD->frame, &got_frame, pkt); //解码该帧
			av_free_packet(pkt);
			if (ret < 0) {
				fprintf(stderr, "Error avcodec_decode_video2\n");
				continue;
			}
			if (got_frame) {
				sws_scale(pVD->sws_cxt, pVD->frame->data, pVD->frame->linesize, 0, pVD->video_dec_ctx->height,
					pVD->video_dst_data, pVD->video_dst_linesize);

				outputData(pVD);

			}
		}
	}
	return 0;
}

int startDecode(AVFormatContext * inputContext, onFrameData onFrameDataCall, onDecodeStop onDecodeStop)
{
	int ret = initVideoDecode(&g_pVideoDecode,inputContext);
	if (g_pVideoDecode)
	{
		g_pVideoDecode->onFrameDataCall = onFrameDataCall;
		g_pVideoDecode->onDecodeStop = onDecodeStop;
		g_pVideoDecode->thread = CreateThread(NULL, 0, decodeThreadFunc, (void*)g_pVideoDecode, NULL,0);
		g_decodeStatus = 1;
		return ERROR_CODE_NONE_ERR;
	}
	else
	{
		return ret;
	}
}

int stopDecode()
{
	g_pVideoDecode = false;
	CloseHandle(g_pVideoDecode->thread);
	onDecodeStop(ERROR_CODE_NONE_ERR);
	destroyVideoDecode(&g_pVideoDecode);
	return (int)ERROR_CODE_NONE_ERR;
}

#endif