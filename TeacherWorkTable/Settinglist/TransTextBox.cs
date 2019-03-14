using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TeacherWorkTable
{
    class TransTextBox:TextBox
    {
        //解决TextBox不支持透明的问题
       

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadLibrary(string lpFileName);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams prams = base.CreateParams;
                if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
                {
                    prams.ExStyle |= 0x020;
                    prams.ClassName = "RICHEDIT50W";
                }
                return prams;
            }
        }

        //若此控件下存在背景图片容器（如：PictureBox,Panle），会发现输入后再删除时文字会残留,
        //目前我是通过给此派生控件添加事件函数来刷新界面解决的

        public TransTextBox()
        {
            this.TextChanged += new System.EventHandler(this.TransTextBox_TextChanged);
            this.LostFocus += new EventHandler(this.TransTextBox_LostFocus);  
        }

        private void TransTextBox_LostFocus(object sender, EventArgs e)
        {

            this.Parent.Refresh();
            
        }

        private void TransTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Parent.Refresh();
            
        }  
    }
}
