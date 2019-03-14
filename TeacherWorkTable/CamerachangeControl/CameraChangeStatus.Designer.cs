namespace libffRtspTest
{
    partial class CameraChangeStatus
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
            this.btnTelescopic = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTelescopic
            // 
            this.btnTelescopic.BackgroundImage = global::libffRtspTest.Properties.Resources.up_icon;
            this.btnTelescopic.Location = new System.Drawing.Point(154, 3);
            this.btnTelescopic.Name = "btnTelescopic";
            this.btnTelescopic.Size = new System.Drawing.Size(24, 24);
            this.btnTelescopic.TabIndex = 0;
            this.btnTelescopic.UseVisualStyleBackColor = true;
            this.btnTelescopic.Click += new System.EventHandler(this.btnTelescopic_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "摄像机1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CameraChangeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::libffRtspTest.Properties.Resources.camera_change_bg;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTelescopic);
            this.Name = "CameraChangeStatus";
            this.Size = new System.Drawing.Size(184, 31);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTelescopic;
        private System.Windows.Forms.Label label1;
    }
}
