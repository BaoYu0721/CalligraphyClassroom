using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace TeacherWorkTable
{
    public partial class SettingControl : UserControl
    {
        Object setCtls = null;
        bool CheckNameFlag = false;
        bool CheckIpFlag = false;
        bool CheckUserFlag = false;
        bool CheckPwdFlag = false;
        public SettingControl(Object ctl)
        {
            InitializeComponent();
            setCtls = ctl;
            if(ctl.GetType() == typeof(SettingListControl))
            {
                SettingListControl setCtl = (SettingListControl)ctl;
                Visible = false;
            }
            else if(ctl.GetType() == typeof(SettingCameraListItem))
            {
                SettingCameraListItem setCli = (SettingCameraListItem)ctl;
                Visible = false;
                this.tbName.Text = setCli.cAlias;
                this.tbIP.Text = setCli.cIp;
                pictureBox1.Image = global::TeacherWorkTable.Properties.Resources.ok;
                pictureBox1.Visible = true;
                CheckNameFlag = true;
                pictureBox2.Image = global::TeacherWorkTable.Properties.Resources.ok;
                pictureBox2.Visible = true;
                CheckIpFlag = true;
            }
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            BringToFront();
            this.BackColor = Color.Transparent;

            SetBtnStyle(btnClose);
            tbName.Parent = pbName;
            tbIP.Parent = pbIP;
            tbUser.Parent = pbUser;
            tbPassword.Parent = pbPwd;
            SetBtnStyle(btnFinished);

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

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (setCtls.GetType() == typeof(SettingListControl))
            {
                SettingListControl setCtl = (SettingListControl)setCtls;
                this.Visible = false;
                setCtl.Visible = true;
            }
            else if (setCtls.GetType() == typeof(SettingCameraListItem))
            {
                SettingCameraListItem setCli = (SettingCameraListItem)setCtls;
                this.Visible = false;
                setCli.Parent.Parent.Visible = true;
            }
        }


        private void btnFinished_Click(object sender, EventArgs e)
        {
            if (!(CheckNameFlag && CheckIpFlag && CheckUserFlag && CheckPwdFlag)) return;
            if (setCtls.GetType() == typeof(SettingListControl))
            {
                SettingListControl setCtl = (SettingListControl)setCtls;
                setCtl.Visible = true;
                this.Visible = false;
                ArrayList clist = new ArrayList();
                clist = DbControl.GetCamerasByDB();
                int count = DbControl.GetCameraNumByDB();
                int cNum = -1;
                for (int i = 0; i <= count; i++)
                {
                    bool flag = true;
                    foreach (string[] camera in clist)
                    {
                        if (int.Parse(camera[0]) == i)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        cNum = i;
                        break;
                    }
                }
                if (!DbControl.SetCameraToDB(cNum, this.tbName.Text, this.tbIP.Text, this.tbUser.Text, this.tbPassword.Text))
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\Release\access.log", true, Encoding.UTF8))
                    {
                        string strLog = DateTime.Now.ToString().Replace('/', '-') + " - error - 摄像头添加失败";
                        file.WriteLine(strLog);
                        file.Close();
                    }
                }
                else
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\Release\access.log", true, Encoding.UTF8))
                    {
                        string strLog = DateTime.Now.ToString().Replace('/', '-') + " - info - 摄像头添加成功";
                        file.WriteLine(strLog);
                        file.Close();
                    }
                    if(cNum != -1)
                    {
                        //将摄像头添加到摄像头列表
                        SettingCameraListItem cameraItem = new SettingCameraListItem();
                        setCtl.GetPnlCameraList.Controls.Add(cameraItem);
                        cameraItem.Dock = System.Windows.Forms.DockStyle.Top;
                        cameraItem.Name = "cameraItem" + cNum;
                        cameraItem.Size = new System.Drawing.Size(298, 35);
                        cameraItem.TabIndex = cNum;
                        cameraItem.cNum = cNum.ToString();
                        cameraItem.cAlias = this.tbName.Text;
                        cameraItem.cIp = this.tbIP.Text;
                        //将摄像头添加到切换列表
                        System.Windows.Forms.Panel panel = TeacherWorkTable.CaneraChangeList.GetPanel3;
                        CameraChangeControl ccc = new CameraChangeControl();
                        panel.Controls.Add(ccc);
                        ccc.GetLabel.Text = this.tbName.Text;
                        ccc.TabIndex = cNum;
                        //清空表单
                        this.tbName.Text = "";
                        this.tbIP.Text = "";
                        this.tbUser.Text = "";
                        this.tbPassword.Text = "";
                        this.pictureBox1.Visible = false;
                        this.pictureBox2.Visible = false;
                        this.pictureBox3.Visible = false;
                        this.pictureBox4.Visible = false;
                    }
                }
            }
            else if (setCtls.GetType() == typeof(SettingCameraListItem))
            {
                SettingCameraListItem setCli = (SettingCameraListItem)setCtls;
                setCli.Parent.Visible = true;
                this.Visible = false;
                if (!DbControl.UpdateCameraDB(int.Parse(setCli.cNum), this.tbName.Text, this.tbIP.Text, this.tbUser.Text, this.tbPassword.Text))
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\Release\access.log", true, Encoding.UTF8))
                    {
                        string strLog = DateTime.Now.ToString().Replace('/', '-') + " - error - 摄像头信息变更失败";
                        file.WriteLine(strLog);
                        file.Close();
                    }
                }
                else
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\Release\access.log", true, Encoding.UTF8))
                    {
                        string strLog = DateTime.Now.ToString().Replace('/', '-') + " - info - 摄像头信息变更成功";
                        file.WriteLine(strLog);
                        file.Close();
                    }
                    setCli.cAlias = this.tbName.Text;
                    setCli.cIp = this.tbIP.Text;

                    System.Windows.Forms.Panel panel = TeacherWorkTable.CaneraChangeList.GetPanel3;
                    foreach(Control ctl in panel.Controls)
                    {
                        if(ctl.GetType() == typeof(CameraChangeControl))
                        {
                            CameraChangeControl ccc = (CameraChangeControl)ctl;
                            if(ccc.TabIndex == int.Parse(setCli.cNum))
                            {
                                ccc.GetLabel.Text = this.tbName.Text;
                            }
                        }
                    }
                    //清空表单
                    this.tbUser.Text = "";
                    this.tbPassword.Text = "";
                    this.pictureBox3.Visible = false;
                    this.pictureBox4.Visible = false;
                }
            }
        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                pictureBox1.Visible = false;
                CheckNameFlag = false;
            }
            else
            {
                if (setCtls.GetType() == typeof(SettingListControl))
                {
                    ArrayList clist = DbControl.GetCamerasByDB();
                    foreach (string[] camera in clist)
                    {
                        if (camera[1] == this.tbName.Text)
                        {
                            pictureBox1.Image = global::TeacherWorkTable.Properties.Resources.no;
                            pictureBox1.Visible = true;
                            CheckNameFlag = false;
                            return;
                        }
                    }
                }
                Regex rx = new Regex(@"^[a-zA-Z0-9_\u4e00-\u9fa5]+$");
                if (!rx.IsMatch(tbName.Text))
                {
                    pictureBox1.Image = global::TeacherWorkTable.Properties.Resources.no;
                    pictureBox1.Visible = true;
                    CheckNameFlag = false;
                }
                else
                {
                    pictureBox1.Image = global::TeacherWorkTable.Properties.Resources.ok;
                    pictureBox1.Visible = true;
                    CheckNameFlag = true;
                }
            }
        }

        private void tbIP_Validated(object sender, EventArgs e)
        {
            if(tbIP.Text == "")
            {
                pictureBox2.Visible = false;
                CheckIpFlag = false;
            }
            else
            {
                if (setCtls.GetType() == typeof(SettingListControl))
                {
                    ArrayList clist = DbControl.GetCamerasByDB();
                    foreach (string[] camera in clist)
                    {
                        if (camera[2] == this.tbIP.Text)
                        {
                            pictureBox2.Image = global::TeacherWorkTable.Properties.Resources.no;
                            pictureBox2.Visible = true;
                            CheckIpFlag = false;
                            return;
                        }
                    }
                }
                Regex rx = new Regex(@"(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)");
                if (!rx.IsMatch(tbIP.Text))
                {
                    pictureBox2.Image = global::TeacherWorkTable.Properties.Resources.no;
                    pictureBox2.Visible = true;
                    CheckIpFlag = false;
                }
                else
                {
                    pictureBox2.Image = global::TeacherWorkTable.Properties.Resources.ok;
                    pictureBox2.Visible = true;
                    CheckIpFlag = true;
                }
            }
        }

        private void tbUser_Validated(object sender, EventArgs e)
        {
            if (tbUser.Text == "")
            {
                pictureBox3.Visible = false;
                CheckUserFlag = false;
            }
            else
            {
                Regex rx = new Regex(@"[a-z0-9_-]{3,16}");
                if (!rx.IsMatch(tbUser.Text))
                {
                    pictureBox3.Image = global::TeacherWorkTable.Properties.Resources.no;
                    pictureBox3.Visible = true;
                    CheckUserFlag = false;
                }
                else
                {
                    pictureBox3.Image = global::TeacherWorkTable.Properties.Resources.ok;
                    pictureBox3.Visible = true;
                    CheckUserFlag = true;
                }
            }
        }

        private void tbPassword_Validated(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                pictureBox4.Visible = false;
                CheckPwdFlag = false;
            }
            else
            {
                Regex rx = new Regex(@"[a-z0-9_-]{6,18}");
                if (!rx.IsMatch(tbPassword.Text))
                {
                    pictureBox4.Image = global::TeacherWorkTable.Properties.Resources.no;
                    pictureBox4.Visible = true;
                    CheckPwdFlag = false;
                }
                else
                {
                    pictureBox4.Image = global::TeacherWorkTable.Properties.Resources.ok;
                    pictureBox4.Visible = true;
                    CheckPwdFlag = true;
                }
            }
        }
    }
}
