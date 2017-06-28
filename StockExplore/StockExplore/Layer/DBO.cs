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

        /// <summary>获取某只个股的所有收盘价
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="markType">市场类型（沪市、深市、创业板）</param>
        /// <param name="stkCode">股票代码</param>
        /// <returns></returns>
        public DataTable GetAllClosePrice(string tableName, string markType, string stkCode, ValueType valueType)
        {
             const string strSql = "SELECT TradeDay, [Close] FROM {0} WHERE MarkType = '{1}' AND StkCode = '{2}' ORDER BY TradeDay ASC";
            return SQLHelper.ExecuteDataTable(string.Format(strSql, tableName, markType, stkCode), CommandType.Text, Connection);
        }
    }
}
