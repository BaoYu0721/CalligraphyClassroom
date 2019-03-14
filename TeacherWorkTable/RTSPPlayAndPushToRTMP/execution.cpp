#include "execution.h"

using namespace std;


int OpenInput(AVFormatContext ** inputContext,string inputUrl)
{
	*inputContext = avformat_alloc_context();
	AVDictionary* options = nullptr;
	av_dict_set(&options, "rtsp_transport", "udp", 0);
	av_dict_set(&options, "stimeout", "6000000", 0);//设置超时返回，单位微秒；不设置时，获取不到流不返回
	av_dict_set(&options, "max_delay", "500000", 0);//设置最大时延
	int ret = avformat_open_input(inputContext, inputUrl.c_str(), nullptr, &options);
	if (ret < 0)
	{
		//av_strerror();
		av_log(NULL, AV_LOG_ERROR, "Input file open input failed\n");
		return  ret;
	}
	ret = avformat_find_stream_info(*inputContext, nullptr);
	if (ret < 0)
	{
		av_log(NULL, AV_LOG_ERROR, "Find input file stream inform failed\n");
	}
	else
	{
		av_log(NULL, AV_LOG_FATAL, "Open input file  %s success\n", inputUrl.c_str());
	}
	return ret;
}

shared_ptr<AVPacket> ReadPacketFromSource(AVFormatContext * inputContext)
{
	shared_ptr<AVPacket> packet(static_cast<AVPacket*>(av_malloc(sizeof(AVPacket))), [&](AVPacket *p) { av_packet_free(&p); av_freep(&p); });
	av_init_packet(packet.get());
	int ret = av_read_frame(inputContext, packet.get());
	if (ret >= 0)
	{
		return packet;
	}
	else
	{
		return nullptr;
	}
}


void av_packet_rescale_ts(AVPacket *pkt, AVRational src_tb, AVRational dst_tb)
{
	if (pkt->pts != AV_NOPTS_VALUE)
		pkt->pts = av_rescale_q(pkt->pts, src_tb, dst_tb);
	if (pkt->dts != AV_NOPTS_VALUE)
		pkt->dts = av_rescale_q(pkt->dts, src_tb, dst_tb);
	if (pkt->duration > 0)
		pkt->duration = av_rescale_q(pkt->duration, src_tb, dst_tb);
}

int WritePacket(shared_ptr<AVPacket> packet, AVFormatContext * inputContext, VideoPush *pVP)
{
	auto inputStream = inputContext->streams[packet->stream_index];
	auto outputStream = pVP->outputContext->streams[packet->stream_index];
	AVPacket * pkt = av_packet_clone(packet.get());  //复制一份，作为修改时间戳后的发送包
	av_packet_rescale_ts(pkt, inputStream->time_base, outputStream->time_base);

	//return av_interleaved_write_frame(outputContext, pkt);//这个方法在网络较好的情况下，一般是几个毫秒就返回发送成功。在网络较差的情况下，会一直卡在这里，没有返回。。。
	EnterCriticalSection(&(pVP->csque));
	pVP->que.push(av_packet_clone(pkt));
	LeaveCriticalSection(&(pVP->csque));
	SetEvent(pVP->hPacketEvent);
	return 0;
}


int execute()
{
	int getPacketAbnormalTimes = 0; //联系获取包异常的次数
	while (g_decodeStatus || g_liveSatatus)
	{
		auto packet = ReadPacketFromSource(g_inputContext);
		if (packet)
		{
			getPacketAbnormalTimes = 0;
			if (g_liveSatatus && g_pVideoPush)
			{
				WritePacket(packet, g_inputContext, g_pVideoPush);
			}
			if (g_decodeStatus && g_pVideoDecode)
			{
				if (packet->stream_index ==  g_pVideoDecode->video_stream_idx) //只处理视频包
				{
					EnterCriticalSection(&g_pVideoDecode->csque);
					g_pVideoDecode->que.push(av_packet_clone(packet.get()));
					LeaveCriticalSection(&g_pVideoDecode->csque);
					SetEvent(g_pVideoDecode->hPacketEvent);
				}
			}
		}
		else
		{
			getPacketAbnormalTimes++;
			if (getPacketAbnormalTimes > MAX_GET_PACKET_ABNORMAL_TIMES)
			{
				g_onErrorCall(ERROT_CODE_GET_PACKET_ABNORMAL);
				break;
			}

		}
	}
	if (g_decodeStatus)
	{
		stopDecode();
	}
	if (g_liveSatatus)
	{
		stopPush();
	}
	//
	avformat_close_input(&g_inputContext);
	g_inputContext = NULL;
	return 0;
}

/*三个线程
 1.从输入流获取包并放入对应的循环队列
 2.从队列中取得包，并解码为rgb图片回调页面
 3.从队列取得包，发送出去

*/

onError g_onErrorCall;

int g_decodeStatus = 0; //解码操作状态：0不解码；1解码
int g_liveSatatus = 0;  //直播状态：0不解码；1解码

AVFormatContext *g_inputContext = nullptr;

VideoDecode * g_pVideoDecode = NULL;
VideoPush * g_pVideoPush = NULL;
