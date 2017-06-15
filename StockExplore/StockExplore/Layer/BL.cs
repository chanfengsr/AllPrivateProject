using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace StockExplore
{
    internal class BL
    {
        private SqlConnection _cnn;

        public BL(string connectionString )
        {
            _cnn = new SqlConnection(connectionString);
        }

        private void OpenConnection()
        {
            if (_cnn.State == System.Data.ConnectionState.Closed)
                _cnn.Open();
        }

        private void CloseConnection()
        {
            if (_cnn.State != System.Data.ConnectionState.Closed)
                _cnn.Close();
        }

        public string ImportKLine(KLineType kLineType, bool convert, bool isComposite, string fileFullName)
        {
            try
            {
                this.OpenConnection();

                switch (kLineType)
                {
                    case KLineType.Day:
                        break;
                    case KLineType.Week:
                        break;
                    case KLineType.Month:
                        break;
                    case KLineType.Minute:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("kLineType");
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}