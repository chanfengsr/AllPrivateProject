// ==================================================================================
//
//	文件名(File Name):		
//
//	功能描述(Description):	通用函数类
//
//	数据表(Tables):			
//
//	作者(Author):			王煜
//
//	日期(Create Date):		2010-2-16
//
//	修改日期(Alter Date):	
//
//	备注(Remark):			
//
// ==================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace StockExplore
{
    /// <summary>系统公共函数
    /// </summary>
    public class SysFunction
    {
        private const string EncryptKey = "ChanFengSanRen026";

        #region 获得数据库系统时间

        /// <summary>获得数据库系统时间
        /// </summary>
        /// <param name="connection">SQLServer 连接</param>
        /// <returns></returns>
        public static DateTime GetServerDateTime(SqlConnection connection)
        {
            return (DateTime)SQLHelper.ExecuteScalar("SELECT GETDATE()", CommandType.Text, connection);
        }

        /// <summary>获得数据库系统时间（带事务）
        /// </summary>
        /// <param name="connection">SQLServer 连接</param>
        /// <param name="transaction">SQLServer 事务</param>
        /// <returns></returns>
        public static DateTime GetServerDateTime(SqlConnection connection, SqlTransaction transaction)
        {
            return (DateTime)SQLHelper.ExecuteScalar("SELECT GETDATE()", CommandType.Text, connection, transaction);
        }

        #endregion

        #region 返回字符串当前日期时间

        /// <summary>返回字符串当前日期时间
        /// </summary>
        /// <param name="format">标准或自定义日期和时间格式的字符串，默认（yyyy-MM-dd HH:mm:ss）</param>
        /// <param name="needParentheses">是否需要括号包围，默认（无括号）</param>
        /// <returns></returns>
        public static string GetStandDataTimeString(string format = "yyyy-MM-dd HH:mm:ss", bool needParentheses = false)
        {
            if (needParentheses)
                return Parenthesis(DateTime.Now.ToString(format));
            else
                return DateTime.Now.ToString(format);
        }

        #endregion 返回字符串当前日期时间

        #region 使字符串参数化

        /// <summary>使字符串参数化
        /// </summary>
        /// <param name="String">原字符串</param>
        /// <param name="isNChar">是否要在前一个单引号前加“N”</param>
        /// <returns></returns>
        public static string SParm(string String, bool isNChar = false)
        {
            if (String == null) throw new ArgumentNullException("String");

            if (isNChar)
                return " N'" + String.Replace("'", "''") + "' ";

            return " '" + String.Replace("'", "''") + "' ";
        }

        /// <summary>使字符串参数化
        /// </summary>
        /// <param name="aString">原字符串数组</param>
        /// <param name="isNChar">是否要在前一个单引号前加“N”</param>
        /// <returns></returns>
        public static string SParm(string[] aString, bool isNChar = false)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string str in aString)
                sb.Append(SParm(str, isNChar) + ",");

            return sb.ToString().TrimEnd(',');
        }

        #endregion

        #region 将表的某一列作为一个列表返回（列表类型为泛型，类型必须与对应列的类型相一致）

        /// <summary>
        /// 将表的某一列作为一个列表返回
        /// （列表类型为泛型，类型必须与对应列的类型相一致）
        /// </summary>
        /// <typeparam name="T">返回列表的类型</typeparam>
        /// <param name="dt">DataTable</param>
        /// <param name="colIndex">需要返回的列的Index</param>
        /// <returns></returns>
        public static IEnumerable<T> GetColList<T>(DataTable dt, int colIndex)
        {
            //for (int i = 0; i < dt.Rows.Count; i++)
            //    yield return (T)(dt.Rows[i][colIndex]);

            return dt.Rows.Cast<DataRow>().Select<DataRow, T>(row => (T)row[colIndex]);
        }

        /// <summary>
        /// 将表的某一列作为一个列表返回
        /// （列表类型为泛型，类型必须与对应列的类型相一致）
        /// </summary>
        /// <typeparam name="T">返回列表的类型</typeparam>
        /// <param name="dt">DataTable</param>
        /// <param name="colName">需要返回的列的名称</param>
        /// <returns></returns>
        public static IEnumerable<T> GetColList<T>(DataTable dt, string colName)
        {
            //for (int i = 0; i < dt.Rows.Count; i++)
            //    yield return (T) (dt.Rows[i][colName]);

            return dt.Rows.Cast<DataRow>().Select<DataRow, T>(row => (T)row[colName]);
        }

        #endregion 将表的某一列作为一个列表返回（列表类型为泛型，类型必须与对应列的类型相一致）

        #region 将列表数据转换为字符串参数

        /// <summary>
        /// 将列表数据转换为字符串参数
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="lstParms">任意数据类型的参数集</param>
        /// <param name="needSParm">是否需要两边加单引号</param>
        /// <returns></returns>
        public static string CastToSQLParmString<T>(List<T> lstParms, bool needSParm)
        {
            StringBuilder sb = new StringBuilder();
            string retVal = "";

            if (lstParms.Count > 0)
            {
                foreach (T parm in lstParms)
                    if (needSParm)
                        sb.Append(SysFunction.SParm(parm.ToString()) + ",");
                    else
                        sb.Append(parm.ToString() + ",");

                retVal = sb.ToString();
                retVal = retVal.Substring(0, retVal.Length - 1);
            }

            return retVal;
        }

        #endregion 将列表数据转换为字符串参数

        #region 将表中的某两列作为Dictionary返回

        /// <summary>
        /// 将表中的某两列作为Dictionary返回
        /// </summary>
        /// <typeparam name="T1">Key的泛型</typeparam>
        /// <typeparam name="T2">Value的泛型</typeparam>
        /// <param name="table">Datatable</param>
        /// <param name="keyColIndex">作为Key的列下标</param>
        /// <param name="valueColIndex">作为Value的列下标</param>
        /// <returns></returns>
        public static Dictionary<T1, T2> GetColDictionary<T1, T2>(DataTable table, int keyColIndex, int valueColIndex)
        {
            Dictionary<T1, T2> retVal = new Dictionary<T1, T2>();

            if (keyColIndex != -1 && valueColIndex != -1 &&
                table.Columns.Count > keyColIndex && table.Columns.Count > valueColIndex)
            {
                foreach (DataRow dr in table.Rows)
                {
                    try
                    {
                        object objColKey = null;
                        object objColValue = null;
                        T1 tKey;
                        T2 tValue;
                        try
                        {
                            if (table.Columns[keyColIndex].DataType.FullName == "System.Type")
                                objColKey = dr[keyColIndex].ToString();
                            else
                                objColKey = (T1)dr[keyColIndex];

                            if (table.Columns[valueColIndex].DataType.FullName == "System.Type")
                                objColValue = dr[valueColIndex].ToString();
                            else
                                objColValue = (T2)dr[valueColIndex];
                        }
                        catch (Exception)
                        {
                            objColKey = dr[keyColIndex].ToString();
                            objColValue = dr[valueColIndex].ToString();
                        }
                        finally
                        {
                            tKey = (T1)objColKey;
                            tValue = (T2)objColValue;
                        }

                        if (!retVal.ContainsKey(tKey))
                        {
                            retVal.Add(tKey, tValue);
                        }
                    }
                    catch (Exception) {}
                }
            }

            return retVal;
        }

        /// <summary>
        /// 将表中的某两列作为Dictionary返回
        /// </summary>
        /// <typeparam name="T1">Key的泛型</typeparam>
        /// <typeparam name="T2">Value的泛型</typeparam>
        /// <param name="table">Datatable</param>
        /// <param name="keyColName">作为Key的列名</param>
        /// <param name="valueColName">作为Value的列名</param>
        /// <returns></returns>
        public static Dictionary<T1, T2> GetColDictionary<T1, T2>(DataTable table, string keyColName, string valueColName)
        {
            Dictionary<T1, T2> retVal = new Dictionary<T1, T2>();

            if (table.Columns.Contains(keyColName) && table.Columns.Contains(valueColName))
            {
                int intKeyIndex = -1, intValIndex = -1;
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (table.Columns[i].ColumnName.Trim().ToLower() == keyColName.Trim().ToLower())
                        intKeyIndex = i;

                    if (table.Columns[i].ColumnName.Trim().ToLower() == valueColName.Trim().ToLower())
                        intValIndex = i;
                }

                retVal = GetColDictionary<T1, T2>(table, intKeyIndex, intValIndex);
            }

            return retVal;
        }

        #endregion

        #region 测试字符串是否是一个数值

        /// <summary>测试字符串是否是一个浮点型数值
        /// </summary>
        /// <param name="value">待检验的字符串</param>
        /// <returns></returns>
        public static bool IsFloatValue(string value)
        {
            bool retVal = false;
            try
            {
                float flt = float.Parse(value);

                retVal = true;
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }

        /// <summary>测试字符串是否是一个整型数值
        /// </summary>
        /// <param name="value">待检验的字符串</param>
        /// <returns></returns>
        public static bool IsIntValue(string value)
        {
            bool retVal = false;
            try
            {
                int iVal = int.Parse(value);

                retVal = true;
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }

        #endregion

        #region 正则表达式验证值

        /// <summary>验证Email地址
        /// </summary>
        /// <param name="emailAddress">Email地址</param>
        /// <returns></returns>
        public static bool VerifyEmailAddress(string emailAddress)
        {
            return Regex.IsMatch(emailAddress, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$");
        }

        #endregion 正则表达式验证值

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

        #region 在命令行中实行退格键

        /// <summary>
        /// 在命令行中实行退格键
        /// </summary>
        /// <param name="previousObject">前一个显示的内容（用于测长度）</param>
        public static void BackspaceInConsole(object previousObject)
        {
            try
            {
                int length = previousObject.ToString().Length;

                for (int i = 0; i < length; i++)
                    Console.Write("\b \b");
                //Console.Write(Keys.Back);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 在TextBox中实行退格键
        /// </summary>
        /// <param name="previousObject">前一个显示的内容（用于测长度）</param>
        /// <param name="textBox">对应的TextBox</param>
        public static void BackspaceInConsole(object previousObject, TextBox textBox)
        {
            try
            {
                int length = previousObject.ToString().Length;

                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion 在命令行中实行退格键

        #region 返回ASCII码

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static int GetAscII(char character)
        {
            System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();

            return (int)asciiEncoding.GetBytes(new char[] {character})[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int[] GetAscII(string text)
        {
            System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
            byte[] bytes = asciiEncoding.GetBytes(text);

            return Array.ConvertAll<byte, int>(bytes, new Converter<byte, int>(ByteToInt));
        }

        private int ByteToInt(byte byt)
        {
            return (int)byt;
        }

        #endregion

        #region 两边加指定符号

        /// <summary>
        /// 两边加指定符号
        /// </summary>
        /// <param name="String">原字符串</param>
        /// <param name="leftSymbol">左边符号</param>
        /// <param name="rightSymbol">右边符号</param>
        /// <returns></returns>
        public static string Parenthesis(string String, string leftSymbol = "(", string rightSymbol = ")")
        {
            return leftSymbol + String + rightSymbol;
        }

        #endregion 两边加指定符号

        #region 转换String类型到其他类型

        /// <summary>
        /// 转换String类型到其他类型
        /// </summary>
        /// <param name="type">转换后的类型</param>
        /// <param name="value">待转换的字符串</param>
        /// <returns></returns>
        public static object ConvertStringType(Type type, string value)
        {
            if (type == typeof (string))
            {
                return value;
            }

            //转换已知的格式
            if (type == typeof (System.Boolean))
            {
                switch (value)
                {
                    case "1":
                        value = "true";
                        break;
                    default:
                        value = "false";
                        break;
                }
            }

            MethodInfo parseMethod = null;

            foreach (MethodInfo mi in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
            {
                if (mi.Name == "Parse" && mi.GetParameters().Length == 1)
                {
                    parseMethod = mi;
                    break;
                }
            }

            if (parseMethod == null)
            {
                throw new ArgumentException(string.Format("Type: {0} has not Parse static method!", type));
            }

            return parseMethod.Invoke(null, new object[] {value});
        }

        #endregion

        #region 根据字符串获取对应类型(Type)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetTypeByString(string type)
        {
            switch (type.ToLower())
            {
                case "bool":
                    return Type.GetType("System.Boolean", true, true);
                case "byte":
                    return Type.GetType("System.Byte", true, true);
                case "sbyte":
                    return Type.GetType("System.SByte", true, true);
                case "char":
                    return Type.GetType("System.Char", true, true);
                case "decimal":
                    return Type.GetType("System.Decimal", true, true);
                case "double":
                    return Type.GetType("System.Double", true, true);
                case "float":
                    return Type.GetType("System.Single", true, true);
                case "int":
                    return Type.GetType("System.Int32", true, true);
                case "uint":
                    return Type.GetType("System.UInt32", true, true);
                case "long":
                    return Type.GetType("System.Int64", true, true);
                case "ulong":
                    return Type.GetType("System.UInt64", true, true);
                case "object":
                    return Type.GetType("System.Object", true, true);
                case "short":
                    return Type.GetType("System.Int16", true, true);
                case "ushort":
                    return Type.GetType("System.UInt16", true, true);
                case "string":
                    return Type.GetType("System.String", true, true);
                case "date":
                case "datetime":
                    return Type.GetType("System.DateTime", true, true);
                case "guid":
                    return Type.GetType("System.Guid", true, true);
                default:
                    return Type.GetType(type, true, true);
            }
        }

        #endregion 根据字符串获取对应类型(Type)

        #region 去掉字符串外面的包围

        /// <summary>
        /// 去掉字符串外面的包围
        /// </summary>
        /// <param name="origString">原字符串</param>
        /// <param name="removeString">要剪掉的字符串</param>
        /// <returns></returns>
        public static string RemoveSurround(string origString, string removeString)
        {
            return origString.Trim(removeString.ToCharArray());
        }

        /// <summary>
        /// 去掉字符串外面的包围
        /// </summary>
        /// <param name="origString">原字符串</param>
        /// <param name="startRemoveString">要剪掉的起始字符串</param>
        /// <param name="endRemoveString">要剪掉的结束字符串</param>
        /// <returns></returns>
        public static string RemoveSurround(string origString, string startRemoveString, string endRemoveString)
        {
            string retVal = origString;
            while (retVal.StartsWith(startRemoveString) && retVal.EndsWith(endRemoveString))
            {
                retVal = retVal.Substring(startRemoveString.Length, retVal.Length - startRemoveString.Length - endRemoveString.Length);
            }

            return retVal;
        }

        #endregion

        #region 从数据库设置表默认值

        /// <summary>
        /// 从数据库设置表默认值
        /// </summary>
        /// <param name="origTable">初始DataTable</param>
        /// <param name="tableName">数据库物理表名</param>
        /// <param name="cnn">SqlConnection</param>
        public static void SetDatatableDefaultValue(ref DataTable origTable, string tableName, SqlConnection cnn)
        {
            #region 原始SQL语句

            /*
SELECT A.name,B.text
FROM syscolumns A JOIN syscomments B ON A.cdefault = B.id 
JOIN sysobjects C ON A.id = C.id AND C.xtype = 'U' AND C.name <> 'dtproperties'
WHERE C.name = 'Pub_Inventory'
            */

            #endregion

            string strSQL = string.Format("SELECT A.name,B.text " + Environment.NewLine
                                          + "FROM syscolumns A JOIN syscomments B ON A.cdefault = B.id  " + Environment.NewLine
                                          + "JOIN sysobjects C ON A.id = C.id AND C.xtype = 'U' AND C.name <> 'dtproperties' " + Environment.NewLine
                                          + "WHERE C.name = {0} ", SParm(tableName));
            //DataTable dtSchemaTable = SqlHelper.GetSchemaTable(tableName, cnn);
            DataTable dtColDefaultValue = SQLHelper.ExecuteDataTable(strSQL, CommandType.Text, cnn);

            Dictionary<string, string> dicColDefaultValue = GetColDictionary<string, string>(dtColDefaultValue, "name", "text");

            foreach (DataColumn dc in origTable.Columns)
            {
                if (dicColDefaultValue.ContainsKey(dc.ColumnName))
                {
                    try
                    {
                        strSQL = "SELECT " + dicColDefaultValue[dc.ColumnName].Trim();
                        object defaultValue = SQLHelper.ExecuteScalar(strSQL, CommandType.Text, cnn);

                        dc.DefaultValue = defaultValue;
                    }
                    catch (Exception) {}
                }
            }
        }

        #endregion 从数据库设置表默认值

        #region 保存数据表所做的更改

        #region 保存数据表所做的更改（不带事务）

        /// <summary>
        /// 保存数据表所做的更改（不带事务）
        /// </summary>
        /// <param name="connection">SqlConnection</param>
        /// <param name="strSQL">SQL查询语句</param>
        /// <param name="dt">DataGridView的DataSource的DataTable</param>
        public static void SaveChanges(SqlConnection connection, string strSQL, DataTable dt)
        {
            SQLHelper.SaveChanges(connection, strSQL, dt);
        }

        #region 保存多数据表所做的更改（不带事务）

        /// <summary>保存多数据表所做的更改（不带事务）
        /// </summary>
        /// <param name="connection">SqlConnection</param>
        /// <param name="cmdSQLs">需要更新的表的SQL语句集</param>
        /// <param name="dts">需要更新的DataTable集</param>
        public static void SaveChanges(SqlConnection connection, string[] cmdSQLs, DataTable[] dts)
        {
            SQLHelper.SaveChanges(connection, cmdSQLs, dts);
        }

        #endregion 保存多数据表所做的更改（不带事务）

        #endregion

        #region 保存数据表所做的更改（带事务）

        /// <summary>
        /// 保存数据表所做的更改（带事务）
        /// </summary>
        /// <param name="connection">SqlConnection</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="strSQL">需要更新的表的SQL语句</param>
        /// <param name="dt">需要更新的DataTable</param>
        public static void SaveChanges(SqlConnection connection, SqlTransaction trans, string strSQL, DataTable dt)
        {
            SQLHelper.SaveChanges(connection, trans, strSQL, dt);
        }

        #region 保存多数据表所做的更改（带事务）

        /// <summary>保存多数据表所做的更改
        /// </summary>
        /// <param name="connection">SqlConnection</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="commandTexts">需要更新的表的SQL语句集</param>
        /// <param name="dts">需要更新的DataTable集</param>
        public static void SaveChanges(SqlConnection connection, SqlTransaction trans, string[] commandTexts, DataTable[] dts)
        {
            SQLHelper.SaveChanges(connection, trans, commandTexts, dts);
        }

        #endregion 保存多数据表所做的更改（带事务）

        #endregion

        #endregion

        #region 判断表是否有更改

        /// <summary>
        /// 判断表是否有更改
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <returns></returns>
        public static bool TableChanged(DataTable dataTable)
        {
            try
            {
                if (dataTable.GetChanges() != null)
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

        #region 将二维数组转换成表

        /// <summary>
        /// 将二维数组转换成表
        /// </summary>
        /// <param name="aobj">二维数组对象</param>
        /// <param name="tableName">表名</param>
        /// <param name="colNames">列名集合</param>
        /// <returns></returns>
        public static DataTable ConvertArrayToDatatable(object[][] aobj, string tableName, params string[] colNames)
        {
            DataTable retVal = new DataTable(tableName);

            //生成列
            if (aobj != null)
            {
                for (int i = 0; i < aobj[0].Length; i++)
                {
                    Type type = aobj[0][i].GetType();
                    string colName = colNames.Length > i ? colNames[i] : Guid.NewGuid().ToString();

                    DataColumn col = new DataColumn(colName, type);

                    retVal.Columns.Add(col);
                }
            }

            //填充数据
            for (int i = 0; i < aobj.GetLength(0); i++)
            {
                DataRow dr = retVal.NewRow();

                for (int j = 0; j < aobj[i].Length; j++)
                    dr[j] = aobj[i][j];

                retVal.Rows.Add(dr);
            }

            return retVal;
        }

        #endregion 将二维数组转换成表

        #region 方法实现把dgv里的数据完整的复制到一张内存表

        /// <summary>
        /// 方法实现把dgv里的数据完整的复制到一张内存表
        /// </summary>
        /// <param name="dgv">dgv控件作为参数</param>
        /// <returns>返回临时内存表</returns>
        public static DataTable GetDataGridViewToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
                dt.Columns.Add(dgv.Columns[count].Name.ToString(), dgv.Columns[count].ValueType);

            for (int iRow = 0; iRow < dgv.Rows.Count; iRow++)
            {
                DataRow dr = dt.NewRow();
                for (int iCol = 0; iCol < dgv.Columns.Count; iCol++)
                {
                    dr[iCol] = dgv.Rows[iRow].Cells[iCol].Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion 方法实现把dgv里的数据完整的复制到一张内存表

        #region 多线程执行委托方法

        /// <summary>多线程执行方法委托
        /// </summary>
        /// <param name="act">委托</param>
        /// <example>MultithreadedExecution(delegate() {/*执行内容*/ });</example>
        public static void MultithreadedExecution(Action act)
        {
            ThreadStart tds = new ThreadStart(act);
            Thread td = new Thread(tds);
            td.Start();
        }

        /// <summary>多线程执行方法委托
        /// </summary>
        /// <param name="act">委托</param>
        /// <param name="parameter">方法参数</param>
        /// <example>MultithreadedExecution(delegate() {/*执行内容*/ },"");</example>
        public static void MultithreadedExecution(Action act, object parameter)
        {
            ThreadStart tds = new ThreadStart(act);
            Thread td = new Thread(tds);
            td.Start(parameter);
        }

        #endregion 多线程执行委托方法

        #region 调用DOS执行CMD方法

        /// <summary>调用DOS执行CMD方法
        /// </summary>
        /// <param name="command">参数</param>
        /// <returns></returns>
        public static string RunCmd(string command = "")
        {
            //实例一个Process类，启动一个独立进程  
            Process p = new Process();

            //Process类有一个StartInfo属性，这个是ProcessStartInfo类，包括了一些属性和方法，下面我们用到了他的几个属性：  

            p.StartInfo.FileName = "cmd.exe"; //设定程序名  
            p.StartInfo.Arguments = "/c " + command; //设定程式执行参数  
            p.StartInfo.UseShellExecute = false; //关闭Shell的使用  
            p.StartInfo.RedirectStandardInput = true; //重定向标准输入  
            p.StartInfo.RedirectStandardOutput = true; //重定向标准输出  
            p.StartInfo.RedirectStandardError = true; //重定向错误输出  
            p.StartInfo.CreateNoWindow = true; //设置不显示窗口  

            p.Start(); //启动  
            p.StandardInput.WriteLine("exit"); //不过要记得加上Exit要不然下一行程式执行的时候会当机  

            return p.StandardOutput.ReadToEnd(); //从输出流取得命令执行结果  

        }

        #endregion 调用DOS执行CMD方法

        #region 字符串加解密

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OriginalValue"></param>
        /// <returns></returns>
        public static string StringEncrypt(string OriginalValue)
        {
            SysSecurityFactory _security = new SysSecurityFactory();
            byte[] key = System.Text.Encoding.Default.GetBytes(EncryptKey);
            return _security.AESEncrypt(OriginalValue, key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EncryptedValue"></param>
        /// <returns></returns>
        public static string StringDecrypt(string EncryptedValue)
        {
            SysSecurityFactory _security = new SysSecurityFactory();
            byte[] key = System.Text.Encoding.Default.GetBytes(EncryptKey);
            return _security.AESDecrypt(EncryptedValue, key);
        }

        #endregion 字符串加解密

        #region 写本地日志

        /// <summary>
        /// syslog\yyyy-MM\ddDay.log
        /// </summary>
        /// <param name="path"></param>
        /// <param name="module"></param>
        /// <param name="functionName"></param>
        /// <param name="message"></param>
        /// <param name="level">0 none,1 normal [Info],2 warning [Warn△],-1 error[Err▲]</param>
        public static void WriteLocalLogFile(string path, string module, string functionName, string message, int level = 0)
        {
            try
            {
                string folder_SysLog = "SysLog\\" + DateTime.Now.ToString("yyyy-MM");
                string fileName_SysLog = DateTime.Now.ToString("dd") + "Day.log";

                if (path.Substring(path.Length - 1, 1) != "\\")
                    path += "\\";

                if (!Directory.Exists(path + folder_SysLog))
                    Directory.CreateDirectory(path + folder_SysLog);

                string str;

                switch (level)
                {
                    case 1:
                        str = "[Info]";
                        break;
                    case 2:
                        str = "[Warn△]";
                        break;
                    case -1:
                        str = "[Err▲]";
                        break;
                    default:
                        str = "";
                        break;
                }

                if (module != "")
                    str += "[module:" + module + "]";

                if (functionName != "")
                    str += "[function:" + functionName + "]";

                FileStream fs = new FileStream(path + folder_SysLog + "\\" + fileName_SysLog, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                sw.WriteLine(DateTime.Now.ToString("HH:mm:ss") + ":" + str);
                sw.WriteLine("         " + message);
                sw.WriteLine("-----------------------------------------------------------------------------------------------------");

                sw.Close();
                fs.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("module:Sysfunction\nfunction:WriteLocalLogFile\n" + err.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion 写本地日志

        #region 转换文件至byte[]类型

        /// <summary>转换文件至byte[]类型
        /// </summary>  
        /// <param name="fileFullName">文件完整名称.</param>  
        /// <returns></returns>  
        public static byte[] File2Byte(string fileFullName)
        {
            if (fileFullName == null) throw new ArgumentNullException("fileFullName");
            FileStream fs = null;

            try
            {
                fs = new FileStream(fileFullName, FileMode.Open, FileAccess.Read);

                byte[] buffur = new byte[fs.Length];
                fs.Read(buffur, 0, (int)fs.Length);

                return buffur;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        #endregion 转换文件至byte[]类型

        #region 转换字符串为Html字符串

        /// <summary>转换字符串为Html字符串
        /// </summary>
        /// <param name="origStr">原始字符串</param>
        /// <param name="withDiv">是否两边包 DIV</param>
        /// <returns></returns>
        public static string ConvertSpecialChar2Html(string origStr, bool withDiv)
        {
            if (string.IsNullOrEmpty(origStr))
                return withDiv ? "<DIV>&nbsp;</DIV>" : string.Empty;

            string strDivStr = origStr.StartsWith("\t") ? "<DIV style=\"TEXT-INDENT: 2em\">" : "<DIV>";

            return
                ( withDiv ? strDivStr : "" ) +
                origStr.Replace("<", "&lt;")
                       .Replace(">", "&gt;")
                       .Replace(" ", "&nbsp;")
                       .Replace("\t", origStr.StartsWith("\t") ? "&nbsp;" : "&nbsp;&nbsp;&nbsp;&nbsp;")
                       .Replace(Environment.NewLine, "<BR>") +
                ( withDiv ? "</DIV>" : "" );
        }

        #endregion 转换字符串为Html字符串

        #region 检验文件/文件夹写权限（使用试写方式）

        /// <summary>检测文件的写权限
        /// </summary>
        /// <param name="fileFullName">文件名全名</param>
        /// <returns></returns>
        public static bool CheckFileWritPermission(string fileFullName)
        {
            string fileEnd = Guid.NewGuid().ToString().Substring(0, 8);
            fileFullName += fileEnd;

            try
            {
                File.WriteAllText(fileFullName, "");
                File.Delete(fileFullName);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>检测文件夹的写权限
        /// </summary>
        /// <param name="folderName">文件夹全名</param>
        /// <returns></returns>
        public static bool CheckFolderWritPermission(string folderName)
        {
            string fileEnd = Guid.NewGuid().ToString().Substring(0, 8);
            string fileName = folderName.TrimEnd('\\') + "\\" + fileEnd;

            return CheckFileWritPermission(fileName);
        }

        #endregion 检验文件/文件夹读写权限（使用试写方式）
    }
}