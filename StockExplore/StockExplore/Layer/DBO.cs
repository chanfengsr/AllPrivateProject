using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StockExplore
{
    class DBO
    {
        protected SqlConnection Connection;

        public DBO(SqlConnection cnn)
        {
            Connection = cnn;
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

        /// <summary>获取某只个股的所有指定价格
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="markType">市场类型（沪市、深市、创业板）</param>
        /// <param name="stkCode">股票代码</param>
        /// <param name="valueTypes">指定类型</param>
        /// <param name="startDay">开始日期</param>
        /// <param name="endDay">结束日期</param>
        /// <returns></returns>
        public DataTable GetStockAllPrice(string tableName, string markType, string stkCode, List<ValueType> valueTypes, DateTime startDay = default( DateTime ), DateTime endDay = default( DateTime ))
        {
            const string sqlMod = "SELECT TradeDay, {0} FROM {1} WHERE MarkType = '{2}' AND StkCode = '{3}' {4} ORDER BY TradeDay ASC";
            string condTradeDay = string.Empty;
            if (startDay != default( DateTime ))
                condTradeDay = string.Format(" AND TradeDay >= '{0}'", startDay.ToString());
            if (endDay != default( DateTime ))
                condTradeDay += string.Format(" AND TradeDay <= '{0}'", endDay.ToString());

            string strSql = string.Format(sqlMod,
                                          ValueTypes2ColNames(valueTypes),
                                          tableName,
                                          markType,
                                          stkCode,
                                          condTradeDay);

            return SQLHelper.ExecuteDataTable(strSql, CommandType.Text, Connection);
        }

        /// <summary> 获取个股总交易日数
        /// </summary>
        /// <param name="markType">市场类型（沪市、深市、创业板）</param>
        /// <param name="stkCode">股票代码</param>
        /// <returns></returns>
        public int GetStockTradeDayCount(string markType, string stkCode)
        {
            const string sqlMod = "SELECT TradeDayCount = COUNT(1) FROM KLineDay" + "\r\n"
                                  + "WHERE MarkType = '{0}' AND StkCode = '{1}'";
            
            return (int)SQLHelper.ExecuteScalar(string.Format(sqlMod, markType, stkCode), CommandType.Text, Connection);
        }

        /// <summary> 查找所有历史交易日
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<DateTime> GetAllTradeDay(string tableName)
        {
            const string sqlMod = "SELECT DISTINCT TradeDay FROM {0} ORDER BY TradeDay";
            
            DataTable dtDays = SQLHelper.ExecuteDataTable(string.Format(sqlMod, tableName), CommandType.Text, Connection);
            return SysFunction.GetColList<DateTime>(dtDays, 0).ToList();
        }


    }
}
