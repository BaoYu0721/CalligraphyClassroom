using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TeacherWorkTable
{
    public class Video
    {
        public delegate int dlgtOnFrameRead(IntPtr frameData, int size);
        public delegate int delOnError(int errCode);
        public delegate int dlgOnDecodeStop(int errCode);
        public delegate int dlgOnPushStop(int errCode);


        [DllImport("RTSPPlayAndPushToRTMP.dll", CharSet = CharSet.Ansi)]
        extern private static void initffmpeg(delOnError onErrorCall);

        [DllImport("RTSPPlayAndPushToRTMP.dll", CharSet = CharSet.Ansi)]
        extern private static int startInputDecode(string url, dlgtOnFrameRead dataCall,dlgOnDecodeStop stopCall);

        [DllImport("RTSPPlayAndPushToRTMP.dll", CharSet = CharSet.Ansi)]
        extern public static int stopInputDecode();

        [DllImport("RTSPPlayAndPushToRTMP.dll", CharSet = CharSet.Ansi)]
        extern public static int startInputPush(string url, string outputUrl, dlgOnPushStop stopCall);

        [DllImport("RTSPPlayAndPushToRTMP.dll", CharSet = CharSet.Ansi)]
        extern public static int stopInputPush();


        private Video()
        {

        }

        public void init(delOnError errCall)
        {
            initffmpeg(errCall);
        }

        public int onFrameread(IntPtr frameData, int size)
        {
            byte[] data = new byte[size];
            Marshal.Copy(frameData, data, 0, size);
            MemoryStream ms = new MemoryStream(data);

            setImage(ms);
            ms.Close();
            return 0;
        }

        public delegate void dlgtSetImage(MemoryStream ms);
        dlgtSetImage setImage = null;

        public int startDecode(string url, dlgtSetImage SICall, dlgOnDecodeStop stopCall)
        {
            //setImage = SICall;
            return 0; //startInputDecode(url, new dlgtOnFrameRead(onFrameread), stopCall);
        }

        // 定义一个静态变量来保存类的实例
        private static Video uniqueInstance;

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Video GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (uniqueInstance == null)
            {
                uniqueInstance = new Video();
            }
            return uniqueInstance;
        }

        public static string GetErrorMsg(int errCode)
        {
            return errCode.ToString();
        }
    }
}
