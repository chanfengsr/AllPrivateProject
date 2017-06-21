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

            string strSql = string.Format("SELECT TradeDay = MAX(TradeDay) FROM {0}" + Environment.NewLine
                                          + "WHERE MarkType = @MarkType AND StkCode = @StkCode", tableName);
            SqlParameter[] parms = new[]
            {
                new SqlParameter("@MarkType", stkHead.MarkType),
                new SqlParameter("@StkCode", stkHead.StkCode)
            };

            object objMaxDay = SQLHelper.ExecuteScalar(strSql, CommandType.Text, parms, _cnn);
            
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

        /// <summary>新增或修改 StockHead(StkName)
        /// </summary>
        public void InsertOrUpdateStockHead(StockHead stockHead)
        {
            
        }
    }
}