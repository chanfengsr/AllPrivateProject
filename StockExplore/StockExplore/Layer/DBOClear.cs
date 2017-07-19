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

        public void TruncateTable(string tableName)
        {
            const string strSql = "TRUNCATE TABLE {0}";
            SQLHelper.ExecuteNonQuery(string.Format(strSql, tableName), CommandType.Text, Connection);
        }
    }
}
