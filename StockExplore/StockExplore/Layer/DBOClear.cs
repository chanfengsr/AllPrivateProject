using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StockExplore
{
    internal class DBOClear : DBO
    {
        public DBOClear(SqlConnection cnn) : base(cnn) {}

        /// <summary> 清空指定的板块信息
        /// </summary>
        /// <param name="lstStockBlockType">为 Null 则清空所有</param>
        public void ClearStockBlock(List<StockBlockType> lstStockBlockType = null)
        {
            if (lstStockBlockType == null)
            {
                base.TruncateTable("StockBlock");
            }
            else
            {
                // todo

            }
        }
    }
}
