namespace 设置自动关机
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDatetime = new System.Windows.Forms.DateTimePicker();
            this.rdoTime = new System.Windows.Forms.RadioButton();
            this.rdoLong = new System.Windows.Forms.RadioButton();
            this.btnReboot = new System.Windows.Forms.Button();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.nMinute = new 设置自动关机.NumericUpDownEx();
            this.nHour = new 设置自动关机.NumericUpDownEx();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHour)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(172, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消关机或重启(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDatetime);
            this.groupBox1.Controls.Add(this.rdoTime);
            this.groupBox1.Controls.Add(this.rdoLong);
            this.groupBox1.Controls.Add(this.nMinute);
            this.groupBox1.Controls.Add(this.nHour);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 85);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置执行时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "分钟";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "小时";
            // 
            // dtpDatetime
            // 
            this.dtpDatetime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDatetime.Enabled = false;
            this.dtpDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatetime.Location = new System.Drawing.Point(118, 51);
            this.dtpDatetime.Name = "dtpDatetime";
            this.dtpDatetime.Size = new System.Drawing.Size(167, 21);
            this.dtpDatetime.TabIndex = 3;
            // 
            // rdoTime
            // 
            this.rdoTime.AutoSize = true;
            this.rdoTime.Location = new System.Drawing.Point(14, 53);
            this.rdoTime.Name = "rdoTime";
            this.rdoTime.Size = new System.Drawing.Size(95, 16);
            this.rdoTime.TabIndex = 2;
            this.rdoTime.TabStop = true;
            this.rdoTime.Text = "按具体时间点";
            this.rdoTime.UseVisualStyleBackColor = true;
            this.rdoTime.CheckedChanged += new System.EventHandler(this.rdoTime_CheckedChanged);
            // 
            // rdoLong
            // 
            this.rdoLong.AutoSize = true;
            this.rdoLong.Location = new System.Drawing.Point(14, 21);
            this.rdoLong.Name = "rdoLong";
            this.rdoLong.Size = new System.Drawing.Size(95, 16);
            this.rdoLong.TabIndex = 2;
            this.rdoLong.TabStop = true;
            this.rdoLong.Text = "按多长时间后";
            this.rdoLong.UseVisualStyleBackColor = true;
            this.rdoLong.CheckedChanged += new System.EventHandler(this.rdoLong_CheckedChanged);
            // 
            // btnReboot
            // 
            this.btnReboot.Enabled = false;
            this.btnReboot.Location = new System.Drawing.Point(10, 93);
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.Size = new System.Drawing.Size(75, 23);
            this.btnReboot.TabIndex = 4;
            this.btnReboot.Text = "设置重启";
            this.btnReboot.UseVisualStyleBackColor = true;
            this.btnReboot.Click += new System.EventHandler(this.btnReboot_Click);
            // 
            // btnShutdown
            // 
            this.btnShutdown.Enabled = false;
            this.btnShutdown.Location = new System.Drawing.Point(91, 93);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(75, 23);
            this.btnShutdown.TabIndex = 4;
            this.btnShutdown.Text = "设置关机";
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // nMinute
            // 
            this.nMinute.ControlText = "0";
            this.nMinute.Enabled = false;
            this.nMinute.Location = new System.Drawing.Point(203, 19);
            this.nMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nMinute.Name = "nMinute";
            this.nMinute.Size = new System.Drawing.Size(32, 21);
            this.nMinute.TabIndex = 1;
            // 
            // nHour
            // 
            this.nHour.ControlText = "0";
            this.nHour.Enabled = false;
            this.nHour.Location = new System.Drawing.Point(118, 19);
            this.nHour.Name = "nHour";
            this.nHour.Size = new System.Drawing.Size(40, 21);
            this.nHour.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 122);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReboot);
            this.Controls.Add(this.btnShutdown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置关机或重启DOS命令版";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private NumericUpDownEx nHour;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoTime;
        private System.Windows.Forms.RadioButton rdoLong;
        private System.Windows.Forms.DateTimePicker dtpDatetime;
        private NumericUpDownEx nMinute;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Button btnReboot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

