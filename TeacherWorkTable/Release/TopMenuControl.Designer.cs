namespace TeacherWorkTable
{
    partial class TopMenuControl
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
            this.btnMin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.icon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMin
            // 
            this.btnMin.BackgroundImage = global::TeacherWorkTable.Properties.Resources.min_icon;
            this.btnMin.Location = new System.Drawing.Point(1278, 9);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(24, 24);
            this.btnMin.TabIndex = 7;
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::TeacherWorkTable.Properties.Resources.close_icon;
            this.btnClose.Location = new System.Drawing.Point(1322, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 6;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbTitle
            // 
            this.pbTitle.Image = global::TeacherWorkTable.Properties.Resources.title_icon;
            this.pbTitle.Location = new System.Drawing.Point(76, 9);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(184, 24);
            this.pbTitle.TabIndex = 5;
            this.pbTitle.TabStop = false;
            // 
            // icon
            // 
            this.icon.Image = global::TeacherWorkTable.Properties.Resources.icon;
            this.icon.Location = new System.Drawing.Point(25, 4);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(34, 34);
            this.icon.TabIndex = 4;
            this.icon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1366, 43);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "23454";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Visible = false;
            this.lblTitle.TextChanged += new System.EventHandler(this.lblTitle_TextChanged);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopMenuControl_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopMenuControl_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopMenuControl_MouseUp);
            // 
            // TopMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pbTitle);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.lblTitle);
            this.Name = "TopMenuControl";
            this.Size = new System.Drawing.Size(1366, 43);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopMenuControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopMenuControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopMenuControl_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.PictureBox icon;
        public System.Windows.Forms.Label lblTitle;  //公共控件，外部可设置属性
    }
}
