using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StockExplore
{
    internal class DBOMetrics : DBO
    {
        public DBOMetrics(SqlConnection cnn) : base(cnn) {}

        /// <summary> 计算个股所有日涨幅
        /// </summary>
        /// <param name="stkCode">股票代码</param>
        /// <returns></returns>
        public Dictionary<DateTime, decimal> CalcStockIncrease_OneStock(string stkCode)
        {
            #region SQL

            #region 原始SQL语句

            /*
SELECT curP.TradeDay, Increase = (curP.[Close] - prepP.[Close]) / prepP.[Close] * 100 FROM 
(
    SELECT RowNum = ROW_NUMBER() OVER ( ORDER BY TradeDay), TradeDay, [Close] FROM KLineDay
    WHERE StkCode = '600620'
) curP
JOIN 
(
    SELECT RowNum = ROW_NUMBER() OVER ( ORDER BY TradeDay) + 1, TradeDay, [Close] FROM KLineDay
    WHERE StkCode = '600620'
) prepP
ON curP.RowNum = prepP.RowNum             
             */

            #endregion 原始SQL语句

            const string sqlMod = "SELECT curP.TradeDay, Increase = (curP.[Close] - prepP.[Close]) / prepP.[Close] * 100 FROM " + "\r\n"
                                  + "(" + "\r\n"
                                  + "    SELECT RowNum = ROW_NUMBER() OVER ( ORDER BY TradeDay), TradeDay, [Close] FROM KLineDay" + "\r\n"
                                  + "    WHERE StkCode = '{0}'" + "\r\n"
                                  + ") curP" + "\r\n"
                                  + "JOIN " + "\r\n"
                                  + "(" + "\r\n"
                                  + "    SELECT RowNum = ROW_NUMBER() OVER ( ORDER BY TradeDay) + 1, TradeDay, [Close] FROM KLineDay" + "\r\n"
                                  + "    WHERE StkCode = '{0}'" + "\r\n"
                                  + ") prepP" + "\r\n"
                                  + "ON curP.RowNum = prepP.RowNum";

            #endregion SQL

            DataTable dt = SQLHelper.ExecuteDataTable(string.Format(sqlMod, stkCode), CommandType.Text, Connection);
            Dictionary<DateTime, decimal> ret = SysFunction.GetColDictionary<DateTime, decimal>(dt, 0, 1);

            return ret;
        }

        /// <summary> 计算单日个股所有涨幅
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public Dictionary<string, decimal> CalcStockIncrease_OneDay(DateTime day)
        {
            #region SQL

            #region 原始SQL语句

            /*
SELECT curP.StkCode, Increase = (curP.[Close] - prepP.[Close]) / prepP.[Close] * 100
FROM KLineDay curP
JOIN
(
    SELECT a.* FROM KLineDay a
    JOIN (SELECT RecId = MAX(RecId) FROM KLineDay WHERE TradeDay < '2017/06/29' GROUP BY StkCode) b
    ON a.RecId = b.RecId
) prepP
ON curP.StkCode = prepP.StkCode
WHERE curP.TradeDay = '2017/06/29'
             */

            #endregion 原始SQL语句

            const string sqlMod = "SELECT curP.StkCode, Increase = (curP.[Close] - prepP.[Close]) / prepP.[Close] * 100" + "\r\n"
                                  + "FROM KLineDay curP" + "\r\n"
                                  + "JOIN" + "\r\n"
                                  + "(" + "\r\n"
                                  + "    SELECT a.* FROM KLineDay a" + "\r\n"
                                  + "    JOIN (SELECT RecId = MAX(RecId) FROM KLineDay WHERE TradeDay < '{0}' GROUP BY StkCode) b" + "\r\n"
                                  + "    ON a.RecId = b.RecId" + "\r\n"
                                  + ") prepP" + "\r\n"
                                  + "ON curP.StkCode = prepP.StkCode" + "\r\n"
                                  + "WHERE curP.TradeDay = '{0}'";


            #endregion SQL

            DataTable dt = SQLHelper.ExecuteDataTable(string.Format(sqlMod, day.ToShortDateString()), CommandType.Text, Connection);
            Dictionary<string, decimal> ret = SysFunction.GetColDictionary<string, decimal>(dt, 0, 1);

            return ret;
        }
    }
}
