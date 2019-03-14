using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace TeacherWorkTable
{
    public partial class SettingListControl: UserControl
    {
        public SettingListControl()
        {
            InitializeComponent();
            //
            //获取摄像头列表
            //
            this.GetCameraList();
        }


        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;

            SetBtnStyle(btnClose);
            //lvCamera.BackColor = Color.Transparent; ListView不支持透明色

            /*
            lvCamera.Columns.Add("序号", 50, HorizontalAlignment.Center);
            lvCamera.Columns.Add("别名", 65, HorizontalAlignment.Left);
            lvCamera.Columns.Add("IP", 88, HorizontalAlignment.Left);
            lvCamera.Columns.Add("操作", 95, HorizontalAlignment.Center);

            ListViewItem item = new ListViewItem();
            item.SubItems[0].Text = (lvCamera.Items.Count + 1).ToString();
            item.SubItems.Add("摄像头ewrtfer1",Color.White,Color.Transparent,new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel));
            item.SubItems.Add("192.168.1.234");
            item.SubItems.Add("修改   删除");
            lvCamera.Items.Insert(lvCamera.Items.Count, item);
             * */
            pnlCameraList.BackColor = Color.Transparent; 

            SetBtnStyle(btnAdd);

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
            this.Visible = false;
        }

        static SettingControl addCtl = null;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(addCtl == null)
            {
                addCtl = new SettingControl(this);
                addCtl.Parent = Parent;
                addCtl.GetLabel1.Text = "添加";
            }
            addCtl.Location = Location;
            this.Visible = false;
            addCtl.Visible = true;
        }
        public static SettingControl GetaddCtl
        {
            get
            {
                return addCtl;
            }
        }

        private void SettingListControl_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible == true)
            {
                //再次显示时，重新获取数据并刷新
            }
        }

        [Category("扩展属性"), Description("显示的提示信息")]
        public bool SwitchStatus
        {
            get { return addCtl == null? Visible : Visible||addCtl.Visible; }
            set { Visible = value; if (value == false && addCtl != null) addCtl.Visible = value; }
        }

        //获取摄像头列表
        private void GetCameraList()
        {
            ArrayList clist = new ArrayList();
            clist = DbControl.GetCamerasByDB();
            if(clist.Count == 0)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\Release\access.log", true, Encoding.UTF8))
                {
                    string strLog = DateTime.Now.ToString().Replace('/', '-') + " - miss -  没有获取到摄像头信息";
                    file.WriteLine(strLog);
                    file.Close();
                }
                return;
            }
            foreach(string[] camera in clist)
            {
                SettingCameraListItem cameraItem = new SettingCameraListItem();
                this.pnlCameraList.Controls.Add(cameraItem);
                cameraItem.Dock = System.Windows.Forms.DockStyle.Top;
                cameraItem.Location = new System.Drawing.Point(0, 30 + int.Parse(camera[0]) * 35);
                cameraItem.Name = "cameraItem" + int.Parse(camera[0]);
                cameraItem.Size = new System.Drawing.Size(298, 35);
                cameraItem.TabIndex = int.Parse(camera[0]);
                cameraItem.cNum = camera[0];
                cameraItem.cAlias = camera[1];
                cameraItem.cIp = camera[2];
            }
        }
    }
}
