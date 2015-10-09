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
        #region   窗体构造函数及公共属性

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
      
        #region 加载数据（返回DataTable）
        /// <summary>
        /// 加载数据（返回DataTable）
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="strTableName">DataTable表名</param> 
        /// <param name="isTable">是否对应有物理表，需要有更新、保存等命令</param>
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

        #region 返回一行一列的数据
        /// <summary>
        /// 返回一行一列的数据
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="strSQL">SQL语句</param>
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
          
        #region 使字符串参数化
        /// <summary>
        /// 使字符串参数化
        /// </summary>
        /// <param name="String">原字符串</param>
        /// <returns></returns>
        public virtual string SParm(string String)
        {
            string strRet;

            String.Replace("'", "''");
            strRet = " '" + String + "' ";

            return strRet;
        }

        #endregion

        #region 将表的某一列作为一个列表返回（列表类型为泛型，类型必须与对应列的类型相一致）
        /// <summary>
        /// 将表的某一列作为一个列表返回
        /// （列表类型为泛型，类型必须与对应列的类型相一致）
        /// </summary>
        /// <typeparam name="T">返回列表的类型</typeparam>
        /// <param name="dt">DataTable</param>
        /// <param name="Col">需要返回的列</param>
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

        #region 测试字符串是否是一个数值（浮点型）
        /// <summary>
        /// 测试字符串是否是一个数值（浮点型）
        /// </summary>
        /// <param name="Value">待检验的字符串</param>
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

        #region 获得某个包含中英文的字符串的非Unicode实际长度
        /// <summary>
        /// 获得某个包含中英文的字符串的非Unicode实际长度
        /// </summary>
        /// <param name="Value">被测字符串</param>
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

        #region 执行一条无返回值的SQL命令

        #region 执行一条无返回值的SQL命令（不带事务）
        /// <summary>
        /// 执行一条无返回值的SQL命令（不带事务）
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="sqlCommand">SQL命令</param>
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

        #region 执行一条无返回值的SQL命令（带事务）
        /// <summary>
        /// 执行一条无返回值的SQL命令（带事务）
        /// </summary>
        /// <param name="conn">SqlConnection</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="sqlCommand">SQL命令</param>
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

        #region 生成连接字符串
        /// <summary>
        /// 生成连接字符串
        /// </summary>
        /// <param name="Server">数据服务器</param>
        /// <param name="DataBase">数据库</param>
        /// <param name="UserID">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public virtual void SetConnectString(string Server, string DataBase, string UserID, string Password)
        {
            this.ConnectionString = "Data Source=" + Server + ";Initial Catalog=" + DataBase + ";Persist Security Info=True;User ID=" + UserID + ";Password=" + Password + ";Connect Timeout=30";
        }
        #endregion
    }
}
