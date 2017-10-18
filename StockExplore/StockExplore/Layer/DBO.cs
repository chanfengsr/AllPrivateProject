using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StockExplore
{
    internal class DBO
    {
        protected SqlConnection _cnn;

        public DBO(SqlConnection cnn)
        {
            _cnn = cnn;
        }

        /// <summary> 枚举 ValueType 类型转换成SQL中要用到的列名
        /// </summary>
        public static string ValueType2ColName(ValueType valueType)
        {
            const string retMod = "[{0}]";
            return string.Format(retMod, Enum.GetName(typeof (ValueType), valueType));
        }

        /// <summary> 枚举 ValueType 类型集合转换成SQL中要用到的列名
        /// </summary>
        public static string ValueTypes2ColNames(List<ValueType> valueTypes)
        {
            string ret = valueTypes.Aggregate(string.Empty, (current, type) => current + ( ValueType2ColName(type) + "," ));

            if (ret.Length == 0)
                return "1";
            else
                return ret.TrimEnd(',');
        }

        /// <summary> 获取表记录数
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int GetTableRecordCount(string tableName)
        {
            const string sqlMod = "SELECT COUNT(1) FROM {0}";
            return (int)SQLHelper.ExecuteScalar(string.Format(sqlMod, tableName), CommandType.Text, _cnn);
        }

        /// <summary>获取某只个股的所有指定日期区间价格
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="stkCode">股票代码</param>
        /// <param name="valueTypes">指定类型</param>
        /// <param name="startDay">开始日期</param>
        /// <param name="endDay">结束日期</param>
        /// <returns></returns>
        public DataTable GetStockAllPrice(string tableName, string stkCode, List<ValueType> valueTypes, DateTime startDay = default( DateTime ), DateTime endDay = default( DateTime ))
        {
            const string sqlMod = "SELECT TradeDay, {0} FROM {1} WHERE StkCode = '{2}' {3} ORDER BY TradeDay ASC";
            string condTradeDay = string.Empty;
            if (startDay != default( DateTime ))
                condTradeDay = string.Format(" AND TradeDay >= '{0}'", startDay.ToString());
            if (endDay != default( DateTime ))
                condTradeDay += string.Format(" AND TradeDay <= '{0}'", endDay.ToString());

            string strSql = string.Format(sqlMod,
                                          ValueTypes2ColNames(valueTypes),
                                          tableName,
                                          stkCode,
                                          condTradeDay);

            return SQLHelper.ExecuteDataTable(strSql, CommandType.Text, _cnn);
        }

        private static Dictionary<string, int> _allStockTradeDayCount = new Dictionary<string, int>();

        /// <summary> 获取个股总交易日数
        /// </summary>
        /// <param name="stkCode">股票代码</param>
        /// <returns></returns>
        public int GetStockTradeDayCount(string stkCode)
        {
            if (_allStockTradeDayCount.Count > 0 && !_allStockTradeDayCount.ContainsKey(stkCode))
                return 0;

            if (_allStockTradeDayCount.Count == 0)
            {
                const string strSql = "SELECT StkCode, DayCount = COUNT(TradeDay) FROM KLineDay GROUP BY StkCode";
                DataTable dtCount = SQLHelper.ExecuteDataTable(strSql, CommandType.Text, _cnn);

                _allStockTradeDayCount = SysFunction.GetColDictionary<string, int>(dtCount, 0, 1);
            }

            return _allStockTradeDayCount.ContainsKey(stkCode) ? _allStockTradeDayCount[stkCode] : 0;
        }

        private static readonly Dictionary<string, List<DateTime>> AllTypeTradeDay = new Dictionary<string, List<DateTime>>();

        /// <summary> 查找所有历史交易日（取上证指数为参考项）
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<DateTime> GetAllTradeDay(string tableName)
        {
            if (! AllTypeTradeDay.ContainsKey(tableName))
            {
                const string sqlMod = "SELECT DISTINCT TradeDay FROM {0} WHERE StkCode = '999999' ORDER BY TradeDay";

                DataTable dtDays = SQLHelper.ExecuteDataTable(string.Format(sqlMod, tableName), CommandType.Text, _cnn);
                List<DateTime> lstDay = SysFunction.GetColList<DateTime>(dtDays, 0).ToList();

                AllTypeTradeDay.Add(tableName, lstDay);
            }

            return AllTypeTradeDay[tableName];
        }

        private static Dictionary<string, DateTime> _stockFirstDay = new Dictionary<string, DateTime>();

        /// <summary> 所有股票（不包括指数）的第一个交易日。如果数据不全，则不代表上市日
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, DateTime> GetAllStockFirstDay()
        {
            if (_stockFirstDay.Count > 0)
            {
                const string strSql = "SELECT StkCode, FirstDay = MIN(TradeDay) FROM KLineDay GROUP BY StkCode";
                DataTable dt = SQLHelper.ExecuteDataTable(strSql, CommandType.Text, _cnn);
                _stockFirstDay = SysFunction.GetColDictionary<string, DateTime>(dt, 0, 1);
            }

            return _stockFirstDay;
        }

        public void TruncateTable(string tableName)
        {
            const string strSql = "TRUNCATE TABLE {0}";
            SQLHelper.ExecuteNonQuery(string.Format(strSql, tableName), CommandType.Text, _cnn);
        }

        /// <summary> 删除所有表，并收缩数据库
        /// </summary>
        public void TruncateAllTable()
        {
            #region SQL
            #region 原始SQL语句
            /*
DECLARE @name AS SYSNAME
DECLARE @ttSql AS NVARCHAR(100)
DECLARE cur1 CURSOR LOCAL FAST_FORWARD READ_ONLY FOR SELECT [name] FROM sys.objects WHERE [type] in (N'U')
OPEN cur1
    WHILE 1 = 1
        BEGIN
            FETCH cur1 INTO @name
            IF @@FETCH_STATUS <> 0
                BREAK

            SET @ttSql = 'TRUNCATE TABLE ' + @name
            --PRINT @ttSql
            exec sp_executesql @ttSql
        END
CLOSE cur1
DEALLOCATE cur1

DBCC SHRINKDATABASE(N'tempdb' )

DECLARE @name2 AS SYSNAME
SET @name2 = DB_NAME()
DBCC SHRINKDATABASE(@name2)
             */
            #endregion 原始SQL语句

            const string strSql = "DECLARE @name AS SYSNAME" + "\r\n"
              + "DECLARE @ttSql AS NVARCHAR(100)" + "\r\n"
              + "DECLARE cur1 CURSOR LOCAL FAST_FORWARD READ_ONLY FOR SELECT [name] FROM sys.objects WHERE [type] in (N'U')" + "\r\n"
              + "OPEN cur1" + "\r\n"
              + "    WHILE 1 = 1" + "\r\n"
              + "        BEGIN" + "\r\n"
              + "            FETCH cur1 INTO @name" + "\r\n"
              + "            IF @@FETCH_STATUS <> 0" + "\r\n"
              + "                BREAK" + "\r\n"
              + "" + "\r\n"
              + "            SET @ttSql = 'TRUNCATE TABLE ' + @name" + "\r\n"
              + "            --PRINT @ttSql" + "\r\n"
              + "            exec sp_executesql @ttSql" + "\r\n"
              + "        END" + "\r\n"
              + "CLOSE cur1" + "\r\n"
              + "DEALLOCATE cur1" + "\r\n"
              + "" + "\r\n"
              + "DBCC SHRINKDATABASE(N'tempdb' )" + "\r\n"
              + "" + "\r\n"
              + "DECLARE @name2 AS SYSNAME" + "\r\n"
              + "SET @name2 = DB_NAME()" + "\r\n"
              + "DBCC SHRINKDATABASE(@name2)";

            #endregion SQL

            SQLHelper.ExecuteNonQuery(strSql, CommandType.Text, _cnn);
        }

        /// <summary> 用 RecId 来批量删表数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="aRecId"></param>
        public void DeleteTableByRecId(string tableName, int[] aRecId)
        {
            const string modSql = "DELETE FROM {0} WHERE RecId IN ({1})";
            StringBuilder sb = new StringBuilder();

            foreach (int id in aRecId)
                sb.Append(id + ",");

            SQLHelper.ExecuteNonQuery(string.Format(modSql, tableName, sb.ToString().TrimEnd(',')), CommandType.Text, _cnn);
        }

        private List<string> _stockACodeList;

        /// <summary> 沪深 A股代码列表
        /// </summary>
        public List<string> GetStockACodeList()
        {
            const string strSql = "SELECT StkCode FROM cv_AStockCode";

            if (_stockACodeList == null || _stockACodeList.Count == 0)
            {
                DataTable dt = SQLHelper.ExecuteDataTable(strSql, CommandType.Text, _cnn);
                _stockACodeList = SysFunction.GetColList<string>(dt, 0).ToList();
            }

            return _stockACodeList;
        }

        private List<string> _stockZSCodeList;

        /// <summary> 指数代码列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetZSCodeList()
        {
            const string strSql = "SELECT StkCode FROM StockHead WHERE StkType = 0";

            if (_stockZSCodeList == null || _stockZSCodeList.Count == 0)
            {
                DataTable dt = SQLHelper.ExecuteDataTable(strSql, CommandType.Text, _cnn);
                _stockZSCodeList = SysFunction.GetColList<string>(dt, 0).ToList();
            }

            return _stockZSCodeList;
        }
    }
}
