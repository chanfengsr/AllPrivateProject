namespace SmartTools
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.测试窗体TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获得框架CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能测试FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试存储过程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.测试生成代码执行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测试窗体TToolStripMenuItem,
            this.功能测试FToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 测试窗体TToolStripMenuItem
            // 
            this.测试窗体TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.获得框架CToolStripMenuItem});
            this.测试窗体TToolStripMenuItem.Name = "测试窗体TToolStripMenuItem";
            this.测试窗体TToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.测试窗体TToolStripMenuItem.Text = "测试窗体(&T)";
            // 
            // 获得框架CToolStripMenuItem
            // 
            this.获得框架CToolStripMenuItem.Name = "获得框架CToolStripMenuItem";
            this.获得框架CToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.获得框架CToolStripMenuItem.Text = "获得框架(&C)";
            this.获得框架CToolStripMenuItem.Click += new System.EventHandler(this.获得框架CToolStripMenuItem_Click);
            // 
            // 功能测试FToolStripMenuItem
            // 
            this.功能测试FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDataBaseToolStripMenuItem,
            this.测试存储过程ToolStripMenuItem,
            this.测试生成代码执行ToolStripMenuItem});
            this.功能测试FToolStripMenuItem.Name = "功能测试FToolStripMenuItem";
            this.功能测试FToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.功能测试FToolStripMenuItem.Text = "功能测试(&F)";
            // 
            // createDataBaseToolStripMenuItem
            // 
            this.createDataBaseToolStripMenuItem.Name = "createDataBaseToolStripMenuItem";
            this.createDataBaseToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.createDataBaseToolStripMenuItem.Text = "CreateDataBase";
            this.createDataBaseToolStripMenuItem.Click += new System.EventHandler(this.createDataBaseToolStripMenuItem_Click);
            // 
            // 测试存储过程ToolStripMenuItem
            // 
            this.测试存储过程ToolStripMenuItem.Name = "测试存储过程ToolStripMenuItem";
            this.测试存储过程ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.测试存储过程ToolStripMenuItem.Text = "测试存储过程";
            this.测试存储过程ToolStripMenuItem.Click += new System.EventHandler(this.测试存储过程ToolStripMenuItem_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel1.Location = new System.Drawing.Point(0, 24);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(696, 418);
            this.dockPanel1.TabIndex = 2;
            // 
            // 测试生成代码执行ToolStripMenuItem
            // 
            this.测试生成代码执行ToolStripMenuItem.Name = "测试生成代码执行ToolStripMenuItem";
            this.测试生成代码执行ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.测试生成代码执行ToolStripMenuItem.Text = "测试生成代码执行";
            this.测试生成代码执行ToolStripMenuItem.Click += new System.EventHandler(this.测试生成代码执行ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 442);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 测试窗体TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获得框架CToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem 功能测试FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试存储过程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试生成代码执行ToolStripMenuItem;

    }
}