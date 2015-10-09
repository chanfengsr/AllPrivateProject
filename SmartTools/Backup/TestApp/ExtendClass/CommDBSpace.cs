using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlTypes;
using SD = System.Data;              // general DB classes
using SDC = System.Data.SqlClient;   // Microsoft SQL Server databases
using SDOL = System.Data.OleDb;

namespace CommDBSpace
{
    /// <summary>
    /// ����ʽö��
    /// </summary>
    public enum ColumnType
    {
        TextBoxColumn = 0,
        CheckBoxColumn = 1,
        ComboBoxColumn = 2,
        DateTimeColumn = 3
    };

    /// <summary>
    /// �����Խṹ
    /// </summary>
    public struct ColumnProperty
    {
        public ColumnType ColumnType;
        public string DataPropertyName;
        public string HeaderText;
        public Type ValueType;
        public bool ReadOnly;
        public bool Frozen;
        public bool Visible;
        public DataGridViewColumnSortMode SortMode;
        public object DataTable;
        public string DisplayMember;
        public string ValueMember;
        public int MaxInputLength;
    }

    /// <summary>
    /// ������֤����ö��
    /// </summary>
    public enum ValidateType
    {
        KeyValue = 0,
        NotNull = 1
    };

    public struct ValidateColumn
    {
        public string ColName;
        public string ColHeadText;
        public ValidateType ColValidateType;
    }

    public class CommForm : Form
    {

        #region   ��������

        //private SD.DataTable dt = null;
        private SDC.SqlDataAdapter sqladp = null;
        private SDC.SqlCommandBuilder sqlcmdbd = null;
        private SDC.SqlCommand sqlcmd = null;
        private SDC.SqlConnection sqlconn = null;

        private SDOL.OleDbDataAdapter OleDbsqladp = null;
        private SDOL.OleDbCommandBuilder OleDbsqlcmdbd = null;
        private SDOL.OleDbCommand OleDbsqlcmd = null;
        private SDOL.OleDbConnection OleDbsqlconn = null;

        protected bool blnOnClearingGrid = false;
        protected bool blnOnDeleteingRows = false;

        protected int intRowCount;//���ڼ�¼�����е��������Խ���У���Ƿ���������

        protected System.DateTime dateTime = new DateTime();

        public ValidateColumn[] ValidateColumns;//��Ҫ��֤���м������ļ���
        public string[] astrValidateColsNames;//��Ҫ��֤���е��������ַ����б�

        private string strConnectionString;

        protected string ConnectionString
        {
            get { return strConnectionString; }
            set { strConnectionString = value; }
        }

        #endregion

        #region ��ʼ����������ؼ�
        ///// <summary>
        ///// ��ʼ����������ؼ�
        ///// </summary>
        ///// <param name="Grid">DataGridView �ؼ�</param>
        //public virtual void InitColumns(DataGridView Grid)
        //{

        //}
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
            return CommDBFunction.GetData(ConnStr, strSQL, strTableName, isTable);
        }

        /// <summary>
        /// �����������OLEDB
        /// </summary>
        /// <param name="ConnStr">�����ַ���</param>
        /// <param name="strSQL">SQL���</param>
        /// <param name="strTableName">DataTable����</param> 
        public virtual SD.DataTable GetOLEDBData(string ConnStr, string strSQL, string strTableName, bool isTable)
        {
            return CommDBFunction.GetOLEDBData(ConnStr, strSQL, strTableName, isTable);
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
            return CommDBFunction.GetScalarData(ConnStr, strSQL);
        }
        #endregion

        #region ��ʽ������ؼ�
        /// <summary>
        /// ��ʽ������ؼ�
        /// </summary>
        /// <param name="Grid">DataGridView�ؼ�</param>
        public virtual void FormatDataGridView(DataGridView Grid)
        {
            CommDBFunction.FormatDataGridView(Grid);
        }
        #endregion

        #region �����Ƿ���������
        ///// <summary>
        ///// �����Ƿ����������
        ///// </summary>
        ///// <param name="dgv">DataGridView �ؼ�</param>
        ///// <param name="ColIndex">�����жϿɷ������е��е�����</param>
        ///// <returns></returns>
        public virtual bool CanAddNewRow(DataGridView dgv, int[] ColIndex)
        {
            return CommDBFunction.CanAddNewRow(dgv, ColIndex);
        }

        #endregion

        #region ������ؼ�����������
        /// <summary>
        /// ������ؼ�����������
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="ColIndex">�����жϿɷ������е��е�����</param>
        public virtual void AddNewRow(DataGridView dgv, int[] ColIndex)
        {
            CommDBFunction.AddNewRow(dgv, ColIndex);
        }

        /// <summary>
        /// ������ؼ����������У�DataTable�Ѿ�����Ĭ��ֵ��ʹ�ã�
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="dt">DataGridView ���󶨵� DataTable</param>
        /// <param name="Col">������������λ�ڵ���</param>
        public virtual void AddNewRow(DataGridView dgv, SD.DataTable dt, int Col)
        {
            CommDBFunction.AddNewRow(dgv, dt, Col);
        }
        #endregion

        #region ������������ָ�����͵�����
        /// <summary>
        /// ������������ָ�����͵�����
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="ColumnProp">���������ͼ����ԵĽṹ������鼯��</param>
        public virtual void InitColumn(DataGridView dgv, ColumnProperty[] ColumnProps)
        {
            CommDBFunction.InitColumn(dgv, ColumnProps);
        }

        #endregion

        #region ���������еĸ���
        /// <summary>
        /// ���������еĸ���
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="dt">DataGridView��DataSource��DataTable</param>
        public virtual void RejectChanges(DataGridView dgv, SD.DataTable dt)
        {
            CommDBFunction.RejectChanges(dgv, dt);
        }
        #endregion

        #region ɾ�������е�ѡ���С���ǰ��
        /// <summary>
        /// ɾ�������е�ѡ����
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="dt">DataGridView��DataSource��DataTable</param>
        public virtual void DeleteRows(DataGridView dgv, SD.DataTable dt)
        {
            CommDBFunction.DeleteRows(dgv, dt);
        }
        #endregion

        #region �������ݱ������ĸ���
        #region �������ݱ������ĸ��ģ���������
        /// <summary>
        /// �������ݱ������ĸ��ģ���������
        /// </summary>
        /// <param name="ConnStr">�����ַ���</param>
        /// <param name="strSQL">SQL��ѯ���</param>
        /// <param name="dt">DataGridView��DataSource��DataTable</param>
        public virtual void SaveChanges(string ConnStr, string strSQL, SD.DataTable dt)
        {
            CommDBFunction.SaveChanges(ConnStr, strSQL, dt);
        }
        #endregion

        #region �������ݱ������ĸ��ģ�������
        /// <summary>
        /// �������ݱ������ĸ��ģ�������
        /// </summary>
        /// <param name="conn">SqlTransaction</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="strSQL">��Ҫ���µı��SQL���</param>
        /// <param name="dt">��Ҫ���µ�DataTable</param>
        public virtual void SaveChangesOnTrans(SDC.SqlConnection conn, SDC.SqlTransaction trans, string strSQL, SD.DataTable dt)
        {
            CommDBFunction.SaveChangesOnTrans(conn, trans, strSQL, dt);
        }
        #endregion
        #endregion

        #region ����Ƿ���δ����ĸ��ģ����ڴ���ر�ʱ��
        /// <summary>
        /// ����Ƿ���δ����ĸ��ģ����ڴ���ر�ʱ��
        /// </summary>
        /// <param name="table">���ڼ���Ƿ��и��ĵ�DataTable</param>
        /// <returns></returns>
        public virtual bool IsChanged(SD.DataTable table)
        {
            return CommDBFunction.IsChanged(table);
        }

        #endregion

        #region �������ؼ�
        /// <summary>
        /// �������ؼ�
        /// </summary>
        /// <param name="gdv">DataGridView �ؼ�</param>
        public virtual void ClearDataGridView(DataGridView gdv)
        {
            CommDBFunction.ClearDataGridView(gdv);
        }

        #endregion

        #region ��֤�����е������Ƿ�Ϸ�
        #region ���ش�����Ҫ��֤���е���Ϣ��������������ͬ���˴������յ��б���ǰ�ٻ����У���������
        ///// <summary>
        ///// ���ش�����Ҫ��֤���е���Ϣ
        ///// </summary>
        ///// <returns></returns>
        //public virtual ValidateColumn[] GetValidateColumnsList()
        //{
        //    List<ValidateColumn> lstValiCols = new List<ValidateColumn>();

        //    return lstValiCols.ToArray();
        //}
        #endregion

        #region �õ���Ҫ��֤���е��������ַ����б�
        /// <summary>
        /// �õ���Ҫ��֤���е��������ַ����б�
        /// </summary>
        /// <param name="ValidateColumns">��Ҫ��֤���м������ļ���</param>
        /// <returns></returns>
        public virtual string[] GetValidateColumnsName(ValidateColumn[] ValidateColumns)
        {
            return CommDBFunction.GetValidateColumnsName(ValidateColumns);
        }
        #endregion

        #region ��֤�����еĵ�Ԫ�������Ƿ�Ϸ�
        /// <summary>
        /// ��֤�����еĵ�Ԫ�������Ƿ�Ϸ�
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="e">��Ԫ������Դ</param>
        /// <param name="ValidateColumns">��֤��������</param>
        public virtual void ValidateKey(DataGridView dgv, DataGridViewCellEventArgs e, ValidateColumn[] ValidateColumns)
        {
            CommDBFunction.ValidateKey(dgv, e, ValidateColumns);
        }
        #endregion

        #region ��֤������ĳһ�е������е����������Ƿ�Ϸ�
        /// <summary>
        /// ��֤�����е����������Ƿ�Ϸ�
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="e">��Ԫ������Դ</param>
        /// <param name="ValidateColumns">��֤��������</param>
        public virtual void ValidateRowKey(DataGridView dgv, DataGridViewCellEventArgs e, ValidateColumn[] ValidateColumns)
        {
            CommDBFunction.ValidateRowKey(dgv, e, ValidateColumns);
        }
        #endregion

        #region ��֤�����е����������Ƿ�Ϸ�
        /// <summary>
        /// ��֤�����е����������Ƿ�Ϸ�
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="ValidateColsNames">��Ҫ��֤���е������ַ�������</param>
        /// <param name="ValidateColumns">��֤��������</param>
        public virtual void ValidateAllKey(DataGridView dgv, string[] ValidateColsNames, ValidateColumn[] ValidateColumns)
        {
            CommDBFunction.ValidateAllKey(dgv, ValidateColsNames, ValidateColumns);
        }
        #endregion

        #endregion

        #region ʹ�ַ���������
        /// <summary>
        /// ʹ�ַ���������
        /// </summary>
        /// <param name="String">ԭ�ַ���</param>
        /// <returns></returns>
        public virtual string SParm(string String)
        {
            return CommDBFunction.SParm(String);
        }

        public virtual string SParm(string String, bool Convert)
        {
            return CommDBFunction.SParm(String, Convert);
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
            return CommDBFunction.GetColList<T>(dt, Col);
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
            return CommDBFunction.IsNumber(Value);
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
            return CommDBFunction.TestTrueLens(Value);
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
            return CommDBFunction.ExecuteNonQuery(ConnStr, sqlCommand);
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
            return CommDBFunction.ExecuteNonQuery(conn, trans, sqlCommand);
        }
        #endregion

        #endregion

        #region �����������Ƿ��е�Ԫ���ErrorText��Ϊ��
        /// <summary>
        /// �����������Ƿ��е�Ԫ���ErrorText��Ϊ��
        /// </summary>
        /// <param name="dgv">DataGridView����</param>
        /// <returns></returns>
        public virtual bool ChkDgvHasErrText(DataGridView dgv)
        {
            return CommDBFunction.ChkDgvHasErrText(dgv);
        }
        #endregion

        #region ����ASCII��
        public string GetAscII(string character)
        {
            return CommDBFunction.GetAscII(character);
        }
        #endregion

        #region Solomon�������
        /// <summary>
        /// Solomon�������
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public string SolEncodePassword(string passWord)
        {
            return CommDBFunction.SolEncodePassword(passWord);
        }
        #endregion

        #region ͨ��Message��
        public DialogResult ErroMessage(string MessageDescription, string MoudleName, MessageBoxButtons MsgButton, MessageBoxIcon Icon, MessageBoxDefaultButton DefaultButton)
        {
            return CommDBFunction.ErroMessage(MessageDescription, MoudleName, MsgButton, Icon, DefaultButton);
        }

        public void ErroMessage(string MessageDescription, string MoudleName, MessageBoxIcon Icon, MessageBoxDefaultButton DefaultButton)
        {
            CommDBFunction.ErroMessage(MessageDescription, MoudleName, Icon, DefaultButton);
        }
        #endregion
    }

    public static class CommDBFunction
    {
        #region   ��������
        private static SDC.SqlDataAdapter sqladp = null;
        private static SDC.SqlCommandBuilder sqlcmdbd = null;
        private static SDC.SqlCommand sqlcmd = null;
        private static SDC.SqlConnection sqlconn = null;

        private static SDOL.OleDbDataAdapter OleDbsqladp = null;
        private static SDOL.OleDbCommandBuilder OleDbsqlcmdbd = null;
        private static SDOL.OleDbCommand OleDbsqlcmd = null;
        private static SDOL.OleDbConnection OleDbsqlconn = null;
        #endregion

        #region ��ʼ����������ؼ�
        ///// <summary>
        ///// ��ʼ����������ؼ�
        ///// </summary>
        ///// <param name="Grid">DataGridView �ؼ�</param>
        //public virtual void InitColumns(DataGridView Grid)
        //{

        //}
        #endregion

        #region �������ݣ�����DataTable��
        /// <summary>
        /// �������ݣ�����DataTable��
        /// </summary>
        /// <param name="ConnStr">�����ַ���</param>
        /// <param name="strSQL">SQL���</param>
        /// <param name="strTableName">DataTable����</param> 
        /// <param name="isTable">�Ƿ��Ӧ���������Ҫ�и��¡����������</param>
        public static SD.DataTable GetData(string ConnStr, string strSQL, string strTableName, bool isTable)
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

        /// <summary>
        /// �����������OLEDB
        /// </summary>
        /// <param name="ConnStr">�����ַ���</param>
        /// <param name="strSQL">SQL���</param>
        /// <param name="strTableName">DataTable����</param> 
        public static SD.DataTable GetOLEDBData(string ConnStr, string strSQL, string strTableName, bool isTable)
        {
            SD.DataTable dt = new SD.DataTable(strTableName);

            try
            {
                using (OleDbsqlconn = new SDOL.OleDbConnection(ConnStr))
                {

                    //sqlconn.Open();

                    using (OleDbsqlcmd = new SDOL.OleDbCommand(strSQL, OleDbsqlconn))
                    {

                        //if (sqlcmd == null)
                        //{
                        //    using (dt = new SD.DataTable(strTableName))
                        //    {
                        //        return dt;
                        //    }
                        //}

                        using (OleDbsqladp = new SDOL.OleDbDataAdapter(OleDbsqlcmd))
                        {
                            if (isTable)
                            {
                                using (OleDbsqlcmdbd = new SDOL.OleDbCommandBuilder(OleDbsqladp))
                                {
                                    OleDbsqlcmdbd.ConflictOption = SD.ConflictOption.CompareAllSearchableValues;

                                    OleDbsqladp.InsertCommand = OleDbsqlcmdbd.GetInsertCommand();
                                    OleDbsqladp.UpdateCommand = OleDbsqlcmdbd.GetUpdateCommand();
                                    OleDbsqladp.DeleteCommand = OleDbsqlcmdbd.GetDeleteCommand();

                                    OleDbsqladp.Fill(dt);

                                    return dt;

                                }
                            }
                            else
                            {
                                OleDbsqladp.Fill(dt);
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
        public static object GetScalarData(string ConnStr, string strSQL)
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

        #region ��ʽ������ؼ�
        /// <summary>
        /// ��ʽ������ؼ�
        /// </summary>
        /// <param name="Grid">DataGridView�ؼ�</param>
        public static void FormatDataGridView(DataGridView Grid)
        {
            //���ý�������ɫ
            Grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(250, 244, 219);
            Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 236, 192);

            //�����û����н�����˳��
            Grid.AllowUserToOrderColumns = true;

            //�Զ������п����и�
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            Grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //��ʾ����
            Grid.RowHeadersVisible = true;

            //ʹ��Ԫ���ý��㼴��ʼ�༭
            //Grid.EditMode = DataGridViewEditMode.EditOnEnter;

            //�������Զ������
            Grid.AutoGenerateColumns = false;

            //�������ѡ
            Grid.MultiSelect = false;
        }
        #endregion

        #region �����Ƿ���������
        ///// <summary>
        ///// �����Ƿ����������
        ///// </summary>
        ///// <param name="dgv">DataGridView �ؼ�</param>
        ///// <param name="ColIndex">�����жϿɷ������е��е�����</param>
        ///// <returns></returns>
        public static bool CanAddNewRow(DataGridView dgv, int[] ColIndex)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                foreach (int j in ColIndex)
                {
                    if (dgv[j, i].Value.ToString().Trim() == "")
                        return false;
                }
            }

            return true;
        }

        #endregion

        #region ������ؼ�����������
        /// <summary>
        /// ������ؼ�����������
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="ColIndex">�����жϿɷ������е��е�����</param>
        public static void AddNewRow(DataGridView dgv, int[] ColIndex)
        {
            try
            {
                //this.Validate();

                if (CanAddNewRow(dgv, ColIndex))
                {
                    //SD.DataRowView drv = (dgv.DataSource as SD.DataTable).DefaultView.AddNew();
                    //drv.EndEdit();


                    //SD.DataRow dr = (dgv.DataSource as SD.DataTable).NewRow();

                    //(dgv.DataSource as SD.DataTable).Rows.Add(dr);

                    SD.DataTable dt = dgv.DataSource as SD.DataTable;

                    dgv.BindingContext[dt].AddNew();

                    dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[ColIndex[0]];

                    dgv.BeginEdit(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ������ؼ����������У�DataTable�Ѿ�����Ĭ��ֵ��ʹ�ã�
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="dt">DataGridView ���󶨵� DataTable</param>
        /// <param name="Col">������������λ�ڵ���</param>
        public static void AddNewRow(DataGridView dgv, SD.DataTable dt, int Col)
        {
            //this.Validate();

            dgv.BindingContext[dt].AddNew();

            dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[Col];
            dgv.BeginEdit(true);
        }
        #endregion

        #region ������������ָ�����͵�����
        /// <summary>
        /// ������������ָ�����͵�����
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="ColumnProp">���������ͼ����ԵĽṹ������鼯��</param>
        public static void InitColumn(DataGridView dgv, ColumnProperty[] ColumnProps)
        {
            foreach (ColumnProperty ColumnProp in ColumnProps)
            {
                switch (ColumnProp.ColumnType)
                {
                    case ColumnType.CheckBoxColumn:
                        DataGridViewCheckBoxColumn ColCheck = new DataGridViewCheckBoxColumn();
                        ColCheck.DataPropertyName = ColumnProp.DataPropertyName;
                        ColCheck.HeaderText = ColumnProp.HeaderText;
                        ColCheck.ValueType = ColumnProp.ValueType;
                        ColCheck.Name = ColumnProp.DataPropertyName;
                        ColCheck.ReadOnly = ColumnProp.ReadOnly;
                        ColCheck.Frozen = ColumnProp.Frozen;
                        ColCheck.Visible = ColumnProp.Visible;
                        ColCheck.SortMode = ColumnProp.SortMode;

                        ColCheck.TrueValue = 1;
                        ColCheck.FalseValue = 0;

                        dgv.Columns.Add(ColCheck);

                        break;

                    case ColumnType.ComboBoxColumn:
                        DataGridViewComboBoxColumn ColComboBox = new DataGridViewComboBoxColumn();
                        ColComboBox.DisplayStyleForCurrentCellOnly = true;
                        ColComboBox.DataPropertyName = ColumnProp.DataPropertyName;
                        ColComboBox.HeaderText = ColumnProp.HeaderText;
                        ColComboBox.ValueType = ColumnProp.ValueType;
                        ColComboBox.Name = ColumnProp.DataPropertyName;
                        ColComboBox.ReadOnly = ColumnProp.ReadOnly;
                        ColComboBox.Frozen = ColumnProp.Frozen;
                        ColComboBox.Visible = ColumnProp.Visible;

                        ColComboBox.DisplayMember = ColumnProp.DisplayMember;
                        ColComboBox.ValueMember = ColumnProp.ValueMember;
                        ColComboBox.SortMode = ColumnProp.SortMode;
                        ColComboBox.DataSource = ColumnProp.DataTable;

                        dgv.Columns.Add(ColComboBox);

                        break;

                    case ColumnType.TextBoxColumn:
                        DataGridViewTextBoxColumn ColTextBox = new DataGridViewTextBoxColumn();
                        ColTextBox.DataPropertyName = ColumnProp.DataPropertyName;
                        ColTextBox.HeaderText = ColumnProp.HeaderText;
                        ColTextBox.ValueType = ColumnProp.ValueType;
                        ColTextBox.Name = ColumnProp.DataPropertyName;
                        ColTextBox.ReadOnly = ColumnProp.ReadOnly;
                        ColTextBox.Frozen = ColumnProp.Frozen;
                        ColTextBox.Visible = ColumnProp.Visible;
                        ColTextBox.SortMode = ColumnProp.SortMode;
                        ColTextBox.MaxInputLength = ColumnProp.MaxInputLength;

                        dgv.Columns.Add(ColTextBox);

                        break;
                    case ColumnType.DateTimeColumn:
                        DataGridViewDateTimeColumn ColDataTime = new DataGridViewDateTimeColumn();
                        ColDataTime.DataPropertyName = ColumnProp.DataPropertyName;
                        ColDataTime.HeaderText = ColumnProp.HeaderText;
                        ColDataTime.ValueType = ColumnProp.ValueType;
                        ColDataTime.Name = ColumnProp.DataPropertyName;
                        ColDataTime.ReadOnly = ColumnProp.ReadOnly;
                        ColDataTime.Frozen = ColumnProp.Frozen;
                        ColDataTime.Visible = ColumnProp.Visible;

                        dgv.Columns.Add(ColDataTime);

                        break;
                }
            }
        }

        #endregion

        #region ���������еĸ���
        /// <summary>
        /// ���������еĸ���
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="dt">DataGridView��DataSource��DataTable</param>
        public static void RejectChanges(DataGridView dgv, SD.DataTable dt)
        {
            dt.RejectChanges();
            dgv.Refresh();
        }
        #endregion

        #region ɾ�������е�ѡ���С���ǰ��
        /// <summary>
        /// ɾ�������е�ѡ����
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="dt">DataGridView��DataSource��DataTable</param>
        public static void DeleteRows(DataGridView dgv, SD.DataTable dt)
        {
            try
            {
                if (dgv.CurrentRow != null && dgv.SelectedRows.Count == 0)
                {
                    dt.DefaultView.Delete(dgv.CurrentRow.Index);
                }

                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    dt.DefaultView.Delete(row.Index);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region �������ݱ������ĸ���
        #region �������ݱ������ĸ��ģ���������
        /// <summary>
        /// �������ݱ������ĸ��ģ���������
        /// </summary>
        /// <param name="ConnStr">�����ַ���</param>
        /// <param name="strSQL">SQL��ѯ���</param>
        /// <param name="dt">DataGridView��DataSource��DataTable</param>
        public static void SaveChanges(string ConnStr, string strSQL, SD.DataTable dt)
        {
            //this.Validate();

            try
            {
                using (sqlconn = new SDC.SqlConnection(ConnStr))
                {

                    sqlconn.Open();

                    using (sqlcmd = new SDC.SqlCommand(strSQL, sqlconn))
                    {
                        using (sqladp = new SDC.SqlDataAdapter(sqlcmd))
                        {
                            using (sqlcmdbd = new SDC.SqlCommandBuilder(sqladp))
                            {
                                sqlcmdbd.ConflictOption = SD.ConflictOption.CompareAllSearchableValues;

                                sqladp.InsertCommand = sqlcmdbd.GetInsertCommand();
                                sqladp.UpdateCommand = sqlcmdbd.GetUpdateCommand();
                                sqladp.DeleteCommand = sqlcmdbd.GetDeleteCommand();

                                sqladp.Update(dt);
                            }
                        }
                    }
                }
            }
            catch (SDC.SqlException ex)
            {
                throw ex;
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

        #region �������ݱ������ĸ��ģ�������
        /// <summary>
        /// �������ݱ������ĸ��ģ�������
        /// </summary>
        /// <param name="conn">SqlTransaction</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="strSQL">��Ҫ���µı��SQL���</param>
        /// <param name="dt">��Ҫ���µ�DataTable</param>
        public static void SaveChangesOnTrans(SDC.SqlConnection conn, SDC.SqlTransaction trans, string strSQL, SD.DataTable dt)
        {
            //this.Validate();

            try
            {
                using (sqlcmd = new SDC.SqlCommand(strSQL, conn, trans))
                {
                    using (sqladp = new SDC.SqlDataAdapter(sqlcmd))
                    {
                        //sqladp.InsertCommand.Transaction = trans;
                        using (sqlcmdbd = new SDC.SqlCommandBuilder(sqladp))
                        {
                            sqlcmdbd.ConflictOption = SD.ConflictOption.CompareRowVersion;

                            sqladp.InsertCommand = sqlcmdbd.GetInsertCommand();
                            sqladp.UpdateCommand = sqlcmdbd.GetUpdateCommand();
                            sqladp.DeleteCommand = sqlcmdbd.GetDeleteCommand();

                            sqladp.Update(dt);
                        }
                    }
                }
            }
            catch (SDC.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region ����Ƿ���δ����ĸ��ģ����ڴ���ر�ʱ��
        /// <summary>
        /// ����Ƿ���δ����ĸ��ģ����ڴ���ر�ʱ��
        /// </summary>
        /// <param name="table">���ڼ���Ƿ��и��ĵ�DataTable</param>
        /// <returns></returns>
        public static bool IsChanged(SD.DataTable table)
        {
            try
            {
                if (table.GetChanges() != null)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        #endregion

        #region �������ؼ�
        /// <summary>
        /// �������ؼ�
        /// </summary>
        /// <param name="gdv">DataGridView �ؼ�</param>
        public static void ClearDataGridView(DataGridView gdv)
        {
            while (gdv.Columns.Count > 0)
            {
                gdv.Columns.Remove(gdv.Columns[0].Name);
            }

            gdv.DataSource = null;
        }

        #endregion

        #region ��֤�����е������Ƿ�Ϸ�
        #region ���ش�����Ҫ��֤���е���Ϣ��������������ͬ���˴������յ��б���ǰ�ٻ����У���������
        ///// <summary>
        ///// ���ش�����Ҫ��֤���е���Ϣ
        ///// </summary>
        ///// <returns></returns>
        //public virtual ValidateColumn[] GetValidateColumnsList()
        //{
        //    List<ValidateColumn> lstValiCols = new List<ValidateColumn>();

        //    return lstValiCols.ToArray();
        //}
        #endregion

        #region �õ���Ҫ��֤���е��������ַ����б�
        /// <summary>
        /// �õ���Ҫ��֤���е��������ַ����б�
        /// </summary>
        /// <param name="ValidateColumns">��Ҫ��֤���м������ļ���</param>
        /// <returns></returns>
        public static string[] GetValidateColumnsName(ValidateColumn[] ValidateColumns)
        {
            List<string> lstValidateColumns = new List<string>();

            foreach (ValidateColumn ValidateCol in ValidateColumns)
            {
                if (lstValidateColumns.Contains(ValidateCol.ColName) == false)
                {
                    lstValidateColumns.Add(ValidateCol.ColName);
                }

            }

            return lstValidateColumns.ToArray();
        }
        #endregion

        #region ��֤�����еĵ�Ԫ�������Ƿ�Ϸ�
        /// <summary>
        /// ��֤�����еĵ�Ԫ�������Ƿ�Ϸ�
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="e">��Ԫ������Դ</param>
        /// <param name="ValidateColumns">��֤��������</param>
        public static void ValidateKey(DataGridView dgv, DataGridViewCellEventArgs e, ValidateColumn[] ValidateColumns)
        {
            int ErrFalg = 0;//��ʱ��Ϊ��Ԫ��û����֤����

            foreach (ValidateColumn ValidateCol in ValidateColumns)
            {
                switch (ValidateCol.ColValidateType)
                {
                    case ValidateType.KeyValue:
                        if (e.ColumnIndex == dgv.Columns[ValidateCol.ColName].Index)
                        {
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                if (row.Cells[ValidateCol.ColName].Value.ToString().Trim().ToUpper() ==
                                    dgv[e.ColumnIndex, e.RowIndex].Value.ToString().Trim().ToUpper()
                                   && row.Index != e.RowIndex
                                  )
                                {
                                    dgv[e.ColumnIndex, e.RowIndex].ErrorText = "��ǰ������ͬ��" + ValidateCol.ColHeadText;
                                    ErrFalg = 1;
                                    break;
                                }
                            }
                        }

                        break;
                    case ValidateType.NotNull:
                        if (e.ColumnIndex == dgv.Columns[ValidateCol.ColName].Index)
                        {
                            if (dgv[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() == "")
                            {
                                dgv[e.ColumnIndex, e.RowIndex].ErrorText = ValidateCol.ColHeadText + "����Ϊ��";
                                ErrFalg = 1;
                            }
                        }

                        break;
                }
            }

            //�����ʱErrFalg����Ϊ0����˵���˵�Ԫ��ȷʵ����֤����
            if (ErrFalg == 0)
            {
                dgv[e.ColumnIndex, e.RowIndex].ErrorText = "";
            }
        }
        #endregion

        #region ��֤������ĳһ�е������е����������Ƿ�Ϸ�
        /// <summary>
        /// ��֤�����е����������Ƿ�Ϸ�
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="e">��Ԫ������Դ</param>
        /// <param name="ValidateColumns">��֤��������</param>
        public static void ValidateRowKey(DataGridView dgv, DataGridViewCellEventArgs e, ValidateColumn[] ValidateColumns)
        {
            DataGridViewCellEventArgs e1;

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                e1 = new DataGridViewCellEventArgs(i, e.RowIndex);

                ValidateKey(dgv, e1, ValidateColumns);
            }
        }
        #endregion

        #region ��֤�����е����������Ƿ�Ϸ�
        /// <summary>
        /// ��֤�����е����������Ƿ�Ϸ�
        /// </summary>
        /// <param name="dgv">DataGridView �ؼ�</param>
        /// <param name="ValidateColsNames">��Ҫ��֤���е������ַ�������</param>
        /// <param name="ValidateColumns">��֤��������</param>
        public static void ValidateAllKey(DataGridView dgv, string[] ValidateColsNames, ValidateColumn[] ValidateColumns)
        {
            foreach (string ValidateColName in ValidateColsNames)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    DataGridViewCellEventArgs e1 = new DataGridViewCellEventArgs(dgv.Columns[ValidateColName].Index, i);

                    ValidateKey(dgv, e1, ValidateColumns);
                }
            }
        }
        #endregion

        #endregion

        #region ʹ�ַ���������
        /// <summary>
        /// ʹ�ַ���������
        /// </summary>
        /// <param name="String">ԭ�ַ���</param>
        /// <returns></returns>
        public static string SParm(string String, bool Convert)
        {
            string strRet;
            String.Replace("'", "''");

            if (Convert)
            {
                byte[] bytes = Encoding.Default.GetBytes(String);
                String = Encoding.GetEncoding(0x4e4).GetString(bytes);
            }

            strRet = " '" + String + "' ";
            return strRet;
        }

        public static string SParm(string String)
        {
            return SParm(String, false);
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
        public static List<T> GetColList<T>(SD.DataTable dt, int Col)
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
        public static bool IsNumber(string Value)
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
        public static int TestTrueLens(string Value)
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
        public static int ExecuteNonQuery(string ConnStr, string sqlCommand)
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
        public static int ExecuteNonQuery(SDC.SqlConnection conn, SDC.SqlTransaction trans, string sqlCommand)
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

        #region �����������Ƿ��е�Ԫ���ErrorText��Ϊ��
        /// <summary>
        /// �����������Ƿ��е�Ԫ���ErrorText��Ϊ��
        /// </summary>
        /// <param name="dgv">DataGridView����</param>
        /// <returns></returns>
        public static bool ChkDgvHasErrText(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ErrorText.Trim().Length != 0)
                        return true;
                }
            }

            return false;
        }
        #endregion

        #region ����ASCII��
        public static string GetAscII(string character)
        {
            string strResult = "";

            if (character.Length > 0)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();

                foreach (Char chr in character)
                {
                    strResult = strResult + ((int)chr).ToString() + " ";
                }

                return (strResult);

            }
            else
            {
                return "";
            }
        }
        #endregion

        #region Solomon�������
        /// <summary>
        /// Solomon�������
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public static string SolEncodePassword(string passWord)
        {
            int[] intRef = new int[12];
            int intAsc;
            int intP, intLen;
            string strEncode;
            if (passWord.Trim() == "")
                return "";
            else
            {
                intRef[0] = 0;
                intRef[1] = 10;
                intRef[2] = 3;
                intRef[3] = 5;
                intRef[4] = 11;
                intRef[5] = 12;
                intRef[6] = 1;
                intRef[7] = 4;
                intRef[8] = 9;
                intRef[9] = 2;
                intRef[10] = 6;
                intRef[11] = 7;

                intLen = passWord.Length;

                strEncode = "";

                char[] cTemp = passWord.ToCharArray();

                for (intP = 1; intP <= intLen; intP++)
                {
                    int c = cTemp[intP - 1];
                    intAsc = c + intLen - 61 + intRef[intP - 1];
                    if (intAsc <= 0)
                        intAsc = intAsc + 126;
                    else
                    {
                        if (intAsc <= 32)
                            intAsc = intAsc + 32;
                    }
                    strEncode = strEncode + (char)intAsc;
                }
                return strEncode;
            }
        }
        #endregion

        #region ͨ��Message��
        public static DialogResult ErroMessage(string MessageDescription, string MoudleName, MessageBoxButtons MsgButton, MessageBoxIcon Icon, MessageBoxDefaultButton DefaultButton)
        {
            string Catpion = "System Message";
            string MessageString = MessageDescription + "\n\n" + MoudleName;

            return MessageBox.Show(MessageString, Catpion, MsgButton, Icon, DefaultButton);

        }

        public static void ErroMessage(string MessageDescription, string MoudleName, MessageBoxIcon Icon, MessageBoxDefaultButton DefaultButton)
        {
            string Catpion = "System Message";
            string MessageString = MessageDescription + "\n\n" + MoudleName;
            MessageBoxButtons MsgButton = MessageBoxButtons.OK;

            MessageBox.Show(MessageString, Catpion, MsgButton, Icon, DefaultButton);

        }
        #endregion
    }
}
