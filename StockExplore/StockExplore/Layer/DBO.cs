using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace StockExplore
{
    class DBO
    {
        SqlConnection _cnn;

        public DBO(string sqlCnnString)
        {
            _cnn = new SqlConnection(sqlCnnString);
        }


    }
}