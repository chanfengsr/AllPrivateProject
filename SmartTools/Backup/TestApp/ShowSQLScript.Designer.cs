namespace SmartTools
{
    partial class ShowSQLScript
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowSQLScript));
            this.txteCode = new ICSharpCode.TextEditor.TextEditorControl();
            this.SuspendLayout();
            // 
            // txteCode
            // 
            this.txteCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txteCode.Encoding = ((System.Text.Encoding)(resources.GetObject("txteCode.Encoding")));
            this.txteCode.Location = new System.Drawing.Point(0, 0);
            this.txteCode.Name = "txteCode";
            this.txteCode.ShowEOLMarkers = true;
            this.txteCode.ShowInvalidLines = false;
            this.txteCode.ShowSpaces = true;
            this.txteCode.ShowTabs = true;
            this.txteCode.ShowVRuler = true;
            this.txteCode.Size = new System.Drawing.Size(292, 266);
            this.txteCode.TabIndex = 0;
            // 
            // ShowSQLScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.txteCode);
            this.Name = "ShowSQLScript";
            this.Text = "ShowSQLScript";
            this.Load += new System.EventHandler(this.ShowSQLScript_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl txteCode;
    }
}