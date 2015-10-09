namespace BackupDataBase
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
            this.btnBegin = new System.Windows.Forms.Button();
            this.grpMsg = new System.Windows.Forms.GroupBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkProfundityTactic = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkRestore = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveCfg = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRestoreDBName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chkDeleteBackupFile = new System.Windows.Forms.CheckBox();
            this.chkForceRestore = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRestoreServerPwd = new System.Windows.Forms.TextBox();
            this.txtRestoreServerUserID = new System.Windows.Forms.TextBox();
            this.txtAimRestoreServer = new System.Windows.Forms.TextBox();
            this.txtRestoreFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPasswordc = new System.Windows.Forms.TextBox();
            this.txtUserIDc = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtSharePath = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtAimServer = new System.Windows.Forms.TextBox();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.chkShrinkDBB = new System.Windows.Forms.CheckBox();
            this.chkShrinkDBA = new System.Windows.Forms.CheckBox();
            this.grpMsg.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(573, 272);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(106, 26);
            this.btnBegin.TabIndex = 17;
            this.btnBegin.Text = "开 始(&P)";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // grpMsg
            // 
            this.grpMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMsg.Controls.Add(this.txtMsg);
            this.grpMsg.Location = new System.Drawing.Point(5, 338);
            this.grpMsg.Margin = new System.Windows.Forms.Padding(8);
            this.grpMsg.Name = "grpMsg";
            this.grpMsg.Padding = new System.Windows.Forms.Padding(8);
            this.grpMsg.Size = new System.Drawing.Size(880, 202);
            this.grpMsg.TabIndex = 5;
            this.grpMsg.TabStop = false;
            this.grpMsg.Text = "运行结果";
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.Color.White;
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Location = new System.Drawing.Point(8, 22);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(864, 172);
            this.txtMsg.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkShrinkDBB);
            this.groupBox1.Controls.Add(this.chkProfundityTactic);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkRestore);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSaveCfg);
            this.groupBox1.Controls.Add(this.btnBegin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPasswordc);
            this.groupBox1.Controls.Add(this.txtUserIDc);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtSharePath);
            this.groupBox1.Controls.Add(this.txtUserID);
            this.groupBox1.Controls.Add(this.txtAimServer);
            this.groupBox1.Controls.Add(this.txtDataBase);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 316);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "备份数据库名";
            // 
            // chkProfundityTactic
            // 
            this.chkProfundityTactic.AutoSize = true;
            this.chkProfundityTactic.Location = new System.Drawing.Point(32, 20);
            this.chkProfundityTactic.Name = "chkProfundityTactic";
            this.chkProfundityTactic.Size = new System.Drawing.Size(120, 16);
            this.chkProfundityTactic.TabIndex = 0;
            this.chkProfundityTactic.Text = "使用深度安全策略";
            this.chkProfundityTactic.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(292, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "系统密码";
            // 
            // chkRestore
            // 
            this.chkRestore.AutoSize = true;
            this.chkRestore.Location = new System.Drawing.Point(34, 154);
            this.chkRestore.Name = "chkRestore";
            this.chkRestore.Size = new System.Drawing.Size(96, 16);
            this.chkRestore.TabIndex = 9;
            this.chkRestore.Text = "并恢复数据库";
            this.chkRestore.UseVisualStyleBackColor = true;
            this.chkRestore.CheckedChanged += new System.EventHandler(this.chkRestore_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "数据库登录密码";
            // 
            // btnSaveCfg
            // 
            this.btnSaveCfg.Location = new System.Drawing.Point(573, 240);
            this.btnSaveCfg.Name = "btnSaveCfg";
            this.btnSaveCfg.Size = new System.Drawing.Size(106, 26);
            this.btnSaveCfg.TabIndex = 16;
            this.btnSaveCfg.Text = "保存配置信息(&S)";
            this.btnSaveCfg.UseVisualStyleBackColor = true;
            this.btnSaveCfg.Click += new System.EventHandler(this.btnSaveCfg_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "共享目录名";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkShrinkDBA);
            this.groupBox2.Controls.Add(this.txtRestoreDBName);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.chkDeleteBackupFile);
            this.groupBox2.Controls.Add(this.chkForceRestore);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtRestoreServerPwd);
            this.groupBox2.Controls.Add(this.txtRestoreServerUserID);
            this.groupBox2.Controls.Add(this.txtAimRestoreServer);
            this.groupBox2.Controls.Add(this.txtRestoreFolder);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(6, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 156);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // txtRestoreDBName
            // 
            this.txtRestoreDBName.Location = new System.Drawing.Point(191, 102);
            this.txtRestoreDBName.Name = "txtRestoreDBName";
            this.txtRestoreDBName.Size = new System.Drawing.Size(134, 21);
            this.txtRestoreDBName.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 32;
            this.label14.Text = "数据库名";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(365, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 12);
            this.label13.TabIndex = 31;
            this.label13.Text = "（会影响其他程序的执行）";
            // 
            // chkDeleteBackupFile
            // 
            this.chkDeleteBackupFile.AutoSize = true;
            this.chkDeleteBackupFile.Location = new System.Drawing.Point(351, 79);
            this.chkDeleteBackupFile.Name = "chkDeleteBackupFile";
            this.chkDeleteBackupFile.Size = new System.Drawing.Size(144, 16);
            this.chkDeleteBackupFile.TabIndex = 11;
            this.chkDeleteBackupFile.Text = "恢复完后删除备份文件";
            this.chkDeleteBackupFile.UseVisualStyleBackColor = true;
            this.chkDeleteBackupFile.CheckedChanged += new System.EventHandler(this.chkRestore_CheckedChanged);
            // 
            // chkForceRestore
            // 
            this.chkForceRestore.AutoSize = true;
            this.chkForceRestore.Location = new System.Drawing.Point(351, 42);
            this.chkForceRestore.Name = "chkForceRestore";
            this.chkForceRestore.Size = new System.Drawing.Size(72, 16);
            this.chkForceRestore.TabIndex = 10;
            this.chkForceRestore.Text = "强制还原";
            this.chkForceRestore.UseVisualStyleBackColor = true;
            this.chkForceRestore.CheckedChanged += new System.EventHandler(this.chkRestore_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "服务器上存放数据文件的目录";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "数据库登录密码";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "数据库用户名";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "目标还原服务器";
            // 
            // txtRestoreServerPwd
            // 
            this.txtRestoreServerPwd.Location = new System.Drawing.Point(191, 74);
            this.txtRestoreServerPwd.Name = "txtRestoreServerPwd";
            this.txtRestoreServerPwd.PasswordChar = '*';
            this.txtRestoreServerPwd.Size = new System.Drawing.Size(134, 21);
            this.txtRestoreServerPwd.TabIndex = 14;
            // 
            // txtRestoreServerUserID
            // 
            this.txtRestoreServerUserID.Location = new System.Drawing.Point(191, 47);
            this.txtRestoreServerUserID.Name = "txtRestoreServerUserID";
            this.txtRestoreServerUserID.Size = new System.Drawing.Size(134, 21);
            this.txtRestoreServerUserID.TabIndex = 13;
            // 
            // txtAimRestoreServer
            // 
            this.txtAimRestoreServer.Location = new System.Drawing.Point(191, 20);
            this.txtAimRestoreServer.Name = "txtAimRestoreServer";
            this.txtAimRestoreServer.Size = new System.Drawing.Size(134, 21);
            this.txtAimRestoreServer.TabIndex = 12;
            // 
            // txtRestoreFolder
            // 
            this.txtRestoreFolder.Location = new System.Drawing.Point(190, 129);
            this.txtRestoreFolder.Name = "txtRestoreFolder";
            this.txtRestoreFolder.Size = new System.Drawing.Size(324, 21);
            this.txtRestoreFolder.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "要备份的数据库名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "系统用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "数据库用户名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "目标机器名/IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "服务器";
            // 
            // txtPasswordc
            // 
            this.txtPasswordc.Location = new System.Drawing.Point(381, 127);
            this.txtPasswordc.Name = "txtPasswordc";
            this.txtPasswordc.PasswordChar = '*';
            this.txtPasswordc.Size = new System.Drawing.Size(134, 21);
            this.txtPasswordc.TabIndex = 8;
            // 
            // txtUserIDc
            // 
            this.txtUserIDc.Location = new System.Drawing.Point(381, 100);
            this.txtUserIDc.Name = "txtUserIDc";
            this.txtUserIDc.Size = new System.Drawing.Size(134, 21);
            this.txtUserIDc.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(137, 127);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(134, 21);
            this.txtPassword.TabIndex = 4;
            // 
            // txtSharePath
            // 
            this.txtSharePath.Location = new System.Drawing.Point(381, 73);
            this.txtSharePath.Name = "txtSharePath";
            this.txtSharePath.Size = new System.Drawing.Size(134, 21);
            this.txtSharePath.TabIndex = 6;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(137, 100);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(134, 21);
            this.txtUserID.TabIndex = 3;
            // 
            // txtAimServer
            // 
            this.txtAimServer.Location = new System.Drawing.Point(381, 46);
            this.txtAimServer.Name = "txtAimServer";
            this.txtAimServer.Size = new System.Drawing.Size(134, 21);
            this.txtAimServer.TabIndex = 5;
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(137, 73);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(134, 21);
            this.txtDataBase.TabIndex = 2;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(137, 46);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(134, 21);
            this.txtServer.TabIndex = 1;
            // 
            // chkShrinkDBB
            // 
            this.chkShrinkDBB.AutoSize = true;
            this.chkShrinkDBB.Location = new System.Drawing.Point(158, 20);
            this.chkShrinkDBB.Name = "chkShrinkDBB";
            this.chkShrinkDBB.Size = new System.Drawing.Size(156, 16);
            this.chkShrinkDBB.TabIndex = 23;
            this.chkShrinkDBB.Text = "备份之前截断数据库日志";
            this.chkShrinkDBB.UseVisualStyleBackColor = true;
            // 
            // chkShrinkDBA
            // 
            this.chkShrinkDBA.AutoSize = true;
            this.chkShrinkDBA.Location = new System.Drawing.Point(351, 19);
            this.chkShrinkDBA.Name = "chkShrinkDBA";
            this.chkShrinkDBA.Size = new System.Drawing.Size(144, 16);
            this.chkShrinkDBA.TabIndex = 23;
            this.chkShrinkDBA.Text = "恢复后截断数据库日志";
            this.chkShrinkDBA.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 544);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpMsg);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "数据库远程备份——By 巉沨散人";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpMsg.ResumeLayout(false);
            this.grpMsg.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.GroupBox grpMsg;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPasswordc;
        private System.Windows.Forms.TextBox txtUserIDc;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtSharePath;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtAimServer;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkRestore;
        private System.Windows.Forms.TextBox txtRestoreFolder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRestoreServerPwd;
        private System.Windows.Forms.TextBox txtRestoreServerUserID;
        private System.Windows.Forms.TextBox txtAimRestoreServer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkDeleteBackupFile;
        private System.Windows.Forms.CheckBox chkForceRestore;
        private System.Windows.Forms.Button btnSaveCfg;
        private System.Windows.Forms.CheckBox chkProfundityTactic;
        private System.Windows.Forms.TextBox txtRestoreDBName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkShrinkDBB;
        private System.Windows.Forms.CheckBox chkShrinkDBA;
    }
}

