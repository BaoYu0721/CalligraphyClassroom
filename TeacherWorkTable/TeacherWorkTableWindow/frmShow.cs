using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeacherWorkTable
{
    public partial class frmShow : Form
    {
         private bool _isFirstClick = true;  
        private bool _isDoubleClick = false;  
        private int _milliseconds = 0;  
        private Timer _doubleClickTimer;  
        private Rectangle _doubleRec;
        private int _liveStatus = 0;

        public frmShow()
        {
            frmLogin nForm = new frmLogin(); //获取登录窗体实例
            if (nForm.ShowDialog() != DialogResult.OK) //如果登录窗体的返回值不等于OK
            {
                Environment.Exit(Environment.ExitCode); //退出程序
                return;
            }

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);  

            InitializeComponent();
            _doubleClickTimer = new Timer();  
            _doubleClickTimer.Interval = 100;  
            _doubleClickTimer.Tick += new EventHandler(_doubleClickTimer_Tick);

            //this.TransparencyKey = pbVideoShow.BackColor;
        }

        private void frmShow_Load(object sender, EventArgs e)
        {
            pnlRightBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            // pnlRightTelescopic.BackColor = Color.Transparent;
            // pnlRightTelescopic.Parent = pbVideoShow;
            classListItemControl1.funClick = classListItemControl2.funClick = classListItemControl3.funClick = classListItemControl1.funClick = classListItemControl4.funClick = new ClassListItemControl.dlgtItemClick(classChanged);
            label1.BackColor = Color.Transparent;
            pnlClassList.BackColor = Color.Transparent;
            //pnlToolbar.BackColor = Color.Transparent;
            // pnlToolbar.Parent = pbVideoShow;
            
            SetBtnStyle(btnTelescopic);
            SetBtnStyle(btnSetting);
            SetBtnStyle(btnLive);

            //settingListControl1.Parent = pbVideoShow;

            btnLive.Enabled = false;

            //预览视频
            CameraPlay.Init(this.pbVideoShow);
            string[] camera = new string[4];
            camera = DbControl.GetUseCameraDB();
            if (camera != null)
            {
                int id = int.Parse(camera[0]);
                string ip = camera[1];
                string user = camera[2];
                string pwd = camera[3];
                foreach (Control ctl in CaneraChangeList.GetPanel3.Controls)
                {
                    if (ctl.GetType() == typeof(CameraChangeControl))
                    {
                        CameraChangeControl ccc = (CameraChangeControl)ctl;
                        if (ccc.TabIndex == id)
                        {
                            ccc.GetLabel.ForeColor = Color.Yellow;
                            break;
                        }
                    }
                }
                if (CameraPlay.Login(ip, user, pwd))
                {
                    CameraPlay.Play();
                }
            }
        }

        Process proc = null;
        string appName = ".\\CGPushStream\\CGPushStream.exe";
        private void live()
        {
            string appParam = AnalyzeConfig.GetInstance().configRoot.test.rtsp_url + " " + AnalyzeConfig.GetInstance().configRoot.test.rtmp_url;
            try
            {
                if (_liveStatus == 0)
                {
                    if (proc != null)
                    {
                        proc.Kill();
                        proc = null;
                    }
                    _liveStatus = 1;
                    proc = Process.Start(appName, appParam);
                    //监视进程退出
                    proc.EnableRaisingEvents = true;
                    //指定退出事件方法
                    proc.Exited += new EventHandler(proc_Exited);
                    setbtnLive_live();
                }
                else
                {
                    if (proc != null)
                    {
                        proc.Kill();
                        proc = null;
                    }
                    _liveStatus = 0;
                    setbtnLive_live();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private delegate void ControlWork();
        void proc_Exited(object sender, EventArgs e)
        {
            proc = null;
            _liveStatus = 0;
            ControlWork fn = new ControlWork(setbtnLive_live);
            this.BeginInvoke(fn);

        }
        void setbtnLive_live()
        {
            if(_liveStatus == 0)
            {
                btnLive.Image = global::TeacherWorkTable.Properties.Resources.video_live_enable;
            }
            else
            {
                btnLive.Image = global::TeacherWorkTable.Properties.Resources.video_live_1;
            }
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

        private void frmShow_MouseDown(object sender, MouseEventArgs e)
        {
             if (_isFirstClick)  
            {  
                _doubleRec = new Rectangle(e.X - SystemInformation.DoubleClickSize.Width / 2,  
                    e.Y - SystemInformation.DoubleClickSize.Height / 2,  
                    SystemInformation.DoubleClickSize.Width,  
                    SystemInformation.DoubleClickSize.Height);  
                _isFirstClick = false;  
                _doubleClickTimer.Start();  
            }  
            else  
            {  
                if (_doubleRec.Contains(e.Location))  
                {  
                    _isDoubleClick = true;  
                }  
            }  

        }
       
   
        //_doubleClickTimer的Tick事件  
        private void _doubleClickTimer_Tick(object sender, EventArgs e)  
        {  
            _milliseconds += 100;  
            if (_milliseconds >= SystemInformation.DoubleClickTime)  
            {  
                _doubleClickTimer.Stop();  
                if (_isDoubleClick)  
                {  
                    MessageBox.Show("Double Click");
                    if(this.WindowState == FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                    else if (this.WindowState == FormWindowState.Normal)
                    {
                        this.WindowState = FormWindowState.Maximized; 
                    }
                    
                }  
                else  
                {  
                    MessageBox.Show("Single Click");  
                }  
                _isDoubleClick = false;  
                _isFirstClick = true;  
                _milliseconds = 0;  
            }  
        }

        private void frmShow_SizeChanged(object sender, EventArgs e)
        {

        }

        private void pbVideoShow_Click(object sender, EventArgs e)
        {

        }

        private void pbRight_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pnlRightTelescopic.Location.ToString());
            MessageBox.Show(pnlToolbar.Location.ToString());

        }
        private bool rightExtend = true;

        private void pnlRightTelescopic_Click(object sender, EventArgs e)
        {
            if (rightExtend)
            {
                // 课程栏收起来的状态
                pnlRightBody.Visible = false;
                rightExtend = false;
                this.pbRightTelescopic.Image = global::TeacherWorkTable.Properties.Resources.left_icon;
                pnlRightTelescopic.Location = new Point(this.Size.Width - pnlRightTelescopic.Size.Width, pnlRightTelescopic.Location.Y);
                pnlToolbar.Location = new Point(this.Size.Width - 185, this.Size.Height - 42);
                settingListControl1.Location = new Point(this.Size.Width - 380, this.Size.Height - 320);
                if (SettingListControl.GetaddCtl != null)
                {
                    SettingListControl.GetaddCtl.Visible = false;
                    SettingListControl.GetaddCtl.Location = settingListControl1.Location;
                }
                if(SettingCameraListItem.GetSc != null)
                {
                    SettingCameraListItem.GetSc.Visible = false;
                    SettingCameraListItem.GetSc.Location = settingListControl1.Location;
                }
            }
            else
            {
                // 课程栏显示的状态
                pnlRightBody.Visible = true;
                rightExtend = true;
                this.pbRightTelescopic.Image = global::TeacherWorkTable.Properties.Resources.right_icon;
                pnlRightTelescopic.Location = new Point(pbVideoShow.Size.Width - pnlRightTelescopic.Size.Width, pnlRightTelescopic.Location.Y);
                pnlToolbar.Location = new Point(this.Size.Width - 407, this.Size.Height - 42);
                settingListControl1.Location = new Point(this.Size.Width - 600, this.Height - 320);
                if (SettingListControl.GetaddCtl != null)
                {
                    SettingListControl.GetaddCtl.Visible = false;
                    SettingListControl.GetaddCtl.Location = settingListControl1.Location;
                }
                if (SettingCameraListItem.GetSc != null)
                {
                    SettingCameraListItem.GetSc.Visible = false;
                    SettingCameraListItem.GetSc.Location = settingListControl1.Location;
                }
            }
        }

        private void btnTelescopic_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // 变成普通状态
                caneraChangeList1.isExtended = false;
                this.WindowState = FormWindowState.Normal;
                this.topMenuControl1.Visible = true;
                caneraChangeList1.Location = new Point(37, this.Size.Height - 34);
                this.btnTelescopic.Image = global::TeacherWorkTable.Properties.Resources.extend_icon;
                if (SettingListControl.GetaddCtl != null)
                {
                    SettingListControl.GetaddCtl.Visible = false;
                    SettingListControl.GetaddCtl.Location = settingListControl1.Location;
                }
                if (SettingCameraListItem.GetSc != null)
                {
                    SettingCameraListItem.GetSc.Visible = false;
                    SettingCameraListItem.GetSc.Location = settingListControl1.Location;
                }
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                // 变成全屏状态
                caneraChangeList1.isExtended = false;
                this.WindowState = FormWindowState.Maximized;
                this.topMenuControl1.Visible = false;
                caneraChangeList1.Location = new Point(37, this.Size.Height - 34);
                this.btnTelescopic.Image = global::TeacherWorkTable.Properties.Resources.reduce_icon;
                if (SettingListControl.GetaddCtl != null)
                {
                    SettingListControl.GetaddCtl.Visible = false;
                    SettingListControl.GetaddCtl.Location = settingListControl1.Location;
                }
                if (SettingCameraListItem.GetSc != null)
                {
                    SettingCameraListItem.GetSc.Visible = false;
                    SettingCameraListItem.GetSc.Location = settingListControl1.Location;
                }
            }
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
            live();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            settingListControl1.SwitchStatus = !settingListControl1.SwitchStatus;
        }

        private void btnLive_EnabledChanged(object sender, EventArgs e)
        {
            if(btnLive.Enabled)
            {
                btnLive.Image = global::TeacherWorkTable.Properties.Resources.video_live_enable;
            }
            else
            {
                btnLive.Image = global::TeacherWorkTable.Properties.Resources.video_live_unable;
            }
        }

        private void classChanged(object sender, EventArgs e)
        {
            classListItemControl1.IsSelect = false;
            classListItemControl2.IsSelect = false;
            classListItemControl3.IsSelect = false;
            classListItemControl4.IsSelect = false;

            ((ClassListItemControl)sender).IsSelect = true;
            topMenuControl1.lblTitle.Visible = true;
            topMenuControl1.lblTitle.Text = ((ClassListItemControl)sender).lblName.Text;
            btnLive.Enabled = true;
        }

        private void topMenuControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
