using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherWorkTable
{
    public partial class TopMenuControl: UserControl
    {
        Form wndForm = null;
        public TopMenuControl()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            wndForm = (Form)this.Parent;   //该空间必须直接放置与form中

            //设置透明
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.icon.BackColor = Color.Transparent;
            this.pbTitle.BackColor = Color.Transparent;
            SetBtnStyle(this.btnMin);
            SetBtnStyle(this.btnClose);
            
        }

        private void btnMin_Click(object sender, EventArgs e)
        {

            wndForm.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            wndForm.Close(); 
        }

        private void SetBtnStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;//样式
            btn.ForeColor = Color.Transparent;//前景
            btn.BackColor = Color.Transparent;//去背景
            btn.FlatAppearance.BorderSize = 0;//去边线
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下
        }
        private void btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderSize = 1;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {

        }
        //实现拖动窗口
        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键

        private void TopMenuControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }

        private void TopMenuControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                wndForm.Location = mouseSet;
            }
        }

        private void TopMenuControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        private void lblTitle_TextChanged(object sender, EventArgs e)
        {
            lblTitle.Location = new Point((this.Size.Width - lblTitle.Size.Width) / 2, lblTitle.Location.Y);
        }
    }
}
