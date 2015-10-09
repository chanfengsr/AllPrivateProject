namespace 键盘发送
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
            this.btnSendKeys = new System.Windows.Forms.Button();
            this.txtSendValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudCycles = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCycles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendKeys
            // 
            this.btnSendKeys.Location = new System.Drawing.Point(83, 92);
            this.btnSendKeys.Name = "btnSendKeys";
            this.btnSendKeys.Size = new System.Drawing.Size(75, 23);
            this.btnSendKeys.TabIndex = 1;
            this.btnSendKeys.Text = "开始";
            this.btnSendKeys.UseVisualStyleBackColor = true;
            this.btnSendKeys.Click += new System.EventHandler(this.btnSendKeys_Click);
            // 
            // txtSendValue
            // 
            this.txtSendValue.Location = new System.Drawing.Point(83, 23);
            this.txtSendValue.Name = "txtSendValue";
            this.txtSendValue.Size = new System.Drawing.Size(255, 21);
            this.txtSendValue.TabIndex = 2;
            this.txtSendValue.Text = "{TAB}{TAB} ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "发送值";
            // 
            // nudCycles
            // 
            this.nudCycles.Location = new System.Drawing.Point(83, 54);
            this.nudCycles.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCycles.Name = "nudCycles";
            this.nudCycles.Size = new System.Drawing.Size(75, 21);
            this.nudCycles.TabIndex = 4;
            this.nudCycles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "循环次数";
            // 
            // nudDelay
            // 
            this.nudDelay.DecimalPlaces = 2;
            this.nudDelay.Location = new System.Drawing.Point(268, 54);
            this.nudDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(70, 21);
            this.nudDelay.TabIndex = 4;
            this.nudDelay.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "循环延时（秒）";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 130);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudDelay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudCycles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSendValue);
            this.Controls.Add(this.btnSendKeys);
            this.Name = "Form1";
            this.Text = "键盘发送";
            ((System.ComponentModel.ISupportInitialize)(this.nudCycles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendKeys;
        private System.Windows.Forms.TextBox txtSendValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudCycles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.Label label3;
    }
}

