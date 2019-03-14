namespace TeacherWorkTable
{
    partial class SettingControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFinished = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlName = new System.Windows.Forms.Panel();
            this.tbName = new TeacherWorkTable.TransTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbName = new System.Windows.Forms.PictureBox();
            this.pnlIP = new System.Windows.Forms.Panel();
            this.tbIP = new TeacherWorkTable.TransTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbIP = new System.Windows.Forms.PictureBox();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.tbUser = new TeacherWorkTable.TransTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.pnlPwd = new System.Windows.Forms.Panel();
            this.tbPassword = new TeacherWorkTable.TransTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pbPwd = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pnlName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbName)).BeginInit();
            this.pnlIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIP)).BeginInit();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            this.pnlPwd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFinished
            // 
            this.btnFinished.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFinished.BackgroundImage = global::TeacherWorkTable.Properties.Resources.finish_button_bg;
            this.btnFinished.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinished.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnFinished.ForeColor = System.Drawing.Color.White;
            this.btnFinished.Location = new System.Drawing.Point(141, 227);
            this.btnFinished.Margin = new System.Windows.Forms.Padding(0);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(46, 18);
            this.btnFinished.TabIndex = 7;
            this.btnFinished.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFinished.UseVisualStyleBackColor = false;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::TeacherWorkTable.Properties.Resources.close_icon;
            this.btnClose.Location = new System.Drawing.Point(294, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 6;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlName
            // 
            this.pnlName.Controls.Add(this.tbName);
            this.pnlName.Controls.Add(this.label2);
            this.pnlName.Controls.Add(this.pbName);
            this.pnlName.Location = new System.Drawing.Point(65, 73);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(199, 20);
            this.pnlName.TabIndex = 9;
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.Location = new System.Drawing.Point(8, 4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(139, 15);
            this.tbName.TabIndex = 2;
            this.tbName.Validated += new System.EventHandler(this.tbName_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "别名";
            // 
            // pbName
            // 
            this.pbName.Image = global::TeacherWorkTable.Properties.Resources.setting_text_bg;
            this.pbName.Location = new System.Drawing.Point(44, 0);
            this.pbName.Name = "pbName";
            this.pbName.Size = new System.Drawing.Size(155, 20);
            this.pbName.TabIndex = 0;
            this.pbName.TabStop = false;
            // 
            // pnlIP
            // 
            this.pnlIP.Controls.Add(this.tbIP);
            this.pnlIP.Controls.Add(this.label3);
            this.pnlIP.Controls.Add(this.pbIP);
            this.pnlIP.Location = new System.Drawing.Point(65, 112);
            this.pnlIP.Name = "pnlIP";
            this.pnlIP.Size = new System.Drawing.Size(199, 20);
            this.pnlIP.TabIndex = 10;
            // 
            // tbIP
            // 
            this.tbIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIP.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbIP.ForeColor = System.Drawing.Color.Black;
            this.tbIP.Location = new System.Drawing.Point(8, 4);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(139, 15);
            this.tbIP.TabIndex = 3;
            this.tbIP.Validated += new System.EventHandler(this.tbIP_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(2, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "IP";
            // 
            // pbIP
            // 
            this.pbIP.Image = global::TeacherWorkTable.Properties.Resources.setting_text_bg;
            this.pbIP.Location = new System.Drawing.Point(44, 0);
            this.pbIP.Name = "pbIP";
            this.pbIP.Size = new System.Drawing.Size(155, 20);
            this.pbIP.TabIndex = 0;
            this.pbIP.TabStop = false;
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.tbUser);
            this.pnlUser.Controls.Add(this.label4);
            this.pnlUser.Controls.Add(this.pbUser);
            this.pnlUser.Location = new System.Drawing.Point(65, 151);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(199, 20);
            this.pnlUser.TabIndex = 11;
            // 
            // tbUser
            // 
            this.tbUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUser.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbUser.ForeColor = System.Drawing.Color.Black;
            this.tbUser.Location = new System.Drawing.Point(8, 4);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(139, 15);
            this.tbUser.TabIndex = 3;
            this.tbUser.Validated += new System.EventHandler(this.tbUser_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "用户名";
            // 
            // pbUser
            // 
            this.pbUser.Image = global::TeacherWorkTable.Properties.Resources.setting_text_bg;
            this.pbUser.Location = new System.Drawing.Point(44, 0);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(155, 20);
            this.pbUser.TabIndex = 0;
            this.pbUser.TabStop = false;
            // 
            // pnlPwd
            // 
            this.pnlPwd.Controls.Add(this.tbPassword);
            this.pnlPwd.Controls.Add(this.label5);
            this.pnlPwd.Controls.Add(this.pbPwd);
            this.pnlPwd.Location = new System.Drawing.Point(65, 190);
            this.pnlPwd.Name = "pnlPwd";
            this.pnlPwd.Size = new System.Drawing.Size(199, 20);
            this.pnlPwd.TabIndex = 12;
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPassword.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbPassword.ForeColor = System.Drawing.Color.Black;
            this.tbPassword.Location = new System.Drawing.Point(8, 4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(139, 15);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Validated += new System.EventHandler(this.tbPassword_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(2, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "密码";
            // 
            // pbPwd
            // 
            this.pbPwd.Image = global::TeacherWorkTable.Properties.Resources.setting_text_bg;
            this.pbPwd.Location = new System.Drawing.Point(44, 0);
            this.pbPwd.Name = "pbPwd";
            this.pbPwd.Size = new System.Drawing.Size(155, 20);
            this.pbPwd.TabIndex = 0;
            this.pbPwd.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(271, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(271, 112);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(271, 151);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(271, 190);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.TabIndex = 17;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // SettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TeacherWorkTable.Properties.Resources.setting_bg;
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlPwd);
            this.Controls.Add(this.pnlUser);
            this.Controls.Add(this.pnlIP);
            this.Controls.Add(this.pnlName);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.btnClose);
            this.Name = "SettingControl";
            this.Size = new System.Drawing.Size(328, 272);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbName)).EndInit();
            this.pnlIP.ResumeLayout(false);
            this.pnlIP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIP)).EndInit();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            this.pnlPwd.ResumeLayout(false);
            this.pnlPwd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.Label GetLabel1
        {
            get
            {
                return label1;
            }
        }

        #endregion

        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbName;
        private TransTextBox tbName;
        private System.Windows.Forms.Panel pnlIP;
        private TransTextBox tbIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbIP;
        private System.Windows.Forms.Panel pnlUser;
        private TransTextBox tbUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Panel pnlPwd;
        private TransTextBox tbPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}
