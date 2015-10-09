using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlTypes;
using SD = System.Data;              // general DB classes
using SDC = System.Data.SqlClient;   // Microsoft SQL Server databases

namespace BackupDataBase
{
    public partial class Form1 : Form
    {
        bool blnIsAutoRun = false;
        string strBackupFile;//Ŀ�걸���ļ���������������

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string[] args)
        {
            InitializeComponent();

            foreach (string strarg in args)
            {
                if (strarg.ToLower() == "/auto")
                {
                    blnIsAutoRun = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDefaultValue();

            if (blnIsAutoRun)
            {
                btnBegin.PerformClick();
            }
        }

        private void LoadDefaultValue()
        {
            this.Text = this.Text + " (V " + Application.ProductVersion + ")";

            //������һ�ε�����
            BackupDataBase.Properties.Settings thisSet = new BackupDataBase.Properties.Settings();

            chkProfundityTactic.Checked = thisSet.ProfundityTactic;
            chkRestore.Checked = thisSet.RestoreDB;
            chkShrinkDBB.Checked = thisSet.ShrinkDBBefore;

            txtServer.Text = thisSet.Server;
            txtDataBase.Text = thisSet.DataBase;
            txtUserID.Text = thisSet.UserID;
            if (thisSet.Password == "")
            {
                txtPassword.Text = "";
            }
            else
            {
                txtPassword.Text = se.ThreeDESDecrypt(thisSet.Password, "WangYu", "chanfengsr");
            }

            txtAimServer.Text = thisSet.AimServer;
            txtSharePath.Text = thisSet.SharPath;
            txtUserIDc.Text = thisSet.UserIDc;
            if (thisSet.Passwordc == "")
            {
                txtPasswordc.Text = "";
            }
            else
            {
                txtPasswordc.Text = se.ThreeDESDecrypt(thisSet.Passwordc, "WangYu", "chanfengsr");
            }

            chkShrinkDBA.Checked = thisSet.ShrinkDBAfter;
            chkForceRestore.Checked = thisSet.ForceRestore;
            chkDeleteBackupFile.Checked = thisSet.DeleteBackupFile;
            txtAimRestoreServer.Text = thisSet.AimRestoreServer;
            txtRestoreServerUserID.Text = thisSet.RestoreServerUserID;
            txtRestoreDBName.Text = thisSet.RestoreDBName;
            txtRestoreFolder.Text = thisSet.RestoreFolder;
            if (thisSet.RestoreServerPwd == "")
            {
                txtRestoreServerPwd.Text = "";
            }
            else
            {
                txtRestoreServerPwd.Text = se.ThreeDESDecrypt(thisSet.RestoreServerPwd, "WangYu", "chanfengsr");
            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            try
            {
                btnBegin.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                strBackupFile = "";

                if (chkConfig() == true)
                {
                    //�������ݿ�����
                    SetConnectString(txtServer.Text.Trim(), txtDataBase.Text.Trim(), txtUserID.Text.Trim(), txtPassword.Text.Trim());

                    //�õ�Ŀ�����������
                    string strAimServer;
                    string strSharePath;
                    string strUserIDc;
                    string strPwdc;

                    strAimServer = txtAimServer.Text.Trim();
                    strSharePath = txtSharePath.Text.Trim();
                    strUserIDc = txtUserIDc.Text.Trim();
                    strPwdc = txtPasswordc.Text.Trim();

                    if (BackupDataBase(ConnectionString, txtDataBase.Text.Trim(), strAimServer, strSharePath, strUserIDc, strPwdc, chkProfundityTactic.Checked) == true)
                    {
                        txtMsg.Text = txtMsg.Text + "���ݳɹ���" + Environment.NewLine;
                        Application.DoEvents();
                    }
                    else
                    {
                        txtMsg.Text = txtMsg.Text + "����ʧ�ܣ�" + Environment.NewLine;
                        Application.DoEvents();
                    }

                    if (chkRestore.Checked)
                    {
                        if (RestoreDataBase() == true)
                        {
                            txtMsg.Text = txtMsg.Text + "��ԭ���ݿ�ɹ���" + Environment.NewLine;
                            Application.DoEvents();
                        }
                        else
                        {
                            txtMsg.Text = txtMsg.Text + "��ԭ���ݿ�ʧ�ܣ����ȼ��������ü�Ȩ�ޣ�" + Environment.NewLine;
                            Application.DoEvents();
                        }
                    }

                }

                this.Cursor = Cursors.Default;
                btnBegin.Enabled = true;
            }
            catch (Exception ex)
            {
                txtMsg.Text = txtMsg.Text + ex.ToString() + Environment.NewLine;
                this.Cursor = Cursors.Default;
                btnBegin.Enabled = true;
            }
        }

        /// <summary>
        /// ����������������
        /// </summary>
        /// <returns></returns>
        private bool chkConfig()
        {
            if (txtServer.Text.Trim() == "" || txtDataBase.Text.Trim() == "" || txtUserID.Text.Trim() == "" ||
               txtAimServer.Text.Trim() == "" || txtSharePath.Text.Trim() == "" || txtUserIDc.Text.Trim() == "" ||
               txtAimRestoreServer.Text.Trim() == "" || txtRestoreServerUserID.Text.Trim() == "" ||
               txtRestoreServerPwd.Text.Trim() == "" || txtRestoreFolder.Text.Trim() == "" || txtRestoreDBName.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <param name="ConnectStr">�����ַ���</param>
        /// <param name="DataBase">Ҫ���ݵ����ݿ�</param>
        /// <param name="AimServer">Ŀ�����</param>
        /// <param name="SharePath">Ŀ������ϵĹ���Ŀ¼</param>
        /// <param name="UserIDc">Ŀ������ϵ��û���</param>
        /// <param name="Pwdc">Ŀ������ϵ�����</param>
        /// <param name="UseProfundityTactic">�Ƿ�ʹ����Ȱ�ȫ����</param>
        /// <returns></returns>
        private bool BackupDataBase(string ConnectStr, string DataBase, string AimServer, string SharePath, string UserIDc, string Pwdc, bool UseProfundityTactic)
        {
            string strSQL;
            SD.DataTable dt = new DataTable();
            dateTime = DateTime.Now;

            strBackupFile = "\\\\" + AimServer + "\\" + SharePath + "\\Data_" + dateTime.ToString("yyyyMMdd_HHmmss") + ".bak";

            txtMsg.Text = txtMsg.Text + "���ڱ������ݿ�..." + Environment.NewLine;
            Application.DoEvents();

            try
            {
                if (UseProfundityTactic)
                {
                    DropProfiler(ConnectStr);
                }

                //����ӳ��
                strSQL = "EXEC master..xp_cmdshell 'net use \\\\" + AimServer + "\\" + SharePath + " " + Pwdc + " " + "/user:" + AimServer + "\\" + UserIDc + "' --password";
                dt = GetData(ConnectStr, strSQL, "output", false);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtMsg.Text = txtMsg.Text + dt.Rows[i][0].ToString() + Environment.NewLine;
                    Application.DoEvents();
                }

                //***********************
                //�������ݿ�
                //***********************
                strSQL = "BACKUP DATABASE [" + DataBase + "] TO DISK = '" + strBackupFile + "'" + Environment.NewLine +
                         " WITH NOINIT,NOUNLOAD,NAME =  N'����',NOSKIP,STATS = 10,NOFORMAT --password";
                dt = GetData(ConnectStr, strSQL, "output", false);
                Application.DoEvents();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtMsg.Text = txtMsg.Text + dt.Rows[i][0].ToString() + Environment.NewLine;
                }

                return true;
            }
            catch (Exception ex)
            {
                txtMsg.Text = txtMsg.Text + ex.ToString() + Environment.NewLine;

                return false;
            }
            finally
            {
                //ɾ��ӳ��
                strSQL = "EXEC master..xp_cmdshell 'net use \\\\" + AimServer + "\\" + SharePath + " /delete /y' --password";

                try
                {
                    ExecuteNonQuery(ConnectStr, strSQL);
                }
                catch (Exception)
                { }
            }

        }

        private bool DropProfiler(string ConnectStr)
        {
            string strSQL;

            try
            {
                strSQL = "Declare @TID integer" + Environment.NewLine
                       + "Declare Trac Cursor For Select Distinct Traceid From :: fn_trace_getinfo(Default)" + Environment.NewLine
                       + "Open Trac Fetch Next From Trac into @TID" + Environment.NewLine
                       + "WHILE @@fetch_status=0" + Environment.NewLine
                       + "BEGIN" + Environment.NewLine
                       + "EXEC sp_trace_setstatus @TID, 0" + Environment.NewLine
                       + "EXEC sp_trace_setstatus @TID, 2" + Environment.NewLine
                       + "Fetch Next From Trac Into @TID" + Environment.NewLine
                       + "END" + Environment.NewLine
                       + "Close Trac" + Environment.NewLine
                       + "Deallocate Trac--password";

                ExecuteNonQuery(ConnectStr, strSQL);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// ��ԭ���ݿ�
        /// </summary>
        /// <returns></returns>
        private bool RestoreDataBase()
        {
            if (strBackupFile.Trim() != "")
            {
                string strSQL;
                SD.DataTable dt = new DataTable();

                //�������ݿ�����
                SetConnectString(txtAimRestoreServer.Text.Trim(), "Master", txtRestoreServerUserID.Text.Trim(), txtRestoreServerPwd.Text.Trim());

                txtMsg.Text = txtMsg.Text + "���ڻ�ԭ���ݿ�..." + Environment.NewLine;
                Application.DoEvents();

                try
                {
                    if (chkProfundityTactic.Checked)
                    {
                        DropProfiler(ConnectionString);
                    }

                    if (chkForceRestore.Checked)
                    {
                        strSQL = "Declare @SPID smallint" + Environment.NewLine
                               + "Declare @temp varchar(100)" + Environment.NewLine
                               + "Declare Trac Cursor For Select spid From master..sysprocesses Where dbid=db_id('" + txtDataBase.Text.Trim() + "')" + Environment.NewLine
                               + "Open Trac Fetch Next From Trac into @SPID" + Environment.NewLine
                               + "WHILE @@fetch_status=0" + Environment.NewLine
                               + "BEGIN" + Environment.NewLine
                               + "Set @temp='Kill ' + rtrim(@SPID)" + Environment.NewLine
                               + "Exec ( @temp )" + Environment.NewLine
                               + "Fetch Next From Trac Into @SPID" + Environment.NewLine
                               + "END" + Environment.NewLine
                               + "Close Trac" + Environment.NewLine
                               + "Deallocate Trac--password";

                        ExecuteNonQuery(ConnectionString, strSQL);
                        Application.DoEvents();
                    }

                    //����ӳ��
                    strSQL = "EXEC master..xp_cmdshell 'net use \\\\" + txtAimServer.Text.Trim() + "\\" + txtSharePath.Text.Trim() + " " + txtPasswordc.Text.Trim() + " " + "/user:" + txtAimServer.Text.Trim() + "\\" + txtUserIDc.Text.Trim() + "' --password";
                    dt = GetData(ConnectionString, strSQL, "output", false);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        txtMsg.Text = txtMsg.Text + dt.Rows[i][0].ToString() + Environment.NewLine;
                        Application.DoEvents();
                    }

                    //***********************
                    //��ԭ���ݿ�
                    //***********************
                    string strOrigDBName, strDBName, strMDFFile, strLDFFile;
                    strOrigDBName = txtDataBase.Text.Trim();
                    strDBName = txtRestoreDBName.Text.Trim();
                    strMDFFile = txtRestoreFolder.Text.Trim() + "\\" + strDBName + "_Data.mdf";
                    strLDFFile = txtRestoreFolder.Text.Trim() + "\\" + strDBName + "_Log.ldf";
                    strMDFFile = strMDFFile.Replace("\\\\", "\\");
                    strLDFFile = strLDFFile.Replace("\\\\", "\\");

                    strSQL = "RESTORE DATABASE [" + strDBName + "] FROM  DISK = N'" + strBackupFile
                           + "' WITH FILE = 1, NOUNLOAD, STATS = 10, RECOVERY, REPLACE, MOVE N'" + strOrigDBName
                           + "' TO N'" + strMDFFile + "', MOVE N'" + strOrigDBName + "_log' TO N'" + strLDFFile + "'--password";
                    dt = GetData(ConnectionString, strSQL, "output", false);
                    Application.DoEvents();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        txtMsg.Text = txtMsg.Text + dt.Rows[i][0].ToString() + Environment.NewLine;
                    }

                    if (chkDeleteBackupFile.Checked)
                    {
                        strSQL = "EXEC master..xp_cmdshell 'del " + strBackupFile + "' --password";

                        try
                        {
                            ExecuteNonQuery(ConnectionString, strSQL);
                        }
                        catch (Exception)
                        { }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    txtMsg.Text = txtMsg.Text + ex.ToString() + Environment.NewLine;

                    return false;
                }
                finally
                {
                    //ɾ��ӳ��
                    strSQL = "EXEC master..xp_cmdshell 'net use \\\\" + txtAimServer.Text.Trim() + "\\" + txtSharePath.Text.Trim() + " /delete /y' --password";

                    try
                    {
                        ExecuteNonQuery(ConnectionString, strSQL);
                    }
                    catch (Exception)
                    { }
                }
            }
            else
            {
                return false;
            }
        }

        private void SaveConfig()
        {
            BackupDataBase.Properties.Settings thisSet = new BackupDataBase.Properties.Settings();

            thisSet.ProfundityTactic = chkProfundityTactic.Checked;
            thisSet.ShrinkDBBefore = chkShrinkDBB.Checked;
            thisSet.RestoreDB = chkRestore.Checked;

            thisSet.Server = txtServer.Text;
            thisSet.DataBase = txtDataBase.Text;
            thisSet.UserID = txtUserID.Text;
            if (txtPassword.Text.Trim() == "")
            {
                thisSet.Password = txtPassword.Text;
            }
            else
            {
                thisSet.Password = se.ThreeDESEncrypt(txtPassword.Text, "WangYu", "chanfengsr");
            }

            thisSet.AimServer = txtAimServer.Text;
            thisSet.SharPath = txtSharePath.Text;
            thisSet.UserIDc = txtUserIDc.Text;
            if (txtPasswordc.Text == "")
            {
                thisSet.Passwordc = txtPasswordc.Text;
            }
            else
            {
                thisSet.Passwordc = se.ThreeDESEncrypt(txtPasswordc.Text, "WangYu", "chanfengsr");
            }

            thisSet.ShrinkDBAfter = chkShrinkDBA.Checked;
            thisSet.ForceRestore = chkForceRestore.Checked;
            thisSet.DeleteBackupFile = chkDeleteBackupFile.Checked;
            thisSet.AimRestoreServer = txtAimRestoreServer.Text;
            thisSet.RestoreServerUserID = txtRestoreServerUserID.Text;
            thisSet.RestoreDBName = txtRestoreDBName.Text;
            thisSet.RestoreFolder = txtRestoreFolder.Text;
            if (txtRestoreServerPwd.Text == "")
            {
                thisSet.RestoreServerPwd = "";
            }
            else
            {
                thisSet.RestoreServerPwd = se.ThreeDESEncrypt(txtRestoreServerPwd.Text, "WangYu", "chanfengsr");
            }

            thisSet.Save();
        }

        private void chkRestore_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestore.Checked == true)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void btnSaveCfg_Click(object sender, EventArgs e)
        {
            SaveConfig();
            txtMsg.Text = txtMsg.Text + "������ɣ�" + Environment.NewLine;
        }
    }
}