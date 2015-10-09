namespace GetWords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtResultFolder = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.labAll3 = new System.Windows.Forms.Label();
            this.labAll2 = new System.Windows.Forms.Label();
            this.labAll1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labFin3 = new System.Windows.Forms.Label();
            this.labFin2 = new System.Windows.Forms.Label();
            this.labFin1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.labCrtdNum = new System.Windows.Forms.Label();
            this.txtResultFolder2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numThreadCnt = new System.Windows.Forms.NumericUpDown();
            this.numFile = new System.Windows.Forms.NumericUpDown();
            this.numRecord = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndChap = new System.Windows.Forms.TextBox();
            this.txtStartChap = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.txtGyszContent = new System.Windows.Forms.TextBox();
            this.btnGyszGetEndsLst = new System.Windows.Forms.Button();
            this.btnGyszRemovEnds = new System.Windows.Forms.Button();
            this.txtGyszEndsList = new System.Windows.Forms.TextBox();
            this.txtGyszReg = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreadCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecord)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(8, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(8, 6);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(282, 331);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.WordWrap = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(616, 425);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(608, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(89, 343);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(296, 6);
            this.textBox2.MaxLength = 0;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(304, 331);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            this.textBox2.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtSourceFolder);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.txtResultFolder);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.labAll3);
            this.tabPage2.Controls.Add(this.labAll2);
            this.tabPage2.Controls.Add(this.labAll1);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.labFin3);
            this.tabPage2.Controls.Add(this.labFin2);
            this.tabPage2.Controls.Add(this.labFin1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(608, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(138, 42);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(269, 21);
            this.txtSourceFolder.TabIndex = 6;
            this.txtSourceFolder.Text = "R:\\中华诗词网\\";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(302, 250);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "解析网页";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtResultFolder
            // 
            this.txtResultFolder.Location = new System.Drawing.Point(138, 69);
            this.txtResultFolder.Name = "txtResultFolder";
            this.txtResultFolder.Size = new System.Drawing.Size(269, 21);
            this.txtResultFolder.TabIndex = 4;
            this.txtResultFolder.Text = "R:\\";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(138, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 24);
            this.button2.TabIndex = 3;
            this.button2.Text = "抓取网页";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labAll3
            // 
            this.labAll3.AutoSize = true;
            this.labAll3.Location = new System.Drawing.Point(230, 179);
            this.labAll3.Name = "labAll3";
            this.labAll3.Size = new System.Drawing.Size(41, 12);
            this.labAll3.TabIndex = 2;
            this.labAll3.Text = "label3";
            // 
            // labAll2
            // 
            this.labAll2.AutoSize = true;
            this.labAll2.Location = new System.Drawing.Point(230, 156);
            this.labAll2.Name = "labAll2";
            this.labAll2.Size = new System.Drawing.Size(41, 12);
            this.labAll2.TabIndex = 2;
            this.labAll2.Text = "label3";
            // 
            // labAll1
            // 
            this.labAll1.AutoSize = true;
            this.labAll1.Location = new System.Drawing.Point(230, 132);
            this.labAll1.Name = "labAll1";
            this.labAll1.Size = new System.Drawing.Size(41, 12);
            this.labAll1.TabIndex = 2;
            this.labAll1.Text = "label3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "/";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "/";
            // 
            // labFin3
            // 
            this.labFin3.AutoSize = true;
            this.labFin3.Location = new System.Drawing.Point(136, 179);
            this.labFin3.Name = "labFin3";
            this.labFin3.Size = new System.Drawing.Size(41, 12);
            this.labFin3.TabIndex = 0;
            this.labFin3.Text = "label1";
            // 
            // labFin2
            // 
            this.labFin2.AutoSize = true;
            this.labFin2.Location = new System.Drawing.Point(136, 156);
            this.labFin2.Name = "labFin2";
            this.labFin2.Size = new System.Drawing.Size(41, 12);
            this.labFin2.TabIndex = 0;
            this.labFin2.Text = "label1";
            // 
            // labFin1
            // 
            this.labFin1.AutoSize = true;
            this.labFin1.Location = new System.Drawing.Point(136, 132);
            this.labFin1.Name = "labFin1";
            this.labFin1.Size = new System.Drawing.Size(41, 12);
            this.labFin1.TabIndex = 0;
            this.labFin1.Text = "label1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.labCrtdNum);
            this.tabPage3.Controls.Add(this.txtResultFolder2);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.numThreadCnt);
            this.tabPage3.Controls.Add(this.numFile);
            this.tabPage3.Controls.Add(this.numRecord);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(608, 399);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(105, 276);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(126, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "生成数据文件(直接)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // labCrtdNum
            // 
            this.labCrtdNum.AutoSize = true;
            this.labCrtdNum.Location = new System.Drawing.Point(103, 56);
            this.labCrtdNum.Name = "labCrtdNum";
            this.labCrtdNum.Size = new System.Drawing.Size(41, 12);
            this.labCrtdNum.TabIndex = 6;
            this.labCrtdNum.Text = "label4";
            // 
            // txtResultFolder2
            // 
            this.txtResultFolder2.Location = new System.Drawing.Point(105, 107);
            this.txtResultFolder2.Name = "txtResultFolder2";
            this.txtResultFolder2.Size = new System.Drawing.Size(269, 21);
            this.txtResultFolder2.TabIndex = 5;
            this.txtResultFolder2.Text = "R:\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "线程数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "文件个数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "单文件记录数";
            // 
            // numThreadCnt
            // 
            this.numThreadCnt.Location = new System.Drawing.Point(105, 188);
            this.numThreadCnt.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numThreadCnt.Name = "numThreadCnt";
            this.numThreadCnt.Size = new System.Drawing.Size(82, 21);
            this.numThreadCnt.TabIndex = 2;
            this.numThreadCnt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numFile
            // 
            this.numFile.Location = new System.Drawing.Point(105, 161);
            this.numFile.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numFile.Name = "numFile";
            this.numFile.Size = new System.Drawing.Size(82, 21);
            this.numFile.TabIndex = 2;
            this.numFile.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numRecord
            // 
            this.numRecord.Location = new System.Drawing.Point(105, 134);
            this.numRecord.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numRecord.Name = "numRecord";
            this.numRecord.Size = new System.Drawing.Size(82, 21);
            this.numRecord.TabIndex = 1;
            this.numRecord.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(105, 224);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(126, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "生成数据文件";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtGyszReg);
            this.tabPage4.Controls.Add(this.txtGyszEndsList);
            this.tabPage4.Controls.Add(this.btnGyszRemovEnds);
            this.tabPage4.Controls.Add(this.btnGyszGetEndsLst);
            this.tabPage4.Controls.Add(this.txtGyszContent);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.txtEndChap);
            this.tabPage4.Controls.Add(this.txtStartChap);
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(608, 399);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "诡域尸咒";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "结束章节";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "起始章节";
            // 
            // txtEndChap
            // 
            this.txtEndChap.Location = new System.Drawing.Point(93, 47);
            this.txtEndChap.Name = "txtEndChap";
            this.txtEndChap.Size = new System.Drawing.Size(100, 21);
            this.txtEndChap.TabIndex = 6;
            this.txtEndChap.Text = "***";
            // 
            // txtStartChap
            // 
            this.txtStartChap.Location = new System.Drawing.Point(93, 20);
            this.txtStartChap.Name = "txtStartChap";
            this.txtStartChap.Size = new System.Drawing.Size(100, 21);
            this.txtStartChap.TabIndex = 6;
            this.txtStartChap.Text = "第一章";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(93, 74);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 5;
            this.button7.Text = "诡域尸咒1";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // txtGyszContent
            // 
            this.txtGyszContent.Location = new System.Drawing.Point(312, 74);
            this.txtGyszContent.MaxLength = 0;
            this.txtGyszContent.Multiline = true;
            this.txtGyszContent.Name = "txtGyszContent";
            this.txtGyszContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGyszContent.Size = new System.Drawing.Size(288, 319);
            this.txtGyszContent.TabIndex = 8;
            this.txtGyszContent.WordWrap = false;
            // 
            // btnGyszGetEndsLst
            // 
            this.btnGyszGetEndsLst.Location = new System.Drawing.Point(215, 12);
            this.btnGyszGetEndsLst.Name = "btnGyszGetEndsLst";
            this.btnGyszGetEndsLst.Size = new System.Drawing.Size(89, 23);
            this.btnGyszGetEndsLst.TabIndex = 9;
            this.btnGyszGetEndsLst.Text = "匹配狗血后缀";
            this.btnGyszGetEndsLst.UseVisualStyleBackColor = true;
            this.btnGyszGetEndsLst.Click += new System.EventHandler(this.btnGyszGetEndsLst_Click);
            // 
            // btnGyszRemovEnds
            // 
            this.btnGyszRemovEnds.Location = new System.Drawing.Point(215, 41);
            this.btnGyszRemovEnds.Name = "btnGyszRemovEnds";
            this.btnGyszRemovEnds.Size = new System.Drawing.Size(89, 23);
            this.btnGyszRemovEnds.TabIndex = 9;
            this.btnGyszRemovEnds.Text = "去除后缀";
            this.btnGyszRemovEnds.UseVisualStyleBackColor = true;
            this.btnGyszRemovEnds.Click += new System.EventHandler(this.btnGyszRemovEnds_Click);
            // 
            // txtGyszEndsList
            // 
            this.txtGyszEndsList.Location = new System.Drawing.Point(204, 74);
            this.txtGyszEndsList.Multiline = true;
            this.txtGyszEndsList.Name = "txtGyszEndsList";
            this.txtGyszEndsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGyszEndsList.Size = new System.Drawing.Size(100, 317);
            this.txtGyszEndsList.TabIndex = 10;
            // 
            // txtGyszReg
            // 
            this.txtGyszReg.Location = new System.Drawing.Point(312, 12);
            this.txtGyszReg.Name = "txtGyszReg";
            this.txtGyszReg.Size = new System.Drawing.Size(132, 21);
            this.txtGyszReg.TabIndex = 11;
            this.txtGyszReg.Text = "\\b\\w{4}\\b。\\r";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 425);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreadCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecord)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtResultFolder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labAll3;
        private System.Windows.Forms.Label labAll2;
        private System.Windows.Forms.Label labAll1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labFin3;
        private System.Windows.Forms.Label labFin2;
        private System.Windows.Forms.Label labFin1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numFile;
        private System.Windows.Forms.NumericUpDown numRecord;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtResultFolder2;
        private System.Windows.Forms.Label labCrtdNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numThreadCnt;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEndChap;
        private System.Windows.Forms.TextBox txtStartChap;
        private System.Windows.Forms.TextBox txtGyszReg;
        private System.Windows.Forms.TextBox txtGyszEndsList;
        private System.Windows.Forms.Button btnGyszRemovEnds;
        private System.Windows.Forms.Button btnGyszGetEndsLst;
        private System.Windows.Forms.TextBox txtGyszContent;
    }
}

