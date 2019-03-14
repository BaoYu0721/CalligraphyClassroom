namespace TeacherWorkTable
{
    partial class frmShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShow));
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnLive = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnTelescopic = new System.Windows.Forms.Button();
            this.pnlRightTelescopic = new System.Windows.Forms.Panel();
            this.pbRightTelescopic = new System.Windows.Forms.PictureBox();
            this.pbVideoShow = new System.Windows.Forms.PictureBox();
            this.pnlRightBody = new System.Windows.Forms.Panel();
            this.pnlClassList = new System.Windows.Forms.Panel();
            this.classListItemControl4 = new TeacherWorkTable.ClassListItemControl();
            this.classListItemControl3 = new TeacherWorkTable.ClassListItemControl();
            this.classListItemControl2 = new TeacherWorkTable.ClassListItemControl();
            this.classListItemControl1 = new TeacherWorkTable.ClassListItemControl();
            this.label1 = new System.Windows.Forms.Label();
            this.topMenuControl1 = new TeacherWorkTable.TopMenuControl();
            this.settingListControl1 = new TeacherWorkTable.SettingListControl();
            this.caneraChangeList1 = new TeacherWorkTable.CaneraChangeList();
            this.pnlToolbar.SuspendLayout();
            this.pnlRightTelescopic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightTelescopic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoShow)).BeginInit();
            this.pnlRightBody.SuspendLayout();
            this.pnlClassList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlToolbar.BackgroundImage = global::TeacherWorkTable.Properties.Resources.toolbar_bg;
            this.pnlToolbar.Controls.Add(this.btnLive);
            this.pnlToolbar.Controls.Add(this.btnSetting);
            this.pnlToolbar.Controls.Add(this.btnTelescopic);
            this.pnlToolbar.Location = new System.Drawing.Point(959, 726);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(133, 40);
            this.pnlToolbar.TabIndex = 4;
            // 
            // btnLive
            // 
            this.btnLive.Image = global::TeacherWorkTable.Properties.Resources.video_live_unable;
            this.btnLive.Location = new System.Drawing.Point(94, 8);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(24, 24);
            this.btnLive.TabIndex = 2;
            this.btnLive.UseVisualStyleBackColor = true;
            this.btnLive.EnabledChanged += new System.EventHandler(this.btnLive_EnabledChanged);
            this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Image = global::TeacherWorkTable.Properties.Resources.setting_icon;
            this.btnSetting.Location = new System.Drawing.Point(55, 8);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(24, 24);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnTelescopic
            // 
            this.btnTelescopic.BackColor = System.Drawing.Color.Transparent;
            this.btnTelescopic.Image = global::TeacherWorkTable.Properties.Resources.extend_icon;
            this.btnTelescopic.Location = new System.Drawing.Point(16, 8);
            this.btnTelescopic.Name = "btnTelescopic";
            this.btnTelescopic.Size = new System.Drawing.Size(24, 24);
            this.btnTelescopic.TabIndex = 0;
            this.btnTelescopic.UseVisualStyleBackColor = false;
            this.btnTelescopic.Click += new System.EventHandler(this.btnTelescopic_Click);
            // 
            // pnlRightTelescopic
            // 
            this.pnlRightTelescopic.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnlRightTelescopic.BackColor = System.Drawing.SystemColors.Control;
            this.pnlRightTelescopic.BackgroundImage = global::TeacherWorkTable.Properties.Resources.right_Telescopic_bg;
            this.pnlRightTelescopic.Controls.Add(this.pbRightTelescopic);
            this.pnlRightTelescopic.Location = new System.Drawing.Point(1118, 287);
            this.pnlRightTelescopic.Name = "pnlRightTelescopic";
            this.pnlRightTelescopic.Size = new System.Drawing.Size(26, 151);
            this.pnlRightTelescopic.TabIndex = 1;
            this.pnlRightTelescopic.Click += new System.EventHandler(this.pnlRightTelescopic_Click);
            // 
            // pbRightTelescopic
            // 
            this.pbRightTelescopic.BackColor = System.Drawing.Color.Transparent;
            this.pbRightTelescopic.Image = global::TeacherWorkTable.Properties.Resources.right_icon;
            this.pbRightTelescopic.Location = new System.Drawing.Point(1, 64);
            this.pbRightTelescopic.Name = "pbRightTelescopic";
            this.pbRightTelescopic.Size = new System.Drawing.Size(24, 24);
            this.pbRightTelescopic.TabIndex = 0;
            this.pbRightTelescopic.TabStop = false;
            this.pbRightTelescopic.Click += new System.EventHandler(this.pnlRightTelescopic_Click);
            // 
            // pbVideoShow
            // 
            this.pbVideoShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbVideoShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbVideoShow.Image = global::TeacherWorkTable.Properties.Resources.background;
            this.pbVideoShow.Location = new System.Drawing.Point(0, 43);
            this.pbVideoShow.Name = "pbVideoShow";
            this.pbVideoShow.Size = new System.Drawing.Size(1144, 725);
            this.pbVideoShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVideoShow.TabIndex = 3;
            this.pbVideoShow.TabStop = false;
            this.pbVideoShow.Click += new System.EventHandler(this.pbVideoShow_Click);
            this.pbVideoShow.DoubleClick += new System.EventHandler(this.btnTelescopic_Click);
            // 
            // pnlRightBody
            // 
            this.pnlRightBody.BackgroundImage = global::TeacherWorkTable.Properties.Resources.right_body_bg;
            this.pnlRightBody.Controls.Add(this.pnlClassList);
            this.pnlRightBody.Controls.Add(this.label1);
            this.pnlRightBody.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightBody.Location = new System.Drawing.Point(1144, 43);
            this.pnlRightBody.Name = "pnlRightBody";
            this.pnlRightBody.Size = new System.Drawing.Size(222, 725);
            this.pnlRightBody.TabIndex = 1;
            // 
            // pnlClassList
            // 
            this.pnlClassList.Controls.Add(this.classListItemControl4);
            this.pnlClassList.Controls.Add(this.classListItemControl3);
            this.pnlClassList.Controls.Add(this.classListItemControl2);
            this.pnlClassList.Controls.Add(this.classListItemControl1);
            this.pnlClassList.Location = new System.Drawing.Point(18, 45);
            this.pnlClassList.Name = "pnlClassList";
            this.pnlClassList.Size = new System.Drawing.Size(172, 680);
            this.pnlClassList.TabIndex = 1;
            // 
            // classListItemControl4
            // 
            this.classListItemControl4.BackColor = System.Drawing.Color.Transparent;
            this.classListItemControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.classListItemControl4.IsSelect = false;
            this.classListItemControl4.Location = new System.Drawing.Point(0, 117);
            this.classListItemControl4.Name = "classListItemControl4";
            this.classListItemControl4.Size = new System.Drawing.Size(172, 39);
            this.classListItemControl4.TabIndex = 3;
            // 
            // classListItemControl3
            // 
            this.classListItemControl3.BackColor = System.Drawing.Color.Transparent;
            this.classListItemControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.classListItemControl3.IsSelect = false;
            this.classListItemControl3.Location = new System.Drawing.Point(0, 78);
            this.classListItemControl3.Name = "classListItemControl3";
            this.classListItemControl3.Size = new System.Drawing.Size(172, 39);
            this.classListItemControl3.TabIndex = 2;
            // 
            // classListItemControl2
            // 
            this.classListItemControl2.BackColor = System.Drawing.Color.Transparent;
            this.classListItemControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.classListItemControl2.IsSelect = false;
            this.classListItemControl2.Location = new System.Drawing.Point(0, 39);
            this.classListItemControl2.Name = "classListItemControl2";
            this.classListItemControl2.Size = new System.Drawing.Size(172, 39);
            this.classListItemControl2.TabIndex = 1;
            // 
            // classListItemControl1
            // 
            this.classListItemControl1.BackColor = System.Drawing.Color.Transparent;
            this.classListItemControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.classListItemControl1.IsSelect = false;
            this.classListItemControl1.Location = new System.Drawing.Point(0, 0);
            this.classListItemControl1.Name = "classListItemControl1";
            this.classListItemControl1.Size = new System.Drawing.Size(172, 39);
            this.classListItemControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择课程";
            // 
            // topMenuControl1
            // 
            this.topMenuControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.topMenuControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topMenuControl1.BackgroundImage")));
            this.topMenuControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topMenuControl1.Location = new System.Drawing.Point(0, 0);
            this.topMenuControl1.Name = "topMenuControl1";
            this.topMenuControl1.Size = new System.Drawing.Size(1366, 43);
            this.topMenuControl1.TabIndex = 2;
            this.topMenuControl1.Load += new System.EventHandler(this.topMenuControl1_Load);
            // 
            // settingListControl1
            // 
            this.settingListControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingListControl1.BackColor = System.Drawing.Color.Transparent;
            this.settingListControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settingListControl1.BackgroundImage")));
            this.settingListControl1.Location = new System.Drawing.Point(766, 448);
            this.settingListControl1.Name = "settingListControl1";
            this.settingListControl1.Size = new System.Drawing.Size(328, 272);
            this.settingListControl1.SwitchStatus = true;
            this.settingListControl1.TabIndex = 5;
            this.settingListControl1.Visible = false;
            // 
            // caneraChangeList1
            // 
            this.caneraChangeList1.Location = new System.Drawing.Point(37, 734);
            this.caneraChangeList1.Name = "caneraChangeList1";
            this.caneraChangeList1.Size = new System.Drawing.Size(184, 139);
            this.caneraChangeList1.TabIndex = 6;
            // 
            // frmShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.caneraChangeList1);
            this.Controls.Add(this.settingListControl1);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlRightTelescopic);
            this.Controls.Add(this.pbVideoShow);
            this.Controls.Add(this.pnlRightBody);
            this.Controls.Add(this.topMenuControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShow";
            this.Text = "frmShow";
            this.Load += new System.EventHandler(this.frmShow_Load);
            this.SizeChanged += new System.EventHandler(this.frmShow_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmShow_MouseDown);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlRightTelescopic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRightTelescopic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoShow)).EndInit();
            this.pnlRightBody.ResumeLayout(false);
            this.pnlRightBody.PerformLayout();
            this.pnlClassList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRightTelescopic;
        private TeacherWorkTable.TopMenuControl topMenuControl1;
        private System.Windows.Forms.PictureBox pbVideoShow;
        private System.Windows.Forms.Panel pnlRightBody;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnTelescopic;
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.Button btnSetting;
        private SettingListControl settingListControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbRightTelescopic;
        private CaneraChangeList caneraChangeList1;
        private System.Windows.Forms.Panel pnlClassList;
        private ClassListItemControl classListItemControl4;
        private ClassListItemControl classListItemControl3;
        private ClassListItemControl classListItemControl2;
        private ClassListItemControl classListItemControl1;
    }
}