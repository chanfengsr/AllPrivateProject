using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StockExplore
{
    class DBOMetrics:DBO
    {
        public DBOMetrics(SqlConnection cnn) : base(cnn)
        {
         
        }

        /// <summary> 计算个股所有日涨幅
        /// </summary>
        /// <param name="stkCode">股票代码</param>
        /// <returns></returns>
        public Dictionary<DateTime, decimal> CalcStockIncrease_OneStock( string stkCode)
        {
            #region SQL

            #region 原始SQL语句

            /*
SELECT curP.TradeDay, Increase = (curP.[Close] - prepP.[Close]) / prepP.[Close] *100 FROM 
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

            const string sqlMod = "SELECT curP.TradeDay, Increase = (curP.[Close] - prepP.[Close]) / prepP.[Close] *100 FROM " + "\r\n"
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

            DataTable dt = SQLHelper.ExecuteDataTable(string.Format(sqlMod,  stkCode), CommandType.Text, Connection);

            Dictionary<DateTime, decimal> ret = SysFunction.GetColDictionary<DateTime, decimal>(dt, 0, 1);

            return ret;
        }
    }
}
