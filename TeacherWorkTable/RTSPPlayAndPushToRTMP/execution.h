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
typedef  int(STDCALL *onDecodeStop)(int errCode); //errCodeΪ������ʽ��������������ĳ�ִ����µĽ���
typedef  int(STDCALL *onPushStop)(int errCode); //errCodeΪ������ʽ��������������ĳ�ִ����µĽ���



#define MAX_GET_PACKET_ABNORMAL_TIMES  10
#define MAX_WRITE_PACKET_ABNORMAL_TIMES 10;

//�����룬����ֵ���߻ص�������ʹ��
enum ErrorCode {
	ERROR_CODE_NONE_ERR = 0,  
	ERROR_CODE_UNKNOWN,  //δ֪����
	ERROR_CODE_ALREADY_RUNNING, // �Ѿ�������
	ERROT_CODE_GET_PACKET_ABNORMAL,//��ȡ������
	EEROR_CODE_WRITE_PACKET_ABNORMAL,//����д�����

	ERROR_CODE_NB

};

struct VideoPush
{
	AVFormatContext *outputContext;
	queue<AVPacket*> que;
	HANDLE thread;
	CRITICAL_SECTION csque;//����que�Ļ�����
	HANDLE hPacketEvent;//��ȡ��֡�¼�
	onPushStop onPushStop;
};
struct VideoDecode
{
	int videoWidth;
	int videoHeight;
	int video_stream_idx;
	AVCodecContext *video_dec_ctx = NULL;//������
	AVFrame *frame = NULL; //�����л�ȡ��֡

	SwsContext* sws_cxt = NULL; //֡��ʽת����

	//ת�����֡�洢
	uint8_t *video_dst_data[4];
	int      video_dst_linesize[4];
	int video_dst_bufsize;

	onFrameData onFrameDataCall;
	onDecodeStop onDecodeStop;
	queue<AVPacket*> que;
	HANDLE thread;
	CRITICAL_SECTION csque;//����que�Ļ�����
	HANDLE hPacketEvent;//��ȡ��֡�¼�
};



extern onError g_onErrorCall;

extern int g_decodeStatus; //�������״̬��0�����룻1����
extern int g_liveSatatus;  //ֱ��״̬��0�����룻1����

extern AVFormatContext *g_inputContext;

extern VideoDecode * g_pVideoDecode;
extern VideoPush * g_pVideoPush;

int OpenInput(AVFormatContext ** inputContext, string inputUrl);

//��ʼ����������ṹ���ݣ������������̣߳��ɹ�����ERROR_CODE_NONE_ERR��ʧ�ܷ�����Ӧ�Ĵ����룻
int startDecode(AVFormatContext * inputContext, onFrameData onFrameDataCall, onDecodeStop onDecodeStop);
int stopDecode();

int startPush(AVFormatContext * inputContext, string outUrl, onPushStop onPushStop);
int stopPush();

#endif