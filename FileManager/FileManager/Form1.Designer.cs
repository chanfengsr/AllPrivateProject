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
            this.tabCtrlFunction = new System.Windows.Forms.TabControl();
            this.tabPageCopyByGroup = new System.Windows.Forms.TabPage();
            this.chkModMove = new System.Windows.Forms.CheckBox();
            this.btnCopyByDate = new System.Windows.Forms.Button();
            this.tabPageFileBatchChangeName = new System.Windows.Forms.TabPage();
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
            this.grpFileSelect = new System.Windows.Forms.GroupBox();
            this.btnEditChangeFileList = new System.Windows.Forms.Button();
            this.chkSpecFileList = new System.Windows.Forms.CheckBox();
            this.btnViewFileNameList = new System.Windows.Forms.Button();
            this.grpSortMode = new System.Windows.Forms.GroupBox();
            this.rdoSortNameDate = new System.Windows.Forms.RadioButton();
            this.rdoSortRecordDate = new System.Windows.Forms.RadioButton();
            this.rdoSortModifyDate = new System.Windows.Forms.RadioButton();
            this.rdoSortCreateDate = new System.Windows.Forms.RadioButton();
            this.rdoSortName = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.grpFileType = new System.Windows.Forms.GroupBox();
            this.txtFileType = new System.Windows.Forms.TextBox();
            this.rdoTypeCust = new System.Windows.Forms.RadioButton();
            this.rdoTypeText = new System.Windows.Forms.RadioButton();
            this.rdoTypeAudio = new System.Windows.Forms.RadioButton();
            this.rdoTypeVideo = new System.Windows.Forms.RadioButton();
            this.rdoTypePic = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.btnTargetFolderBrowser = new System.Windows.Forms.Button();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.btnSourceFolderBrowser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpFunction.SuspendLayout();
            this.tabCtrlFunction.SuspendLayout();
            this.tabPageCopyByGroup.SuspendLayout();
            this.tabPageFileBatchChangeName.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChgNmWildcardLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChgNmStartNum)).BeginInit();
            this.grpFileSelect.SuspendLayout();
            this.grpSortMode.SuspendLayout();
            this.grpFileType.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(756, 643);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 12;
            // 
            // grpFunction
            // 
            this.grpFunction.Controls.Add(this.tabCtrlFunction);
            this.grpFunction.Controls.Add(this.grpFileSelect);
            this.grpFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFunction.Location = new System.Drawing.Point(0, 0);
            this.grpFunction.Name = "grpFunction";
            this.grpFunction.Size = new System.Drawing.Size(756, 500);
            this.grpFunction.TabIndex = 1;
            this.grpFunction.TabStop = false;
            this.grpFunction.Text = "功能";
            // 
            // tabCtrlFunction
            // 
            this.tabCtrlFunction.Controls.Add(this.tabPageCopyByGroup);
            this.tabCtrlFunction.Controls.Add(this.tabPageFileBatchChangeName);
            this.tabCtrlFunction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabCtrlFunction.Location = new System.Drawing.Point(3, 288);
            this.tabCtrlFunction.Name = "tabCtrlFunction";
            this.tabCtrlFunction.SelectedIndex = 0;
            this.tabCtrlFunction.Size = new System.Drawing.Size(750, 209);
            this.tabCtrlFunction.TabIndex = 1;
            this.tabCtrlFunction.SelectedIndexChanged += new System.EventHandler(this.tabCtrlFunction_SelectedIndexChanged);
            // 
            // tabPageCopyByGroup
            // 
            this.tabPageCopyByGroup.Controls.Add(this.chkModMove);
            this.tabPageCopyByGroup.Controls.Add(this.btnCopyByDate);
            this.tabPageCopyByGroup.Location = new System.Drawing.Point(4, 22);
            this.tabPageCopyByGroup.Name = "tabPageCopyByGroup";
            this.tabPageCopyByGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCopyByGroup.Size = new System.Drawing.Size(742, 183);
            this.tabPageCopyByGroup.TabIndex = 0;
            this.tabPageCopyByGroup.Text = "日期分组复制文件";
            this.tabPageCopyByGroup.UseVisualStyleBackColor = true;
            // 
            // chkModMove
            // 
            this.chkModMove.AutoSize = true;
            this.chkModMove.Location = new System.Drawing.Point(20, 15);
            this.chkModMove.Name = "chkModMove";
            this.chkModMove.Size = new System.Drawing.Size(48, 16);
            this.chkModMove.TabIndex = 0;
            this.chkModMove.Text = "移动";
            this.chkModMove.UseVisualStyleBackColor = true;
            // 
            // btnCopyByDate
            // 
            this.btnCopyByDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCopyByDate.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCopyByDate.Location = new System.Drawing.Point(74, 15);
            this.btnCopyByDate.Name = "btnCopyByDate";
            this.btnCopyByDate.Size = new System.Drawing.Size(116, 33);
            this.btnCopyByDate.TabIndex = 1;
            this.btnCopyByDate.Text = "按日期复制";
            this.btnCopyByDate.UseVisualStyleBackColor = true;
            this.btnCopyByDate.Click += new System.EventHandler(this.btnCopyByDate_Click);
            // 
            // tabPageFileBatchChangeName
            // 
            this.tabPageFileBatchChangeName.Controls.Add(this.btnChgNmExecute);
            this.tabPageFileBatchChangeName.Controls.Add(this.groupBox5);
            this.tabPageFileBatchChangeName.Location = new System.Drawing.Point(4, 22);
            this.tabPageFileBatchChangeName.Name = "tabPageFileBatchChangeName";
            this.tabPageFileBatchChangeName.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFileBatchChangeName.Size = new System.Drawing.Size(742, 183);
            this.tabPageFileBatchChangeName.TabIndex = 1;
            this.tabPageFileBatchChangeName.Text = "文件批量改名";
            this.tabPageFileBatchChangeName.UseVisualStyleBackColor = true;
            // 
            // btnChgNmExecute
            // 
            this.btnChgNmExecute.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChgNmExecute.ForeColor = System.Drawing.Color.DarkRed;
            this.btnChgNmExecute.Location = new System.Drawing.Point(17, 136);
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
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
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
            this.chkChgNmOnlyFixStr.Location = new System.Drawing.Point(494, 55);
            this.chkChgNmOnlyFixStr.Name = "chkChgNmOnlyFixStr";
            this.chkChgNmOnlyFixStr.Size = new System.Drawing.Size(72, 16);
            this.chkChgNmOnlyFixStr.TabIndex = 8;
            this.chkChgNmOnlyFixStr.Text = "仅前后缀";
            this.chkChgNmOnlyFixStr.UseVisualStyleBackColor = true;
            this.chkChgNmOnlyFixStr.CheckedChanged += new System.EventHandler(this.chkChgNmOnlyFixStr_CheckedChanged);
            // 
            // chkChgNmIsRegex
            // 
            this.chkChgNmIsRegex.AutoSize = true;
            this.chkChgNmIsRegex.Location = new System.Drawing.Point(423, 25);
            this.chkChgNmIsRegex.Name = "chkChgNmIsRegex";
            this.chkChgNmIsRegex.Size = new System.Drawing.Size(84, 16);
            this.chkChgNmIsRegex.TabIndex = 2;
            this.chkChgNmIsRegex.Text = "正则表达式";
            this.chkChgNmIsRegex.UseVisualStyleBackColor = true;
            // 
            // btnChgNmViewChgFileNameList
            // 
            this.btnChgNmViewChgFileNameList.Location = new System.Drawing.Point(605, 38);
            this.btnChgNmViewChgFileNameList.Name = "btnChgNmViewChgFileNameList";
            this.btnChgNmViewChgFileNameList.Size = new System.Drawing.Size(93, 23);
            this.btnChgNmViewChgFileNameList.TabIndex = 9;
            this.btnChgNmViewChgFileNameList.Text = "更名列表预览";
            this.btnChgNmViewChgFileNameList.UseVisualStyleBackColor = true;
            this.btnChgNmViewChgFileNameList.Click += new System.EventHandler(this.btnChgNmViewChgFileNameList_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(565, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 48);
            this.label8.TabIndex = 6;
            this.label8.Text = "}";
            // 
            // btnChgNmEditChangeList
            // 
            this.btnChgNmEditChangeList.Enabled = false;
            this.btnChgNmEditChangeList.Location = new System.Drawing.Point(134, 86);
            this.btnChgNmEditChangeList.Name = "btnChgNmEditChangeList";
            this.btnChgNmEditChangeList.Size = new System.Drawing.Size(75, 23);
            this.btnChgNmEditChangeList.TabIndex = 11;
            this.btnChgNmEditChangeList.Text = "编辑列表";
            this.btnChgNmEditChangeList.UseVisualStyleBackColor = true;
            this.btnChgNmEditChangeList.Click += new System.EventHandler(this.btnChgNmEditChangeList_Click);
            // 
            // numChgNmWildcardLen
            // 
            this.numChgNmWildcardLen.Enabled = false;
            this.numChgNmWildcardLen.Location = new System.Drawing.Point(331, 53);
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
            this.numChgNmWildcardLen.Size = new System.Drawing.Size(49, 21);
            this.numChgNmWildcardLen.TabIndex = 6;
            this.numChgNmWildcardLen.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "通配符长度";
            // 
            // numChgNmStartNum
            // 
            this.numChgNmStartNum.Enabled = false;
            this.numChgNmStartNum.Location = new System.Drawing.Point(204, 53);
            this.numChgNmStartNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numChgNmStartNum.Name = "numChgNmStartNum";
            this.numChgNmStartNum.Size = new System.Drawing.Size(49, 21);
            this.numChgNmStartNum.TabIndex = 5;
            this.numChgNmStartNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(398, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "+";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "+  起始序号";
            // 
            // txtChgNmSuffixStr
            // 
            this.txtChgNmSuffixStr.Enabled = false;
            this.txtChgNmSuffixStr.Location = new System.Drawing.Point(417, 53);
            this.txtChgNmSuffixStr.Name = "txtChgNmSuffixStr";
            this.txtChgNmSuffixStr.Size = new System.Drawing.Size(71, 21);
            this.txtChgNmSuffixStr.TabIndex = 2;
            // 
            // txtChgNmPerfixStr
            // 
            this.txtChgNmPerfixStr.Enabled = false;
            this.txtChgNmPerfixStr.Location = new System.Drawing.Point(42, 53);
            this.txtChgNmPerfixStr.Name = "txtChgNmPerfixStr";
            this.txtChgNmPerfixStr.Size = new System.Drawing.Size(71, 21);
            this.txtChgNmPerfixStr.TabIndex = 4;
            // 
            // txtChgNmFixedStr
            // 
            this.txtChgNmFixedStr.Location = new System.Drawing.Point(133, 23);
            this.txtChgNmFixedStr.Name = "txtChgNmFixedStr";
            this.txtChgNmFixedStr.Size = new System.Drawing.Size(284, 21);
            this.txtChgNmFixedStr.TabIndex = 1;
            // 
            // rdoChgNmRulSpecList
            // 
            this.rdoChgNmRulSpecList.AutoSize = true;
            this.rdoChgNmRulSpecList.Location = new System.Drawing.Point(20, 89);
            this.rdoChgNmRulSpecList.Name = "rdoChgNmRulSpecList";
            this.rdoChgNmRulSpecList.Size = new System.Drawing.Size(95, 16);
            this.rdoChgNmRulSpecList.TabIndex = 10;
            this.rdoChgNmRulSpecList.Text = "指定更名列表";
            this.rdoChgNmRulSpecList.UseVisualStyleBackColor = true;
            this.rdoChgNmRulSpecList.CheckedChanged += new System.EventHandler(this.rdoChgNmRulSpecList_CheckedChanged);
            // 
            // rdoChgNmRulWildcard
            // 
            this.rdoChgNmRulWildcard.AutoSize = true;
            this.rdoChgNmRulWildcard.Location = new System.Drawing.Point(20, 57);
            this.rdoChgNmRulWildcard.Name = "rdoChgNmRulWildcard";
            this.rdoChgNmRulWildcard.Size = new System.Drawing.Size(14, 13);
            this.rdoChgNmRulWildcard.TabIndex = 3;
            this.rdoChgNmRulWildcard.UseVisualStyleBackColor = true;
            this.rdoChgNmRulWildcard.CheckedChanged += new System.EventHandler(this.rdoChgNmRulWildcard_CheckedChanged);
            // 
            // rdoChgNmRulFixedStr
            // 
            this.rdoChgNmRulFixedStr.AutoSize = true;
            this.rdoChgNmRulFixedStr.Checked = true;
            this.rdoChgNmRulFixedStr.Location = new System.Drawing.Point(20, 25);
            this.rdoChgNmRulFixedStr.Name = "rdoChgNmRulFixedStr";
            this.rdoChgNmRulFixedStr.Size = new System.Drawing.Size(107, 16);
            this.rdoChgNmRulFixedStr.TabIndex = 0;
            this.rdoChgNmRulFixedStr.TabStop = true;
            this.rdoChgNmRulFixedStr.Text = "去掉固定字符串";
            this.rdoChgNmRulFixedStr.UseVisualStyleBackColor = true;
            this.rdoChgNmRulFixedStr.CheckedChanged += new System.EventHandler(this.rdoChgNmRulFixedStr_CheckedChanged);
            // 
            // grpFileSelect
            // 
            this.grpFileSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFileSelect.Controls.Add(this.btnEditChangeFileList);
            this.grpFileSelect.Controls.Add(this.chkSpecFileList);
            this.grpFileSelect.Controls.Add(this.btnViewFileNameList);
            this.grpFileSelect.Controls.Add(this.grpSortMode);
            this.grpFileSelect.Controls.Add(this.label5);
            this.grpFileSelect.Controls.Add(this.grpFileType);
            this.grpFileSelect.Controls.Add(this.label4);
            this.grpFileSelect.Controls.Add(this.label10);
            this.grpFileSelect.Controls.Add(this.label3);
            this.grpFileSelect.Controls.Add(this.txtTargetFolder);
            this.grpFileSelect.Controls.Add(this.btnTargetFolderBrowser);
            this.grpFileSelect.Controls.Add(this.txtSourceFolder);
            this.grpFileSelect.Controls.Add(this.btnSourceFolderBrowser);
            this.grpFileSelect.Location = new System.Drawing.Point(13, 22);
            this.grpFileSelect.Name = "grpFileSelect";
            this.grpFileSelect.Size = new System.Drawing.Size(730, 204);
            this.grpFileSelect.TabIndex = 0;
            this.grpFileSelect.TabStop = false;
            this.grpFileSelect.Text = "文件选择";
            // 
            // btnEditChangeFileList
            // 
            this.btnEditChangeFileList.Enabled = false;
            this.btnEditChangeFileList.Location = new System.Drawing.Point(254, 170);
            this.btnEditChangeFileList.Name = "btnEditChangeFileList";
            this.btnEditChangeFileList.Size = new System.Drawing.Size(75, 23);
            this.btnEditChangeFileList.TabIndex = 8;
            this.btnEditChangeFileList.Text = "编辑列表";
            this.btnEditChangeFileList.UseVisualStyleBackColor = true;
            this.btnEditChangeFileList.Click += new System.EventHandler(this.btnEditChangeFileList_Click);
            // 
            // chkSpecFileList
            // 
            this.chkSpecFileList.AutoSize = true;
            this.chkSpecFileList.Location = new System.Drawing.Point(152, 173);
            this.chkSpecFileList.Name = "chkSpecFileList";
            this.chkSpecFileList.Size = new System.Drawing.Size(96, 16);
            this.chkSpecFileList.TabIndex = 7;
            this.chkSpecFileList.Text = "指定文件列表";
            this.chkSpecFileList.UseVisualStyleBackColor = true;
            this.chkSpecFileList.CheckedChanged += new System.EventHandler(this.chkSpecChangeFile_CheckedChanged);
            // 
            // btnViewFileNameList
            // 
            this.btnViewFileNameList.Location = new System.Drawing.Point(20, 170);
            this.btnViewFileNameList.Name = "btnViewFileNameList";
            this.btnViewFileNameList.Size = new System.Drawing.Size(92, 23);
            this.btnViewFileNameList.TabIndex = 6;
            this.btnViewFileNameList.Text = "文件列表预览";
            this.btnViewFileNameList.UseVisualStyleBackColor = true;
            this.btnViewFileNameList.Click += new System.EventHandler(this.btnViewFileNameList_Click);
            // 
            // grpSortMode
            // 
            this.grpSortMode.Controls.Add(this.rdoSortNameDate);
            this.grpSortMode.Controls.Add(this.rdoSortRecordDate);
            this.grpSortMode.Controls.Add(this.rdoSortModifyDate);
            this.grpSortMode.Controls.Add(this.rdoSortCreateDate);
            this.grpSortMode.Controls.Add(this.rdoSortName);
            this.grpSortMode.Location = new System.Drawing.Point(113, 125);
            this.grpSortMode.Name = "grpSortMode";
            this.grpSortMode.Size = new System.Drawing.Size(603, 37);
            this.grpSortMode.TabIndex = 5;
            this.grpSortMode.TabStop = false;
            // 
            // rdoSortNameDate
            // 
            this.rdoSortNameDate.AutoSize = true;
            this.rdoSortNameDate.Location = new System.Drawing.Point(376, 14);
            this.rdoSortNameDate.Name = "rdoSortNameDate";
            this.rdoSortNameDate.Size = new System.Drawing.Size(203, 16);
            this.rdoSortNameDate.TabIndex = 4;
            this.rdoSortNameDate.Text = "文件名日期，拍摄日期，修改日期";
            this.rdoSortNameDate.UseVisualStyleBackColor = true;
            // 
            // rdoSortRecordDate
            // 
            this.rdoSortRecordDate.AutoSize = true;
            this.rdoSortRecordDate.Location = new System.Drawing.Point(237, 14);
            this.rdoSortRecordDate.Name = "rdoSortRecordDate";
            this.rdoSortRecordDate.Size = new System.Drawing.Size(131, 16);
            this.rdoSortRecordDate.TabIndex = 3;
            this.rdoSortRecordDate.Text = "拍摄日期，修改日期";
            this.rdoSortRecordDate.UseVisualStyleBackColor = true;
            // 
            // rdoSortModifyDate
            // 
            this.rdoSortModifyDate.AutoSize = true;
            this.rdoSortModifyDate.Location = new System.Drawing.Point(158, 14);
            this.rdoSortModifyDate.Name = "rdoSortModifyDate";
            this.rdoSortModifyDate.Size = new System.Drawing.Size(71, 16);
            this.rdoSortModifyDate.TabIndex = 2;
            this.rdoSortModifyDate.Text = "修改日期";
            this.rdoSortModifyDate.UseVisualStyleBackColor = true;
            // 
            // rdoSortCreateDate
            // 
            this.rdoSortCreateDate.AutoSize = true;
            this.rdoSortCreateDate.Location = new System.Drawing.Point(79, 14);
            this.rdoSortCreateDate.Name = "rdoSortCreateDate";
            this.rdoSortCreateDate.Size = new System.Drawing.Size(71, 16);
            this.rdoSortCreateDate.TabIndex = 1;
            this.rdoSortCreateDate.Text = "创建日期";
            this.rdoSortCreateDate.UseVisualStyleBackColor = true;
            // 
            // rdoSortName
            // 
            this.rdoSortName.AutoSize = true;
            this.rdoSortName.Checked = true;
            this.rdoSortName.Location = new System.Drawing.Point(12, 14);
            this.rdoSortName.Name = "rdoSortName";
            this.rdoSortName.Size = new System.Drawing.Size(59, 16);
            this.rdoSortName.TabIndex = 0;
            this.rdoSortName.TabStop = true;
            this.rdoSortName.Text = "文件名";
            this.rdoSortName.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "排序/日期方式";
            // 
            // grpFileType
            // 
            this.grpFileType.Controls.Add(this.txtFileType);
            this.grpFileType.Controls.Add(this.rdoTypeCust);
            this.grpFileType.Controls.Add(this.rdoTypeText);
            this.grpFileType.Controls.Add(this.rdoTypeAudio);
            this.grpFileType.Controls.Add(this.rdoTypeVideo);
            this.grpFileType.Controls.Add(this.rdoTypePic);
            this.grpFileType.Location = new System.Drawing.Point(113, 84);
            this.grpFileType.Name = "grpFileType";
            this.grpFileType.Size = new System.Drawing.Size(603, 37);
            this.grpFileType.TabIndex = 4;
            this.grpFileType.TabStop = false;
            // 
            // txtFileType
            // 
            this.txtFileType.Location = new System.Drawing.Point(382, 12);
            this.txtFileType.Name = "txtFileType";
            this.txtFileType.Size = new System.Drawing.Size(185, 21);
            this.txtFileType.TabIndex = 0;
            this.txtFileType.Text = "*";
            // 
            // rdoTypeCust
            // 
            this.rdoTypeCust.AutoSize = true;
            this.rdoTypeCust.Checked = true;
            this.rdoTypeCust.Location = new System.Drawing.Point(264, 14);
            this.rdoTypeCust.Name = "rdoTypeCust";
            this.rdoTypeCust.Size = new System.Drawing.Size(113, 16);
            this.rdoTypeCust.TabIndex = 5;
            this.rdoTypeCust.TabStop = true;
            this.rdoTypeCust.Text = "自定义(\"|\"分割)";
            this.rdoTypeCust.UseVisualStyleBackColor = true;
            this.rdoTypeCust.CheckedChanged += new System.EventHandler(this.rdoTypeCust_CheckedChanged);
            // 
            // rdoTypeText
            // 
            this.rdoTypeText.AutoSize = true;
            this.rdoTypeText.Location = new System.Drawing.Point(201, 14);
            this.rdoTypeText.Name = "rdoTypeText";
            this.rdoTypeText.Size = new System.Drawing.Size(47, 16);
            this.rdoTypeText.TabIndex = 3;
            this.rdoTypeText.Text = "文本";
            this.rdoTypeText.UseVisualStyleBackColor = true;
            // 
            // rdoTypeAudio
            // 
            this.rdoTypeAudio.AutoSize = true;
            this.rdoTypeAudio.Location = new System.Drawing.Point(138, 14);
            this.rdoTypeAudio.Name = "rdoTypeAudio";
            this.rdoTypeAudio.Size = new System.Drawing.Size(47, 16);
            this.rdoTypeAudio.TabIndex = 2;
            this.rdoTypeAudio.Text = "音频";
            this.rdoTypeAudio.UseVisualStyleBackColor = true;
            // 
            // rdoTypeVideo
            // 
            this.rdoTypeVideo.AutoSize = true;
            this.rdoTypeVideo.Location = new System.Drawing.Point(75, 14);
            this.rdoTypeVideo.Name = "rdoTypeVideo";
            this.rdoTypeVideo.Size = new System.Drawing.Size(47, 16);
            this.rdoTypeVideo.TabIndex = 1;
            this.rdoTypeVideo.Text = "视频";
            this.rdoTypeVideo.UseVisualStyleBackColor = true;
            // 
            // rdoTypePic
            // 
            this.rdoTypePic.AutoSize = true;
            this.rdoTypePic.Location = new System.Drawing.Point(12, 14);
            this.rdoTypePic.Name = "rdoTypePic";
            this.rdoTypePic.Size = new System.Drawing.Size(47, 16);
            this.rdoTypePic.TabIndex = 0;
            this.rdoTypePic.Text = "图片";
            this.rdoTypePic.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "文件类型";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "文件路径(目标)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "文件路径(源)";
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.AllowDrop = true;
            this.txtTargetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetFolder.Location = new System.Drawing.Point(113, 55);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.Size = new System.Drawing.Size(545, 21);
            this.txtTargetFolder.TabIndex = 2;
            this.txtTargetFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragDrop);
            this.txtTargetFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragEnter);
            // 
            // btnTargetFolderBrowser
            // 
            this.btnTargetFolderBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTargetFolderBrowser.Location = new System.Drawing.Point(672, 54);
            this.btnTargetFolderBrowser.Name = "btnTargetFolderBrowser";
            this.btnTargetFolderBrowser.Size = new System.Drawing.Size(33, 23);
            this.btnTargetFolderBrowser.TabIndex = 3;
            this.btnTargetFolderBrowser.Text = "...";
            this.btnTargetFolderBrowser.UseVisualStyleBackColor = true;
            this.btnTargetFolderBrowser.Click += new System.EventHandler(this.btnTargetFolderBrowser_Click);
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.AllowDrop = true;
            this.txtSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceFolder.Location = new System.Drawing.Point(113, 25);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(545, 21);
            this.txtSourceFolder.TabIndex = 0;
            this.txtSourceFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragDrop);
            this.txtSourceFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFileFolder_DragEnter);
            // 
            // btnSourceFolderBrowser
            // 
            this.btnSourceFolderBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourceFolderBrowser.Location = new System.Drawing.Point(672, 24);
            this.btnSourceFolderBrowser.Name = "btnSourceFolderBrowser";
            this.btnSourceFolderBrowser.Size = new System.Drawing.Size(33, 23);
            this.btnSourceFolderBrowser.TabIndex = 1;
            this.btnSourceFolderBrowser.Text = "...";
            this.btnSourceFolderBrowser.UseVisualStyleBackColor = true;
            this.btnSourceFolderBrowser.Click += new System.EventHandler(this.btnSourceFolderBrowser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCloseForm);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtConsole);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 139);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "执行信息";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseForm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCloseForm.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCloseForm.Location = new System.Drawing.Point(614, 52);
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
            this.btnClear.Location = new System.Drawing.Point(673, 25);
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
            this.txtConsole.Size = new System.Drawing.Size(744, 113);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.TabStop = false;
            this.txtConsole.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseForm;
            this.ClientSize = new System.Drawing.Size(756, 643);
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
            this.tabCtrlFunction.ResumeLayout(false);
            this.tabPageCopyByGroup.ResumeLayout(false);
            this.tabPageCopyByGroup.PerformLayout();
            this.tabPageFileBatchChangeName.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChgNmWildcardLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChgNmStartNum)).EndInit();
            this.grpFileSelect.ResumeLayout(false);
            this.grpFileSelect.PerformLayout();
            this.grpSortMode.ResumeLayout(false);
            this.grpSortMode.PerformLayout();
            this.grpFileType.ResumeLayout(false);
            this.grpFileType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabCtrlFunction;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.GroupBox grpFunction;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabPage tabPageCopyByGroup;
        private System.Windows.Forms.Button btnCopyByDate;
        private System.Windows.Forms.TabPage tabPageFileBatchChangeName;
        private System.Windows.Forms.GroupBox grpFileSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Button btnSourceFolderBrowser;
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
        private System.Windows.Forms.Button btnViewFileNameList;
        private System.Windows.Forms.GroupBox grpSortMode;
        private System.Windows.Forms.RadioButton rdoSortRecordDate;
        private System.Windows.Forms.RadioButton rdoSortModifyDate;
        private System.Windows.Forms.RadioButton rdoSortCreateDate;
        private System.Windows.Forms.RadioButton rdoSortName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpFileType;
        private System.Windows.Forms.TextBox txtFileType;
        private System.Windows.Forms.RadioButton rdoTypeCust;
        private System.Windows.Forms.RadioButton rdoTypeAudio;
        private System.Windows.Forms.RadioButton rdoTypeVideo;
        private System.Windows.Forms.RadioButton rdoTypePic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChgNmEditChangeList;
        private System.Windows.Forms.RadioButton rdoTypeText;
        private System.Windows.Forms.Button btnChgNmViewChgFileNameList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEditChangeFileList;
        private System.Windows.Forms.CheckBox chkSpecFileList;
        private System.Windows.Forms.CheckBox chkChgNmIsRegex;
        private System.Windows.Forms.CheckBox chkChgNmOnlyFixStr;
        private System.Windows.Forms.CheckBox chkModMove;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTargetFolder;
        private System.Windows.Forms.Button btnTargetFolderBrowser;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.RadioButton rdoSortNameDate;

    }
}

