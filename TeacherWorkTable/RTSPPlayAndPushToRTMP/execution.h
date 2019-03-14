#ifndef EXECUTION_H
#define EXECUTION_H

#include "include.h"
#include <Windows.h>
#include <queue>
#include <wingdi.h>
using namespace std;



#define STDCALL  __stdcall 


typedef  int(STDCALL *onFrameData)(char* FrameData, int dataSize);
typedef  int(STDCALL *onError)(int errCode);
typedef  int(STDCALL *onDecodeStop)(int errCode); //errCode为结束方式，正常结束或者某种错误导致的结束
typedef  int(STDCALL *onPushStop)(int errCode); //errCode为结束方式，正常结束或者某种错误导致的结束



#define MAX_GET_PACKET_ABNORMAL_TIMES  10
#define MAX_WRITE_PACKET_ABNORMAL_TIMES 10;

//错误码，返回值或者回调函数中使用
enum ErrorCode {
	ERROR_CODE_NONE_ERR = 0,  
	ERROR_CODE_UNKNOWN,  //未知错误
	ERROR_CODE_ALREADY_RUNNING, // 已经在运行
	ERROT_CODE_GET_PACKET_ABNORMAL,//获取包错误
	EEROR_CODE_WRITE_PACKET_ABNORMAL,//推流写入错误

	ERROR_CODE_NB

};

struct VideoPush
{
	AVFormatContext *outputContext;
	queue<AVPacket*> que;
	HANDLE thread;
	CRITICAL_SECTION csque;//访问que的互斥量
	HANDLE hPacketEvent;//获取到帧事件
	onPushStop onPushStop;
};
struct VideoDecode
{
	int videoWidth;
	int videoHeight;
	int video_stream_idx;
	AVCodecContext *video_dec_ctx = NULL;//解码器
	AVFrame *frame = NULL; //从流中获取的帧

	SwsContext* sws_cxt = NULL; //帧格式转换器

	//转换后的帧存储
	uint8_t *video_dst_data[4];
	int      video_dst_linesize[4];
	int video_dst_bufsize;

	onFrameData onFrameDataCall;
	onDecodeStop onDecodeStop;
	queue<AVPacket*> que;
	HANDLE thread;
	CRITICAL_SECTION csque;//访问que的互斥量
	HANDLE hPacketEvent;//获取到帧事件
};



extern onError g_onErrorCall;

extern int g_decodeStatus; //解码操作状态：0不解码；1解码
extern int g_liveSatatus;  //直播状态：0不解码；1解码

extern AVFormatContext *g_inputContext;

extern VideoDecode * g_pVideoDecode;
extern VideoPush * g_pVideoPush;

int OpenInput(AVFormatContext ** inputContext, string inputUrl);

//初始化解码所需结构数据，并创建解码线程，成功返回ERROR_CODE_NONE_ERR，失败返回相应的错误码；
int startDecode(AVFormatContext * inputContext, onFrameData onFrameDataCall, onDecodeStop onDecodeStop);
int stopDecode();

int startPush(AVFormatContext * inputContext, string outUrl, onPushStop onPushStop);
int stopPush();

#endif