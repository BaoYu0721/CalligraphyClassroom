#include "execution.h"

using namespace std;


int OpenInput(AVFormatContext ** inputContext,string inputUrl)
{
	*inputContext = avformat_alloc_context();
	AVDictionary* options = nullptr;
	av_dict_set(&options, "rtsp_transport", "udp", 0);
	av_dict_set(&options, "stimeout", "6000000", 0);//���ó�ʱ���أ���λ΢�룻������ʱ����ȡ������������
	av_dict_set(&options, "max_delay", "500000", 0);//�������ʱ��
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
	AVPacket * pkt = av_packet_clone(packet.get());  //����һ�ݣ���Ϊ�޸�ʱ�����ķ��Ͱ�
	av_packet_rescale_ts(pkt, inputStream->time_base, outputStream->time_base);

	//return av_interleaved_write_frame(outputContext, pkt);//�������������Ϻõ�����£�һ���Ǽ�������ͷ��ط��ͳɹ���������ϲ������£���һֱ�������û�з��ء�����
	EnterCriticalSection(&(pVP->csque));
	pVP->que.push(av_packet_clone(pkt));
	LeaveCriticalSection(&(pVP->csque));
	SetEvent(pVP->hPacketEvent);
	return 0;
}


int execute()
{
	int getPacketAbnormalTimes = 0; //��ϵ��ȡ���쳣�Ĵ���
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
				if (packet->stream_index ==  g_pVideoDecode->video_stream_idx) //ֻ������Ƶ��
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

/*�����߳�
 1.����������ȡ���������Ӧ��ѭ������
 2.�Ӷ�����ȡ�ð���������ΪrgbͼƬ�ص�ҳ��
 3.�Ӷ���ȡ�ð������ͳ�ȥ

*/

onError g_onErrorCall;

int g_decodeStatus = 0; //�������״̬��0�����룻1����
int g_liveSatatus = 0;  //ֱ��״̬��0�����룻1����

AVFormatContext *g_inputContext = nullptr;

VideoDecode * g_pVideoDecode = NULL;
VideoPush * g_pVideoPush = NULL;
