using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace libffRtspTest
{
    public partial class CameraChangeStatus: UserControl
    {
        public CameraChangeStatus()
        {
            InitializeComponent();
        }


        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
           // pnlRightBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));

        }

        private void btnTelescopic_Click(object sender, EventArgs e)
        {

        }

    }
}
