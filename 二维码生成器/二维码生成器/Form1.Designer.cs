namespace 显示二维码
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkWordWrap = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCreateQRCode = new System.Windows.Forms.Button();
            this.grpText = new System.Windows.Forms.GroupBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.grpSize = new System.Windows.Forms.GroupBox();
            this.rdbManualSize = new System.Windows.Forms.RadioButton();
            this.rdb300 = new System.Windows.Forms.RadioButton();
            this.rdb500 = new System.Windows.Forms.RadioButton();
            this.rdb250 = new System.Windows.Forms.RadioButton();
            this.rdb400 = new System.Windows.Forms.RadioButton();
            this.rdb200 = new System.Windows.Forms.RadioButton();
            this.rdb125 = new System.Windows.Forms.RadioButton();
            this.rdb100 = new System.Windows.Forms.RadioButton();
            this.rdb80 = new System.Windows.Forms.RadioButton();
            this.picCode = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbGoogleAPI = new System.Windows.Forms.RadioButton();
            this.rdbZXingAPI = new System.Windows.Forms.RadioButton();
            this.nudManualSize = new System.Windows.Forms.NumericUpDown();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpText.SuspendLayout();
            this.grpSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudManualSize)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkWordWrap);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.btnCreateQRCode);
            this.splitContainer1.Panel1.Controls.Add(this.grpText);
            this.splitContainer1.Panel1.Controls.Add(this.grpSize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.picCode);
            this.splitContainer1.Size = new System.Drawing.Size(744, 451);
            this.splitContainer1.SplitterDistance = 243;
            this.splitContainer1.TabIndex = 0;
            // 
            // chkWordWrap
            // 
            this.chkWordWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWordWrap.AutoSize = true;
            this.chkWordWrap.Checked = true;
            this.chkWordWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWordWrap.Location = new System.Drawing.Point(114, 388);
            this.chkWordWrap.Name = "chkWordWrap";
            this.chkWordWrap.Size = new System.Drawing.Size(74, 17);
            this.chkWordWrap.TabIndex = 1;
            this.chkWordWrap.Text = "自动换行";
            this.chkWordWrap.UseVisualStyleBackColor = true;
            this.chkWordWrap.CheckedChanged += new System.EventHandler(this.chkWordWrap_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(130, 415);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 25);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清除(&C)";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(68, 415);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(56, 25);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(6, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 25);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCreateQRCode
            // 
            this.btnCreateQRCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateQRCode.Location = new System.Drawing.Point(6, 384);
            this.btnCreateQRCode.Name = "btnCreateQRCode";
            this.btnCreateQRCode.Size = new System.Drawing.Size(100, 25);
            this.btnCreateQRCode.TabIndex = 3;
            this.btnCreateQRCode.Text = "生成二维码(&B)";
            this.btnCreateQRCode.UseVisualStyleBackColor = true;
            this.btnCreateQRCode.Click += new System.EventHandler(this.btnCreateQRCode_Click);
            // 
            // grpText
            // 
            this.grpText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpText.Controls.Add(this.txtText);
            this.grpText.Location = new System.Drawing.Point(0, 133);
            this.grpText.Name = "grpText";
            this.grpText.Size = new System.Drawing.Size(241, 244);
            this.grpText.TabIndex = 0;
            this.grpText.TabStop = false;
            this.grpText.Text = "文本";
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(3, 18);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtText.Size = new System.Drawing.Size(235, 217);
            this.txtText.TabIndex = 0;
            // 
            // grpSize
            // 
            this.grpSize.Controls.Add(this.nudManualSize);
            this.grpSize.Controls.Add(this.rdbManualSize);
            this.grpSize.Controls.Add(this.rdb300);
            this.grpSize.Controls.Add(this.rdb500);
            this.grpSize.Controls.Add(this.rdb250);
            this.grpSize.Controls.Add(this.rdb400);
            this.grpSize.Controls.Add(this.rdb200);
            this.grpSize.Controls.Add(this.rdb125);
            this.grpSize.Controls.Add(this.rdb100);
            this.grpSize.Controls.Add(this.rdb80);
            this.grpSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSize.Location = new System.Drawing.Point(0, 0);
            this.grpSize.Name = "grpSize";
            this.grpSize.Size = new System.Drawing.Size(241, 127);
            this.grpSize.TabIndex = 2;
            this.grpSize.TabStop = false;
            this.grpSize.Text = "Size 尺寸 (px)";
            // 
            // rdbManualSize
            // 
            this.rdbManualSize.AutoSize = true;
            this.rdbManualSize.Location = new System.Drawing.Point(17, 95);
            this.rdbManualSize.Name = "rdbManualSize";
            this.rdbManualSize.Size = new System.Drawing.Size(61, 17);
            this.rdbManualSize.TabIndex = 11;
            this.rdbManualSize.TabStop = true;
            this.rdbManualSize.Text = "自定义";
            this.rdbManualSize.UseVisualStyleBackColor = true;
            this.rdbManualSize.CheckedChanged += new System.EventHandler(this.rdbtnManualSize_CheckedChanged);
            // 
            // rdb300
            // 
            this.rdb300.AutoSize = true;
            this.rdb300.Checked = true;
            this.rdb300.Location = new System.Drawing.Point(159, 47);
            this.rdb300.Name = "rdb300";
            this.rdb300.Size = new System.Drawing.Size(66, 17);
            this.rdb300.TabIndex = 8;
            this.rdb300.TabStop = true;
            this.rdb300.Text = "300x300";
            this.rdb300.UseVisualStyleBackColor = true;
            // 
            // rdb500
            // 
            this.rdb500.AutoSize = true;
            this.rdb500.Location = new System.Drawing.Point(88, 70);
            this.rdb500.Name = "rdb500";
            this.rdb500.Size = new System.Drawing.Size(66, 17);
            this.rdb500.TabIndex = 10;
            this.rdb500.Text = "500x500";
            this.rdb500.UseVisualStyleBackColor = true;
            // 
            // rdb250
            // 
            this.rdb250.AutoSize = true;
            this.rdb250.Location = new System.Drawing.Point(88, 47);
            this.rdb250.Name = "rdb250";
            this.rdb250.Size = new System.Drawing.Size(66, 17);
            this.rdb250.TabIndex = 7;
            this.rdb250.Text = "250x250";
            this.rdb250.UseVisualStyleBackColor = true;
            // 
            // rdb400
            // 
            this.rdb400.AutoSize = true;
            this.rdb400.Location = new System.Drawing.Point(17, 70);
            this.rdb400.Name = "rdb400";
            this.rdb400.Size = new System.Drawing.Size(66, 17);
            this.rdb400.TabIndex = 9;
            this.rdb400.Text = "400x400";
            this.rdb400.UseVisualStyleBackColor = true;
            // 
            // rdb200
            // 
            this.rdb200.AutoSize = true;
            this.rdb200.Location = new System.Drawing.Point(17, 47);
            this.rdb200.Name = "rdb200";
            this.rdb200.Size = new System.Drawing.Size(66, 17);
            this.rdb200.TabIndex = 6;
            this.rdb200.Text = "200x200";
            this.rdb200.UseVisualStyleBackColor = true;
            // 
            // rdb125
            // 
            this.rdb125.AutoSize = true;
            this.rdb125.Location = new System.Drawing.Point(159, 23);
            this.rdb125.Name = "rdb125";
            this.rdb125.Size = new System.Drawing.Size(66, 17);
            this.rdb125.TabIndex = 5;
            this.rdb125.Text = "125x125";
            this.rdb125.UseVisualStyleBackColor = true;
            // 
            // rdb100
            // 
            this.rdb100.AutoSize = true;
            this.rdb100.Location = new System.Drawing.Point(88, 23);
            this.rdb100.Name = "rdb100";
            this.rdb100.Size = new System.Drawing.Size(66, 17);
            this.rdb100.TabIndex = 4;
            this.rdb100.Text = "100x100";
            this.rdb100.UseVisualStyleBackColor = true;
            // 
            // rdb80
            // 
            this.rdb80.AutoSize = true;
            this.rdb80.Location = new System.Drawing.Point(17, 23);
            this.rdb80.Name = "rdb80";
            this.rdb80.Size = new System.Drawing.Size(54, 17);
            this.rdb80.TabIndex = 3;
            this.rdb80.Text = "80x80";
            this.rdb80.UseVisualStyleBackColor = true;
            // 
            // picCode
            // 
            this.picCode.BackColor = System.Drawing.Color.White;
            this.picCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCode.Location = new System.Drawing.Point(0, 0);
            this.picCode.Name = "picCode";
            this.picCode.Size = new System.Drawing.Size(495, 449);
            this.picCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picCode.TabIndex = 0;
            this.picCode.TabStop = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbGoogleAPI);
            this.groupBox1.Controls.Add(this.rdbZXingAPI);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 42);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rdbGoogleAPI
            // 
            this.rdbGoogleAPI.AutoSize = true;
            this.rdbGoogleAPI.Location = new System.Drawing.Point(115, 13);
            this.rdbGoogleAPI.Name = "rdbGoogleAPI";
            this.rdbGoogleAPI.Size = new System.Drawing.Size(79, 17);
            this.rdbGoogleAPI.TabIndex = 1;
            this.rdbGoogleAPI.Text = "Google API";
            this.rdbGoogleAPI.UseVisualStyleBackColor = true;
            // 
            // rdbZXingAPI
            // 
            this.rdbZXingAPI.AutoSize = true;
            this.rdbZXingAPI.Checked = true;
            this.rdbZXingAPI.Location = new System.Drawing.Point(18, 13);
            this.rdbZXingAPI.Name = "rdbZXingAPI";
            this.rdbZXingAPI.Size = new System.Drawing.Size(73, 17);
            this.rdbZXingAPI.TabIndex = 0;
            this.rdbZXingAPI.TabStop = true;
            this.rdbZXingAPI.Text = "ZXing API";
            this.rdbZXingAPI.UseVisualStyleBackColor = true;
            // 
            // nudManualSize
            // 
            this.nudManualSize.Location = new System.Drawing.Point(84, 95);
            this.nudManualSize.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudManualSize.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudManualSize.Name = "nudManualSize";
            this.nudManualSize.Size = new System.Drawing.Size(56, 20);
            this.nudManualSize.TabIndex = 13;
            this.nudManualSize.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudManualSize.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 499);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "二维码生成器";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grpText.ResumeLayout(false);
            this.grpText.PerformLayout();
            this.grpSize.ResumeLayout(false);
            this.grpSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudManualSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox picCode;
        private System.Windows.Forms.GroupBox grpSize;
        private System.Windows.Forms.RadioButton rdb300;
        private System.Windows.Forms.RadioButton rdb250;
        private System.Windows.Forms.RadioButton rdb200;
        private System.Windows.Forms.RadioButton rdb125;
        private System.Windows.Forms.RadioButton rdb100;
        private System.Windows.Forms.RadioButton rdb80;
        private System.Windows.Forms.RadioButton rdb500;
        private System.Windows.Forms.RadioButton rdb400;
        private System.Windows.Forms.GroupBox grpText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnCreateQRCode;
        private System.Windows.Forms.CheckBox chkWordWrap;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdbManualSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbGoogleAPI;
        private System.Windows.Forms.RadioButton rdbZXingAPI;
        private System.Windows.Forms.NumericUpDown nudManualSize;

    }
}

