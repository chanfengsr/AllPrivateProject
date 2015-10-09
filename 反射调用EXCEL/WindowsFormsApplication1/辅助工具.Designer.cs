namespace WindowsFormsApplication1
{
    partial class 辅助工具
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(辅助工具));
            this.找出所有的枚举 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.找出属性 = new System.Windows.Forms.Button();
            this.属性代码生成 = new System.Windows.Forms.Button();
            this.找出枚举名称 = new System.Windows.Forms.Button();
            this.方法代码生成 = new System.Windows.Forms.Button();
            this.修正注释标签 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.复制到网格 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // 找出所有的枚举
            // 
            this.找出所有的枚举.Location = new System.Drawing.Point(12, 40);
            this.找出所有的枚举.Name = "找出所有的枚举";
            this.找出所有的枚举.Size = new System.Drawing.Size(105, 23);
            this.找出所有的枚举.TabIndex = 0;
            this.找出所有的枚举.Text = "找出所有的枚举";
            this.找出所有的枚举.UseVisualStyleBackColor = true;
            this.找出所有的枚举.Click += new System.EventHandler(this.找出所有的枚举_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(870, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "_objNames";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.MaxLength = 0;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(411, 372);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            this.textBox2.WordWrap = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 603);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(870, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 69);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox3);
            this.splitContainer1.Size = new System.Drawing.Size(870, 372);
            this.splitContainer1.SplitterDistance = 411;
            this.splitContainer1.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.MaxLength = 0;
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(455, 372);
            this.textBox3.TabIndex = 0;
            this.textBox3.WordWrap = false;
            // 
            // 找出属性
            // 
            this.找出属性.Location = new System.Drawing.Point(205, 40);
            this.找出属性.Name = "找出属性";
            this.找出属性.Size = new System.Drawing.Size(75, 23);
            this.找出属性.TabIndex = 4;
            this.找出属性.Text = "找出属性";
            this.找出属性.UseVisualStyleBackColor = true;
            this.找出属性.Click += new System.EventHandler(this.找出属性_Click);
            // 
            // 属性代码生成
            // 
            this.属性代码生成.Location = new System.Drawing.Point(459, 40);
            this.属性代码生成.Name = "属性代码生成";
            this.属性代码生成.Size = new System.Drawing.Size(87, 23);
            this.属性代码生成.TabIndex = 5;
            this.属性代码生成.Text = "属性代码生成";
            this.属性代码生成.UseVisualStyleBackColor = true;
            this.属性代码生成.Click += new System.EventHandler(this.属性代码生成_Click);
            // 
            // 找出枚举名称
            // 
            this.找出枚举名称.Location = new System.Drawing.Point(123, 40);
            this.找出枚举名称.Name = "找出枚举名称";
            this.找出枚举名称.Size = new System.Drawing.Size(75, 23);
            this.找出枚举名称.TabIndex = 6;
            this.找出枚举名称.Text = "找出枚举名称";
            this.找出枚举名称.UseVisualStyleBackColor = true;
            this.找出枚举名称.Click += new System.EventHandler(this.找出枚举名称_Click);
            // 
            // 方法代码生成
            // 
            this.方法代码生成.Location = new System.Drawing.Point(552, 40);
            this.方法代码生成.Name = "方法代码生成";
            this.方法代码生成.Size = new System.Drawing.Size(87, 23);
            this.方法代码生成.TabIndex = 7;
            this.方法代码生成.Text = "方法代码生成";
            this.方法代码生成.UseVisualStyleBackColor = true;
            this.方法代码生成.Click += new System.EventHandler(this.方法代码生成_Click);
            // 
            // 修正注释标签
            // 
            this.修正注释标签.Location = new System.Drawing.Point(286, 40);
            this.修正注释标签.Name = "修正注释标签";
            this.修正注释标签.Size = new System.Drawing.Size(86, 23);
            this.修正注释标签.TabIndex = 8;
            this.修正注释标签.Text = "修正注释标签";
            this.修正注释标签.UseVisualStyleBackColor = true;
            this.修正注释标签.Click += new System.EventHandler(this.修正注释标签_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dataGridView1.Location = new System.Drawing.Point(12, 447);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(870, 150);
            this.dataGridView1.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Column9";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Column10";
            this.Column10.Name = "Column10";
            // 
            // 复制到网格
            // 
            this.复制到网格.Location = new System.Drawing.Point(378, 40);
            this.复制到网格.Name = "复制到网格";
            this.复制到网格.Size = new System.Drawing.Size(75, 23);
            this.复制到网格.TabIndex = 10;
            this.复制到网格.Text = "复制到网格";
            this.复制到网格.UseVisualStyleBackColor = true;
            this.复制到网格.Click += new System.EventHandler(this.复制到网格_Click);
            // 
            // 辅助工具
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 638);
            this.Controls.Add(this.复制到网格);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.修正注释标签);
            this.Controls.Add(this.方法代码生成);
            this.Controls.Add(this.找出枚举名称);
            this.Controls.Add(this.属性代码生成);
            this.Controls.Add(this.找出属性);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.找出所有的枚举);
            this.Name = "辅助工具";
            this.Text = "辅助工具";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button 找出所有的枚举;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button 找出属性;
        private System.Windows.Forms.Button 属性代码生成;
        private System.Windows.Forms.Button 找出枚举名称;
        private System.Windows.Forms.Button 方法代码生成;
        private System.Windows.Forms.Button 修正注释标签;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button 复制到网格;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}