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
            this.tabPageDataImport = new System.Windows.Forms.TabPage();
            this.dataImptBtnStkHeadImport = new System.Windows.Forms.Button();
            this.btnSourceFileBrowser = new System.Windows.Forms.Button();
            this.grpBlock = new System.Windows.Forms.GroupBox();
            this.dataImptBtnBlockImport1 = new System.Windows.Forms.Button();
            this.grpDayKLine = new System.Windows.Forms.GroupBox();
            this.dataImptBtnDayKLineImport = new System.Windows.Forms.Button();
            this.dataImptDayKLineChkIsComposite = new System.Windows.Forms.CheckBox();
            this.dataImptDayKLineChkConvert = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.btnSourceFolderBrowser = new System.Windows.Forms.Button();
            this.tabPageDataClear = new System.Windows.Forms.TabPage();
            this.dataClearBtnStockHeadTruncate = new System.Windows.Forms.Button();
            this.dataClearBtnWeekKLineTruncate = new System.Windows.Forms.Button();
            this.dataClearBtnDayKLineZSTruncate = new System.Windows.Forms.Button();
            this.dataClearBtnDayKLineTruncate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProcCancel = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bkgDataImport = new System.ComponentModel.BackgroundWorker();
            this.dataImptDayKLineChkTDXFile = new System.Windows.Forms.CheckBox();
            this.dataClearBtnTruncateAllTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageDataImport.SuspendLayout();
            this.grpBlock.SuspendLayout();
            this.grpDayKLine.SuspendLayout();
            this.tabPageDataClear.SuspendLayout();
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
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDataImport);
            this.tabControl1.Controls.Add(this.tabPageDataClear);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(655, 210);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageDataImport
            // 
            this.tabPageDataImport.Controls.Add(this.dataImptBtnStkHeadImport);
            this.tabPageDataImport.Controls.Add(this.btnSourceFileBrowser);
            this.tabPageDataImport.Controls.Add(this.grpBlock);
            this.tabPageDataImport.Controls.Add(this.grpDayKLine);
            this.tabPageDataImport.Controls.Add(this.label3);
            this.tabPageDataImport.Controls.Add(this.txtSourceFolder);
            this.tabPageDataImport.Controls.Add(this.btnSourceFolderBrowser);
            this.tabPageDataImport.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataImport.Name = "tabPageDataImport";
            this.tabPageDataImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataImport.Size = new System.Drawing.Size(647, 184);
            this.tabPageDataImport.TabIndex = 0;
            this.tabPageDataImport.Text = "数据导入";
            this.tabPageDataImport.UseVisualStyleBackColor = true;
            // 
            // dataImptBtnStkHeadImport
            // 
            this.dataImptBtnStkHeadImport.Location = new System.Drawing.Point(12, 45);
            this.dataImptBtnStkHeadImport.Name = "dataImptBtnStkHeadImport";
            this.dataImptBtnStkHeadImport.Size = new System.Drawing.Size(99, 23);
            this.dataImptBtnStkHeadImport.TabIndex = 2;
            this.dataImptBtnStkHeadImport.Text = "刷新代码名称";
            this.dataImptBtnStkHeadImport.UseVisualStyleBackColor = true;
            this.dataImptBtnStkHeadImport.Click += new System.EventHandler(this.dataImptBtnStkHeadImport_Click);
            // 
            // btnSourceFileBrowser
            // 
            this.btnSourceFileBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourceFileBrowser.Location = new System.Drawing.Point(560, 11);
            this.btnSourceFileBrowser.Name = "btnSourceFileBrowser";
            this.btnSourceFileBrowser.Size = new System.Drawing.Size(53, 23);
            this.btnSourceFileBrowser.TabIndex = 19;
            this.btnSourceFileBrowser.Text = "文件";
            this.btnSourceFileBrowser.UseVisualStyleBackColor = true;
            this.btnSourceFileBrowser.Click += new System.EventHandler(this.btnSourceFileBrowser_Click);
            // 
            // grpBlock
            // 
            this.grpBlock.Controls.Add(this.dataImptBtnBlockImport1);
            this.grpBlock.Location = new System.Drawing.Point(158, 45);
            this.grpBlock.Name = "grpBlock";
            this.grpBlock.Size = new System.Drawing.Size(200, 131);
            this.grpBlock.TabIndex = 18;
            this.grpBlock.TabStop = false;
            this.grpBlock.Text = "板块";
            // 
            // dataImptBtnBlockImport1
            // 
            this.dataImptBtnBlockImport1.Location = new System.Drawing.Point(20, 22);
            this.dataImptBtnBlockImport1.Name = "dataImptBtnBlockImport1";
            this.dataImptBtnBlockImport1.Size = new System.Drawing.Size(159, 38);
            this.dataImptBtnBlockImport1.TabIndex = 0;
            this.dataImptBtnBlockImport1.Text = "概念、风格、指数、行业\r\n（tdx文件直接导入）";
            this.dataImptBtnBlockImport1.UseVisualStyleBackColor = true;
            this.dataImptBtnBlockImport1.Click += new System.EventHandler(this.dataImptBtnBlockImport1_Click);
            // 
            // grpDayKLine
            // 
            this.grpDayKLine.Controls.Add(this.dataImptDayKLineChkTDXFile);
            this.grpDayKLine.Controls.Add(this.dataImptBtnDayKLineImport);
            this.grpDayKLine.Controls.Add(this.dataImptDayKLineChkIsComposite);
            this.grpDayKLine.Controls.Add(this.dataImptDayKLineChkConvert);
            this.grpDayKLine.Location = new System.Drawing.Point(12, 74);
            this.grpDayKLine.Name = "grpDayKLine";
            this.grpDayKLine.Size = new System.Drawing.Size(140, 102);
            this.grpDayKLine.TabIndex = 17;
            this.grpDayKLine.TabStop = false;
            this.grpDayKLine.Text = "日K线";
            // 
            // dataImptBtnDayKLineImport
            // 
            this.dataImptBtnDayKLineImport.Location = new System.Drawing.Point(12, 67);
            this.dataImptBtnDayKLineImport.Name = "dataImptBtnDayKLineImport";
            this.dataImptBtnDayKLineImport.Size = new System.Drawing.Size(75, 23);
            this.dataImptBtnDayKLineImport.TabIndex = 1;
            this.dataImptBtnDayKLineImport.Text = "导入";
            this.dataImptBtnDayKLineImport.UseVisualStyleBackColor = true;
            this.dataImptBtnDayKLineImport.Click += new System.EventHandler(this.dataImptBtnDayKLineImport_Click);
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
            this.dataImptDayKLineChkIsComposite.CheckedChanged += new System.EventHandler(this.dataImptDayKLineChkIsComposite_CheckedChanged);
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
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "文件路径(源)";
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.AllowDrop = true;
            this.txtSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnSourceFolderBrowser.Location = new System.Drawing.Point(501, 11);
            this.btnSourceFolderBrowser.Name = "btnSourceFolderBrowser";
            this.btnSourceFolderBrowser.Size = new System.Drawing.Size(53, 23);
            this.btnSourceFolderBrowser.TabIndex = 15;
            this.btnSourceFolderBrowser.Text = "文件夹";
            this.btnSourceFolderBrowser.UseVisualStyleBackColor = true;
            this.btnSourceFolderBrowser.Click += new System.EventHandler(this.btnSourceFolderBrowser_Click);
            // 
            // tabPageDataClear
            // 
            this.tabPageDataClear.Controls.Add(this.dataClearBtnTruncateAllTable);
            this.tabPageDataClear.Controls.Add(this.dataClearBtnStockHeadTruncate);
            this.tabPageDataClear.Controls.Add(this.dataClearBtnWeekKLineTruncate);
            this.tabPageDataClear.Controls.Add(this.dataClearBtnDayKLineZSTruncate);
            this.tabPageDataClear.Controls.Add(this.dataClearBtnDayKLineTruncate);
            this.tabPageDataClear.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataClear.Name = "tabPageDataClear";
            this.tabPageDataClear.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataClear.Size = new System.Drawing.Size(647, 184);
            this.tabPageDataClear.TabIndex = 1;
            this.tabPageDataClear.Text = "数据清理";
            this.tabPageDataClear.UseVisualStyleBackColor = true;
            // 
            // dataClearBtnStockHeadTruncate
            // 
            this.dataClearBtnStockHeadTruncate.Location = new System.Drawing.Point(8, 10);
            this.dataClearBtnStockHeadTruncate.Name = "dataClearBtnStockHeadTruncate";
            this.dataClearBtnStockHeadTruncate.Size = new System.Drawing.Size(127, 23);
            this.dataClearBtnStockHeadTruncate.TabIndex = 6;
            this.dataClearBtnStockHeadTruncate.Text = "清空股票代码表头";
            this.dataClearBtnStockHeadTruncate.UseVisualStyleBackColor = true;
            this.dataClearBtnStockHeadTruncate.Click += new System.EventHandler(this.dataClearBtnStockHeadTruncate_Click);
            // 
            // dataClearBtnWeekKLineTruncate
            // 
            this.dataClearBtnWeekKLineTruncate.Location = new System.Drawing.Point(8, 97);
            this.dataClearBtnWeekKLineTruncate.Name = "dataClearBtnWeekKLineTruncate";
            this.dataClearBtnWeekKLineTruncate.Size = new System.Drawing.Size(127, 23);
            this.dataClearBtnWeekKLineTruncate.TabIndex = 5;
            this.dataClearBtnWeekKLineTruncate.Text = "清空周线";
            this.dataClearBtnWeekKLineTruncate.UseVisualStyleBackColor = true;
            this.dataClearBtnWeekKLineTruncate.Click += new System.EventHandler(this.dataClearBtnWeekKLineTruncate_Click);
            // 
            // dataClearBtnDayKLineZSTruncate
            // 
            this.dataClearBtnDayKLineZSTruncate.Location = new System.Drawing.Point(8, 68);
            this.dataClearBtnDayKLineZSTruncate.Name = "dataClearBtnDayKLineZSTruncate";
            this.dataClearBtnDayKLineZSTruncate.Size = new System.Drawing.Size(127, 23);
            this.dataClearBtnDayKLineZSTruncate.TabIndex = 4;
            this.dataClearBtnDayKLineZSTruncate.Text = "清空指数日线";
            this.dataClearBtnDayKLineZSTruncate.UseVisualStyleBackColor = true;
            this.dataClearBtnDayKLineZSTruncate.Click += new System.EventHandler(this.dataClearBtnDayKLineZSTruncate_Click);
            // 
            // dataClearBtnDayKLineTruncate
            // 
            this.dataClearBtnDayKLineTruncate.Location = new System.Drawing.Point(8, 39);
            this.dataClearBtnDayKLineTruncate.Name = "dataClearBtnDayKLineTruncate";
            this.dataClearBtnDayKLineTruncate.Size = new System.Drawing.Size(127, 23);
            this.dataClearBtnDayKLineTruncate.TabIndex = 3;
            this.dataClearBtnDayKLineTruncate.Text = "清空个股日线";
            this.dataClearBtnDayKLineTruncate.UseVisualStyleBackColor = true;
            this.dataClearBtnDayKLineTruncate.Click += new System.EventHandler(this.dataClearDayBtnKLineTruncate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnProcCancel);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.btnCloseForm);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtConsole);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 240);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "执行信息";
            // 
            // btnProcCancel
            // 
            this.btnProcCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnProcCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnProcCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.btnProcCancel.Location = new System.Drawing.Point(527, 52);
            this.btnProcCancel.Name = "btnProcCancel";
            this.btnProcCancel.Size = new System.Drawing.Size(102, 34);
            this.btnProcCancel.TabIndex = 13;
            this.btnProcCancel.TabStop = false;
            this.btnProcCancel.Text = "Cancel...";
            this.btnProcCancel.UseVisualStyleBackColor = true;
            this.btnProcCancel.Click += new System.EventHandler(this.btnProcCancel_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseForm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCloseForm.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCloseForm.Location = new System.Drawing.Point(513, 88);
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
            this.txtConsole.Size = new System.Drawing.Size(643, 214);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.TabStop = false;
            this.txtConsole.WordWrap = false;
            // 
            // bkgDataImport
            // 
            this.bkgDataImport.WorkerReportsProgress = true;
            this.bkgDataImport.WorkerSupportsCancellation = true;
            this.bkgDataImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgDataImport_DoWork);
            // 
            // dataImptDayKLineChkTDXFile
            // 
            this.dataImptDayKLineChkTDXFile.AutoSize = true;
            this.dataImptDayKLineChkTDXFile.Location = new System.Drawing.Point(65, 44);
            this.dataImptDayKLineChkTDXFile.Name = "dataImptDayKLineChkTDXFile";
            this.dataImptDayKLineChkTDXFile.Size = new System.Drawing.Size(66, 16);
            this.dataImptDayKLineChkTDXFile.TabIndex = 2;
            this.dataImptDayKLineChkTDXFile.Text = "TDX文件";
            this.dataImptDayKLineChkTDXFile.UseVisualStyleBackColor = true;
            // 
            // dataClearBtnTruncateAllTable
            // 
            this.dataClearBtnTruncateAllTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataClearBtnTruncateAllTable.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dataClearBtnTruncateAllTable.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.dataClearBtnTruncateAllTable.ForeColor = System.Drawing.Color.DarkRed;
            this.dataClearBtnTruncateAllTable.Location = new System.Drawing.Point(515, 144);
            this.dataClearBtnTruncateAllTable.Name = "dataClearBtnTruncateAllTable";
            this.dataClearBtnTruncateAllTable.Size = new System.Drawing.Size(126, 34);
            this.dataClearBtnTruncateAllTable.TabIndex = 14;
            this.dataClearBtnTruncateAllTable.TabStop = false;
            this.dataClearBtnTruncateAllTable.Text = "清空全表！！！";
            this.dataClearBtnTruncateAllTable.UseVisualStyleBackColor = true;
            this.dataClearBtnTruncateAllTable.Click += new System.EventHandler(this.dataClearBtnTruncateAllTable_Click);
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
            this.tabPageDataImport.ResumeLayout(false);
            this.tabPageDataImport.PerformLayout();
            this.grpBlock.ResumeLayout(false);
            this.grpDayKLine.ResumeLayout(false);
            this.grpDayKLine.PerformLayout();
            this.tabPageDataClear.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPageDataImport;
        private System.Windows.Forms.TabPage tabPageDataClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Button btnSourceFolderBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox grpDayKLine;
        private System.Windows.Forms.Button dataImptBtnDayKLineImport;
        private System.Windows.Forms.CheckBox dataImptDayKLineChkIsComposite;
        private System.Windows.Forms.CheckBox dataImptDayKLineChkConvert;
        private System.ComponentModel.BackgroundWorker bkgDataImport;
        private System.Windows.Forms.Button btnProcCancel;
        private System.Windows.Forms.Button dataClearBtnDayKLineTruncate;
        private System.Windows.Forms.Button dataClearBtnWeekKLineTruncate;
        private System.Windows.Forms.Button dataClearBtnDayKLineZSTruncate;
        private System.Windows.Forms.GroupBox grpBlock;
        private System.Windows.Forms.Button dataImptBtnBlockImport1;
        private System.Windows.Forms.Button btnSourceFileBrowser;
        private System.Windows.Forms.Button dataImptBtnStkHeadImport;
        private System.Windows.Forms.Button dataClearBtnStockHeadTruncate;
        private System.Windows.Forms.CheckBox dataImptDayKLineChkTDXFile;
        private System.Windows.Forms.Button dataClearBtnTruncateAllTable;
    }
}

