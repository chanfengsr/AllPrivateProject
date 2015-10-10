namespace CreateED2K {
    partial class frmCreateEd2k {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.bkDoProcess = new System.ComponentModel.BackgroundWorker();
            this.labTimeAll = new System.Windows.Forms.Label();
            this.labTimeHashAll = new System.Windows.Forms.Label();
            this.labTimeEd2kHash = new System.Windows.Forms.Label();
            this.labTimeAichHash = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labProcCount = new System.Windows.Forms.Label();
            this.btnClearSource = new System.Windows.Forms.Button();
            this.btnClearTarget = new System.Windows.Forms.Button();
            this.btnCalcRHashExe = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(382, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "btnTest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSource
            // 
            this.txtSource.AllowDrop = true;
            this.txtSource.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSource.Location = new System.Drawing.Point(0, 0);
            this.txtSource.MaxLength = 0;
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSource.Size = new System.Drawing.Size(376, 522);
            this.txtSource.TabIndex = 0;
            this.txtSource.WordWrap = false;
            this.txtSource.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtSource_DragDrop);
            this.txtSource.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtSource_DragEnter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(3, 66);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtTarget);
            this.splitContainer1.Size = new System.Drawing.Size(757, 524);
            this.splitContainer1.SplitterDistance = 378;
            this.splitContainer1.TabIndex = 5;
            // 
            // txtTarget
            // 
            this.txtTarget.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTarget.Location = new System.Drawing.Point(0, 0);
            this.txtTarget.MaxLength = 0;
            this.txtTarget.Multiline = true;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.ReadOnly = true;
            this.txtTarget.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTarget.Size = new System.Drawing.Size(373, 522);
            this.txtTarget.TabIndex = 0;
            this.txtTarget.WordWrap = false;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.ForeColor = System.Drawing.Color.Green;
            this.btnClear.Location = new System.Drawing.Point(199, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 27);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCalculate.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCalculate.Location = new System.Drawing.Point(11, 7);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(111, 27);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // bkDoProcess
            // 
            this.bkDoProcess.WorkerReportsProgress = true;
            this.bkDoProcess.WorkerSupportsCancellation = true;
            this.bkDoProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkDoProcess_DoWork);
            this.bkDoProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkDoProcess_ProgressChanged);
            this.bkDoProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkDoProcess_RunWorkerCompleted);
            // 
            // labTimeAll
            // 
            this.labTimeAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labTimeAll.AutoSize = true;
            this.labTimeAll.Location = new System.Drawing.Point(6, 596);
            this.labTimeAll.Name = "labTimeAll";
            this.labTimeAll.Size = new System.Drawing.Size(53, 12);
            this.labTimeAll.TabIndex = 10;
            this.labTimeAll.Text = "总耗时：";
            // 
            // labTimeHashAll
            // 
            this.labTimeHashAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labTimeHashAll.AutoSize = true;
            this.labTimeHashAll.Location = new System.Drawing.Point(187, 596);
            this.labTimeHashAll.Name = "labTimeHashAll";
            this.labTimeHashAll.Size = new System.Drawing.Size(77, 12);
            this.labTimeHashAll.TabIndex = 10;
            this.labTimeHashAll.Text = "总Hash耗时：";
            // 
            // labTimeEd2kHash
            // 
            this.labTimeEd2kHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labTimeEd2kHash.AutoSize = true;
            this.labTimeEd2kHash.Location = new System.Drawing.Point(380, 596);
            this.labTimeEd2kHash.Name = "labTimeEd2kHash";
            this.labTimeEd2kHash.Size = new System.Drawing.Size(65, 12);
            this.labTimeEd2kHash.TabIndex = 10;
            this.labTimeEd2kHash.Text = "ED2K耗时：";
            // 
            // labTimeAichHash
            // 
            this.labTimeAichHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labTimeAichHash.AutoSize = true;
            this.labTimeAichHash.Location = new System.Drawing.Point(573, 596);
            this.labTimeAichHash.Name = "labTimeAichHash";
            this.labTimeAichHash.Size = new System.Drawing.Size(65, 12);
            this.labTimeAichHash.TabIndex = 10;
            this.labTimeAichHash.Text = "AICH耗时：";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(128, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Canc&el";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labProcCount
            // 
            this.labProcCount.AutoSize = true;
            this.labProcCount.Location = new System.Drawing.Point(11, 46);
            this.labProcCount.Name = "labProcCount";
            this.labProcCount.Size = new System.Drawing.Size(41, 12);
            this.labProcCount.TabIndex = 11;
            this.labProcCount.Text = "label1";
            // 
            // btnClearSource
            // 
            this.btnClearSource.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearSource.ForeColor = System.Drawing.Color.Green;
            this.btnClearSource.Location = new System.Drawing.Point(199, 37);
            this.btnClearSource.Name = "btnClearSource";
            this.btnClearSource.Size = new System.Drawing.Size(31, 23);
            this.btnClearSource.TabIndex = 3;
            this.btnClearSource.Text = "C1";
            this.btnClearSource.UseVisualStyleBackColor = true;
            this.btnClearSource.Click += new System.EventHandler(this.btnClearSource_Click);
            // 
            // btnClearTarget
            // 
            this.btnClearTarget.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearTarget.ForeColor = System.Drawing.Color.Green;
            this.btnClearTarget.Location = new System.Drawing.Point(233, 37);
            this.btnClearTarget.Name = "btnClearTarget";
            this.btnClearTarget.Size = new System.Drawing.Size(31, 23);
            this.btnClearTarget.TabIndex = 4;
            this.btnClearTarget.Text = "C2";
            this.btnClearTarget.UseVisualStyleBackColor = true;
            this.btnClearTarget.Click += new System.EventHandler(this.btnClearTarget_Click);
            // 
            // btnCalcRHashExe
            // 
            this.btnCalcRHashExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcRHashExe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCalcRHashExe.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCalcRHashExe.Location = new System.Drawing.Point(629, 7);
            this.btnCalcRHashExe.Name = "btnCalcRHashExe";
            this.btnCalcRHashExe.Size = new System.Drawing.Size(122, 27);
            this.btnCalcRHashExe.TabIndex = 0;
            this.btnCalcRHashExe.Text = "Calc_RHashExe";
            this.btnCalcRHashExe.UseVisualStyleBackColor = true;
            this.btnCalcRHashExe.Click += new System.EventHandler(this.btnCalcRHashExe_Click);
            // 
            // frmCreateEd2k
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 613);
            this.Controls.Add(this.labProcCount);
            this.Controls.Add(this.labTimeAichHash);
            this.Controls.Add(this.labTimeEd2kHash);
            this.Controls.Add(this.labTimeHashAll);
            this.Controls.Add(this.labTimeAll);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClearTarget);
            this.Controls.Add(this.btnClearSource);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalcRHashExe);
            this.Controls.Add(this.btnCalculate);
            this.Name = "frmCreateEd2k";
            this.Text = "Create Ed2k";
            this.Load += new System.EventHandler(this.frmCreateEd2k_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCalculate;
        private System.ComponentModel.BackgroundWorker bkDoProcess;
        private System.Windows.Forms.Label labTimeAll;
        private System.Windows.Forms.Label labTimeHashAll;
        private System.Windows.Forms.Label labTimeEd2kHash;
        private System.Windows.Forms.Label labTimeAichHash;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labProcCount;
        private System.Windows.Forms.Button btnClearSource;
        private System.Windows.Forms.Button btnClearTarget;
        private System.Windows.Forms.Button btnCalcRHashExe;
    }
}