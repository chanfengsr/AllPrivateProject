using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Table:BaseTable 
    {
        public Table(string tableName)
        {
            if (tableName == null || tableName.Trim().Length == 0) throw new ArgumentNullException("TableName");

            tableName = tableName.Trim();

            this.name = tableName;
        }     
    }
}
