using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherWorkTable
{
    public static class CameraPlay
    {
        public static void Init(System.Windows.Forms.PictureBox RealPlayWnd)
        {
            if (!m_Init)
            {
                m_Init = CHCNetSDK.NET_DVR_Init();
                if (!m_Init)
                {
                    Log("error", "Camera Init Msg 初始化失敗");
                }
                CHCNetSDK.NET_DVR_SetConnectTime(2000, 1);
                CHCNetSDK.NET_DVR_SetReconnect(10000, 1);
            }
            m_RealPlayWnd = RealPlayWnd;
        }
        public static bool Login(string ip, string user, string pwd)
        {
            if (!m_Init) return false;
            if(m_lUserID < 0)
            {
                m_lUserID = CHCNetSDK.NET_DVR_Login_V30(ip, 8000, user, pwd, ref DeviceInfo);
                if(m_lUserID < 0)
                {
                    Log("error", "Camera Login Msg 失敗");
                    return false;
                }
                else
                {
                    //Log("info", "Camera Login Msg 成功");
                    return true;
                }
            }
            else
            {
                if(m_lRealHandle >= 0)
                {
                    Log("info", "Camera Login Msg 请先停止视频预览");
                    return false;
                }
                if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                {
                    Log("error", "Camera Logout Msg 失败");
                    return false;
                }
                m_lUserID = -1;
            }
            return true;
        }
        public static void Play()
        {
            if(m_lUserID < 0)
            {
                Log("info", "Camera Play Msg 请先Login");
                return;
            }
            if(m_lRealHandle < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = m_RealPlayWnd.Handle;                                        //预览窗口 live view window
                lpPreviewInfo.lChannel = 1;                                                         //预览的设备通道 the device channel number
                lpPreviewInfo.dwStreamType = 0;                                                     //码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                lpPreviewInfo.dwLinkMode = 0;                                                       //连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                lpPreviewInfo.bBlocked = true;                                                      //0- 非阻塞取流，1- 阻塞取流
                lpPreviewInfo.dwDisplayBufNum = 15;                                                 //播放库显示缓冲区最大帧数
                IntPtr pUser = IntPtr.Zero;                                                         //用户数据
                m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null, pUser);
                if(m_lRealHandle < 0)
                {
                    Log("error", "Camera Play Msg 预览失败");
                    if (m_lUserID >= 0)
                    {
                        if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                        {
                            Log("info", "Camera Logout Msg 失败");
                        }
                        m_lUserID = -1;
                    }
                    return;
                }
                else
                {
                    //Log("info", "Camera Play Msg 预览成功");
                    return;
                }
            }
            else
            {
                if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                {
                    Log("error", "Camera Play Msg 停止预览失败");
                    return;
                }
                m_lRealHandle = -1;
                m_RealPlayWnd.Invalidate();
            }
            return;
        }

        public static bool Stop()
        {
            if(m_lRealHandle >= 0)
            {
                if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                {
                    Log("error", "Camera Play Msg 停止预览失败");
                    return false;
                }
                m_lRealHandle = -1;
                m_RealPlayWnd.Invalidate();
            }
            if (m_lUserID >= 0)
            {
                if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                {
                    Log("error", "Camera Logout Msg 失败");
                }
                m_lUserID = -1;
            }
            return true;
        }

        private static void Log(string level, string strLog)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\Release\access.log", true, Encoding.UTF8))
            {
                string str = DateTime.Now.ToString().Replace('/', '-') + " - " + level + " - " + strLog;
                file.WriteLine(str);
                file.Close();
            }
        }

        private static Int32 m_lUserID = -1;
        private static Int32 m_lRealHandle = -1;
        private static bool m_Init = false;
        private static System.Windows.Forms.PictureBox m_RealPlayWnd;
        private static CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
    }
}
