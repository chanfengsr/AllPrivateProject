// ==================================================================================
//
//	文件名(File Name):		
//
//	功能描述(Description):	实体类通用SQL命令生成类
//
//	数据表(Tables):			
//
//	作者(Author):			王煜
//
//	日期(Create Date):		2013-4-16
//
//	修改日期(Alter Date):	
//
//	备注(Remark):			
//
// ==================================================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StockExplore
{
    /// <summary>实体类通用SQL命令生成类
    /// </summary>
    public class ModelHelp
    {
        /// <summary>用表数据填充实体类
        /// </summary>
        /// <typeparam name="T">实体类 类型</typeparam>
        /// <param name="dataSource">数据源</param>
        /// <param name="dicConverter">用于对应某字段转换的函数集 (要转换的字段名, 相应的转换函数)</param>
        /// <returns></returns>
        public static List<T> GenerateList<T>(DataTable dataSource,
                                              Dictionary<string, Func<object, object>> dicConverter = null)
        {
            if (dataSource == null) throw new ArgumentNullException("dataSource");

            List<T> retVal = new List<T>(dataSource.Rows.Count);
            List<string> lstColNames = dataSource.Columns.Cast<DataColumn>().Select<DataColumn, string>(col => col.ColumnName).ToList();
            List<PropertyInfo> lstPropInfo = typeof(T).GetProperties().Where(p => lstColNames.Contains(p.Name)).ToList();

            foreach (DataRow row in dataSource.Rows)
            {
                T mod = Activator.CreateInstance<T>();

                foreach (PropertyInfo propInfo in lstPropInfo)
                    if (dicConverter == null || !dicConverter.ContainsKey(propInfo.Name))
                        if (row[propInfo.Name] == DBNull.Value)
                            propInfo.SetValue(mod, null, null);
                        else
                            propInfo.SetValue(mod, row[propInfo.Name], null);
                    else
                        propInfo.SetValue(mod, dicConverter[propInfo.Name](row[propInfo.Name]), null);

                retVal.Add(mod);
            }

            return retVal;
        }

        /// <summary>用表上的行数据填充实体类
        /// </summary>
        /// <typeparam name="T">实体类 类型</typeparam>
        /// <param name="dataSource">数据源</param>
        /// <param name="colNames">列名集合</param>
        /// <param name="dicConverter">用于对应某字段转换的函数集 (要转换的字段名, 相应的转换函数)</param>
        /// <returns></returns>
        public static List<T> GenerateList<T>(IEnumerable<DataRow> dataSource,
                                              List<string> colNames,
                                              Dictionary<string, Func<object, object>> dicConverter = null)
        {
            if (dataSource == null) throw new ArgumentNullException("dataSource");
            if (colNames == null) throw new ArgumentNullException("colNames");

            List<T> retVal = new List<T>(dataSource.Count());
            List<string> lstColNames = colNames;
            List<PropertyInfo> lstPropInfo = typeof(T).GetProperties().Where(p => lstColNames.Contains(p.Name)).ToList();

            foreach (DataRow row in dataSource)
            {
                T mod = Activator.CreateInstance<T>();

                foreach (PropertyInfo propInfo in lstPropInfo)
                    if (dicConverter == null || !dicConverter.ContainsKey(propInfo.Name))
                        if (row[propInfo.Name] == DBNull.Value)
                            propInfo.SetValue(mod, null, null);
                        else
                            propInfo.SetValue(mod, row[propInfo.Name], null);
                    else
                        propInfo.SetValue(mod, dicConverter[propInfo.Name](row[propInfo.Name]), null);

                retVal.Add(mod);
            }

            return retVal;
        }

        /// <summary>获得类的新增命令
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="models">类实体集合</param>
        /// <param name="insertExpression">Where条件表达式（列名 + （表达式 + 参数值））; 表达式中 {@col} 为列名， {@parm} 为参数；如果有“{@parm}”，但参数值为空，则用实体类上的值</param>
        /// <param name="refColNames">参照列集合（表上的列，默认类中的属性都是表上的列）</param>
        /// <param name="tableName">实际表名，默认用类名</param>
        /// <returns></returns>
        public static SqlCommand GenerateInsertCommand<T>(List<T> models,
                                                          Dictionary<string, TupleValue<string, object>> insertExpression = null,
                                                          List<string> refColNames = null,
                                                          string tableName = null)
        {
            if (models == null || models.Count == 0) throw new ArgumentNullException("models");
            if (refColNames != null && refColNames.Count < 1) throw new ArgumentException("refColNames has no value!");

            SqlCommand retVal = new SqlCommand();
            Type type = typeof(T);
            PropertyInfo[] propInfos = type.GetProperties();
            string tabName = tableName ?? type.Name;
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbParms = new StringBuilder();
            StringBuilder sbSql = new StringBuilder();
            List<SqlParameter> lstParms = new List<SqlParameter>();
            int parmId = 0;
            bool firstField;

            if (insertExpression == null)
                insertExpression = new Dictionary<string, TupleValue<string, object>>();

            foreach (T model in models)
            {
                firstField = true;
                sbFields = new StringBuilder();
                sbParms = new StringBuilder();
                foreach (PropertyInfo propInfo in propInfos)
                {
                    if (refColNames != null && !refColNames.Contains(propInfo.Name))
                        continue;

                    object value = propInfo.GetValue(model, null) ?? DBNull.Value;

                    if (firstField)
                        firstField = false;
                    else
                    {
                        sbFields.Append(",");
                        sbParms.Append(",");
                    }

                    sbFields.Append("[" + propInfo.Name + "]");

                    if (insertExpression.ContainsKey(propInfo.Name))
                    {
                        TupleValue<bool, string> expEntity = GetExpressionEntity(propInfo.Name, insertExpression[propInfo.Name].Value1, parmId);
                        if (expEntity.Value1)
                            if (insertExpression[propInfo.Name].Value2 != null)
                                lstParms.Add(new SqlParameter("@" + parmId++, insertExpression[propInfo.Name].Value2));
                            else if (value != DBNull.Value)
                                lstParms.Add(new SqlParameter("@" + parmId++, value));
                            else
                                lstParms.Add(new SqlParameter("@" + parmId++, "NULL"));

                        sbParms.Append(expEntity.Value2);
                    }
                    else
                    {
                        if (value == DBNull.Value)
                        {
                            sbParms.Append("NULL");
                        }
                        else
                        {
                            sbParms.Append("@" + parmId);
                            lstParms.Add(new SqlParameter("@" + parmId, value));
                            parmId++;
                        }
                    }
                }

                if (sbFields.Length > 0)
                    sbSql.AppendLine("INSERT INTO " + tabName + "(" + sbFields + ") VALUES(" + sbParms + ");");
            }

            if (sbSql.Length == 0)
                return null;

            retVal.CommandType = CommandType.Text;
            retVal.CommandText = sbSql.ToString();
            if (lstParms.Count > 0)
                SQLHelper.AttachParameters(retVal, lstParms.ToArray());

            return retVal;
        }

        /// <summary>获得类的新增命令
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="model">类实体</param>
        /// <param name="insertExpression">Where条件表达式（列名 + （表达式 + 参数值））; 表达式中 {@col} 为列名， {@parm} 为参数；如果有“{@parm}”，但参数值为空，则用实体类上的值</param>
        /// <param name="refColNames">参照列集合（表上的列，默认类中的属性都是表上的列）</param>
        /// <param name="tableName">实际表名，默认用类名</param>
        /// <returns></returns>
        public static SqlCommand GenerateInsertCommand<T>(T model,
                                                          Dictionary<string, TupleValue<string, object>> insertExpression = null,
                                                          List<string> refColNames = null,
                                                          string tableName = null)
        {
            return GenerateInsertCommand(new List<T> { model }, insertExpression, refColNames, tableName);
        }

        /// <summary>获得类的删除命令
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="models">类实体集合</param>
        /// <param name="keyColName">用作Where条件的关键列名称集合</param>
        /// <param name="whereExpression">Where条件表达式（列名 + （表达式 + 参数值））; 表达式中 {@col} 为列名， {@parm} 为参数；如果有“{@parm}”，但参数值为空，则用实体类上的值</param>
        /// <param name="refColNames">参照列集合（表上的列，默认类中的属性都是表上的列）</param>
        /// <param name="tableName">实际表名，默认用类名</param>
        /// <returns></returns>
        public static SqlCommand GenerateDeleteCommand<T>(List<T> models,
                                                          List<string> keyColName = null,
                                                          Dictionary<string, TupleValue<string, object>> whereExpression = null,
                                                          List<string> refColNames = null,
                                                          string tableName = null)
        {
            if (models == null || models.Count == 0) throw new ArgumentNullException("models");

            SqlCommand retVal = new SqlCommand();
            Type type = typeof(T);
            PropertyInfo[] propInfos = type.GetProperties();
            string tabName = tableName ?? type.Name;
            StringBuilder sbWhereCondition = new StringBuilder();
            StringBuilder sbSql = new StringBuilder();
            List<SqlParameter> lstParms = new List<SqlParameter>();
            int parmId = 0;
            bool isFirst;

            if (whereExpression == null)
                whereExpression = new Dictionary<string, TupleValue<string, object>>();

            foreach (T model in models)
            {
                sbWhereCondition = new StringBuilder();
                isFirst = true;

                foreach (PropertyInfo propInfo in propInfos.Where(propInfo => keyColName == null || keyColName.Contains(propInfo.Name)).Where(propInfo => refColNames == null || refColNames.Contains(propInfo.Name)))
                {
                    if (isFirst) isFirst = false;
                    else sbWhereCondition.Append(" AND ");

                    object value = propInfo.GetValue(model, null) ?? DBNull.Value;

                    if (whereExpression.ContainsKey(propInfo.Name))
                    {
                        TupleValue<bool, string> expEntity = GetExpressionEntity(propInfo.Name, whereExpression[propInfo.Name].Value1, parmId);
                        if (expEntity.Value1)
                            if (whereExpression[propInfo.Name].Value2 != null)
                                lstParms.Add(new SqlParameter("@" + parmId++, whereExpression[propInfo.Name].Value2));
                            else if (value != DBNull.Value)
                                lstParms.Add(new SqlParameter("@" + parmId++, value));
                            else
                                lstParms.Add(new SqlParameter("@" + parmId++, "NULL"));

                        sbWhereCondition.Append("[" + propInfo.Name + "]" + expEntity.Value2);
                    }
                    else
                    {
                        if (value == DBNull.Value)
                        {
                            sbWhereCondition.Append("[" + propInfo.Name + "]" + " IS NULL");
                        }
                        else
                        {
                            sbWhereCondition.Append("[" + propInfo.Name + "]" + " = @" + parmId);
                            lstParms.Add(new SqlParameter("@" + parmId, value));
                            parmId++;
                        }
                    }
                }

                if (sbWhereCondition.Length > 0)
                    sbSql.AppendLine("DELETE " + tabName + " WHERE " + sbWhereCondition + ";");
                else
                    throw new Exception("WhereCondition is null");
            }

            if (sbSql.Length == 0)
                return null;

            retVal.CommandType = CommandType.Text;
            retVal.CommandText = sbSql.ToString();
            if (lstParms.Count > 0)
                SQLHelper.AttachParameters(retVal, lstParms.ToArray());

            return retVal;
        }

        /// <summary>获得类的删除命令
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="model">类实体</param>
        /// <param name="keyColName">用作Where条件的关键列名称集合</param>
        /// <param name="whereExpression">Where条件表达式（列名 + （表达式 + 参数值））; 表达式中 {@col} 为列名， {@parm} 为参数；如果有“{@parm}”，但参数值为空，则用实体类上的值</param>
        /// <param name="refColNames">参照列集合（表上的列，默认类中的属性都是表上的列）</param>
        /// <param name="tableName">实际表名，默认用类名</param>
        /// <returns></returns>
        public static SqlCommand GenerateDeleteCommand<T>(T model,
                                                          List<string> keyColName = null,
                                                          Dictionary<string, TupleValue<string, object>> whereExpression = null,
                                                          List<string> refColNames = null,
                                                          string tableName = null)
        {
            return GenerateDeleteCommand(new List<T> { model }, keyColName, whereExpression, refColNames, tableName);
        }

        /// <summary>获得类的删除命令（直接删全表）
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="tableName">实际表名，默认用类名</param>
        /// <param name="userTruncate">用 Truncate 语句来删表</param>
        /// <returns></returns>
        public static SqlCommand GenerateDeleteCommand<T>(string tableName = null, bool userTruncate = true)
        {
            SqlCommand retVal = new SqlCommand();
            string tabName = tableName ?? typeof(T).Name;

            retVal.CommandType = CommandType.Text;
            if (userTruncate)
                retVal.CommandText = "TRUNCATE TABLE " + tabName;
            else
                retVal.CommandText = "DELETE FROM " + tabName;

            return retVal;
        }

        /// <summary>获得类的更新命令
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="models">类实体集合</param>
        /// <param name="keyColName">用作Where条件的关键列名称集合</param>
        /// <param name="needUpdateColName">需要被更新的列的列名称集合</param>
        /// <param name="setExpression">Set条件表达式（列名 + （表达式 + 参数值））; 表达式中 {@col} 为列名， {@parm} 为参数；如果有“{@parm}”，但参数值为空，则用实体类上的值</param>
        /// <param name="whereExpression">Where条件表达式（列名 + （表达式 + 参数值））; 表达式中 {@col} 为列名， {@parm} 为参数；如果有“{@parm}”，但参数值为空，则用实体类上的值</param>
        /// <param name="refColNames">参照列集合（表上的列，默认类中的属性都是表上的列）</param>
        /// <param name="tableName">实际表名，默认用类名</param>
        /// <returns></returns>
        public static SqlCommand GenerateUpdateCommand<T>(List<T> models,
                                                          List<string> keyColName = null,
                                                          List<string> needUpdateColName = null,
                                                          Dictionary<string, TupleValue<string, object>> setExpression = null,
                                                          Dictionary<string, TupleValue<string, object>> whereExpression = null,
                                                          List<string> refColNames = null,
                                                          string tableName = null)
        {
            if (models == null) throw new ArgumentNullException("models");
            if (needUpdateColName != null && refColNames != null)
                if (needUpdateColName.Count < 1 && refColNames.Count < 1)
                    throw new ArgumentException("Select statement can't be null!");

            SqlCommand retVal = new SqlCommand();
            Type type = typeof(T);
            PropertyInfo[] propInfos = type.GetProperties();
            string tabName = tableName ?? type.Name;
            StringBuilder sbSetCondition = new StringBuilder();
            StringBuilder sbWhereCondition = new StringBuilder();
            StringBuilder sbSql = new StringBuilder();
            List<SqlParameter> lstParms = new List<SqlParameter>();
            List<SqlParameter> lstLastSetParms = new List<SqlParameter>(); //标识最后的 Set 参数，用于无 Where 的语句只取最后一条
            int parmId = 0;
            bool firstSetField, firstWhrField, setField, whrField;
            TupleValue<bool, string> expEntity;

            if (setExpression == null)
                setExpression = new Dictionary<string, TupleValue<string, object>>();

            if (whereExpression == null)
                whereExpression = new Dictionary<string, TupleValue<string, object>>();

            foreach (T model in models)
            {
                firstSetField = true;
                firstWhrField = true;

                sbSetCondition = new StringBuilder();
                sbWhereCondition = new StringBuilder();
                foreach (PropertyInfo propInfo in propInfos)
                {
                    if (refColNames != null)
                        if (!refColNames.Contains(propInfo.Name))
                            continue;

                    whrField = setField = false;

                    if (keyColName == null)
                        whrField = true;
                    else if (keyColName.Contains(propInfo.Name))
                        whrField = true;

                    if (needUpdateColName == null)
                        setField = true;
                    else if (needUpdateColName.Contains(propInfo.Name))
                        setField = true;

                    if (!whrField && !setField)
                        continue;

                    object value = propInfo.GetValue(model, null) ?? DBNull.Value;

                    //组织 Set 语句
                    if (setField)
                    {
                        if (firstSetField) firstSetField = false;
                        else sbSetCondition.Append(",");

                        if (setExpression.ContainsKey(propInfo.Name))
                        {
                            expEntity = GetExpressionEntity(propInfo.Name, setExpression[propInfo.Name].Value1, parmId);
                            if (expEntity.Value1)
                                if (setExpression[propInfo.Name].Value2 != null)
                                    lstParms.Add(new SqlParameter("@" + parmId++, setExpression[propInfo.Name].Value2));
                                else if (value != DBNull.Value)
                                    lstParms.Add(new SqlParameter("@" + parmId++, value));
                                else
                                    lstParms.Add(new SqlParameter("@" + parmId++, "NULL"));

                            sbSetCondition.Append("[" + propInfo.Name + "]" + expEntity.Value2);
                        }
                        else
                        {
                            sbSetCondition.Append("[" + propInfo.Name + "]" + " = @" + parmId);
                            lstParms.Add(new SqlParameter("@" + parmId, value));
                            lstLastSetParms.Add(new SqlParameter("@" + parmId, value));
                            parmId++;
                        }
                    }

                    //组织 Where 语句
                    if (whrField)
                    {
                        if (firstWhrField) firstWhrField = false;
                        else sbWhereCondition.Append(" AND ");

                        if (whereExpression.ContainsKey(propInfo.Name))
                        {
                            expEntity = GetExpressionEntity(propInfo.Name, whereExpression[propInfo.Name].Value1, parmId);
                            if (expEntity.Value1)
                                if (whereExpression[propInfo.Name].Value2 != null)
                                    lstParms.Add(new SqlParameter("@" + parmId++, whereExpression[propInfo.Name].Value2));
                                else if (value != DBNull.Value)
                                    lstParms.Add(new SqlParameter("@" + parmId++, value));
                                else
                                    lstParms.Add(new SqlParameter("@" + parmId++, "NULL"));

                            sbWhereCondition.Append("[" + propInfo.Name + "]" + expEntity.Value2);
                        }
                        else
                        {
                            if (value == DBNull.Value)
                            {
                                sbWhereCondition.Append("[" + propInfo.Name + "]" + " IS NULL");
                            }
                            else
                            {
                                sbWhereCondition.Append("[" + propInfo.Name + "]" + " = @" + parmId);
                                lstParms.Add(new SqlParameter("@" + parmId, value));
                                parmId++;
                            }
                        }
                    }
                }

                if (sbSetCondition.Length > 0)
                    if (sbWhereCondition.Length > 0)
                        sbSql.AppendLine("UPDATE " + tabName + " SET " + sbSetCondition + " WHERE " + sbWhereCondition + ";");
                    else
                    {
                        lstParms.Clear();
                        lstParms.AddRange(lstLastSetParms);

                        sbSql = new StringBuilder();
                        sbSql.AppendLine("UPDATE " + tabName + " SET " + sbSetCondition + ";");
                    }

                lstLastSetParms.Clear();
            }

            if (sbSql.Length == 0)
                return null;

            retVal.CommandType = CommandType.Text;
            retVal.CommandText = sbSql.ToString();
            if (lstParms.Count > 0)
                SQLHelper.AttachParameters(retVal, lstParms.ToArray());

            return retVal;
        }

        /// <summary>获得类的更新命令
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="model">类实体</param>
        /// <param name="keyColName">用作Where条件的关键列名称集合</param>
        /// <param name="needUpdateColName">需要被更新的列的列名称集合</param>
        /// <param name="setExpression">Set条件表达式（列名 + （表达式 + 参数值））; 表达式中 {@col} 为列名， {@parm} 为参数；如果有“{@parm}”，但参数值为空，则用实体类上的值</param>
        /// <param name="whereExpression">Where条件表达式（列名 + （表达式 + 参数值））; 表达式中 {@col} 为列名， {@parm} 为参数；如果有“{@parm}”，但参数值为空，则用实体类上的值</param>
        /// <param name="refColNames">参照列集合（表上的列，默认类中的属性都是表上的列）</param>
        /// <param name="tableName">实际表名，默认用类名</param>
        /// <returns></returns>
        public static SqlCommand GenerateUpdateCommand<T>(T model,
                                                          List<string> keyColName = null,
                                                          List<string> needUpdateColName = null,
                                                          Dictionary<string, TupleValue<string, object>> setExpression = null,
                                                          Dictionary<string, TupleValue<string, object>> whereExpression = null,
                                                          List<string> refColNames = null,
                                                          string tableName = null)
        {
            return GenerateUpdateCommand(new List<T> { model }, keyColName, needUpdateColName, setExpression, whereExpression, refColNames, tableName);
        }

        /// <summary>获得类的选择命令
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="selColNames">要选择的列的列名集合（默认类上的属性名）</param>
        /// <param name="whereCondition">Where 条件（列名 + 值）</param>
        /// <param name="selectExpression">选择列的表达式（列名 + （表达式 + 参数值））; 表达式中 {@col} 为列名， {@parm} 为参数</param>
        /// <param name="whereExpression">Where 条件表达式（列名 + 表达式 + 参数值）; 表达式中 {@col} 为列名， {@parm} 为参数</param>
        /// <param name="useAndSymbol">Where 条件有多个值的话默认用 "And" 关联，否则用 "Or"</param>
        /// <param name="tableName">实际表名，默认用类名</param>
        /// <returns></returns>
        public static SqlCommand GenerateSelectCommand<T>(List<string> selColNames = null,
                                                          List<TupleValue<string, object>> whereCondition = null,
                                                          Dictionary<string, TupleValue<string, object>> selectExpression = null,
                                                          List<TupleValue<string, string, object>> whereExpression = null,
                                                          bool useAndSymbol = true,
                                                          string tableName = null)
        {
            SqlCommand retVal = new SqlCommand();
            Type type = typeof(T);
            List<string> colNames = selColNames ?? type.GetProperties().Select(p => p.Name).ToList();
            string linkSymbol = useAndSymbol ? " AND " : " OR ";
            string tabName = tableName ?? type.Name;
            StringBuilder sbSql = new StringBuilder();
            int parmId = 0;
            List<SqlParameter> lstParms = new List<SqlParameter>();

            Dictionary<string, TupleValue<string, object>> selExpression = selectExpression ?? new Dictionary<string, TupleValue<string, object>>();
            string expEntityStr;
            TupleValue<bool, string> expEntity;

            if (colNames.Count == 0) throw new ArgumentException("No select columns");

            //生成 Select 部分语句
            sbSql.Append("SELECT ");
            for (int i = 0; i < colNames.Count; i++)
            {
                string colName = colNames[i];
                expEntityStr = "";
                if (selExpression.ContainsKey(colName))
                {
                    expEntity = GetExpressionEntity(colName, selExpression[colName].Value1, parmId);
                    expEntityStr = expEntity.Value2;

                    if (expEntity.Value1)
                        lstParms.Add(new SqlParameter("@" + parmId++, selExpression[colName].Value2));
                }

                if (i == colNames.Count - 1)
                    sbSql.AppendLine("[" + colName + "] " + expEntityStr);
                else
                    sbSql.Append("[" + colName + "] " + expEntityStr + ",");
            }

            sbSql.AppendLine("FROM " + tabName);

            bool useLinkSymbol = false;
            bool usedWhere = false;
            //生成 Where 部分语句
            if (whereCondition != null && whereCondition.Count > 0)
            {
                sbSql.Append("WHERE ");
                usedWhere = true;

                foreach (TupleValue<string, object> whrCnd in whereCondition)
                {
                    if (useLinkSymbol) sbSql.Append(linkSymbol);
                    else useLinkSymbol = true;

                    if (whrCnd.Value2 == null || whrCnd.Value2 is DBNull)
                        sbSql.Append("[" + whrCnd.Value1 + "] IS NULL");
                    else
                    {
                        sbSql.Append("[" + whrCnd.Value1 + "] = @" + parmId);
                        lstParms.Add(new SqlParameter("@" + parmId++, whrCnd.Value2));
                    }
                }
            }

            //Where 查询表达式部分
            if (whereExpression != null && whereExpression.Count > 0)
            {
                if (!usedWhere)
                    sbSql.Append("WHERE ");

                foreach (TupleValue<string, string, object> whrExp in whereExpression)
                {
                    if (useLinkSymbol) sbSql.Append(linkSymbol);
                    else useLinkSymbol = true;

                    expEntity = GetExpressionEntity(whrExp.Value1, whrExp.Value2, parmId);
                    if (expEntity.Value1)
                        lstParms.Add(new SqlParameter("@" + parmId++, whrExp.Value3));

                    sbSql.Append("[" + whrExp.Value1 + "]" + expEntity.Value2);
                }
            }

            retVal.CommandType = CommandType.Text;
            retVal.CommandText = sbSql.ToString();
            if (lstParms.Count > 0)
                SQLHelper.AttachParameters(retVal, lstParms.ToArray());

            return retVal;
        }

        /// <summary>获得类的判断存在与否命令
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="whereCondition">Where 条件（列名 + 值）</param>
        /// <param name="useAndSymbol">Where 条件有多个值的话默认用 "And" 关联，否则用 "Or"</param>
        /// <param name="whereExpression">Where 条件表达式（列名 + 表达式 + 参数值）; 表达式中 {@col} 为列名， {@parm} 为参数</param>
        /// <param name="tableName">实际表名，默认用类名</param>
        /// <returns></returns>
        public static SqlCommand GenerateExistsCommand<T>(List<TupleValue<string, object>> whereCondition = null,
                                                          bool useAndSymbol = true,
                                                          List<TupleValue<string, string, object>> whereExpression = null,
                                                          string tableName = null)
        {
            SqlCommand retVal = GenerateSelectCommand<T>(whereCondition: whereCondition, useAndSymbol: useAndSymbol, whereExpression: whereExpression, tableName: tableName);
            string[] cmdTextLines = retVal.CommandText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sbSql = new StringBuilder();

            sbSql.AppendLine("SELECT ReturnValue = CASE WHEN EXISTS (");
            foreach (string line in cmdTextLines)
                sbSql.AppendLine(line.StartsWith("SELECT ") ? "SELECT TOP 1 1" : line);
            sbSql.AppendLine(") THEN 1 ELSE 0 END");

            retVal.CommandText = sbSql.ToString();

            return retVal;
        }

        /// <summary>转换表达式至 SQL 中的实体
        /// </summary>
        /// <param name="colName">列名</param>
        /// <param name="expression">表达式</param>
        /// <param name="parmValue">参数值</param>
        /// <returns></returns>
        private static string GetExpressionEntity(string colName, string expression, string parmValue)
        {
            return expression.Replace("{@col}", "[" + colName + "]")
                             .Replace("{@parm}", parmValue);
        }

        /// <summary>转换表达式至 SQL 中的实体
        /// </summary>
        /// <param name="colName">列名</param>
        /// <param name="expression">表达式</param>
        /// <param name="parmId">当前所至参数号</param>
        /// <returns></returns>
        private static TupleValue<bool, string> GetExpressionEntity(string colName, string expression, int parmId)
        {
            bool haveParm = expression.Contains("{@parm}");
            string expStr = expression.Replace("{@col}", "[" + colName + "]")
                                      .Replace("{@parm}", "@" + parmId);

            return new TupleValue<bool, string>(haveParm, expStr);
        }
    }
}


/****************   测试方法  ****************
 
        public DataTable GetPurchOrd_testSLInCSharp()
        {
            string strSql = "SELECT PONbr, CuryID, POAmt, [Status], VendID, VendName = [master].dbo.CvrtC2N(VendName), PODate " + Environment.NewLine
                            + "FROM PurchOrd_testSLInCSharp WHERE [Status] = 'X'";

            return SQLHelper.ExecuteDataTable(strSql, CommandType.Text, _sl.SqlConn);
        }

        public DataTable GetPurchOrd_testSLInCSharp2()
        {
            string strSql = "SELECT PONbr, CuryID, POAmt, [Status], VendID, VendName = [master].dbo.CvrtC2N(VendName), PODate " + Environment.NewLine
                            + "FROM PurchOrd_testSLInCSharp WHERE PONbr = '699772'";

            return SQLHelper.ExecuteDataTable(strSql, CommandType.Text, _sl.SqlConn);
        }

        public void TestInsertCommand()
        {
            List<PurchOrd_testSLInCSharp> lstHead = new List<PurchOrd_testSLInCSharp>();

            PurchOrd_testSLInCSharp pohd = new PurchOrd_testSLInCSharp();
            pohd.PONbr = "699772";
            pohd.CuryID = "JPY";
            pohd.POAmt = 123456.78;
            pohd.Status = "X";
            pohd.VendID = "W0001";
            pohd.VendName = "倪渠斯信息技术（上海）有限公司";
            pohd.PODate = DateTime.Now;

            lstHead.Add(pohd);

            Dictionary<string, TupleValue<string, object>> insertExpression = new Dictionary<string, TupleValue<string, object>>();
            insertExpression.Add("VendName", new TupleValue<string, object>("[master].dbo.CvrtN2C({@parm})", pohd.VendName));

            SqlCommand modelInsertCommand = ModelHelp.GenerateInsertCommand(lstHead, insertExpression: insertExpression);

            SQLHelper.ExecuteNonQuery(modelInsertCommand, _sl.SqlConn);
        }

        public void TestUpdateCommand()
        {
            DataTable dtPurchOrd_testSLInCSharp = GetPurchOrd_testSLInCSharp2();
            List<PurchOrd_testSLInCSharp> lstHead = ModelHelp.GenerateList<PurchOrd_testSLInCSharp>(dtPurchOrd_testSLInCSharp);
            
            Dictionary<string, TupleValue<string, object>> setExpression = new Dictionary<string, TupleValue<string, object>>();
            setExpression.Add("VendName", new TupleValue<string, object>(" = [master].dbo.CvrtN2C({@parm})", "倪豺斯信息技术（上海）有限公司"));
            
            Dictionary<string, TupleValue<string, object>> whereExpression = new Dictionary<string, TupleValue<string, object>>();
            whereExpression.Add("VendName", new TupleValue<string, object>(" = [master].dbo.CvrtN2C({@parm})", null));

            SqlCommand updateCommand = ModelHelp.GenerateUpdateCommand(lstHead, new List<string> {"VendName"}, new List<string> {"VendName"}, setExpression, whereExpression);
            SQLHelper.ExecuteNonQuery(updateCommand, _sl.SqlConn);
        }

        public void TestDeleteCommand()
        {
            DataTable dtPurchOrd_testSLInCSharp = GetPurchOrd_testSLInCSharp2();
            List<PurchOrd_testSLInCSharp> lstHead = ModelHelp.GenerateList<PurchOrd_testSLInCSharp>(dtPurchOrd_testSLInCSharp);

            Dictionary<string, TupleValue<string, object>> whereExpression = new Dictionary<string, TupleValue<string, object>>();
            whereExpression.Add("VendName", new TupleValue<string, object>(" = [master].dbo.CvrtN2C({@parm})", "倪豺斯信息技术（上海）有限公司"));

            SqlCommand deleteCommand = ModelHelp.GenerateDeleteCommand(lstHead, new List<string> {"VendName"}, whereExpression);
            SQLHelper.ExecuteNonQuery(deleteCommand, _sl.SqlConn);
        }

        public void TestSelectCommand()
        {
            List<TupleValue<string, object>> whereCondition = new List<TupleValue<string, object>>();
            whereCondition.Add(new TupleValue<string, object>("VendId", "W0001"));

            Dictionary<string, TupleValue<string, object>> selectExpression = new Dictionary<string, TupleValue<string, object>>();
            selectExpression.Add("VendName", new TupleValue<string, object>(" = [master].dbo.CvrtC2N({@col})", null));

            List<TupleValue<string, string, object>> whereExpression = new List<TupleValue<string, string, object>>();
            whereExpression.Add(new TupleValue<string, string, object>("VendName", " = [master].dbo.CvrtN2C({@parm})", "倪豺斯信息技术（上海）有限公司"));

            SqlCommand selectCommand = ModelHelp.GenerateSelectCommand<PurchOrd_testSLInCSharp>(whereCondition: whereCondition, selectExpression: selectExpression, whereExpression: whereExpression);
            DataTable dt = SQLHelper.ExecuteDataTable(selectCommand, _sl.SqlConn);
        }

        public void TestExistsCommand()
        {
            List<TupleValue<string, object>> whereCondition = new List<TupleValue<string, object>>();
            whereCondition.Add(new TupleValue<string, object>("VendId", "W0001"));

            List<TupleValue<string, string, object>> whereExpression = new List<TupleValue<string, string, object>>();
            whereExpression.Add(new TupleValue<string, string, object>("VendName", " = [master].dbo.CvrtN2C({@parm})", "倪豺斯信息技术（上海）有限公司"));

            SqlCommand existsCommand = ModelHelp.GenerateExistsCommand<PurchOrd_testSLInCSharp>(whereCondition: whereCondition, whereExpression: whereExpression);
            
            object scalar = SQLHelper.ExecuteScalar(existsCommand, _sl.SqlConn);
        } 
 */