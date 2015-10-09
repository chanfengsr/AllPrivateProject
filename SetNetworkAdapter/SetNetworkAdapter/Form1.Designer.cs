namespace SetNetworkAdapter
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
            this.btnOut = new System.Windows.Forms.Button();
            this.btnOutInner = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnShowWMIInfo = new System.Windows.Forms.Button();
            this.btnInner = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(12, 12);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 0;
            this.btnOut.Text = "只开外网";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnOutInner
            // 
            this.btnOutInner.Location = new System.Drawing.Point(174, 12);
            this.btnOutInner.Name = "btnOutInner";
            this.btnOutInner.Size = new System.Drawing.Size(75, 23);
            this.btnOutInner.TabIndex = 1;
            this.btnOutInner.Text = "外网+内网";
            this.btnOutInner.UseVisualStyleBackColor = true;
            this.btnOutInner.Click += new System.EventHandler(this.btnOutInner_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(336, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.Location = new System.Drawing.Point(2, 54);
            this.txtMsg.MaxLength = 0;
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(411, 291);
            this.txtMsg.TabIndex = 3;
            // 
            // btnShowWMIInfo
            // 
            this.btnShowWMIInfo.Location = new System.Drawing.Point(255, 12);
            this.btnShowWMIInfo.Name = "btnShowWMIInfo";
            this.btnShowWMIInfo.Size = new System.Drawing.Size(75, 23);
            this.btnShowWMIInfo.TabIndex = 4;
            this.btnShowWMIInfo.Text = "显示WMI";
            this.btnShowWMIInfo.UseVisualStyleBackColor = true;
            this.btnShowWMIInfo.Click += new System.EventHandler(this.btnShowWMIInfo_Click);
            // 
            // btnInner
            // 
            this.btnInner.Location = new System.Drawing.Point(93, 12);
            this.btnInner.Name = "btnInner";
            this.btnInner.Size = new System.Drawing.Size(75, 23);
            this.btnInner.TabIndex = 0;
            this.btnInner.Text = "只开内网";
            this.btnInner.UseVisualStyleBackColor = true;
            this.btnInner.Click += new System.EventHandler(this.btnInner_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 348);
            this.Controls.Add(this.btnShowWMIInfo);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnOutInner);
            this.Controls.Add(this.btnInner);
            this.Controls.Add(this.btnOut);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnOutInner;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnShowWMIInfo;
        private System.Windows.Forms.Button btnInner;
    }
}

