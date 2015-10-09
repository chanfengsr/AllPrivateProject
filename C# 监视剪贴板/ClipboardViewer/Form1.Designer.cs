namespace ClipboardViewer
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.llabClearAll = new System.Windows.Forms.LinkLabel();
            this.chkNoneAdd = new System.Windows.Forms.CheckBox();
            this.labHave = new System.Windows.Forms.Label();
            this.llabAddNoneLine = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.llabClearRegex = new System.Windows.Forms.LinkLabel();
            this.chkRegex = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(2, 33);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(628, 78);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(2, 117);
            this.textBox2.MaxLength = 0;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(628, 334);
            this.textBox2.TabIndex = 0;
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(2, 458);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(48, 16);
            this.chkActive.TabIndex = 1;
            this.chkActive.Text = "开启";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // llabClearAll
            // 
            this.llabClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llabClearAll.AutoSize = true;
            this.llabClearAll.Location = new System.Drawing.Point(568, 459);
            this.llabClearAll.Name = "llabClearAll";
            this.llabClearAll.Size = new System.Drawing.Size(53, 12);
            this.llabClearAll.TabIndex = 2;
            this.llabClearAll.TabStop = true;
            this.llabClearAll.Text = "ClearAll";
            this.llabClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabClearAll_LinkClicked);
            // 
            // chkNoneAdd
            // 
            this.chkNoneAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNoneAdd.AutoSize = true;
            this.chkNoneAdd.Location = new System.Drawing.Point(56, 458);
            this.chkNoneAdd.Name = "chkNoneAdd";
            this.chkNoneAdd.Size = new System.Drawing.Size(84, 16);
            this.chkNoneAdd.TabIndex = 3;
            this.chkNoneAdd.Text = "不存在添加";
            this.chkNoneAdd.UseVisualStyleBackColor = true;
            // 
            // labHave
            // 
            this.labHave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labHave.AutoSize = true;
            this.labHave.Location = new System.Drawing.Point(545, 459);
            this.labHave.Name = "labHave";
            this.labHave.Size = new System.Drawing.Size(17, 12);
            this.labHave.TabIndex = 4;
            this.labHave.Text = "无";
            // 
            // llabAddNoneLine
            // 
            this.llabAddNoneLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llabAddNoneLine.AutoSize = true;
            this.llabAddNoneLine.Location = new System.Drawing.Point(450, 459);
            this.llabAddNoneLine.Name = "llabAddNoneLine";
            this.llabAddNoneLine.Size = new System.Drawing.Size(89, 12);
            this.llabAddNoneLine.TabIndex = 5;
            this.llabAddNoneLine.TabStop = true;
            this.llabAddNoneLine.Text = "添加不存在的行";
            this.llabAddNoneLine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabAddNoneLine_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "正则表达式：";
            // 
            // txtRegex
            // 
            this.txtRegex.Location = new System.Drawing.Point(83, 6);
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(188, 21);
            this.txtRegex.TabIndex = 12;
            this.txtRegex.Text = "[BCDFGHJKMPQRTVWXY2346789]{5}-[BCDFGHJKMPQRTVWXY2346789]{5}-[BCDFGHJKMPQRTVWXY234" +
                "6789]{5}-[BCDFGHJKMPQRTVWXY2346789]{5}-[BCDFGHJKMPQRTVWXY2346789]{5}";
            // 
            // llabClearRegex
            // 
            this.llabClearRegex.AutoSize = true;
            this.llabClearRegex.Location = new System.Drawing.Point(277, 9);
            this.llabClearRegex.Name = "llabClearRegex";
            this.llabClearRegex.Size = new System.Drawing.Size(35, 12);
            this.llabClearRegex.TabIndex = 13;
            this.llabClearRegex.TabStop = true;
            this.llabClearRegex.Text = "Clear";
            this.llabClearRegex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabClearRegex_LinkClicked);
            // 
            // chkRegex
            // 
            this.chkRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRegex.AutoSize = true;
            this.chkRegex.Location = new System.Drawing.Point(146, 458);
            this.chkRegex.Name = "chkRegex";
            this.chkRegex.Size = new System.Drawing.Size(72, 16);
            this.chkRegex.TabIndex = 14;
            this.chkRegex.Text = "匹配正则";
            this.chkRegex.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 480);
            this.Controls.Add(this.chkRegex);
            this.Controls.Add(this.llabClearRegex);
            this.Controls.Add(this.txtRegex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llabAddNoneLine);
            this.Controls.Add(this.labHave);
            this.Controls.Add(this.chkNoneAdd);
            this.Controls.Add(this.llabClearAll);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "ClipboardViewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.LinkLabel llabClearAll;
        private System.Windows.Forms.CheckBox chkNoneAdd;
        private System.Windows.Forms.Label labHave;
        private System.Windows.Forms.LinkLabel llabAddNoneLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.LinkLabel llabClearRegex;
        private System.Windows.Forms.CheckBox chkRegex;
    }
}

