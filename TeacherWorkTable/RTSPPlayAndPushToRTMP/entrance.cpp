/*
dll��������
*/
#define __ENTRANCE_CPP
#ifdef __ENTRANCE_CPP

#include "include.h"
#include "execution.h"
using namespace std;

string g_inputUrl;


void STDCALL initffmpeg(onError onErrorCall)
{
	g_onErrorCall = onErrorCall;
	av_register_all();
	avfilter_register_all();
	avformat_network_init();
	av_log_set_level(AV_LOG_ERROR);
}

int STDCALL startInputDecode(string inputUrl, onFrameData onFrameDataCall, onDecodeStop onDecodeStopCall)
{
	/*
		����Ѿ��ڽ���������������ش���
	*/
	if (g_decodeStatus || g_liveSatatus )
	{
		return ERROR_CODE_ALREADY_RUNNING;
	}
	g_inputUrl = inputUrl;
	OpenInput(&g_inputContext, g_inputUrl);
	startDecode(g_inputContext, onFrameDataCall, onDecodeStopCall);
}

int STDCALL stopInputDecode()
{
	/*
	�رս���
	*/
	return stopDecode();
}

int STDCALL startInputPush(string inputUrl, string outputUrl, onPushStop onPushStopCall)
{
	/*
	����Ѿ��ڽ��������������ش���
	*/
	if (g_liveSatatus)
	{
		return ERROR_CODE_ALREADY_RUNNING;
	}
	/*
	1.
	  ���û�������ˣ�������������
	  ����Ѿ���������:
			����ַ��inputUrl��ͬ������Ҫ�ٴλ�ȡ��;
							����ͬ����������ڽ��У����� 
	2.����ֱ�� 
	*/
	
	if (g_decodeStatus)
	{
		if (g_inputUrl == inputUrl)
		{
			return startPush(g_inputContext, outputUrl, onPushStopCall);
		}
		else
		{
			return ERROR_CODE_ALREADY_RUNNING;
		}
	}
	else
	{
		g_inputUrl = inputUrl;
		OpenInput(&g_inputContext, g_inputUrl);
		return startPush(g_inputContext, outputUrl, onPushStopCall);
	}
}
int STDCALL stopInputPush()
{
	/*
	�ر�����
	*/
	return stopDecode();
}


#endif