namespace StatisticsCPUUsage {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtCPUUsageInfo = new System.Windows.Forms.TextBox();
            this.btnCopy2Clipboard = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.chkToSystemTray = new System.Windows.Forms.CheckBox();
            this.taskIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.grpDynAllocate = new System.Windows.Forms.GroupBox();
            this.btnImmediateAlloc = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combCpuNum = new System.Windows.Forms.ComboBox();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.chkDynAllocate = new System.Windows.Forms.CheckBox();
            this.timerDynAlloc = new System.Windows.Forms.Timer(this.components);
            this.btnTest = new System.Windows.Forms.Button();
            this.grpProcessState = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdo100 = new System.Windows.Forms.RadioButton();
            this.rdo50 = new System.Windows.Forms.RadioButton();
            this.rdo90 = new System.Windows.Forms.RadioButton();
            this.rdo40 = new System.Windows.Forms.RadioButton();
            this.rdo80 = new System.Windows.Forms.RadioButton();
            this.rdo30 = new System.Windows.Forms.RadioButton();
            this.rdo70 = new System.Windows.Forms.RadioButton();
            this.rdo20 = new System.Windows.Forms.RadioButton();
            this.rdo60 = new System.Windows.Forms.RadioButton();
            this.rdo10 = new System.Windows.Forms.RadioButton();
            this.txtProcThrottleMax = new System.Windows.Forms.TextBox();
            this.txtProcThrottleMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpDynAllocate.SuspendLayout();
            this.grpProcessState.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCPUUsageInfo
            // 
            this.txtCPUUsageInfo.Location = new System.Drawing.Point(7, 7);
            this.txtCPUUsageInfo.Multiline = true;
            this.txtCPUUsageInfo.Name = "txtCPUUsageInfo";
            this.txtCPUUsageInfo.Size = new System.Drawing.Size(208, 250);
            this.txtCPUUsageInfo.TabIndex = 2;
            // 
            // btnCopy2Clipboard
            // 
            this.btnCopy2Clipboard.Location = new System.Drawing.Point(7, 265);
            this.btnCopy2Clipboard.Name = "btnCopy2Clipboard";
            this.btnCopy2Clipboard.Size = new System.Drawing.Size(102, 23);
            this.btnCopy2Clipboard.TabIndex = 0;
            this.btnCopy2Clipboard.Text = "To Clipboard";
            this.btnCopy2Clipboard.UseVisualStyleBackColor = true;
            this.btnCopy2Clipboard.Click += new System.EventHandler(this.btnCopy2Clipboard_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 1000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // chkToSystemTray
            // 
            this.chkToSystemTray.AutoSize = true;
            this.chkToSystemTray.Checked = true;
            this.chkToSystemTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkToSystemTray.Location = new System.Drawing.Point(7, 296);
            this.chkToSystemTray.Name = "chkToSystemTray";
            this.chkToSystemTray.Size = new System.Drawing.Size(162, 16);
            this.chkToSystemTray.TabIndex = 1;
            this.chkToSystemTray.Text = "Minimize to system tray";
            this.chkToSystemTray.UseVisualStyleBackColor = true;
            // 
            // taskIcon
            // 
            this.taskIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskIcon.Icon")));
            this.taskIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.taskIcon_MouseClick);
            // 
            // grpDynAllocate
            // 
            this.grpDynAllocate.Controls.Add(this.btnImmediateAlloc);
            this.grpDynAllocate.Controls.Add(this.label2);
            this.grpDynAllocate.Controls.Add(this.label1);
            this.grpDynAllocate.Controls.Add(this.combCpuNum);
            this.grpDynAllocate.Controls.Add(this.txtProcessName);
            this.grpDynAllocate.Enabled = false;
            this.grpDynAllocate.Location = new System.Drawing.Point(223, 7);
            this.grpDynAllocate.Name = "grpDynAllocate";
            this.grpDynAllocate.Size = new System.Drawing.Size(257, 122);
            this.grpDynAllocate.TabIndex = 3;
            this.grpDynAllocate.TabStop = false;
            // 
            // btnImmediateAlloc
            // 
            this.btnImmediateAlloc.Location = new System.Drawing.Point(103, 87);
            this.btnImmediateAlloc.Name = "btnImmediateAlloc";
            this.btnImmediateAlloc.Size = new System.Drawing.Size(109, 23);
            this.btnImmediateAlloc.TabIndex = 4;
            this.btnImmediateAlloc.Text = "ImmediateAlloc";
            this.btnImmediateAlloc.UseVisualStyleBackColor = true;
            this.btnImmediateAlloc.Click += new System.EventHandler(this.btnImmediateAlloc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Use CPU Num";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Process Name";
            // 
            // combCpuNum
            // 
            this.combCpuNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combCpuNum.FormattingEnabled = true;
            this.combCpuNum.Location = new System.Drawing.Point(103, 59);
            this.combCpuNum.Name = "combCpuNum";
            this.combCpuNum.Size = new System.Drawing.Size(134, 20);
            this.combCpuNum.TabIndex = 2;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(103, 29);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(134, 21);
            this.txtProcessName.TabIndex = 1;
            this.txtProcessName.Text = "mencoder";
            // 
            // chkDynAllocate
            // 
            this.chkDynAllocate.AutoSize = true;
            this.chkDynAllocate.Location = new System.Drawing.Point(231, 6);
            this.chkDynAllocate.Name = "chkDynAllocate";
            this.chkDynAllocate.Size = new System.Drawing.Size(204, 16);
            this.chkDynAllocate.TabIndex = 0;
            this.chkDynAllocate.Text = "Dynamic Allocation CPU (5 min)";
            this.chkDynAllocate.UseVisualStyleBackColor = true;
            this.chkDynAllocate.CheckedChanged += new System.EventHandler(this.chkDynAllocate_CheckedChanged);
            // 
            // timerDynAlloc
            // 
            this.timerDynAlloc.Interval = 1000;
            this.timerDynAlloc.Tick += new System.EventHandler(this.timerDynAlloc_Tick);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(154, 263);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "btnTest";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // grpProcessState
            // 
            this.grpProcessState.Controls.Add(this.label5);
            this.grpProcessState.Controls.Add(this.label4);
            this.grpProcessState.Controls.Add(this.rdo100);
            this.grpProcessState.Controls.Add(this.rdo50);
            this.grpProcessState.Controls.Add(this.rdo90);
            this.grpProcessState.Controls.Add(this.rdo40);
            this.grpProcessState.Controls.Add(this.rdo80);
            this.grpProcessState.Controls.Add(this.rdo30);
            this.grpProcessState.Controls.Add(this.rdo70);
            this.grpProcessState.Controls.Add(this.rdo20);
            this.grpProcessState.Controls.Add(this.rdo60);
            this.grpProcessState.Controls.Add(this.rdo10);
            this.grpProcessState.Controls.Add(this.txtProcThrottleMax);
            this.grpProcessState.Controls.Add(this.txtProcThrottleMin);
            this.grpProcessState.Controls.Add(this.label3);
            this.grpProcessState.Location = new System.Drawing.Point(223, 135);
            this.grpProcessState.Name = "grpProcessState";
            this.grpProcessState.Size = new System.Drawing.Size(257, 122);
            this.grpProcessState.TabIndex = 5;
            this.grpProcessState.TabStop = false;
            this.grpProcessState.Text = "CPU Throttle ( % )";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Set Max Throttle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "-";
            // 
            // rdo100
            // 
            this.rdo100.AutoSize = true;
            this.rdo100.Location = new System.Drawing.Point(187, 92);
            this.rdo100.Name = "rdo100";
            this.rdo100.Size = new System.Drawing.Size(41, 16);
            this.rdo100.TabIndex = 2;
            this.rdo100.TabStop = true;
            this.rdo100.Text = "100";
            this.rdo100.UseVisualStyleBackColor = true;
            this.rdo100.CheckedChanged += new System.EventHandler(this.rdoProcessState_CheckedChanged);
            // 
            // rdo50
            // 
            this.rdo50.AutoSize = true;
            this.rdo50.Location = new System.Drawing.Point(187, 70);
            this.rdo50.Name = "rdo50";
            this.rdo50.Size = new System.Drawing.Size(35, 16);
            this.rdo50.TabIndex = 2;
            this.rdo50.TabStop = true;
            this.rdo50.Text = "50";
            this.rdo50.UseVisualStyleBackColor = true;
            this.rdo50.CheckedChanged += new System.EventHandler(this.rdoProcessState_CheckedChanged);
            // 
            // rdo90
            // 
            this.rdo90.AutoSize = true;
            this.rdo90.Location = new System.Drawing.Point(146, 92);
            this.rdo90.Name = "rdo90";
            this.rdo90.Size = new System.Drawing.Size(35, 16);
            this.rdo90.TabIndex = 2;
            this.rdo90.TabStop = true;
            this.rdo90.Text = "90";
            this.rdo90.UseVisualStyleBackColor = true;
            this.rdo90.CheckedChanged += new System.EventHandler(this.rdoProcessState_CheckedChanged);
            // 
            // rdo40
            // 
            this.rdo40.AutoSize = true;
            this.rdo40.Location = new System.Drawing.Point(146, 70);
            this.rdo40.Name = "rdo40";
            this.rdo40.Size = new System.Drawing.Size(35, 16);
            this.rdo40.TabIndex = 2;
            this.rdo40.TabStop = true;
            this.rdo40.Text = "40";
            this.rdo40.UseVisualStyleBackColor = true;
            this.rdo40.CheckedChanged += new System.EventHandler(this.rdoProcessState_CheckedChanged);
            // 
            // rdo80
            // 
            this.rdo80.AutoSize = true;
            this.rdo80.Location = new System.Drawing.Point(105, 92);
            this.rdo80.Name = "rdo80";
            this.rdo80.Size = new System.Drawing.Size(35, 16);
            this.rdo80.TabIndex = 2;
            this.rdo80.TabStop = true;
            this.rdo80.Text = "80";
            this.rdo80.UseVisualStyleBackColor = true;
            this.rdo80.CheckedChanged += new System.EventHandler(this.rdoProcessState_CheckedChanged);
            // 
            // rdo30
            // 
            this.rdo30.AutoSize = true;
            this.rdo30.Location = new System.Drawing.Point(105, 70);
            this.rdo30.Name = "rdo30";
            this.rdo30.Size = new System.Drawing.Size(35, 16);
            this.rdo30.TabIndex = 2;
            this.rdo30.TabStop = true;
            this.rdo30.Text = "30";
            this.rdo30.UseVisualStyleBackColor = true;
            this.rdo30.CheckedChanged += new System.EventHandler(this.rdoProcessState_CheckedChanged);
            // 
            // rdo70
            // 
            this.rdo70.AutoSize = true;
            this.rdo70.Location = new System.Drawing.Point(64, 92);
            this.rdo70.Name = "rdo70";
            this.rdo70.Size = new System.Drawing.Size(35, 16);
            this.rdo70.TabIndex = 2;
            this.rdo70.TabStop = true;
            this.rdo70.Text = "70";
            this.rdo70.UseVisualStyleBackColor = true;
            this.rdo70.CheckedChanged += new System.EventHandler(this.rdoProcessState_CheckedChanged);
            // 
            // rdo20
            // 
            this.rdo20.AutoSize = true;
            this.rdo20.Location = new System.Drawing.Point(64, 70);
            this.rdo20.Name = "rdo20";
            this.rdo20.Size = new System.Drawing.Size(35, 16);
            this.rdo20.TabIndex = 2;
            this.rdo20.TabStop = true;
            this.rdo20.Text = "20";
            this.rdo20.UseVisualStyleBackColor = true;
            this.rdo20.CheckedChanged += new System.EventHandler(this.rdoProcessState_CheckedChanged);
            // 
            // rdo60
            // 
            this.rdo60.AutoSize = true;
            this.rdo60.Location = new System.Drawing.Point(23, 92);
            this.rdo60.Name = "rdo60";
            this.rdo60.Size = new System.Drawing.Size(35, 16);
            this.rdo60.TabIndex = 2;
            this.rdo60.TabStop = true;
            this.rdo60.Text = "60";
            this.rdo60.UseVisualStyleBackColor = true;
            this.rdo60.CheckedChanged += new System.EventHandler(this.rdoProcessState_CheckedChanged);
            // 
            // rdo10
            // 
            this.rdo10.AutoSize = true;
            this.rdo10.Location = new System.Drawing.Point(23, 70);
            this.rdo10.Name = "rdo10";
            this.rdo10.Size = new System.Drawing.Size(35, 16);
            this.rdo10.TabIndex = 2;
            this.rdo10.TabStop = true;
            this.rdo10.Text = "10";
            this.rdo10.UseVisualStyleBackColor = true;
            this.rdo10.CheckedChanged += new System.EventHandler(this.rdoProcessState_CheckedChanged);
            // 
            // txtProcThrottleMax
            // 
            this.txtProcThrottleMax.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtProcThrottleMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProcThrottleMax.Location = new System.Drawing.Point(163, 21);
            this.txtProcThrottleMax.Name = "txtProcThrottleMax";
            this.txtProcThrottleMax.ReadOnly = true;
            this.txtProcThrottleMax.Size = new System.Drawing.Size(30, 21);
            this.txtProcThrottleMax.TabIndex = 1;
            // 
            // txtProcThrottleMin
            // 
            this.txtProcThrottleMin.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtProcThrottleMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProcThrottleMin.Location = new System.Drawing.Point(122, 21);
            this.txtProcThrottleMin.Name = "txtProcThrottleMin";
            this.txtProcThrottleMin.ReadOnly = true;
            this.txtProcThrottleMin.Size = new System.Drawing.Size(30, 21);
            this.txtProcThrottleMin.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Current Min/Max";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 319);
            this.Controls.Add(this.grpProcessState);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.chkDynAllocate);
            this.Controls.Add(this.grpDynAllocate);
            this.Controls.Add(this.chkToSystemTray);
            this.Controls.Add(this.btnCopy2Clipboard);
            this.Controls.Add(this.txtCPUUsageInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics CPU Usage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.grpDynAllocate.ResumeLayout(false);
            this.grpDynAllocate.PerformLayout();
            this.grpProcessState.ResumeLayout(false);
            this.grpProcessState.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCPUUsageInfo;
        private System.Windows.Forms.Button btnCopy2Clipboard;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.CheckBox chkToSystemTray;
        private System.Windows.Forms.NotifyIcon taskIcon;
        private System.Windows.Forms.GroupBox grpDynAllocate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combCpuNum;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.CheckBox chkDynAllocate;
        private System.Windows.Forms.Button btnImmediateAlloc;
        private System.Windows.Forms.Timer timerDynAlloc;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox grpProcessState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdo100;
        private System.Windows.Forms.RadioButton rdo50;
        private System.Windows.Forms.RadioButton rdo90;
        private System.Windows.Forms.RadioButton rdo40;
        private System.Windows.Forms.RadioButton rdo80;
        private System.Windows.Forms.RadioButton rdo30;
        private System.Windows.Forms.RadioButton rdo70;
        private System.Windows.Forms.RadioButton rdo20;
        private System.Windows.Forms.RadioButton rdo60;
        private System.Windows.Forms.RadioButton rdo10;
        private System.Windows.Forms.TextBox txtProcThrottleMax;
        private System.Windows.Forms.TextBox txtProcThrottleMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}

