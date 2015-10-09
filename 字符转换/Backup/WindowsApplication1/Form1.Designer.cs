namespace WindowsApplication1
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtChs = new System.Windows.Forms.TextBox();
            this.txtEnUC = new System.Windows.Forms.TextBox();
            this.txtASCII = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(210, 261);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "转 换";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtChs
            // 
            this.txtChs.Location = new System.Drawing.Point(37, 12);
            this.txtChs.Multiline = true;
            this.txtChs.Name = "txtChs";
            this.txtChs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChs.Size = new System.Drawing.Size(466, 77);
            this.txtChs.TabIndex = 1;
            // 
            // txtEnUC
            // 
            this.txtEnUC.Location = new System.Drawing.Point(37, 95);
            this.txtEnUC.Multiline = true;
            this.txtEnUC.Name = "txtEnUC";
            this.txtEnUC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEnUC.Size = new System.Drawing.Size(466, 77);
            this.txtEnUC.TabIndex = 1;
            // 
            // txtASCII
            // 
            this.txtASCII.Location = new System.Drawing.Point(37, 178);
            this.txtASCII.Multiline = true;
            this.txtASCII.Name = "txtASCII";
            this.txtASCII.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtASCII.Size = new System.Drawing.Size(466, 77);
            this.txtASCII.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "原文";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "转换后";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 74);
            this.label3.TabIndex = 2;
            this.label3.Text = "ASCII";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 290);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtASCII);
            this.Controls.Add(this.txtEnUC);
            this.Controls.Add(this.txtChs);
            this.Controls.Add(this.btnConvert);
            this.Name = "Form1";
            this.Text = "字符转换     by 巉沨散人";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtChs;
        private System.Windows.Forms.TextBox txtEnUC;
        private System.Windows.Forms.TextBox txtASCII;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

