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
    /// 列样式枚举
    /// </summary>
    public enum ColumnType
    {
        TextBoxColumn = 0,
        CheckBoxColumn = 1,
        ComboBoxColumn = 2,
        DateTimeColumn = 3
    };

    /// <summary>
    /// 列属性结构
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
    /// 错误验证类型枚举
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

        #region   公共属性

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

        protected int intRowCount;//用于记录网格中的行数，以进行校验是否新增了行

        protected System.DateTime dateTime = new DateTime();

        public ValidateColumn[] ValidateColumns;//需要验证的列及其规则的集合
        public string[] astrValidateColsNames;//需要验证的列的列名的字符串列表

        private string strConnectionString;

        protected string ConnectionString
        {
            get { return strConnectionString; }
            set { strConnectionString = value; }
        }

        #endregion

        #region 初始化界面网格控件
        ///// <summary>
        ///// 初始化界面网格控件
        ///// </summary>
        ///// <param name="Grid">DataGridView 控件</param>
        //public virtual void InitColumns(DataGridView Grid)
        //{

        //}
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
            return CommDBFunction.GetData(ConnStr, strSQL, strTableName, isTable);
        }

        /// <summary>
        /// 界面加载数据OLEDB
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="strTableName">DataTable表名</param> 
        public virtual SD.DataTable GetOLEDBData(string ConnStr, string strSQL, string strTableName, bool isTable)
        {
            return CommDBFunction.GetOLEDBData(ConnStr, strSQL, strTableName, isTable);
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
            return CommDBFunction.GetScalarData(ConnStr, strSQL);
        }
        #endregion

        #region 格式化网格控件
        /// <summary>
        /// 格式化网格控件
        /// </summary>
        /// <param name="Grid">DataGridView控件</param>
        public virtual void FormatDataGridView(DataGridView Grid)
        {
            CommDBFunction.FormatDataGridView(Grid);
        }
        #endregion

        #region 测试是否能新增行
        ///// <summary>
        ///// 返回是否可以新增行
        ///// </summary>
        ///// <param name="dgv">DataGridView 控件</param>
        ///// <param name="ColIndex">用于判断可否新增行的列的数组</param>
        ///// <returns></returns>
        public virtual bool CanAddNewRow(DataGridView dgv, int[] ColIndex)
        {
            return CommDBFunction.CanAddNewRow(dgv, ColIndex);
        }

        #endregion

        #region 在网格控件中增加新行
        /// <summary>
        /// 在网格控件中增加新行
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="ColIndex">用于判断可否新增行的列的数组</param>
        public virtual void AddNewRow(DataGridView dgv, int[] ColIndex)
        {
            CommDBFunction.AddNewRow(dgv, ColIndex);
        }

        /// <summary>
        /// 在网格控件中增加新行（DataTable已经做了默认值的使用）
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="dt">DataGridView 所绑定的 DataTable</param>
        /// <param name="Col">新增后光标所定位在的列</param>
        public virtual void AddNewRow(DataGridView dgv, SD.DataTable dt, int Col)
        {
            CommDBFunction.AddNewRow(dgv, dt, Col);
        }
        #endregion

        #region 在网格中增加指定类型的新列
        /// <summary>
        /// 在网格中增加指定类型的新列
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="ColumnProp">描述列类型及属性的结构体的数组集合</param>
        public virtual void InitColumn(DataGridView dgv, ColumnProperty[] ColumnProps)
        {
            CommDBFunction.InitColumn(dgv, ColumnProps);
        }

        #endregion

        #region 撤消网格中的更改
        /// <summary>
        /// 撤消网格中的更改
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="dt">DataGridView的DataSource的DataTable</param>
        public virtual void RejectChanges(DataGridView dgv, SD.DataTable dt)
        {
            CommDBFunction.RejectChanges(dgv, dt);
        }
        #endregion

        #region 删除网格中的选中行、当前行
        /// <summary>
        /// 删除网格中的选中行
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="dt">DataGridView的DataSource的DataTable</param>
        public virtual void DeleteRows(DataGridView dgv, SD.DataTable dt)
        {
            CommDBFunction.DeleteRows(dgv, dt);
        }
        #endregion

        #region 保存数据表所做的更改
        #region 保存数据表所做的更改（不带事务）
        /// <summary>
        /// 保存数据表所做的更改（不带事务）
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="strSQL">SQL查询语句</param>
        /// <param name="dt">DataGridView的DataSource的DataTable</param>
        public virtual void SaveChanges(string ConnStr, string strSQL, SD.DataTable dt)
        {
            CommDBFunction.SaveChanges(ConnStr, strSQL, dt);
        }
        #endregion

        #region 保存数据表所做的更改（带事务）
        /// <summary>
        /// 保存数据表所做的更改（带事务）
        /// </summary>
        /// <param name="conn">SqlTransaction</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="strSQL">需要更新的表的SQL语句</param>
        /// <param name="dt">需要更新的DataTable</param>
        public virtual void SaveChangesOnTrans(SDC.SqlConnection conn, SDC.SqlTransaction trans, string strSQL, SD.DataTable dt)
        {
            CommDBFunction.SaveChangesOnTrans(conn, trans, strSQL, dt);
        }
        #endregion
        #endregion

        #region 检测是否有未保存的更改（用于窗体关闭时）
        /// <summary>
        /// 检测是否有未保存的更改（用于窗体关闭时）
        /// </summary>
        /// <param name="table">用于检测是否有更改的DataTable</param>
        /// <returns></returns>
        public virtual bool IsChanged(SD.DataTable table)
        {
            return CommDBFunction.IsChanged(table);
        }

        #endregion

        #region 清空网格控件
        /// <summary>
        /// 清空网格控件
        /// </summary>
        /// <param name="gdv">DataGridView 控件</param>
        public virtual void ClearDataGridView(DataGridView gdv)
        {
            CommDBFunction.ClearDataGridView(gdv);
        }

        #endregion

        #region 验证网格中的输入是否合法
        #region 返回窗体需要验证的列的信息（因各窗体情况不同，此处给出空的列表）以前再基类中，现在隐藏
        ///// <summary>
        ///// 返回窗体需要验证的列的信息
        ///// </summary>
        ///// <returns></returns>
        //public virtual ValidateColumn[] GetValidateColumnsList()
        //{
        //    List<ValidateColumn> lstValiCols = new List<ValidateColumn>();

        //    return lstValiCols.ToArray();
        //}
        #endregion

        #region 拿到需要验证的列的列名的字符串列表
        /// <summary>
        /// 拿到需要验证的列的列名的字符串列表
        /// </summary>
        /// <param name="ValidateColumns">需要验证的列及其规则的集合</param>
        /// <returns></returns>
        public virtual string[] GetValidateColumnsName(ValidateColumn[] ValidateColumns)
        {
            return CommDBFunction.GetValidateColumnsName(ValidateColumns);
        }
        #endregion

        #region 验证网格中的单元格输入是否合法
        /// <summary>
        /// 验证网格中的单元格输入是否合法
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="e">单元格数据源</param>
        /// <param name="ValidateColumns">验证条件集合</param>
        public virtual void ValidateKey(DataGridView dgv, DataGridViewCellEventArgs e, ValidateColumn[] ValidateColumns)
        {
            CommDBFunction.ValidateKey(dgv, e, ValidateColumns);
        }
        #endregion

        #region 验证网格中某一行的所有列的所有输入是否合法
        /// <summary>
        /// 验证网格中的所有输入是否合法
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="e">单元格数据源</param>
        /// <param name="ValidateColumns">验证条件集合</param>
        public virtual void ValidateRowKey(DataGridView dgv, DataGridViewCellEventArgs e, ValidateColumn[] ValidateColumns)
        {
            CommDBFunction.ValidateRowKey(dgv, e, ValidateColumns);
        }
        #endregion

        #region 验证网格中的所有输入是否合法
        /// <summary>
        /// 验证网格中的所有输入是否合法
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="ValidateColsNames">需要验证的列的列名字符串数组</param>
        /// <param name="ValidateColumns">验证条件集合</param>
        public virtual void ValidateAllKey(DataGridView dgv, string[] ValidateColsNames, ValidateColumn[] ValidateColumns)
        {
            CommDBFunction.ValidateAllKey(dgv, ValidateColsNames, ValidateColumns);
        }
        #endregion

        #endregion

        #region 使字符串参数化
        /// <summary>
        /// 使字符串参数化
        /// </summary>
        /// <param name="String">原字符串</param>
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
            return CommDBFunction.GetColList<T>(dt, Col);
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
            return CommDBFunction.IsNumber(Value);
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
            return CommDBFunction.TestTrueLens(Value);
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
            return CommDBFunction.ExecuteNonQuery(ConnStr, sqlCommand);
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
            return CommDBFunction.ExecuteNonQuery(conn, trans, sqlCommand);
        }
        #endregion

        #endregion

        #region 检验网格中是否有单元格的ErrorText不为空
        /// <summary>
        /// 检验网格中是否有单元格的ErrorText不为空
        /// </summary>
        /// <param name="dgv">DataGridView网格</param>
        /// <returns></returns>
        public virtual bool ChkDgvHasErrText(DataGridView dgv)
        {
            return CommDBFunction.ChkDgvHasErrText(dgv);
        }
        #endregion

        #region 返回ASCII码
        public string GetAscII(string character)
        {
            return CommDBFunction.GetAscII(character);
        }
        #endregion

        #region Solomon密码加密
        /// <summary>
        /// Solomon密码加密
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public string SolEncodePassword(string passWord)
        {
            return CommDBFunction.SolEncodePassword(passWord);
        }
        #endregion

        #region 通用Message框
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
        #region   公共属性
        private static SDC.SqlDataAdapter sqladp = null;
        private static SDC.SqlCommandBuilder sqlcmdbd = null;
        private static SDC.SqlCommand sqlcmd = null;
        private static SDC.SqlConnection sqlconn = null;

        private static SDOL.OleDbDataAdapter OleDbsqladp = null;
        private static SDOL.OleDbCommandBuilder OleDbsqlcmdbd = null;
        private static SDOL.OleDbCommand OleDbsqlcmd = null;
        private static SDOL.OleDbConnection OleDbsqlconn = null;
        #endregion

        #region 初始化界面网格控件
        ///// <summary>
        ///// 初始化界面网格控件
        ///// </summary>
        ///// <param name="Grid">DataGridView 控件</param>
        //public virtual void InitColumns(DataGridView Grid)
        //{

        //}
        #endregion

        #region 加载数据（返回DataTable）
        /// <summary>
        /// 加载数据（返回DataTable）
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="strTableName">DataTable表名</param> 
        /// <param name="isTable">是否对应有物理表，需要有更新、保存等命令</param>
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
        /// 界面加载数据OLEDB
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="strTableName">DataTable表名</param> 
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

        #region 返回一行一列的数据
        /// <summary>
        /// 返回一行一列的数据
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="strSQL">SQL语句</param>
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

        #region 格式化网格控件
        /// <summary>
        /// 格式化网格控件
        /// </summary>
        /// <param name="Grid">DataGridView控件</param>
        public static void FormatDataGridView(DataGridView Grid)
        {
            //设置交互列颜色
            Grid.RowsDefaultCellStyle.BackColor = Color.FromArgb(250, 244, 219);
            Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 236, 192);

            //允许用户自行交换列顺序
            Grid.AllowUserToOrderColumns = true;

            //自动调整列宽与行高
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            Grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //显示行首
            Grid.RowHeadersVisible = true;

            //使单元格获得焦点即开始编辑
            //Grid.EditMode = DataGridViewEditMode.EditOnEnter;

            //不允许自动添加列
            Grid.AutoGenerateColumns = false;

            //不允许多选
            Grid.MultiSelect = false;
        }
        #endregion

        #region 测试是否能新增行
        ///// <summary>
        ///// 返回是否可以新增行
        ///// </summary>
        ///// <param name="dgv">DataGridView 控件</param>
        ///// <param name="ColIndex">用于判断可否新增行的列的数组</param>
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

        #region 在网格控件中增加新行
        /// <summary>
        /// 在网格控件中增加新行
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="ColIndex">用于判断可否新增行的列的数组</param>
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
        /// 在网格控件中增加新行（DataTable已经做了默认值的使用）
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="dt">DataGridView 所绑定的 DataTable</param>
        /// <param name="Col">新增后光标所定位在的列</param>
        public static void AddNewRow(DataGridView dgv, SD.DataTable dt, int Col)
        {
            //this.Validate();

            dgv.BindingContext[dt].AddNew();

            dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[Col];
            dgv.BeginEdit(true);
        }
        #endregion

        #region 在网格中增加指定类型的新列
        /// <summary>
        /// 在网格中增加指定类型的新列
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="ColumnProp">描述列类型及属性的结构体的数组集合</param>
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

        #region 撤消网格中的更改
        /// <summary>
        /// 撤消网格中的更改
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="dt">DataGridView的DataSource的DataTable</param>
        public static void RejectChanges(DataGridView dgv, SD.DataTable dt)
        {
            dt.RejectChanges();
            dgv.Refresh();
        }
        #endregion

        #region 删除网格中的选中行、当前行
        /// <summary>
        /// 删除网格中的选中行
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="dt">DataGridView的DataSource的DataTable</param>
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

        #region 保存数据表所做的更改
        #region 保存数据表所做的更改（不带事务）
        /// <summary>
        /// 保存数据表所做的更改（不带事务）
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="strSQL">SQL查询语句</param>
        /// <param name="dt">DataGridView的DataSource的DataTable</param>
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

        #region 保存数据表所做的更改（带事务）
        /// <summary>
        /// 保存数据表所做的更改（带事务）
        /// </summary>
        /// <param name="conn">SqlTransaction</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="strSQL">需要更新的表的SQL语句</param>
        /// <param name="dt">需要更新的DataTable</param>
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

        #region 检测是否有未保存的更改（用于窗体关闭时）
        /// <summary>
        /// 检测是否有未保存的更改（用于窗体关闭时）
        /// </summary>
        /// <param name="table">用于检测是否有更改的DataTable</param>
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

        #region 清空网格控件
        /// <summary>
        /// 清空网格控件
        /// </summary>
        /// <param name="gdv">DataGridView 控件</param>
        public static void ClearDataGridView(DataGridView gdv)
        {
            while (gdv.Columns.Count > 0)
            {
                gdv.Columns.Remove(gdv.Columns[0].Name);
            }

            gdv.DataSource = null;
        }

        #endregion

        #region 验证网格中的输入是否合法
        #region 返回窗体需要验证的列的信息（因各窗体情况不同，此处给出空的列表）以前再基类中，现在隐藏
        ///// <summary>
        ///// 返回窗体需要验证的列的信息
        ///// </summary>
        ///// <returns></returns>
        //public virtual ValidateColumn[] GetValidateColumnsList()
        //{
        //    List<ValidateColumn> lstValiCols = new List<ValidateColumn>();

        //    return lstValiCols.ToArray();
        //}
        #endregion

        #region 拿到需要验证的列的列名的字符串列表
        /// <summary>
        /// 拿到需要验证的列的列名的字符串列表
        /// </summary>
        /// <param name="ValidateColumns">需要验证的列及其规则的集合</param>
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

        #region 验证网格中的单元格输入是否合法
        /// <summary>
        /// 验证网格中的单元格输入是否合法
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="e">单元格数据源</param>
        /// <param name="ValidateColumns">验证条件集合</param>
        public static void ValidateKey(DataGridView dgv, DataGridViewCellEventArgs e, ValidateColumn[] ValidateColumns)
        {
            int ErrFalg = 0;//初时认为单元格没有验证错误

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
                                    dgv[e.ColumnIndex, e.RowIndex].ErrorText = "当前已有相同的" + ValidateCol.ColHeadText;
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
                                dgv[e.ColumnIndex, e.RowIndex].ErrorText = ValidateCol.ColHeadText + "不能为空";
                                ErrFalg = 1;
                            }
                        }

                        break;
                }
            }

            //如果此时ErrFalg还是为0，则说明此单元格确实无验证错误
            if (ErrFalg == 0)
            {
                dgv[e.ColumnIndex, e.RowIndex].ErrorText = "";
            }
        }
        #endregion

        #region 验证网格中某一行的所有列的所有输入是否合法
        /// <summary>
        /// 验证网格中的所有输入是否合法
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="e">单元格数据源</param>
        /// <param name="ValidateColumns">验证条件集合</param>
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

        #region 验证网格中的所有输入是否合法
        /// <summary>
        /// 验证网格中的所有输入是否合法
        /// </summary>
        /// <param name="dgv">DataGridView 控件</param>
        /// <param name="ValidateColsNames">需要验证的列的列名字符串数组</param>
        /// <param name="ValidateColumns">验证条件集合</param>
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

        #region 使字符串参数化
        /// <summary>
        /// 使字符串参数化
        /// </summary>
        /// <param name="String">原字符串</param>
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

        #region 将表的某一列作为一个列表返回（列表类型为泛型，类型必须与对应列的类型相一致）
        /// <summary>
        /// 将表的某一列作为一个列表返回
        /// （列表类型为泛型，类型必须与对应列的类型相一致）
        /// </summary>
        /// <typeparam name="T">返回列表的类型</typeparam>
        /// <param name="dt">DataTable</param>
        /// <param name="Col">需要返回的列</param>
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

        #region 测试字符串是否是一个数值（浮点型）
        /// <summary>
        /// 测试字符串是否是一个数值（浮点型）
        /// </summary>
        /// <param name="Value">待检验的字符串</param>
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

        #region 获得某个包含中英文的字符串的非Unicode实际长度
        /// <summary>
        /// 获得某个包含中英文的字符串的非Unicode实际长度
        /// </summary>
        /// <param name="Value">被测字符串</param>
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

        #region 执行一条无返回值的SQL命令

        #region 执行一条无返回值的SQL命令（不带事务）
        /// <summary>
        /// 执行一条无返回值的SQL命令（不带事务）
        /// </summary>
        /// <param name="ConnStr">连接字符串</param>
        /// <param name="sqlCommand">SQL命令</param>
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

        #region 执行一条无返回值的SQL命令（带事务）
        /// <summary>
        /// 执行一条无返回值的SQL命令（带事务）
        /// </summary>
        /// <param name="conn">SqlConnection</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="sqlCommand">SQL命令</param>
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

        #region 检验网格中是否有单元格的ErrorText不为空
        /// <summary>
        /// 检验网格中是否有单元格的ErrorText不为空
        /// </summary>
        /// <param name="dgv">DataGridView网格</param>
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

        #region 返回ASCII码
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

        #region Solomon密码加密
        /// <summary>
        /// Solomon密码加密
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

        #region 通用Message框
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
