using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeacherWorkTable
{
    public partial class SettingCameraListItem: UserControl
    {
        public SettingCameraListItem()
        {
            InitializeComponent();
        }

        private void lblNum_Click(object sender, EventArgs e)
        {

        }

        private void SettingCameraListItem_Load(object sender, EventArgs e)
        {
            SetBtnStyle(btnChange);
            SetBtnStyle(btnDel);
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

        private void btnChange_MouseEnter(object sender, EventArgs e)
        {
            this.btnChange.Image = global::TeacherWorkTable.Properties.Resources.change_button_blue;

        }

        private void btnChange_MouseLeave(object sender, EventArgs e)
        {
            this.btnChange.Image = global::TeacherWorkTable.Properties.Resources.change_button_white;

        }

        private void btnDel_MouseEnter(object sender, EventArgs e)
        {
            this.btnDel.Image = global::TeacherWorkTable.Properties.Resources.delete_button_blue;

        }

        private void btnDel_MouseLeave(object sender, EventArgs e)
        {
            this.btnDel.Image = global::TeacherWorkTable.Properties.Resources.delete_button_white;

        }
        static SettingControl sc = null;
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (sc == null)
            {
                sc = new SettingControl(this);
                sc.Parent = Parent.Parent.Parent;
                sc.GetLabel1.Text = "修改";
            }
            sc.Location = this.Parent.Parent.Location;
            this.Parent.Parent.Visible = false;
            sc.Visible = true;
        }
        public static SettingControl GetSc
        {
            get
            {
                return sc;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //如果该摄像头正在播放则停止
            string[] camera = new string[4];
            camera = DbControl.GetUseCameraDB();
            if(camera != null)
            {
                if (this.TabIndex == int.Parse(camera[0]))
                {
                    CameraPlay.Stop();
                }
            }

            if (!DbControl.DeleteCameraDB(int.Parse(this.cNum))){
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\Release\access.log", true, Encoding.UTF8))
                {
                    string strLog = DateTime.Now.ToString().Replace('/', '-') + " - error - 摄像头删除失败";
                    file.WriteLine(strLog);
                    file.Close();
                }
                return;
            }
            else
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\Release\access.log", true, Encoding.UTF8))
                {
                    string strLog = DateTime.Now.ToString().Replace('/', '-') + " - info - 摄像头删除成功";
                    file.WriteLine(strLog);
                    file.Close();
                }

                System.Windows.Forms.Panel panel = TeacherWorkTable.CaneraChangeList.GetPanel3;
                foreach (Control ctl in panel.Controls)
                {
                    if (ctl.GetType() == typeof(CameraChangeControl))
                    {
                        CameraChangeControl ccc = (CameraChangeControl)ctl;
                        if (ccc.TabIndex == int.Parse(this.cNum))
                        {
                            ccc.Dispose();
                            break;
                        }
                    }
                }

                this.Dispose();
            }
        }
    }
}
