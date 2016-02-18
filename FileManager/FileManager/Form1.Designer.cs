namespace FileManager
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
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpFunction = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkUseCameraDate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopyByDate = new System.Windows.Forms.Button();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.btnTargetFolderBrowser = new System.Windows.Forms.Button();
            this.btnSourceFolderBrowser = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnChgNmExecute = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkChgNmOnlyFixStr = new System.Windows.Forms.CheckBox();
            this.chkChgNmIsRegex = new System.Windows.Forms.CheckBox();
            this.btnChgNmViewChgFileNameList = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnChgNmEditChangeList = new System.Windows.Forms.Button();
            this.numChgNmWildcardLen = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numChgNmStartNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtChgNmSuffixStr = new System.Windows.Forms.TextBox();
            this.txtChgNmPerfixStr = new System.Windows.Forms.TextBox();
            this.txtChgNmFixedStr = new System.Windows.Forms.TextBox();
            this.rdoChgNmRulSpecList = new System.Windows.Forms.RadioButton();
            this.rdoChgNmRulWildcard = new System.Windows.Forms.RadioButton();
            this.rdoChgNmRulFixedStr = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChgNmEditChangeFileList = new System.Windows.Forms.Button();
            this.chkChgNmSpecChangeFile = new System.Windows.Forms.CheckBox();
            this.btnChgNmViewFileNameList = new System.Windows.Forms.Button();
            this.grpChgNmSortMode = new System.Windows.Forms.GroupBox();
            this.rdoChgNmSortRecordDate = new System.Windows.Forms.RadioButton();
            this.rdoChgNmSortModifyDate = new System.Windows.Forms.RadioButton();
            this.rdoChgNmSortCreateDate = new System.Windows.Forms.RadioButton();
            this.rdoChgNmSortName = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.grpChgNmFileType = new System.Windows.Forms.GroupBox();
            this.txtChgNmFileType = new System.Windows.Forms.TextBox();
            this.rdoChgNmTypeCust = new System.Windows.Forms.RadioButton();
            this.rdoChgNmTypeText = new System.Windows.Forms.RadioButton();
            this.rdoChgNmTypeAudio = new System.Windows.Forms.RadioButton();
            this.rdoChgNmTypeVideo = new System.Windows.Forms.RadioButton();
            this.rdoChgNmTypePic = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChgNmFileFolder = new System.Windows.Forms.TextBox();
            this.btnChgNmFolderBrowser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpFunction.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChgNmWildcardLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChgNmStartNum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpChgNmSortMode.SuspendLayout();
            this.grpChgNmFileType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grpFunction);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(756, 582);
            this.splitContainer1.SplitterDistance = 398;
            this.splitContainer1.TabIndex = 12;
            // 
            // grpFunction
            // 
            this.grpFunction.Controls.Add(this.tabControl1);
            this.grpFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFunction.Location = new System.Drawing.Point(0, 0);
            this.grpFunction.Name = "grpFunction";
            this.grpFunction.Size = new System.Drawing.Size(756, 398);
            this.grpFunction.TabIndex = 1;
            this.grpFunction.TabStop = false;
            this.grpFunction.Text = "功能";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(750, 378);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkUseCameraDate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnCopyByDate);
            this.tabPage1.Controls.Add(this.txtSourceFolder);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtTargetFolder);
            this.tabPage1.Controls.Add(this.btnTargetFolderBrowser);
            this.tabPage1.Controls.Add(this.btnSourceFolderBrowser);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(742, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "日期分组复制文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkUseCameraDate
            // 
            this.chkUseCameraDate.AutoSize = true;
            this.chkUseCameraDate.Location = new System.Drawing.Point(21, 120);
            this.chkUseCameraDate.Name = "chkUseCameraDate";
            this.chkUseCameraDate.Size = new System.Drawing.Size(132, 16);
            this.chkUseCameraDate.TabIndex = 4;
            this.chkUseCameraDate.Text = "优先取照片拍摄日期";
            this.chkUseCameraDate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "源文件夹";
            // 
            // btnCopyByDate
            // 
            this.btnCopyByDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCopyByDate.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCopyByDate.Location = new System.Drawing.Point(21, 146);
            this.btnCopyByDate.Name = "btnCopyByDate";
            this.btnCopyByDate.Size = new System.Drawing.Size(116, 33);
            this.btnCopyByDate.TabIndex = 5;
            this.btnCopyByDate.Text = "按日期复制";
            this.btnCopyByDate.UseVisualStyleBackColor = true;
            this.btnCopyByDate.Click += new System.EventHandler(this.btnCopyByDate_Click);
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.AllowDrop = true;
            this.txtSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceFolder.Location = new System.Drawing.Point(21, 33);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(643, 21);
            this.txtSourceFolder.TabIndex = 0;
            this.txtSourceFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragDrop);
            this.txtSourceFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "目标文件夹";
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.AllowDrop = true;
            this.txtTargetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetFolder.Location = new System.Drawing.Point(21, 86);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.Size = new System.Drawing.Size(643, 21);
            this.txtTargetFolder.TabIndex = 2;
            this.txtTargetFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragDrop);
            this.txtTargetFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragEnter);
            // 
            // btnTargetFolderBrowser
            // 
            this.btnTargetFolderBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTargetFolderBrowser.Location = new System.Drawing.Point(684, 85);
            this.btnTargetFolderBrowser.Name = "btnTargetFolderBrowser";
            this.btnTargetFolderBrowser.Size = new System.Drawing.Size(33, 23);
            this.btnTargetFolderBrowser.TabIndex = 3;
            this.btnTargetFolderBrowser.Text = "...";
            this.btnTargetFolderBrowser.UseVisualStyleBackColor = true;
            this.btnTargetFolderBrowser.Click += new System.EventHandler(this.btnTargetFolderBrowser_Click);
            // 
            // btnSourceFolderBrowser
            // 
            this.btnSourceFolderBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourceFolderBrowser.Location = new System.Drawing.Point(684, 32);
            this.btnSourceFolderBrowser.Name = "btnSourceFolderBrowser";
            this.btnSourceFolderBrowser.Size = new System.Drawing.Size(33, 23);
            this.btnSourceFolderBrowser.TabIndex = 1;
            this.btnSourceFolderBrowser.Text = "...";
            this.btnSourceFolderBrowser.UseVisualStyleBackColor = true;
            this.btnSourceFolderBrowser.Click += new System.EventHandler(this.btnSourceFolderBrowser_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnChgNmExecute);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(742, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "文件批量改名";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnChgNmExecute
            // 
            this.btnChgNmExecute.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChgNmExecute.ForeColor = System.Drawing.Color.DarkRed;
            this.btnChgNmExecute.Location = new System.Drawing.Point(26, 309);
            this.btnChgNmExecute.Name = "btnChgNmExecute";
            this.btnChgNmExecute.Size = new System.Drawing.Size(88, 29);
            this.btnChgNmExecute.TabIndex = 19;
            this.btnChgNmExecute.Text = "执 行";
            this.btnChgNmExecute.UseVisualStyleBackColor = true;
            this.btnChgNmExecute.Click += new System.EventHandler(this.btnChgNmExecute_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.chkChgNmOnlyFixStr);
            this.groupBox5.Controls.Add(this.chkChgNmIsRegex);
            this.groupBox5.Controls.Add(this.btnChgNmViewChgFileNameList);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.btnChgNmEditChangeList);
            this.groupBox5.Controls.Add(this.numChgNmWildcardLen);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.numChgNmStartNum);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtChgNmSuffixStr);
            this.groupBox5.Controls.Add(this.txtChgNmPerfixStr);
            this.groupBox5.Controls.Add(this.txtChgNmFixedStr);
            this.groupBox5.Controls.Add(this.rdoChgNmRulSpecList);
            this.groupBox5.Controls.Add(this.rdoChgNmRulWildcard);
            this.groupBox5.Controls.Add(this.rdoChgNmRulFixedStr);
            this.groupBox5.Location = new System.Drawing.Point(6, 181);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(730, 120);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "改名规则";
            // 
            // chkChgNmOnlyFixStr
            // 
            this.chkChgNmOnlyFixStr.AutoSize = true;
            this.chkChgNmOnlyFixStr.Enabled = false;
            this.chkChgNmOnlyFixStr.Location = new System.Drawing.Point(494, 56);
            this.chkChgNmOnlyFixStr.Name = "chkChgNmOnlyFixStr";
            this.chkChgNmOnlyFixStr.Size = new System.Drawing.Size(72, 16);
            this.chkChgNmOnlyFixStr.TabIndex = 9;
            this.chkChgNmOnlyFixStr.Text = "仅前后缀";
            this.chkChgNmOnlyFixStr.UseVisualStyleBackColor = true;
            this.chkChgNmOnlyFixStr.CheckedChanged += new System.EventHandler(this.chkChgNmOnlyFixStr_CheckedChanged);
            // 
            // chkChgNmIsRegex
            // 
            this.chkChgNmIsRegex.AutoSize = true;
            this.chkChgNmIsRegex.Location = new System.Drawing.Point(423, 26);
            this.chkChgNmIsRegex.Name = "chkChgNmIsRegex";
            this.chkChgNmIsRegex.Size = new System.Drawing.Size(84, 16);
            this.chkChgNmIsRegex.TabIndex = 8;
            this.chkChgNmIsRegex.Text = "正则表达式";
            this.chkChgNmIsRegex.UseVisualStyleBackColor = true;
            // 
            // btnChgNmViewChgFileNameList
            // 
            this.btnChgNmViewChgFileNameList.Location = new System.Drawing.Point(605, 39);
            this.btnChgNmViewChgFileNameList.Name = "btnChgNmViewChgFileNameList";
            this.btnChgNmViewChgFileNameList.Size = new System.Drawing.Size(93, 23);
            this.btnChgNmViewChgFileNameList.TabIndex = 7;
            this.btnChgNmViewChgFileNameList.Text = "更名列表预览";
            this.btnChgNmViewChgFileNameList.UseVisualStyleBackColor = true;
            this.btnChgNmViewChgFileNameList.Click += new System.EventHandler(this.btnChgNmViewChgFileNameList_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(565, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 48);
            this.label8.TabIndex = 6;
            this.label8.Text = "}";
            // 
            // btnChgNmEditChangeList
            // 
            this.btnChgNmEditChangeList.Enabled = false;
            this.btnChgNmEditChangeList.Location = new System.Drawing.Point(134, 87);
            this.btnChgNmEditChangeList.Name = "btnChgNmEditChangeList";
            this.btnChgNmEditChangeList.Size = new System.Drawing.Size(75, 23);
            this.btnChgNmEditChangeList.TabIndex = 5;
            this.btnChgNmEditChangeList.Text = "编辑列表";
            this.btnChgNmEditChangeList.UseVisualStyleBackColor = true;
            this.btnChgNmEditChangeList.Click += new System.EventHandler(this.btnChgNmEditChangeList_Click);
            // 
            // numChgNmWildcardLen
            // 
            this.numChgNmWildcardLen.Enabled = false;
            this.numChgNmWildcardLen.Location = new System.Drawing.Point(331, 54);
            this.numChgNmWildcardLen.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numChgNmWildcardLen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChgNmWildcardLen.Name = "numChgNmWildcardLen";
            this.numChgNmWildcardLen.Size = new System.Drawing.Size(48, 21);
            this.numChgNmWildcardLen.TabIndex = 4;
            this.numChgNmWildcardLen.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "通配符长度";
            // 
            // numChgNmStartNum
            // 
            this.numChgNmStartNum.Enabled = false;
            this.numChgNmStartNum.Location = new System.Drawing.Point(204, 54);
            this.numChgNmStartNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numChgNmStartNum.Name = "numChgNmStartNum";
            this.numChgNmStartNum.Size = new System.Drawing.Size(48, 21);
            this.numChgNmStartNum.TabIndex = 4;
            this.numChgNmStartNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(398, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "+";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "+  起始序号";
            // 
            // txtChgNmSuffixStr
            // 
            this.txtChgNmSuffixStr.Enabled = false;
            this.txtChgNmSuffixStr.Location = new System.Drawing.Point(417, 54);
            this.txtChgNmSuffixStr.Name = "txtChgNmSuffixStr";
            this.txtChgNmSuffixStr.Size = new System.Drawing.Size(71, 21);
            this.txtChgNmSuffixStr.TabIndex = 2;
            // 
            // txtChgNmPerfixStr
            // 
            this.txtChgNmPerfixStr.Enabled = false;
            this.txtChgNmPerfixStr.Location = new System.Drawing.Point(42, 54);
            this.txtChgNmPerfixStr.Name = "txtChgNmPerfixStr";
            this.txtChgNmPerfixStr.Size = new System.Drawing.Size(71, 21);
            this.txtChgNmPerfixStr.TabIndex = 2;
            // 
            // txtChgNmFixedStr
            // 
            this.txtChgNmFixedStr.Location = new System.Drawing.Point(133, 24);
            this.txtChgNmFixedStr.Name = "txtChgNmFixedStr";
            this.txtChgNmFixedStr.Size = new System.Drawing.Size(284, 21);
            this.txtChgNmFixedStr.TabIndex = 1;
            // 
            // rdoChgNmRulSpecList
            // 
            this.rdoChgNmRulSpecList.AutoSize = true;
            this.rdoChgNmRulSpecList.Location = new System.Drawing.Point(20, 90);
            this.rdoChgNmRulSpecList.Name = "rdoChgNmRulSpecList";
            this.rdoChgNmRulSpecList.Size = new System.Drawing.Size(95, 16);
            this.rdoChgNmRulSpecList.TabIndex = 0;
            this.rdoChgNmRulSpecList.Text = "指定更名列表";
            this.rdoChgNmRulSpecList.UseVisualStyleBackColor = true;
            this.rdoChgNmRulSpecList.CheckedChanged += new System.EventHandler(this.rdoChgNmRulSpecList_CheckedChanged);
            // 
            // rdoChgNmRulWildcard
            // 
            this.rdoChgNmRulWildcard.AutoSize = true;
            this.rdoChgNmRulWildcard.Location = new System.Drawing.Point(20, 58);
            this.rdoChgNmRulWildcard.Name = "rdoChgNmRulWildcard";
            this.rdoChgNmRulWildcard.Size = new System.Drawing.Size(14, 13);
            this.rdoChgNmRulWildcard.TabIndex = 0;
            this.rdoChgNmRulWildcard.UseVisualStyleBackColor = true;
            this.rdoChgNmRulWildcard.CheckedChanged += new System.EventHandler(this.rdoChgNmRulWildcard_CheckedChanged);
            // 
            // rdoChgNmRulFixedStr
            // 
            this.rdoChgNmRulFixedStr.AutoSize = true;
            this.rdoChgNmRulFixedStr.Checked = true;
            this.rdoChgNmRulFixedStr.Location = new System.Drawing.Point(20, 26);
            this.rdoChgNmRulFixedStr.Name = "rdoChgNmRulFixedStr";
            this.rdoChgNmRulFixedStr.Size = new System.Drawing.Size(107, 16);
            this.rdoChgNmRulFixedStr.TabIndex = 0;
            this.rdoChgNmRulFixedStr.TabStop = true;
            this.rdoChgNmRulFixedStr.Text = "去掉固定字符串";
            this.rdoChgNmRulFixedStr.UseVisualStyleBackColor = true;
            this.rdoChgNmRulFixedStr.CheckedChanged += new System.EventHandler(this.rdoChgNmRulFixedStr_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnChgNmEditChangeFileList);
            this.groupBox2.Controls.Add(this.chkChgNmSpecChangeFile);
            this.groupBox2.Controls.Add(this.btnChgNmViewFileNameList);
            this.groupBox2.Controls.Add(this.grpChgNmSortMode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.grpChgNmFileType);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtChgNmFileFolder);
            this.groupBox2.Controls.Add(this.btnChgNmFolderBrowser);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 169);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件选择";
            // 
            // btnChgNmEditChangeFileList
            // 
            this.btnChgNmEditChangeFileList.Enabled = false;
            this.btnChgNmEditChangeFileList.Location = new System.Drawing.Point(254, 137);
            this.btnChgNmEditChangeFileList.Name = "btnChgNmEditChangeFileList";
            this.btnChgNmEditChangeFileList.Size = new System.Drawing.Size(75, 23);
            this.btnChgNmEditChangeFileList.TabIndex = 18;
            this.btnChgNmEditChangeFileList.Text = "编辑列表";
            this.btnChgNmEditChangeFileList.UseVisualStyleBackColor = true;
            this.btnChgNmEditChangeFileList.Click += new System.EventHandler(this.btnChgNmEditChangeFileList_Click);
            // 
            // chkChgNmSpecChangeFile
            // 
            this.chkChgNmSpecChangeFile.AutoSize = true;
            this.chkChgNmSpecChangeFile.Location = new System.Drawing.Point(152, 140);
            this.chkChgNmSpecChangeFile.Name = "chkChgNmSpecChangeFile";
            this.chkChgNmSpecChangeFile.Size = new System.Drawing.Size(96, 16);
            this.chkChgNmSpecChangeFile.TabIndex = 17;
            this.chkChgNmSpecChangeFile.Text = "指定文件列表";
            this.chkChgNmSpecChangeFile.UseVisualStyleBackColor = true;
            this.chkChgNmSpecChangeFile.CheckedChanged += new System.EventHandler(this.chkChgNmSpecChangeFile_CheckedChanged);
            // 
            // btnChgNmViewFileNameList
            // 
            this.btnChgNmViewFileNameList.Location = new System.Drawing.Point(20, 137);
            this.btnChgNmViewFileNameList.Name = "btnChgNmViewFileNameList";
            this.btnChgNmViewFileNameList.Size = new System.Drawing.Size(92, 23);
            this.btnChgNmViewFileNameList.TabIndex = 16;
            this.btnChgNmViewFileNameList.Text = "文件列表预览";
            this.btnChgNmViewFileNameList.UseVisualStyleBackColor = true;
            this.btnChgNmViewFileNameList.Click += new System.EventHandler(this.btnChgNmViewFileNameList_Click);
            // 
            // grpChgNmSortMode
            // 
            this.grpChgNmSortMode.Controls.Add(this.rdoChgNmSortRecordDate);
            this.grpChgNmSortMode.Controls.Add(this.rdoChgNmSortModifyDate);
            this.grpChgNmSortMode.Controls.Add(this.rdoChgNmSortCreateDate);
            this.grpChgNmSortMode.Controls.Add(this.rdoChgNmSortName);
            this.grpChgNmSortMode.Location = new System.Drawing.Point(77, 93);
            this.grpChgNmSortMode.Name = "grpChgNmSortMode";
            this.grpChgNmSortMode.Size = new System.Drawing.Size(639, 37);
            this.grpChgNmSortMode.TabIndex = 15;
            this.grpChgNmSortMode.TabStop = false;
            // 
            // rdoChgNmSortRecordDate
            // 
            this.rdoChgNmSortRecordDate.AutoSize = true;
            this.rdoChgNmSortRecordDate.Location = new System.Drawing.Point(261, 14);
            this.rdoChgNmSortRecordDate.Name = "rdoChgNmSortRecordDate";
            this.rdoChgNmSortRecordDate.Size = new System.Drawing.Size(71, 16);
            this.rdoChgNmSortRecordDate.TabIndex = 0;
            this.rdoChgNmSortRecordDate.Text = "拍摄日期";
            this.rdoChgNmSortRecordDate.UseVisualStyleBackColor = true;
            // 
            // rdoChgNmSortModifyDate
            // 
            this.rdoChgNmSortModifyDate.AutoSize = true;
            this.rdoChgNmSortModifyDate.Location = new System.Drawing.Point(174, 14);
            this.rdoChgNmSortModifyDate.Name = "rdoChgNmSortModifyDate";
            this.rdoChgNmSortModifyDate.Size = new System.Drawing.Size(71, 16);
            this.rdoChgNmSortModifyDate.TabIndex = 0;
            this.rdoChgNmSortModifyDate.Text = "修改日期";
            this.rdoChgNmSortModifyDate.UseVisualStyleBackColor = true;
            // 
            // rdoChgNmSortCreateDate
            // 
            this.rdoChgNmSortCreateDate.AutoSize = true;
            this.rdoChgNmSortCreateDate.Location = new System.Drawing.Point(87, 14);
            this.rdoChgNmSortCreateDate.Name = "rdoChgNmSortCreateDate";
            this.rdoChgNmSortCreateDate.Size = new System.Drawing.Size(71, 16);
            this.rdoChgNmSortCreateDate.TabIndex = 0;
            this.rdoChgNmSortCreateDate.Text = "创建日期";
            this.rdoChgNmSortCreateDate.UseVisualStyleBackColor = true;
            // 
            // rdoChgNmSortName
            // 
            this.rdoChgNmSortName.AutoSize = true;
            this.rdoChgNmSortName.Checked = true;
            this.rdoChgNmSortName.Location = new System.Drawing.Point(12, 14);
            this.rdoChgNmSortName.Name = "rdoChgNmSortName";
            this.rdoChgNmSortName.Size = new System.Drawing.Size(59, 16);
            this.rdoChgNmSortName.TabIndex = 0;
            this.rdoChgNmSortName.TabStop = true;
            this.rdoChgNmSortName.Text = "文件名";
            this.rdoChgNmSortName.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "排序方式";
            // 
            // grpChgNmFileType
            // 
            this.grpChgNmFileType.Controls.Add(this.txtChgNmFileType);
            this.grpChgNmFileType.Controls.Add(this.rdoChgNmTypeCust);
            this.grpChgNmFileType.Controls.Add(this.rdoChgNmTypeText);
            this.grpChgNmFileType.Controls.Add(this.rdoChgNmTypeAudio);
            this.grpChgNmFileType.Controls.Add(this.rdoChgNmTypeVideo);
            this.grpChgNmFileType.Controls.Add(this.rdoChgNmTypePic);
            this.grpChgNmFileType.Location = new System.Drawing.Point(77, 52);
            this.grpChgNmFileType.Name = "grpChgNmFileType";
            this.grpChgNmFileType.Size = new System.Drawing.Size(639, 37);
            this.grpChgNmFileType.TabIndex = 15;
            this.grpChgNmFileType.TabStop = false;
            // 
            // txtChgNmFileType
            // 
            this.txtChgNmFileType.Location = new System.Drawing.Point(382, 12);
            this.txtChgNmFileType.Name = "txtChgNmFileType";
            this.txtChgNmFileType.Size = new System.Drawing.Size(211, 21);
            this.txtChgNmFileType.TabIndex = 1;
            this.txtChgNmFileType.Text = "*";
            // 
            // rdoChgNmTypeCust
            // 
            this.rdoChgNmTypeCust.AutoSize = true;
            this.rdoChgNmTypeCust.Checked = true;
            this.rdoChgNmTypeCust.Location = new System.Drawing.Point(264, 14);
            this.rdoChgNmTypeCust.Name = "rdoChgNmTypeCust";
            this.rdoChgNmTypeCust.Size = new System.Drawing.Size(113, 16);
            this.rdoChgNmTypeCust.TabIndex = 0;
            this.rdoChgNmTypeCust.TabStop = true;
            this.rdoChgNmTypeCust.Text = "自定义(\"|\"分割)";
            this.rdoChgNmTypeCust.UseVisualStyleBackColor = true;
            this.rdoChgNmTypeCust.CheckedChanged += new System.EventHandler(this.rdoChgNmTypeCust_CheckedChanged);
            // 
            // rdoChgNmTypeText
            // 
            this.rdoChgNmTypeText.AutoSize = true;
            this.rdoChgNmTypeText.Location = new System.Drawing.Point(201, 14);
            this.rdoChgNmTypeText.Name = "rdoChgNmTypeText";
            this.rdoChgNmTypeText.Size = new System.Drawing.Size(47, 16);
            this.rdoChgNmTypeText.TabIndex = 0;
            this.rdoChgNmTypeText.Text = "文本";
            this.rdoChgNmTypeText.UseVisualStyleBackColor = true;
            // 
            // rdoChgNmTypeAudio
            // 
            this.rdoChgNmTypeAudio.AutoSize = true;
            this.rdoChgNmTypeAudio.Location = new System.Drawing.Point(138, 14);
            this.rdoChgNmTypeAudio.Name = "rdoChgNmTypeAudio";
            this.rdoChgNmTypeAudio.Size = new System.Drawing.Size(47, 16);
            this.rdoChgNmTypeAudio.TabIndex = 0;
            this.rdoChgNmTypeAudio.Text = "音频";
            this.rdoChgNmTypeAudio.UseVisualStyleBackColor = true;
            // 
            // rdoChgNmTypeVideo
            // 
            this.rdoChgNmTypeVideo.AutoSize = true;
            this.rdoChgNmTypeVideo.Location = new System.Drawing.Point(75, 14);
            this.rdoChgNmTypeVideo.Name = "rdoChgNmTypeVideo";
            this.rdoChgNmTypeVideo.Size = new System.Drawing.Size(47, 16);
            this.rdoChgNmTypeVideo.TabIndex = 0;
            this.rdoChgNmTypeVideo.Text = "视频";
            this.rdoChgNmTypeVideo.UseVisualStyleBackColor = true;
            // 
            // rdoChgNmTypePic
            // 
            this.rdoChgNmTypePic.AutoSize = true;
            this.rdoChgNmTypePic.Location = new System.Drawing.Point(12, 14);
            this.rdoChgNmTypePic.Name = "rdoChgNmTypePic";
            this.rdoChgNmTypePic.Size = new System.Drawing.Size(47, 16);
            this.rdoChgNmTypePic.TabIndex = 0;
            this.rdoChgNmTypePic.Text = "图片";
            this.rdoChgNmTypePic.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "文件类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "文件路径";
            // 
            // txtChgNmFileFolder
            // 
            this.txtChgNmFileFolder.AllowDrop = true;
            this.txtChgNmFileFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChgNmFileFolder.Location = new System.Drawing.Point(77, 25);
            this.txtChgNmFileFolder.Name = "txtChgNmFileFolder";
            this.txtChgNmFileFolder.Size = new System.Drawing.Size(575, 21);
            this.txtChgNmFileFolder.TabIndex = 11;
            this.txtChgNmFileFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragDrop);
            this.txtChgNmFileFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragEnter);
            // 
            // btnChgNmFolderBrowser
            // 
            this.btnChgNmFolderBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChgNmFolderBrowser.Location = new System.Drawing.Point(672, 24);
            this.btnChgNmFolderBrowser.Name = "btnChgNmFolderBrowser";
            this.btnChgNmFolderBrowser.Size = new System.Drawing.Size(33, 23);
            this.btnChgNmFolderBrowser.TabIndex = 12;
            this.btnChgNmFolderBrowser.Text = "...";
            this.btnChgNmFolderBrowser.UseVisualStyleBackColor = true;
            this.btnChgNmFolderBrowser.Click += new System.EventHandler(this.btnChgNmFolderBrowser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtConsole);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 180);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "执行信息";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(673, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(57, 21);
            this.btnClear.TabIndex = 1;
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
            this.txtConsole.Size = new System.Drawing.Size(744, 155);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.TabStop = false;
            this.txtConsole.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 582);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "自用文件管理器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpFunction.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChgNmWildcardLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChgNmStartNum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpChgNmSortMode.ResumeLayout(false);
            this.grpChgNmSortMode.PerformLayout();
            this.grpChgNmFileType.ResumeLayout(false);
            this.grpChgNmFileType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.GroupBox grpFunction;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkUseCameraDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopyByDate;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTargetFolder;
        private System.Windows.Forms.Button btnTargetFolderBrowser;
        private System.Windows.Forms.Button btnSourceFolderBrowser;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChgNmFileFolder;
        private System.Windows.Forms.Button btnChgNmFolderBrowser;
        private System.Windows.Forms.Button btnChgNmExecute;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown numChgNmWildcardLen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numChgNmStartNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtChgNmSuffixStr;
        private System.Windows.Forms.TextBox txtChgNmPerfixStr;
        private System.Windows.Forms.TextBox txtChgNmFixedStr;
        private System.Windows.Forms.RadioButton rdoChgNmRulSpecList;
        private System.Windows.Forms.RadioButton rdoChgNmRulWildcard;
        private System.Windows.Forms.RadioButton rdoChgNmRulFixedStr;
        private System.Windows.Forms.Button btnChgNmViewFileNameList;
        private System.Windows.Forms.GroupBox grpChgNmSortMode;
        private System.Windows.Forms.RadioButton rdoChgNmSortRecordDate;
        private System.Windows.Forms.RadioButton rdoChgNmSortModifyDate;
        private System.Windows.Forms.RadioButton rdoChgNmSortCreateDate;
        private System.Windows.Forms.RadioButton rdoChgNmSortName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpChgNmFileType;
        private System.Windows.Forms.TextBox txtChgNmFileType;
        private System.Windows.Forms.RadioButton rdoChgNmTypeCust;
        private System.Windows.Forms.RadioButton rdoChgNmTypeAudio;
        private System.Windows.Forms.RadioButton rdoChgNmTypeVideo;
        private System.Windows.Forms.RadioButton rdoChgNmTypePic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChgNmEditChangeList;
        private System.Windows.Forms.RadioButton rdoChgNmTypeText;
        private System.Windows.Forms.Button btnChgNmViewChgFileNameList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnChgNmEditChangeFileList;
        private System.Windows.Forms.CheckBox chkChgNmSpecChangeFile;
        private System.Windows.Forms.CheckBox chkChgNmIsRegex;
        private System.Windows.Forms.CheckBox chkChgNmOnlyFixStr;

    }
}

