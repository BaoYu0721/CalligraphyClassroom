/*
dll导出函数
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
		如果已经在解码或者推流，返回错误；
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
	关闭解码
	*/
	return stopDecode();
}

int STDCALL startInputPush(string inputUrl, string outputUrl, onPushStop onPushStopCall)
{
	/*
	如果已经在解码在推流，返回错误；
	*/
	if (g_liveSatatus)
	{
		return ERROR_CODE_ALREADY_RUNNING;
	}
	/*
	1.
	  如果没有输入了，创建输入流；
	  如果已经有输入流:
			流地址与inputUrl相同，则不需要再次获取流;
							不相同，如果解码在进行；报错 
	2.启动直播 
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
	关闭推流
	*/
	return stopDecode();
}


#endif