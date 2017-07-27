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

        /// <summary>获取某只个股的所有指定价格
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

        /// <summary> 用 RecId 来批量删表数据
        /// </summary>
        /// <param name="aRecId"></param>
        public void DeleteTableByRecId(int[] aRecId)
        {
            const string modSql = "DELETE FROM StockBlock WHERE RecId IN ({0})";
            StringBuilder sb = new StringBuilder();

            foreach (int id in aRecId)
                sb.Append(id + ",");
            
            SQLHelper.ExecuteNonQuery(string.Format(modSql, sb.ToString().TrimEnd(',')), CommandType.Text, _cnn);
        }
    }
}
