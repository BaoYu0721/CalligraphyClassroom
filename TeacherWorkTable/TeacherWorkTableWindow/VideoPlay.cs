using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TeacherWorkTable
{
    class VideoPlay
    {
        public delegate int dlgtOnFrameRead(IntPtr frameData, int size);
        public int iFramerate = 10;//每10帧图像播出几帧
        string rtsp_url = "";

        Thread m_thread = null;
        int m_status = 0;  //播放状态

        public delegate void dlgtSetImage(MemoryStream ms);
        dlgtSetImage setImage = null;

        public int onFrameread(IntPtr frameData, int size)
        {
            byte[] data = new byte[size];
            Marshal.Copy(frameData, data, 0, size);
            MemoryStream ms = new MemoryStream(data);

            setImage(ms);
            ms.Close();
            return 0;
        }


        [DllImport("libffRtsp.dll", CharSet = CharSet.Ansi)]
        extern private static int startDecode(string url, int framerate, dlgtOnFrameRead dataCall);

        [DllImport("libffRtsp.dll", CharSet = CharSet.Ansi, EntryPoint = "setEndDecode")]
        extern private static int setEndDecode();

        private void doJob()
        {
            try
            {
                startDecode(rtsp_url, iFramerate, new dlgtOnFrameRead(onFrameread));
            }
            catch (System.Exception ex)
            {
               // System.Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        private void startPaly()
        {
             /*
                 *这种方式创建进程后，调用Abort后，进程并不处理，导致无法结束进程，原因不明；
                 *尝试在dll里创建进程，通过函数调用和结束
                 */
             try
            {
                 if(m_status == 1)
                 {
                     if (m_thread != null && m_thread.IsAlive)
                    {
                        setEndDecode();
                        /*m_thread.Abort(); 不能强制线程退出，会导致参数不能变回原始状态，线程死锁等
                        m_thread.Join();*/
                        m_status = 0;

                    }
                 }
                 m_thread = new Thread(new ThreadStart(doJob));
                    m_thread.IsBackground = true;
                    m_thread.Start();
                    m_status = 1;
             }
             catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void play(String url,dlgtSetImage fun)
        {
            setImage = fun;
            /*if(rtsp_url == url)
            {
                if(m_status == 0)
                {
                    startPaly();
                }
            }
            else
            {*/
                rtsp_url = url;
                startPaly();
            //}*/
        }
    }
}
