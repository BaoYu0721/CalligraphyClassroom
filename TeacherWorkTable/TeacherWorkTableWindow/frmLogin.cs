using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace TeacherWorkTable
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

        }
        private void SetBtnStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;//样式
            //btn.ForeColor = Color.Transparent;//前景
            btn.BackColor = Color.Transparent;//去背景
            btn.FlatAppearance.BorderSize = 0;//去边线
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();  
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            pbUserAvatar.BackColor = Color.Transparent;
            pnlUser.BackColor = Color.Transparent;
            pnlPassword.BackColor = Color.Transparent;
            txbPassword.WaterText = global::TeacherWorkTable.Properties.Resources.pwd_input_prompt;
            txbUser.WaterText = global::TeacherWorkTable.Properties.Resources.user_input_prompt;

            cbRemember.BackColor = Color.Transparent;
            //cbRemember.ForeColor = Color.FromArgb(120, 0, 0, 0);
            //lblForget.ForeColor = Color.FromArgb(120, 0, 0, 0);
            lblForget.BackColor = Color.Transparent;
            SetBtnStyle(btnLogin);
        }

        private void pbBg_Click(object sender, EventArgs e)
        {

        }

        private void pnlUser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txbUser_Enter(object sender, EventArgs e)
        {

        }

        private void txbPassword_Enter(object sender, EventArgs e)
        {
            
        }

        private void txbPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private string HttpPost(string url, string acount, string pwd)
        {
            string PostStr = "acount=" + acount + "&pwd=" + pwd;
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.Timeout = 3000;
            req.ContentLength = PostStr.Length;

            StreamWriter writer = new StreamWriter(req.GetRequestStream(), Encoding.ASCII);
            writer.Write(PostStr);
            writer.Flush();

            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            string encoding = res.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8";
            }
            StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding(encoding));
            string reStr = reader.ReadToEnd();
            return reStr;
        }
    }
}
