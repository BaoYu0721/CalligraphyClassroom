namespace TeacherWorkTable
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.topMenuControl1 = new TeacherWorkTable.TopMenuControl();
            this.pbBg = new System.Windows.Forms.PictureBox();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblForget = new System.Windows.Forms.Label();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.pbPassword = new System.Windows.Forms.PictureBox();
            this.txbPassword = new TeacherWorkTable.WaterTextBox();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.txbUser = new TeacherWorkTable.WaterTextBox();
            this.pbUserAvatar = new System.Windows.Forms.PictureBox();
            this.cbRemember = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.topMenuControl2 = new TeacherWorkTable.TopMenuControl();
            this.topMenuControl3 = new TeacherWorkTable.TopMenuControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbBg)).BeginInit();
            this.pnlLogin.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).BeginInit();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // topMenuControl1
            // 
            this.topMenuControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.topMenuControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topMenuControl1.BackgroundImage")));
            this.topMenuControl1.Location = new System.Drawing.Point(0, 0);
            this.topMenuControl1.Name = "topMenuControl1";
            this.topMenuControl1.Size = new System.Drawing.Size(1366, 43);
            this.topMenuControl1.TabIndex = 5;
            // 
            // pbBg
            // 
            this.pbBg.BackgroundImage = global::TeacherWorkTable.Properties.Resources.login_background;
            this.pbBg.Location = new System.Drawing.Point(0, 43);
            this.pbBg.Name = "pbBg";
            this.pbBg.Size = new System.Drawing.Size(1366, 725);
            this.pbBg.TabIndex = 6;
            this.pbBg.TabStop = false;
            this.pbBg.Click += new System.EventHandler(this.pbBg_Click);
            // 
            // pnlLogin
            // 
            this.pnlLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlLogin.BackgroundImage = global::TeacherWorkTable.Properties.Resources.login_panel_bg;
            this.pnlLogin.Controls.Add(this.lblForget);
            this.pnlLogin.Controls.Add(this.pnlPassword);
            this.pnlLogin.Controls.Add(this.pnlUser);
            this.pnlLogin.Controls.Add(this.pbUserAvatar);
            this.pnlLogin.Controls.Add(this.cbRemember);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Location = new System.Drawing.Point(867, 215);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(281, 362);
            this.pnlLogin.TabIndex = 4;
            // 
            // lblForget
            // 
            this.lblForget.AutoSize = true;
            this.lblForget.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblForget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lblForget.Location = new System.Drawing.Point(200, 256);
            this.lblForget.Name = "lblForget";
            this.lblForget.Size = new System.Drawing.Size(68, 17);
            this.lblForget.TabIndex = 8;
            this.lblForget.Text = "忘记密码？";
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackgroundImage = global::TeacherWorkTable.Properties.Resources.text_panel_bg;
            this.pnlPassword.Controls.Add(this.pbPassword);
            this.pnlPassword.Controls.Add(this.txbPassword);
            this.pnlPassword.Location = new System.Drawing.Point(13, 201);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(255, 32);
            this.pnlPassword.TabIndex = 7;
            // 
            // pbPassword
            // 
            this.pbPassword.BackgroundImage = global::TeacherWorkTable.Properties.Resources.password_icon;
            this.pbPassword.Location = new System.Drawing.Point(11, 5);
            this.pbPassword.Name = "pbPassword";
            this.pbPassword.Size = new System.Drawing.Size(22, 22);
            this.pbPassword.TabIndex = 2;
            this.pbPassword.TabStop = false;
            // 
            // txbPassword
            // 
            this.txbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPassword.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txbPassword.Location = new System.Drawing.Point(43, 8);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(200, 16);
            this.txbPassword.TabIndex = 1;
            this.txbPassword.WaterText = "";
            this.txbPassword.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
            this.txbPassword.Enter += new System.EventHandler(this.txbPassword_Enter);
            // 
            // pnlUser
            // 
            this.pnlUser.BackgroundImage = global::TeacherWorkTable.Properties.Resources.text_panel_bg;
            this.pnlUser.Controls.Add(this.pbUser);
            this.pnlUser.Controls.Add(this.txbUser);
            this.pnlUser.Location = new System.Drawing.Point(13, 138);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(255, 32);
            this.pnlUser.TabIndex = 6;
            this.pnlUser.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlUser_Paint);
            // 
            // pbUser
            // 
            this.pbUser.BackgroundImage = global::TeacherWorkTable.Properties.Resources.user_icon;
            this.pbUser.Location = new System.Drawing.Point(11, 5);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(22, 22);
            this.pbUser.TabIndex = 2;
            this.pbUser.TabStop = false;
            // 
            // txbUser
            // 
            this.txbUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbUser.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txbUser.Location = new System.Drawing.Point(43, 8);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(200, 16);
            this.txbUser.TabIndex = 1;
            this.txbUser.WaterText = "";
            this.txbUser.Enter += new System.EventHandler(this.txbUser_Enter);
            // 
            // pbUserAvatar
            // 
            this.pbUserAvatar.BackgroundImage = global::TeacherWorkTable.Properties.Resources.user_avatar;
            this.pbUserAvatar.Location = new System.Drawing.Point(105, 36);
            this.pbUserAvatar.Name = "pbUserAvatar";
            this.pbUserAvatar.Size = new System.Drawing.Size(70, 70);
            this.pbUserAvatar.TabIndex = 5;
            this.pbUserAvatar.TabStop = false;
            // 
            // cbRemember
            // 
            this.cbRemember.AutoSize = true;
            this.cbRemember.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cbRemember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cbRemember.Location = new System.Drawing.Point(13, 256);
            this.cbRemember.Name = "cbRemember";
            this.cbRemember.Size = new System.Drawing.Size(75, 21);
            this.cbRemember.TabIndex = 4;
            this.cbRemember.Text = "记住密码";
            this.cbRemember.UseVisualStyleBackColor = true;
            this.cbRemember.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImage = global::TeacherWorkTable.Properties.Resources.text_panel_bg;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnLogin.Location = new System.Drawing.Point(13, 295);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(255, 32);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // topMenuControl2
            // 
            this.topMenuControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.topMenuControl2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topMenuControl2.BackgroundImage")));
            this.topMenuControl2.Location = new System.Drawing.Point(0, 0);
            this.topMenuControl2.Name = "topMenuControl2";
            this.topMenuControl2.Size = new System.Drawing.Size(1366, 43);
            this.topMenuControl2.TabIndex = 7;
            // 
            // topMenuControl3
            // 
            this.topMenuControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.topMenuControl3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topMenuControl3.BackgroundImage")));
            this.topMenuControl3.Location = new System.Drawing.Point(0, 0);
            this.topMenuControl3.Name = "topMenuControl3";
            this.topMenuControl3.Size = new System.Drawing.Size(1366, 43);
            this.topMenuControl3.TabIndex = 8;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.topMenuControl3);
            this.Controls.Add(this.topMenuControl2);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pbBg);
            this.Controls.Add(this.topMenuControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBg)).EndInit();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).EndInit();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.TextBox txbUser;
        private TeacherWorkTable.TopMenuControl topMenuControl1;
        private System.Windows.Forms.PictureBox pbBg;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblForget;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.PictureBox pbPassword;
        private WaterTextBox txbPassword;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.PictureBox pbUser;
        private WaterTextBox txbUser;
        private System.Windows.Forms.PictureBox pbUserAvatar;
        private System.Windows.Forms.CheckBox cbRemember;
        private System.Windows.Forms.Button btnLogin;
        private TopMenuControl topMenuControl2;
        private TopMenuControl topMenuControl3;
        //private System.Windows.Forms.TextBox txbPassword;
    }
}