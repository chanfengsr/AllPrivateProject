namespace StockExplore {
    partial class MainForm {
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
            this.btnTest = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageImportData = new System.Windows.Forms.TabPage();
            this.grpDayKLine = new System.Windows.Forms.GroupBox();
            this.dataImptDayKLineBtnImport = new System.Windows.Forms.Button();
            this.dataImptDayKLineChkIsComposite = new System.Windows.Forms.CheckBox();
            this.dataImptDayKLineChkConvert = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.btnSourceFolderBrowser = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bkgDataImport = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageImportData.SuspendLayout();
            this.grpDayKLine.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(491, 25);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 21);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "btnTest";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(655, 454);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageImportData);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(655, 202);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageImportData
            // 
            this.tabPageImportData.Controls.Add(this.grpDayKLine);
            this.tabPageImportData.Controls.Add(this.label3);
            this.tabPageImportData.Controls.Add(this.txtSourceFolder);
            this.tabPageImportData.Controls.Add(this.btnSourceFolderBrowser);
            this.tabPageImportData.Location = new System.Drawing.Point(4, 22);
            this.tabPageImportData.Name = "tabPageImportData";
            this.tabPageImportData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImportData.Size = new System.Drawing.Size(647, 176);
            this.tabPageImportData.TabIndex = 0;
            this.tabPageImportData.Text = "数据导入";
            this.tabPageImportData.UseVisualStyleBackColor = true;
            // 
            // grpDayKLine
            // 
            this.grpDayKLine.Controls.Add(this.dataImptDayKLineBtnImport);
            this.grpDayKLine.Controls.Add(this.dataImptDayKLineChkIsComposite);
            this.grpDayKLine.Controls.Add(this.dataImptDayKLineChkConvert);
            this.grpDayKLine.Location = new System.Drawing.Point(12, 39);
            this.grpDayKLine.Name = "grpDayKLine";
            this.grpDayKLine.Size = new System.Drawing.Size(99, 103);
            this.grpDayKLine.TabIndex = 17;
            this.grpDayKLine.TabStop = false;
            this.grpDayKLine.Text = "日K线";
            // 
            // dataImptDayKLineBtnImport
            // 
            this.dataImptDayKLineBtnImport.Location = new System.Drawing.Point(12, 67);
            this.dataImptDayKLineBtnImport.Name = "dataImptDayKLineBtnImport";
            this.dataImptDayKLineBtnImport.Size = new System.Drawing.Size(75, 23);
            this.dataImptDayKLineBtnImport.TabIndex = 1;
            this.dataImptDayKLineBtnImport.Text = "导入";
            this.dataImptDayKLineBtnImport.UseVisualStyleBackColor = true;
            // 
            // dataImptDayKLineChkIsComposite
            // 
            this.dataImptDayKLineChkIsComposite.AutoSize = true;
            this.dataImptDayKLineChkIsComposite.Location = new System.Drawing.Point(11, 44);
            this.dataImptDayKLineChkIsComposite.Name = "dataImptDayKLineChkIsComposite";
            this.dataImptDayKLineChkIsComposite.Size = new System.Drawing.Size(48, 16);
            this.dataImptDayKLineChkIsComposite.TabIndex = 0;
            this.dataImptDayKLineChkIsComposite.Text = "指数";
            this.dataImptDayKLineChkIsComposite.UseVisualStyleBackColor = true;
            // 
            // dataImptDayKLineChkConvert
            // 
            this.dataImptDayKLineChkConvert.AutoSize = true;
            this.dataImptDayKLineChkConvert.Location = new System.Drawing.Point(11, 22);
            this.dataImptDayKLineChkConvert.Name = "dataImptDayKLineChkConvert";
            this.dataImptDayKLineChkConvert.Size = new System.Drawing.Size(48, 16);
            this.dataImptDayKLineChkConvert.TabIndex = 0;
            this.dataImptDayKLineChkConvert.Text = "覆盖";
            this.dataImptDayKLineChkConvert.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "文件路径(源)";
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.AllowDrop = true;
            this.txtSourceFolder.Location = new System.Drawing.Point(105, 12);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(390, 21);
            this.txtSourceFolder.TabIndex = 14;
            this.txtSourceFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragDrop);
            this.txtSourceFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragEnter);
            // 
            // btnSourceFolderBrowser
            // 
            this.btnSourceFolderBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourceFolderBrowser.Location = new System.Drawing.Point(505, 11);
            this.btnSourceFolderBrowser.Name = "btnSourceFolderBrowser";
            this.btnSourceFolderBrowser.Size = new System.Drawing.Size(33, 23);
            this.btnSourceFolderBrowser.TabIndex = 15;
            this.btnSourceFolderBrowser.Text = "...";
            this.btnSourceFolderBrowser.UseVisualStyleBackColor = true;
            this.btnSourceFolderBrowser.Click += new System.EventHandler(this.btnSourceFolderBrowser_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(647, 176);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.btnCloseForm);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtConsole);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 248);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "执行信息";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseForm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCloseForm.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCloseForm.Location = new System.Drawing.Point(513, 56);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(116, 33);
            this.btnCloseForm.TabIndex = 12;
            this.btnCloseForm.TabStop = false;
            this.btnCloseForm.Text = "Close Form";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(572, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(57, 21);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.ForeColor = System.Drawing.Color.Lime;
            this.txtConsole.Location = new System.Drawing.Point(6, 21);
            this.txtConsole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(643, 222);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.TabStop = false;
            this.txtConsole.WordWrap = false;
            // 
            // bkgDataImport
            // 
            this.bkgDataImport.WorkerReportsProgress = true;
            this.bkgDataImport.WorkerSupportsCancellation = true;
            this.bkgDataImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgDataImport_DoWork);
            this.bkgDataImport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkgDataImport_ProgressChanged);
            this.bkgDataImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgDataImport_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseForm;
            this.ClientSize = new System.Drawing.Size(655, 454);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "个人股票辅助工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageImportData.ResumeLayout(false);
            this.tabPageImportData.PerformLayout();
            this.grpDayKLine.ResumeLayout(false);
            this.grpDayKLine.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageImportData;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Button btnSourceFolderBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox grpDayKLine;
        private System.Windows.Forms.Button dataImptDayKLineBtnImport;
        private System.Windows.Forms.CheckBox dataImptDayKLineChkIsComposite;
        private System.Windows.Forms.CheckBox dataImptDayKLineChkConvert;
        private System.ComponentModel.BackgroundWorker bkgDataImport;
    }
}

