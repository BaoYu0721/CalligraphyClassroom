using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace TeacherWorkTable
{
    public partial class CaneraChangeList : UserControl
    {
        public CaneraChangeList()
        {
            InitializeComponent();
            //
            //获取摄像头信息
            //
            GetCameraList();
        }

        private void CaneraChangeList_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            //label2.BackColor = Color.Transparent;
            //label3.BackColor = Color.Transparent;
            //label4.BackColor = Color.Transparent;
            SetBtnStyle(btnTelescopic);
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

        public bool isExtended = false;
        int minHeight = 34;
        int maxHeight = 139;

        private void btnTelescopic_Click(object sender, EventArgs e)
        {
            if(isExtended)
            {
                Location = new Point(Location.X, Parent.Size.Height - minHeight);
                isExtended = false;
                this.btnTelescopic.BackgroundImage = global::TeacherWorkTable.Properties.Resources.up_icon;
            }
            else
            {
                Location = new Point(Location.X, Parent.Size.Height - maxHeight);
                isExtended = true;
                this.btnTelescopic.BackgroundImage = global::TeacherWorkTable.Properties.Resources.down_icon;
            }
        }

        private void GetCameraList()
        {
            ArrayList clist = new ArrayList();
            clist = DbControl.GetCamerasByDB();
            if (clist.Count == 0)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\Release\access.log", true, Encoding.UTF8))
                {
                    string strLog = DateTime.Now.ToString().Replace('/', '-') + " - miss -  没有获取到摄像头信息";
                    file.WriteLine(strLog);
                    file.Close();
                }
                return;
            }
            foreach (string[] camera in clist)
            {
                string cNum = camera[0];
                string cAlias = camera[1];

                System.Windows.Forms.Panel panel = TeacherWorkTable.CaneraChangeList.GetPanel3;
                CameraChangeControl ccc = new CameraChangeControl();
                panel.Controls.Add(ccc);
                ccc.Location = new System.Drawing.Point(15, int.Parse(cNum) * 35);
                ccc.TabIndex = int.Parse(cNum);
                ccc.GetLabel.Text = cAlias;
            }
        }

    }
}
