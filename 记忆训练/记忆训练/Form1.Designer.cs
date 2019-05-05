namespace 记忆训练
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
            this.btnRandNum = new System.Windows.Forms.Button();
            this.labRandNum = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInfoPic = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRandNum
            // 
            this.btnRandNum.Location = new System.Drawing.Point(13, 13);
            this.btnRandNum.Name = "btnRandNum";
            this.btnRandNum.Size = new System.Drawing.Size(75, 23);
            this.btnRandNum.TabIndex = 0;
            this.btnRandNum.Text = "随机数字";
            this.btnRandNum.UseVisualStyleBackColor = true;
            this.btnRandNum.Click += new System.EventHandler(this.btnRandNum_Click);
            // 
            // labRandNum
            // 
            this.labRandNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labRandNum.Font = new System.Drawing.Font("宋体", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRandNum.Location = new System.Drawing.Point(3, 17);
            this.labRandNum.Name = "labRandNum";
            this.labRandNum.Size = new System.Drawing.Size(535, 343);
            this.labRandNum.TabIndex = 1;
            this.labRandNum.Text = "0";
            this.labRandNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labRandNum);
            this.groupBox1.Location = new System.Drawing.Point(13, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 363);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnInfoPic
            // 
            this.btnInfoPic.Location = new System.Drawing.Point(94, 12);
            this.btnInfoPic.Name = "btnInfoPic";
            this.btnInfoPic.Size = new System.Drawing.Size(75, 23);
            this.btnInfoPic.TabIndex = 3;
            this.btnInfoPic.TabStop = false;
            this.btnInfoPic.Text = "提示图 &P";
            this.btnInfoPic.UseVisualStyleBackColor = true;
            this.btnInfoPic.Click += new System.EventHandler(this.btnInfoPic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 435);
            this.Controls.Add(this.btnInfoPic);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRandNum);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "记忆训练";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRandNum;
        private System.Windows.Forms.Label labRandNum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInfoPic;
    }
}

