namespace TestDragDrop
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
            this.ListDragSource = new System.Windows.Forms.ListBox();
            this.ListDragTarget = new System.Windows.Forms.ListBox();
            this.UseCustomCursorsCheck = new System.Windows.Forms.CheckBox();
            this.DropLocationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ListDragSource
            // 
            this.ListDragSource.FormattingEnabled = true;
            this.ListDragSource.ItemHeight = 12;
            this.ListDragSource.Items.AddRange(new object[] {
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten"});
            this.ListDragSource.Location = new System.Drawing.Point(9, 12);
            this.ListDragSource.Name = "ListDragSource";
            this.ListDragSource.Size = new System.Drawing.Size(279, 268);
            this.ListDragSource.TabIndex = 0;
            this.ListDragSource.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.ListDragSource_GiveFeedback);
            this.ListDragSource.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.ListDragSource_QueryContinueDrag);
            this.ListDragSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListDragSource_MouseDown);
            this.ListDragSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListDragSource_MouseMove);
            this.ListDragSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListDragSource_MouseUp);
            // 
            // ListDragTarget
            // 
            this.ListDragTarget.AllowDrop = true;
            this.ListDragTarget.FormattingEnabled = true;
            this.ListDragTarget.ItemHeight = 12;
            this.ListDragTarget.Location = new System.Drawing.Point(317, 12);
            this.ListDragTarget.Name = "ListDragTarget";
            this.ListDragTarget.Size = new System.Drawing.Size(279, 268);
            this.ListDragTarget.TabIndex = 0;
            this.ListDragTarget.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListDragTarget_DragDrop);
            this.ListDragTarget.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListDragTarget_DragEnter);
            this.ListDragTarget.DragOver += new System.Windows.Forms.DragEventHandler(this.ListDragTarget_DragOver);
            this.ListDragTarget.DragLeave += new System.EventHandler(this.ListDragTarget_DragLeave);
            // 
            // UseCustomCursorsCheck
            // 
            this.UseCustomCursorsCheck.AutoSize = true;
            this.UseCustomCursorsCheck.Location = new System.Drawing.Point(9, 296);
            this.UseCustomCursorsCheck.Name = "UseCustomCursorsCheck";
            this.UseCustomCursorsCheck.Size = new System.Drawing.Size(132, 16);
            this.UseCustomCursorsCheck.TabIndex = 1;
            this.UseCustomCursorsCheck.Text = "Use Custom Cursors";
            this.UseCustomCursorsCheck.UseVisualStyleBackColor = true;
            // 
            // DropLocationLabel
            // 
            this.DropLocationLabel.AutoSize = true;
            this.DropLocationLabel.Location = new System.Drawing.Point(13, 319);
            this.DropLocationLabel.Name = "DropLocationLabel";
            this.DropLocationLabel.Size = new System.Drawing.Size(29, 12);
            this.DropLocationLabel.TabIndex = 2;
            this.DropLocationLabel.Text = "None";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "→";
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(9, 345);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(587, 172);
            this.listBox1.TabIndex = 4;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 534);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DropLocationLabel);
            this.Controls.Add(this.UseCustomCursorsCheck);
            this.Controls.Add(this.ListDragTarget);
            this.Controls.Add(this.ListDragSource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListDragSource;
        private System.Windows.Forms.ListBox ListDragTarget;
        private System.Windows.Forms.CheckBox UseCustomCursorsCheck;
        private System.Windows.Forms.Label DropLocationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

