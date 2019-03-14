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
    public partial class CameraChangeControl : UserControl
    {
        public CameraChangeControl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in CaneraChangeList.GetPanel3.Controls)
            {
                if (ctl.GetType() == typeof(CameraChangeControl))
                {
                    CameraChangeControl ccc = (CameraChangeControl)ctl;
                    ccc.label1.ForeColor = Color.White;
                }
            }
            this.label1.ForeColor = Color.Yellow;
            string[] camera = new string[3];
            DbControl.SwitchCameraDB(this.TabIndex);
            camera = DbControl.SelectCameraById(this.TabIndex);
            string ip = camera[0];
            string user = camera[1];
            string pwd = camera[2];
            if (CameraPlay.Stop())
            {
                if(CameraPlay.Login(ip, user, pwd))
                {
                    CameraPlay.Play();
                }
            }
        }
    }
}
