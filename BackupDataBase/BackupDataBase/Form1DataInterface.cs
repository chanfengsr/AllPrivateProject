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
    partial class Form1
    {
        #region   ���幹�캯������������

        protected System.DateTime dateTime = new DateTime();

        SecurityHash se = new SecurityHash(true, false);

        //private SD.DataTable dt = null;
        private SDC.SqlDataAdapter sqladp = null;
        private SDC.SqlCommandBuilder sqlcmdbd = null;
        private SDC.SqlCommand sqlcmd = null;
        private SDC.SqlConnection sqlconn = null;

        private string strConnectionString;

        protected string ConnectionString
        {
            get { return strConnectionString; }
            set { strConnectionString = value; }
        }
        #endregion
      
        #region �������ݣ�����DataTable��
        /// <summary>
        /// �������ݣ�����DataTable��
        /// </summary>
        /// <param name="ConnStr">�����ַ���</param>
        /// <param name="strSQL">SQL���</param>
        /// <param name="strTableName">DataTable����</param> 
        /// <param name="isTable">�Ƿ��Ӧ���������Ҫ�и��¡����������</param>
        public virtual SD.DataTable GetData(string ConnStr, string strSQL, string strTableName, bool isTable)
        {
            SD.DataTable dt = new SD.DataTable(strTableName);

            try
            {


                using (sqlconn = new SDC.SqlConnection(ConnStr))
                {

                    //sqlconn.Open();                    

                    using (sqlcmd = new SDC.SqlCommand(strSQL, sqlconn))
                    {

                        //if (sqlcmd == null)
                        //{
                        //    using (dt = new SD.DataTable(strTableName))
                        //    {
                        //        return dt;
                        //    }
                        //}

                        sqlcmd.CommandTimeout = 7200;

                        using (sqladp = new SDC.SqlDataAdapter(sqlcmd))
                        {
                            if (isTable)
                            {
                                using (sqlcmdbd = new SDC.SqlCommandBuilder(sqladp))
                                {
                                    sqlcmdbd.ConflictOption = SD.ConflictOption.CompareAllSearchableValues;

                                    sqladp.InsertCommand = sqlcmdbd.GetInsertCommand();
                                    sqladp.UpdateCommand = sqlcmdbd.GetUpdateCommand();
                                    sqladp.DeleteCommand = sqlcmdbd.GetDeleteCommand();
                                    
                                    sqladp.Fill(dt);

                                    return dt;

                                }
                            }
                            else
                            {
                                sqladp.Fill(dt);

                                return dt;

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlconn != null)
                {
                    if (sqlconn.State != SD.ConnectionState.Closed)
                    {
                        sqlconn.Close();
                    }

                    sqlconn.Dispose();
                }
            }

        }
        #endregion

        #region ����һ��һ�е�����
        /// <summary>
        /// ����һ��һ�е�����
        /// </summary>
        /// <param name="ConnStr">�����ַ���</param>
        /// <param name="strSQL">SQL���</param>
        /// <returns></returns>
        public virtual object GetScalarData(string ConnStr, string strSQL)
        {
            {
                try
                {
                    using (sqlconn = new SDC.SqlConnection(ConnStr))
                    {
                        sqlconn.Open();

                        using (sqlcmd = new SDC.SqlCommand(strSQL, sqlconn))
                        {
                            return sqlcmd.ExecuteScalar();
                        }
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sqlconn != null)
                    {
                        if (sqlconn.State != SD.ConnectionState.Closed)
                        {
                            sqlconn.Close();
                        }

                        sqlconn.Dispose();
                    }
                }

            }
        }
        #endregion
          
        #region ʹ�ַ���������
        /// <summary>
        /// ʹ�ַ���������
        /// </summary>
        /// <param name="String">ԭ�ַ���</param>
        /// <returns></returns>
        public virtual string SParm(string String)
        {
            string strRet;

            String.Replace("'", "''");
            strRet = " '" + String + "' ";

            return strRet;
        }

        #endregion

        #region �����ĳһ����Ϊһ���б��أ��б�����Ϊ���ͣ����ͱ������Ӧ�е�������һ�£�
        /// <summary>
        /// �����ĳһ����Ϊһ���б���
        /// ���б�����Ϊ���ͣ����ͱ������Ӧ�е�������һ�£�
        /// </summary>
        /// <typeparam name="T">�����б������</typeparam>
        /// <param name="dt">DataTable</param>
        /// <param name="Col">��Ҫ���ص���</param>
        /// <returns></returns>
        public List<T> GetColList<T>(SD.DataTable dt, int Col)
        {
            List<T> lstCol = new List<T>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstCol.Add((T)(dt.Rows[i][Col]));
            }

            return lstCol;
        }
        #endregion

        #region �����ַ����Ƿ���һ����ֵ�������ͣ�
        /// <summary>
        /// �����ַ����Ƿ���һ����ֵ�������ͣ�
        /// </summary>
        /// <param name="Value">��������ַ���</param>
        /// <returns></returns>
        public virtual bool IsNumber(string Value)
        {
            bool RetVal = false;
            try
            {
                float flt = float.Parse(Value);

                RetVal = true;
            }
            catch (Exception)
            {
                RetVal = false;
            }

            return RetVal;
        }
        #endregion

        #region ���ĳ��������Ӣ�ĵ��ַ����ķ�Unicodeʵ�ʳ���
        /// <summary>
        /// ���ĳ��������Ӣ�ĵ��ַ����ķ�Unicodeʵ�ʳ���
        /// </summary>
        /// <param name="Value">�����ַ���</param>
        /// <returns></returns>
        public virtual int TestTrueLens(string Value)
        {
            int Lens = 0;

            for (int i = 0; i < Value.Length; i++)
            {
                if (Convert.ToInt32(Value[i]) < 0 || Convert.ToInt32(Value[i]) > 255)
                {
                    Lens += 2;
                }
                else
                {
                    Lens += 1;
                }
            }

            return Lens;
        }
        #endregion

        #region ִ��һ���޷���ֵ��SQL����

        #region ִ��һ���޷���ֵ��SQL�����������
        /// <summary>
        /// ִ��һ���޷���ֵ��SQL�����������
        /// </summary>
        /// <param name="ConnStr">�����ַ���</param>
        /// <param name="sqlCommand">SQL����</param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(string ConnStr, string sqlCommand)
        {
            try
            {
                using (sqlconn = new SDC.SqlConnection(ConnStr))
                {

                    sqlconn.Open();

                    using (sqlcmd = new SDC.SqlCommand(sqlCommand, sqlconn))
                    {
                        return sqlcmd.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlconn != null)
                {
                    if (sqlconn.State != SD.ConnectionState.Closed)
                    {
                        sqlconn.Close();
                    }

                    sqlconn.Dispose();
                }
            }
        }
        #endregion

        #region ִ��һ���޷���ֵ��SQL���������
        /// <summary>
        /// ִ��һ���޷���ֵ��SQL���������
        /// </summary>
        /// <param name="conn">SqlConnection</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="sqlCommand">SQL����</param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(SDC.SqlConnection conn, SDC.SqlTransaction trans, string sqlCommand)
        {
            try
            {
                using (sqlcmd = new SDC.SqlCommand(sqlCommand, conn, trans))
                {
                    return sqlcmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region ���������ַ���
        /// <summary>
        /// ���������ַ���
        /// </summary>
        /// <param name="Server">���ݷ�����</param>
        /// <param name="DataBase">���ݿ�</param>
        /// <param name="UserID">�û���</param>
        /// <param name="Password">����</param>
        /// <returns></returns>
        public virtual void SetConnectString(string Server, string DataBase, string UserID, string Password)
        {
            this.ConnectionString = "Data Source=" + Server + ";Initial Catalog=" + DataBase + ";Persist Security Info=True;User ID=" + UserID + ";Password=" + Password + ";Connect Timeout=30";
        }
        #endregion
    }
}
