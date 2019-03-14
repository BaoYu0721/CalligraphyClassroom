namespace TeacherWorkTable
{
    partial class SettingCameraListItem
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
            this.lblNum = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNum
            // 
            this.lblNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNum.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNum.ForeColor = System.Drawing.Color.White;
            this.lblNum.Location = new System.Drawing.Point(0, 9);
            this.lblNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(67, 25);
            this.lblNum.TabIndex = 0;
            this.lblNum.Text = "1";
            this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNum.Click += new System.EventHandler(this.lblNum_Click);
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(67, 9);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "摄像机1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIP
            // 
            this.lblIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIP.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblIP.ForeColor = System.Drawing.Color.White;
            this.lblIP.Location = new System.Drawing.Point(153, 9);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(117, 25);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "192.168.1.109";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(397, 1);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnDel
            // 
            this.btnDel.Image = global::TeacherWorkTable.Properties.Resources.delete_button_white;
            this.btnDel.Location = new System.Drawing.Point(331, 8);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(47, 29);
            this.btnDel.TabIndex = 4;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            this.btnDel.MouseEnter += new System.EventHandler(this.btnDel_MouseEnter);
            this.btnDel.MouseLeave += new System.EventHandler(this.btnDel_MouseLeave);
            // 
            // btnChange
            // 
            this.btnChange.ForeColor = System.Drawing.Color.White;
            this.btnChange.Image = global::TeacherWorkTable.Properties.Resources.change_button_white;
            this.btnChange.Location = new System.Drawing.Point(271, 8);
            this.btnChange.Margin = new System.Windows.Forms.Padding(4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(47, 29);
            this.btnChange.TabIndex = 3;
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            this.btnChange.MouseEnter += new System.EventHandler(this.btnChange_MouseEnter);
            this.btnChange.MouseLeave += new System.EventHandler(this.btnChange_MouseLeave);
            // 
            // SettingCameraListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNum);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SettingCameraListItem";
            this.Size = new System.Drawing.Size(397, 44);
            this.Load += new System.EventHandler(this.SettingCameraListItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        public string cNum
        {
            get
            {
                return lblNum.Text;
            }
            set
            {
                lblNum.Text = value;
            }
        }
        public string cAlias
        {
            get
            {
                return lblName.Text;
            }
            set
            {
                lblName.Text = value;
            }
        }
        public string cIp
        {
            get
            {
                return lblIP.Text;
            }
            set
            {
                lblIP.Text = value;
            }
        }
        #endregion

        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
