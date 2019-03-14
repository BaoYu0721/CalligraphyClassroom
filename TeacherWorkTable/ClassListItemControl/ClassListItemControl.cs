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
    public partial class ClassListItemControl: UserControl
    {
        public delegate void dlgtItemClick(object sender, EventArgs e);
        public dlgtItemClick funClick = null;
        public ClassListItemControl(dlgtItemClick func)
        {
            
            InitializeComponent();
            funClick = func;
        }
        public ClassListItemControl()
        {

            InitializeComponent();
        }

        private void ClassListItemControl_Click(object sender, EventArgs e)
        {
            funClick(this, e);
        }
        

        [Category("扩展属性"), Description("显示的提示信息")]
        public bool IsSelect
        {
            get { return isSelect; }
            set { isSelect = value; SelectChange(); }
        }

        bool isSelect = false;

        void SelectChange()
        {
            Color c;
            if(isSelect)
            {
                c = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(152)))), ((int)(((byte)(179)))));

            }
            else
            {
                c = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));

            }
            lblNum.ForeColor = c;// 
            lblName.ForeColor = c;
        }

        private void ClassListItemControl_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
            SelectChange();
        }
    }
}
