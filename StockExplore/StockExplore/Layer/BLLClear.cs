using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace StockExplore
{
    internal class BLLClear : BLL
    {
        private readonly SqlConnection _cnn;
        private readonly DBOClear _dbo;

        public BLLClear(string connectionString)
        {
            _cnn = new SqlConnection(connectionString);
            _dbo = new DBOClear(_cnn);
        }

        public void OpenConnection()
        {
            if (_cnn.State == ConnectionState.Closed)
                _cnn.Open();
        }

        public void CloseConnection()
        {
            if (_cnn.State != ConnectionState.Closed)
                _cnn.Close();
        }

        public void TruncateStkKLine(KLineType kLineType, bool isComposite)
        {
            string tableName = BLL.GetDBTableName(kLineType, isComposite);
            _dbo.TruncateTable(tableName);
        }

        public void TruncateStkKLine(KLineType kLineType)
        {
            if (kLineType == KLineType.Day)
                throw new ArgumentException("KLineDay need specify parm:isComposite)");

            this.TruncateStkKLine(kLineType, false);
        }
    }
}