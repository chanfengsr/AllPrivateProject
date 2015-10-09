namespace ModifyFileTime
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
            this.btnModify = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textFile = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.dtpDateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSetCreationTime = new System.Windows.Forms.CheckBox();
            this.chkSetLastWriteTime = new System.Windows.Forms.CheckBox();
            this.chkSetLastAccessTime = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCreationTime = new System.Windows.Forms.Label();
            this.lblLastWriteTime = new System.Windows.Forms.Label();
            this.lblLastAccessTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(261, 228);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(85, 26);
            this.btnModify.TabIndex = 6;
            this.btnModify.Text = "设 置(&S)";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件：";
            // 
            // textFile
            // 
            this.textFile.Location = new System.Drawing.Point(83, 62);
            this.textFile.Name = "textFile";
            this.textFile.Size = new System.Drawing.Size(254, 21);
            this.textFile.TabIndex = 1;
            this.textFile.TextChanged += new System.EventHandler(this.textFile_TextChanged);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(344, 60);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(33, 23);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // dtpDateTime
            // 
            this.dtpDateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTime.Location = new System.Drawing.Point(83, 25);
            this.dtpDateTime.Name = "dtpDateTime";
            this.dtpDateTime.Size = new System.Drawing.Size(150, 21);
            this.dtpDateTime.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "时间：";
            // 
            // chkSetCreationTime
            // 
            this.chkSetCreationTime.AutoSize = true;
            this.chkSetCreationTime.Checked = true;
            this.chkSetCreationTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetCreationTime.Location = new System.Drawing.Point(23, 190);
            this.chkSetCreationTime.Name = "chkSetCreationTime";
            this.chkSetCreationTime.Size = new System.Drawing.Size(96, 16);
            this.chkSetCreationTime.TabIndex = 3;
            this.chkSetCreationTime.Text = "设置创建时间";
            this.chkSetCreationTime.UseVisualStyleBackColor = true;
            // 
            // chkSetLastWriteTime
            // 
            this.chkSetLastWriteTime.AutoSize = true;
            this.chkSetLastWriteTime.Checked = true;
            this.chkSetLastWriteTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetLastWriteTime.Location = new System.Drawing.Point(23, 212);
            this.chkSetLastWriteTime.Name = "chkSetLastWriteTime";
            this.chkSetLastWriteTime.Size = new System.Drawing.Size(96, 16);
            this.chkSetLastWriteTime.TabIndex = 4;
            this.chkSetLastWriteTime.Text = "设置修改时间";
            this.chkSetLastWriteTime.UseVisualStyleBackColor = true;
            // 
            // chkSetLastAccessTime
            // 
            this.chkSetLastAccessTime.AutoSize = true;
            this.chkSetLastAccessTime.Checked = true;
            this.chkSetLastAccessTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetLastAccessTime.Location = new System.Drawing.Point(23, 234);
            this.chkSetLastAccessTime.Name = "chkSetLastAccessTime";
            this.chkSetLastAccessTime.Size = new System.Drawing.Size(96, 16);
            this.chkSetLastAccessTime.TabIndex = 5;
            this.chkSetLastAccessTime.Text = "设置访问时间";
            this.chkSetLastAccessTime.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "创建时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "修改时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "访问时间：";
            // 
            // lblCreationTime
            // 
            this.lblCreationTime.AutoSize = true;
            this.lblCreationTime.Location = new System.Drawing.Point(102, 104);
            this.lblCreationTime.Name = "lblCreationTime";
            this.lblCreationTime.Size = new System.Drawing.Size(0, 12);
            this.lblCreationTime.TabIndex = 7;
            // 
            // lblLastWriteTime
            // 
            this.lblLastWriteTime.AutoSize = true;
            this.lblLastWriteTime.Location = new System.Drawing.Point(102, 128);
            this.lblLastWriteTime.Name = "lblLastWriteTime";
            this.lblLastWriteTime.Size = new System.Drawing.Size(0, 12);
            this.lblLastWriteTime.TabIndex = 7;
            // 
            // lblLastAccessTime
            // 
            this.lblLastAccessTime.AutoSize = true;
            this.lblLastAccessTime.Location = new System.Drawing.Point(102, 151);
            this.lblLastAccessTime.Name = "lblLastAccessTime";
            this.lblLastAccessTime.Size = new System.Drawing.Size(0, 12);
            this.lblLastAccessTime.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 271);
            this.Controls.Add(this.lblLastAccessTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLastWriteTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCreationTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkSetLastAccessTime);
            this.Controls.Add(this.chkSetLastWriteTime);
            this.Controls.Add(this.chkSetCreationTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDateTime);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.textFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "文件系统时间设置——By 巉沨散人";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.DateTimePicker dtpDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSetCreationTime;
        private System.Windows.Forms.CheckBox chkSetLastWriteTime;
        private System.Windows.Forms.CheckBox chkSetLastAccessTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCreationTime;
        private System.Windows.Forms.Label lblLastWriteTime;
        private System.Windows.Forms.Label lblLastAccessTime;
    }
}

