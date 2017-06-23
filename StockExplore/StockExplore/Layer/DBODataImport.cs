using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace StockExplore
{
    internal class DBODataImport
    {
        private SqlConnection _cnn;

        public DBODataImport(SqlConnection cnn)
        {
            _cnn = cnn;
        }

        public DataTable GetEmptyTable(string tableName)
        {
            string strSql = string.Format("SELECT TOP 0 * FROM {0}", tableName);
            return SQLHelper.ExecuteDataTable(strSql, CommandType.Text, _cnn);
        }

        public void TruncateTable(string tableName)
        {
            string strSql = string.Format("TRUNCATE TABLE {0}", tableName);

            SQLHelper.ExecuteNonQuery(strSql, CommandType.Text, _cnn);
        }

        public void DeleteTable(string tableName, StockHead stkHead)
        {
            string strSql = string.Format("DELETE FROM {0} WHERE MarkType = @MarkType AND StkCode = @StkCode", tableName);
            SqlParameter[] parms = new[]
            {
                new SqlParameter("@MarkType", stkHead.MarkType),
                new SqlParameter("@StkCode", stkHead.StkCode)
            };

            SQLHelper.ExecuteNonQuery(strSql, CommandType.Text, parms, _cnn);
        }

        /// <summary>找到指定股票代码已有数据的最大交易日
        /// </summary>
        public DateTime FindMaxExistTradeDay(string tableName, StockHead stkHead)
        {
            DateTime retVal = DateTime.MinValue;

/**/
            string strSql = string.Format("SELECT TradeDay = MAX(TradeDay) FROM {0}" + Environment.NewLine
                                          + "WHERE MarkType = @MarkType AND StkCode = @StkCode", tableName);
            SqlParameter[] parms = new[]
            {
                new SqlParameter("@MarkType", stkHead.MarkType),
                new SqlParameter("@StkCode", stkHead.StkCode)
            };
            
            object objMaxDay = SQLHelper.ExecuteScalar(strSql, CommandType.Text, parms, _cnn);

            /*
                        const string strSql = "SELECT TradeDay = MAX(TradeDay) FROM {0}" + "\r\n"
                                                           + "WHERE MarkType = '{1}' AND StkCode = '{2}'";

                        object objMaxDay = SQLHelper.ExecuteScalar(string.Format(strSql, tableName, stkHead.MarkType, stkHead.StkCode), CommandType.Text, _cnn);
            */

            if (objMaxDay != System.DBNull.Value)
                retVal = (DateTime)objMaxDay;

            return retVal;
        }

        /// <summary>批量插入数据
        /// </summary>
        public void BulkInsertTable(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(_cnn);
                bulkCopy.DestinationTableName = dataTable.TableName;
                foreach (DataColumn col in dataTable.Columns)
                    if (!col.AutoIncrement)
                        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);

                bulkCopy.WriteToServer(dataTable, DataRowState.Added);
                bulkCopy.Close();
            }
        }

        /// <summary> 数据库中查找 StockHead
        /// </summary>
        /// <param name="markType">市场类型（沪市、深市、创业板）</param>
        /// <param name="stkCode">股票代码</param>
        /// <returns></returns>
        public StockHead FindStockHead(string markType, string stkCode)
        {
            const string strSql = "SELECT * FROM StockHead WHERE MarkType = @MarkType AND StkCode = @StkCode";
            SqlParameter[] parms = new[]
            {
                new SqlParameter("@MarkType", markType),
                new SqlParameter("@StkCode", stkCode)
            };

            DataTable dt = SQLHelper.ExecuteDataTable(strSql, CommandType.Text, parms, _cnn);

            if (dt.Rows.Count > 0)
                return ModelHelp.GenerateList<StockHead>(dt)[0];
            else
                return new StockHead();
        }

        /// <summary>新增或修改 StockHead(StkName)
        /// </summary>
        public void InsertOrUpdateStockHead(StockHead stockHead)
        {
            StockHead existStkHead = this.FindStockHead(stockHead.MarkType, stockHead.StkCode);

            if (!string.IsNullOrEmpty(existStkHead.StkCode))
            {
                if (existStkHead.StkName.Trim() != stockHead.StkName.Trim())
                {
                    const string strSql = "UPDATE StockHead SET StkName = @StkName WHERE MarkType = @MarkType AND StkCode = @StkCode";
                    SqlParameter[] parms = new[]
                    {
                        new SqlParameter("@StkName", stockHead.StkName),
                        new SqlParameter("@MarkType", stockHead.MarkType),
                        new SqlParameter("@StkCode", stockHead.StkCode)
                    };

                    SQLHelper.ExecuteNonQuery(strSql, CommandType.Text, parms, _cnn);
                }
            }
            else
            {
                const string strSql = "INSERT INTO StockHead(MarkType,StkCode,StkName,StkType) " + "\r\n"
                                      + "VALUES(@MarkType,@StkCode,@StkName,@StkType) ";
                SqlParameter[] parms = new[]
                {
                    new SqlParameter("@MarkType", stockHead.MarkType),
                    new SqlParameter("@StkCode", stockHead.StkCode),
                    new SqlParameter("@StkName", stockHead.StkName),
                    new SqlParameter("@StkType", stockHead.StkType)
                };

                SQLHelper.ExecuteNonQuery(strSql, CommandType.Text, parms, _cnn);
            }
        }
    }
}