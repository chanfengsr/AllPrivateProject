using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Database
    {
        public enum DatabaseType { Sql2000, Sql2005 }
        public enum DatabaseObjectType { Table, View, StoreProcedure }

        private string connectionString;
        private List<Table> tables = new List<Table>();
        private List<View> views = new List<View>();
        private List<StoreProcedure> storeProcedures = new List<StoreProcedure>();
        private DatabaseType type = DatabaseType.Sql2000;
        private string dBName = "";

        public Database(string connectionString)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("ConnectionString");

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    if (cnn.Database.Length == 0 || cnn.Database.Length == 0)
                        throw new ArgumentException("ConnectionString Err");

                    dBName = cnn.Database;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("ConnectionString Err");
            }

            this.connectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public string DBName
        {
            get { return this.dBName; }
        }

        public List<Table> Tables
        {
            get { return tables; }
            set
            {
                //校验是否有重复的项
                foreach (Table table in this.tables)
                {
                    if (FindTable(this.tables, table).Count > 1)
                    {
                        throw new Exception("有重复的表名！");
                    }
                }

                this.tables = value;
            }
        }

        public List<View> Views
        {
            get { return views; }
            set
            {
                //校验是否有重复的项
                foreach (View vw in this.views)
                {
                    if (FindView(this.views, vw).Count > 1)
                    {
                        throw new Exception("有重复的视图名！");
                    }
                }

                this.views = value;
            }
        }

        public List<StoreProcedure> StoreProcedures
        {
            get { return storeProcedures; }
            set
            {
                //校验是否有重复的项
                foreach (StoreProcedure var in this.storeProcedures)
                {
                    if (FindProc(this.storeProcedures, var).Count > 1)
                    {
                        throw new Exception("有重复的存储过程名！");
                    }
                }

                this.storeProcedures = value;
            }
        }

        public DatabaseType Type
        {
            get { return type; }
            set { type = value; }
        }

        #region 增删表
        public bool AddTable(Table Table)
        {
            foreach (Table table in this.tables)
            {
                if (table.Name.ToUpper().Trim() == Table.Name.ToUpper().Trim())
                {
                    return false;
                }
            }

            this.tables.Add(Table);
            return true;
        }

        public bool AddTable(string tableName)
        {
            tableName = tableName.Trim();

            foreach (Table table in this.tables)
            {
                if (table.Name.ToUpper().Trim() == tableName.ToUpper().Trim())
                {
                    return false;
                }
            }

            Table newTable = new Table(tableName.Trim());
            FillSchemaTable(newTable as BaseTable, GetSchemaTable(this.connectionString, tableName.Trim()));
            this.tables.Add(newTable);

            return true;
        }

        public bool RemoveTable(Table Table)
        {
            return this.tables.Remove(Table);
        }

        public bool RemoveTable(string TableName)
        {
            foreach (Table table in this.tables)
            {
                if (table.Name.ToUpper().Trim() == TableName.ToUpper().Trim())
                {
                    this.tables.Remove(table);
                    return true;
                }
            }
            return false;
        }

        public Table GetTable(string TableName)
        {
            foreach (Table table in this.tables)
            {
                if (table.Name.ToUpper().Trim() == TableName.ToUpper().Trim())
                {
                    return table;
                }
            }

            return null;
        }

        #endregion

        #region 增删视图
        public bool AddView(View View)
        {
            foreach (View view in this.views)
            {
                if (view.Name.ToUpper().Trim() == View.Name.ToUpper().Trim())
                {
                    return false;
                }
            }

            this.views.Add(View);
            return true;
        }

        public bool AddView(string viewName)
        {
            viewName = viewName.Trim();

            foreach (View view in this.views)
            {
                if (view.Name.ToUpper().Trim() == viewName.ToUpper().Trim())
                {
                    return false;
                }
            }

            View newView = new View(viewName.Trim());
            FillSchemaTable(newView as BaseTable, GetSchemaTable(connectionString, viewName.Trim()));
            this.views.Add(newView);

            return true;
        }

        public bool RemoveView(View View)
        {
            return this.views.Remove(View);
        }

        public bool RemoveView(string ViewName)
        {
            foreach (View view in this.views)
            {
                if (view.Name.ToUpper().Trim() == ViewName.ToUpper().Trim())
                {
                    this.views.Remove(view);
                    return true;
                }
            }
            return false;
        }

        public View GetView(string ViewName)
        {
            foreach (View view in this.views)
            {
                if (view.Name.ToUpper().Trim() == ViewName.ToUpper().Trim())
                {
                    return view;
                }
            }

            return null;
        }

        #endregion

        #region 增删存储过程
        public bool AddStoreProcedure(StoreProcedure StoreProcedure)
        {
            foreach (StoreProcedure var in this.StoreProcedures)
            {
                if (var.Name.ToUpper().Trim() == StoreProcedure.Name.ToUpper().Trim())
                {
                    return false;
                }
            }

            this.StoreProcedures.Add(StoreProcedure);
            return true;
        }

        public bool AddStoreProcedure(string storeProcedureName)
        {
            storeProcedureName = storeProcedureName.Trim();

            foreach (StoreProcedure  storeProcedure in this.storeProcedures )
            {
                if (storeProcedure.Name.ToUpper().Trim() == storeProcedureName.ToUpper().Trim())
                {
                    return false;
                }
            }

            StoreProcedure newProc = new StoreProcedure(storeProcedureName.Trim());
            FillProcSchemaTable(newProc, GetProcSchemaTable(this.connectionString, storeProcedureName.Trim()));
            this.storeProcedures.Add(newProc);

            return true;
        }

        public bool RemoveStoreProcedure(StoreProcedure StoreProcedure)
        {
            return this.StoreProcedures.Remove(StoreProcedure);
        }

        public bool RemoveStoreProcedure(string StoreProcedureName)
        {
            foreach (StoreProcedure var in this.StoreProcedures)
            {
                if (var.Name.ToUpper().Trim() == StoreProcedureName.ToUpper().Trim())
                {
                    this.StoreProcedures.Remove(var);
                    return true;
                }
            }
            return false;
        }

        public StoreProcedure GetStoreProcedure(string StoreProcedureName)
        {
            foreach (StoreProcedure var in this.StoreProcedures)
            {
                if (var.Name.ToUpper().Trim() == StoreProcedureName.ToUpper().Trim())
                {
                    return var;
                }
            }

            return null;
        }
        #endregion

        private static List<Table> FindTable(List<Table> lstTable, Table Table)
        {
            List<Table> lbt = new List<Table>();

            foreach (Table bt in lstTable)
            {
                if (bt.Name.ToUpper().Trim() == Table.Name.ToUpper().Trim())
                {
                    lbt.Add(bt);
                }
            }

            return lbt;
        }

        private static List<View> FindView(List<View> lstView, View View)
        {
            List<View> lbt = new List<View>();

            foreach (View bt in lstView)
            {
                if (bt.Name.ToUpper().Trim() == View.Name.ToUpper().Trim())
                {
                    lbt.Add(bt);
                }
            }

            return lbt;
        }

        private static List<StoreProcedure> FindProc(List<StoreProcedure> lstSP, StoreProcedure SP)
        {
            List<StoreProcedure> lsp = new List<StoreProcedure>();

            foreach (StoreProcedure var in lstSP)
            {
                if (var.Name.ToUpper().Trim() == SP.Name.ToUpper().Trim())
                {
                    lsp.Add(var);
                }
            }

            return lsp;
        }

        public void GetAllTable()
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

            this.tables.Clear();

            foreach (string tableName in GetDatabaseObjectList(this.connectionString, DatabaseObjectType.Table))
            {
                Table table = new Table(tableName.Trim());
                FillSchemaTable(table as BaseTable, GetSchemaTable(this.connectionString, tableName.Trim()));
                this.tables.Add(table);
            }
        }

        public void GetAllView()
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

            this.views.Clear();

            foreach (string viewName in GetDatabaseObjectList(this.connectionString, DatabaseObjectType.View))
            {
                View view = new View(viewName.Trim());
                FillSchemaTable(view as BaseTable, GetSchemaTable(this.connectionString, viewName.Trim()));
                this.views.Add(view);
            }
        }

        public void GetAllStoreProcedure()
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

            this.storeProcedures.Clear();

            foreach (string spName in GetDatabaseObjectList(this.connectionString, DatabaseObjectType.StoreProcedure))
            {
                StoreProcedure storeProcedure = new StoreProcedure(spName.Trim());
                FillProcSchemaTable(storeProcedure, GetProcSchemaTable(this.connectionString, spName.Trim()));
                this.storeProcedures.Add(storeProcedure);
            }
        }

        /// <summary>
        /// 拿到数据库对象名称列表
        /// </summary>
        /// <param name="ConnString">连接字符串</param>
        /// <param name="DBOType">对象类型</param>
        /// <returns></returns>
        private List<string> GetDatabaseObjectList(string connectionString, DatabaseObjectType DBOType)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

            string strCmd, strSType = "";
            List<string> retList = new List<string>();

            switch (DBOType)
            {
                case DatabaseObjectType.Table:
                    strSType = "U";
                    break;
                case DatabaseObjectType.View:
                    strSType = "V";
                    break;
                case DatabaseObjectType.StoreProcedure:
                    strSType = "P";
                    break;
            }

            strCmd = string.Format("select [name] from sysobjects where xtype = '{0}' and status >= 0 order by [name]", strSType);

            DataSet ds = new DataSet("OList");
            SqlHelper.FillDataset(connectionString, CommandType.Text, strCmd, ds, new string[] { "List" });

            foreach (DataRow var in ds.Tables["List"].Rows)
            {
                retList.Add(var["name"].ToString());
            }

            return retList;
        }

        /// <summary>
        /// 拿到表/视图的结构
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="tableName">表/视图名</param>
        /// <returns></returns>
        private DataTable GetSchemaTable(string connectionString, string tableName)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string strCmd = string.Format("Select Top 0 * From [{0}]", tableName);

                connection.Open();
                SqlCommand sqlcmd = new SqlCommand(strCmd, connection);
                SqlDataReader sqldr = sqlcmd.ExecuteReader(CommandBehavior.KeyInfo);
                return sqldr.GetSchemaTable();
            }
        }

        /// <summary>
        /// 填充表结构表
        /// </summary>
        /// <param name="baseTable">要填充的Table/View</param>
        /// <param name="schemaDataTable">从数据库中获得的结构表</param>
        private void FillSchemaTable(BaseTable baseTable, DataTable schemaDataTable)
        {
            baseTable.Fields.Clear();

            foreach (DataRow dr in schemaDataTable.Rows)
            {
                TableField tableField = new TableField();

                FillTableSchemaField(tableField, dr);

                baseTable.AddField(tableField);
            }

            if (baseTable is View)
            {
                (baseTable as View).CreateCmdText = GetObjectCreateText(baseTable.Name);
            }
        }

        /// <summary>
        /// 填充表结构字段
        /// </summary>
        /// <param name="tableField">结构字段</param>
        /// <param name="schemaDataRow">从数据库中获得的结构表行</param>
        private void FillTableSchemaField(TableField tableField, DataRow schemaDataRow)
        {
            tableField.ColumnName = (schemaDataRow["ColumnName"] is DBNull) ? null : (String)schemaDataRow["ColumnName"];
            tableField.ColumnOrdinal = (schemaDataRow["ColumnOrdinal"] is DBNull) ? null : (Int32?)schemaDataRow["ColumnOrdinal"];
            tableField.ColumnSize = (schemaDataRow["ColumnSize"] is DBNull) ? null : (Int32?)schemaDataRow["ColumnSize"];
            tableField.NumericPrecision = (schemaDataRow["NumericPrecision"] is DBNull) ? null : (Int16?)schemaDataRow["NumericPrecision"];
            tableField.NumericScale = (schemaDataRow["NumericScale"] is DBNull) ? null : (Int16?)schemaDataRow["NumericScale"];
            tableField.IsUnique = (schemaDataRow["IsUnique"] is DBNull) ? null : (Boolean?)schemaDataRow["IsUnique"];
            tableField.IsKey = (schemaDataRow["IsKey"] is DBNull) ? null : (Boolean?)schemaDataRow["IsKey"];
            tableField.BaseServerName = (schemaDataRow["BaseServerName"] is DBNull) ? null : (String)schemaDataRow["BaseServerName"];
            tableField.BaseCatalogName = (schemaDataRow["BaseCatalogName"] is DBNull) ? null : (String)schemaDataRow["BaseCatalogName"];
            tableField.BaseColumnName = (schemaDataRow["BaseColumnName"] is DBNull) ? null : (String)schemaDataRow["BaseColumnName"];
            tableField.BaseSchemaName = (schemaDataRow["BaseSchemaName"] is DBNull) ? null : (String)schemaDataRow["BaseSchemaName"];
            tableField.BaseTableName = (schemaDataRow["BaseTableName"] is DBNull) ? null : (String)schemaDataRow["BaseTableName"];
            tableField.DataType = (schemaDataRow["DataType"] is DBNull) ? null : (Type)schemaDataRow["DataType"];
            tableField.AllowDBNull = (schemaDataRow["AllowDBNull"] is DBNull) ? null : (Boolean?)schemaDataRow["AllowDBNull"];
            tableField.ProviderType = (schemaDataRow["ProviderType"] is DBNull) ? null : (Int32?)schemaDataRow["ProviderType"];
            tableField.IsAliased = (schemaDataRow["IsAliased"] is DBNull) ? null : (Boolean?)schemaDataRow["IsAliased"];
            tableField.IsExpression = (schemaDataRow["IsExpression"] is DBNull) ? null : (Boolean?)schemaDataRow["IsExpression"];
            tableField.IsIdentity = (schemaDataRow["IsIdentity"] is DBNull) ? null : (Boolean?)schemaDataRow["IsIdentity"];
            tableField.IsAutoIncrement = (schemaDataRow["IsAutoIncrement"] is DBNull) ? null : (Boolean?)schemaDataRow["IsAutoIncrement"];
            tableField.IsRowVersion = (schemaDataRow["IsRowVersion"] is DBNull) ? null : (Boolean?)schemaDataRow["IsRowVersion"];
            tableField.IsHidden = (schemaDataRow["IsHidden"] is DBNull) ? null : (Boolean?)schemaDataRow["IsHidden"];
            tableField.IsLong = (schemaDataRow["IsLong"] is DBNull) ? null : (Boolean?)schemaDataRow["IsLong"];
            tableField.IsReadOnly = (schemaDataRow["IsReadOnly"] is DBNull) ? null : (Boolean?)schemaDataRow["IsReadOnly"];
            tableField.ProviderSpecificDataType = (schemaDataRow["ProviderSpecificDataType"] is DBNull) ? null : (Type)schemaDataRow["ProviderSpecificDataType"];
            tableField.DataTypeName = (schemaDataRow["DataTypeName"] is DBNull) ? null : (String)schemaDataRow["DataTypeName"];
            tableField.XmlSchemaCollectionDatabase = (schemaDataRow["XmlSchemaCollectionDatabase"] is DBNull) ? null : (String)schemaDataRow["XmlSchemaCollectionDatabase"];
            tableField.XmlSchemaCollectionOwningSchema = (schemaDataRow["XmlSchemaCollectionOwningSchema"] is DBNull) ? null : (String)schemaDataRow["XmlSchemaCollectionOwningSchema"];
            tableField.XmlSchemaCollectionName = (schemaDataRow["XmlSchemaCollectionName"] is DBNull) ? null : (String)schemaDataRow["XmlSchemaCollectionName"];
            tableField.UdtAssemblyQualifiedName = (schemaDataRow["UdtAssemblyQualifiedName"] is DBNull) ? null : (String)schemaDataRow["UdtAssemblyQualifiedName"];
            tableField.NonVersionedProviderType = (schemaDataRow["NonVersionedProviderType"] is DBNull) ? null : (Int32?)schemaDataRow["NonVersionedProviderType"];           
        }

        private DataTable GetProcSchemaTable(string connectionString, string procName)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

            DataTable tb;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                tb = connection.GetSchema("ProcedureParameters", new string[] { dBName, null, procName, null });
            }

            return tb;
        }

        private void FillProcSchemaTable(StoreProcedure storeProcedure, DataTable schemaProcTable)
        {
            storeProcedure.Parameters.Clear();

            foreach (DataRow dr in schemaProcTable.Rows)
            {
                SPField spField = new SPField();

                FillProcSchemaField(spField, dr);

                storeProcedure.AddParameter(spField);
            }

            //添加创建命令代码
            storeProcedure.CreateCmdText = GetObjectCreateText(storeProcedure.Name);
        }

        private void FillProcSchemaField(SPField spField, DataRow schemaDataRow)
        {
            spField.SPECIFIC_CATALOG = (schemaDataRow["SPECIFIC_CATALOG"] is DBNull) ? null : (String)schemaDataRow["SPECIFIC_CATALOG"];
            spField.SPECIFIC_SCHEMA = (schemaDataRow["SPECIFIC_SCHEMA"] is DBNull) ? null : (String)schemaDataRow["SPECIFIC_SCHEMA"];
            spField.SPECIFIC_NAME = (schemaDataRow["SPECIFIC_NAME"] is DBNull) ? null : (String)schemaDataRow["SPECIFIC_NAME"];
            spField.ORDINAL_POSITION = (schemaDataRow["ORDINAL_POSITION"] is DBNull) ? null : (Int16?)schemaDataRow["ORDINAL_POSITION"];
            spField.PARAMETER_MODE = (schemaDataRow["PARAMETER_MODE"] is DBNull) ? null : (String)schemaDataRow["PARAMETER_MODE"];
            spField.IS_RESULT = (schemaDataRow["IS_RESULT"] is DBNull) ? null : (String)schemaDataRow["IS_RESULT"];
            spField.AS_LOCATOR = (schemaDataRow["AS_LOCATOR"] is DBNull) ? null : (String)schemaDataRow["AS_LOCATOR"];
            spField.PARAMETER_NAME = (schemaDataRow["PARAMETER_NAME"] is DBNull) ? null : (String)schemaDataRow["PARAMETER_NAME"];
            spField.DATA_TYPE = (schemaDataRow["DATA_TYPE"] is DBNull) ? null : (String)schemaDataRow["DATA_TYPE"];
            spField.CHARACTER_MAXIMUM_LENGTH = (schemaDataRow["CHARACTER_MAXIMUM_LENGTH"] is DBNull) ? null : (Int32?)schemaDataRow["CHARACTER_MAXIMUM_LENGTH"];
            spField.CHARACTER_OCTET_LENGTH = (schemaDataRow["CHARACTER_OCTET_LENGTH"] is DBNull) ? null : (Int32?)schemaDataRow["CHARACTER_OCTET_LENGTH"];
            spField.COLLATION_CATALOG = (schemaDataRow["COLLATION_CATALOG"] is DBNull) ? null : (String)schemaDataRow["COLLATION_CATALOG"];
            spField.COLLATION_SCHEMA = (schemaDataRow["COLLATION_SCHEMA"] is DBNull) ? null : (String)schemaDataRow["COLLATION_SCHEMA"];
            spField.COLLATION_NAME = (schemaDataRow["COLLATION_NAME"] is DBNull) ? null : (String)schemaDataRow["COLLATION_NAME"];
            spField.CHARACTER_SET_CATALOG = (schemaDataRow["CHARACTER_SET_CATALOG"] is DBNull) ? null : (String)schemaDataRow["CHARACTER_SET_CATALOG"];
            spField.CHARACTER_SET_SCHEMA = (schemaDataRow["CHARACTER_SET_SCHEMA"] is DBNull) ? null : (String)schemaDataRow["CHARACTER_SET_SCHEMA"];
            spField.CHARACTER_SET_NAME = (schemaDataRow["CHARACTER_SET_NAME"] is DBNull) ? null : (String)schemaDataRow["CHARACTER_SET_NAME"];
            spField.NUMERIC_PRECISION = (schemaDataRow["NUMERIC_PRECISION"] is DBNull) ? null : (Byte?)schemaDataRow["NUMERIC_PRECISION"];
            spField.NUMERIC_PRECISION_RADIX = (schemaDataRow["NUMERIC_PRECISION_RADIX"] is DBNull) ? null : (Int16?)schemaDataRow["NUMERIC_PRECISION_RADIX"];
            spField.NUMERIC_SCALE = (schemaDataRow["NUMERIC_SCALE"] is DBNull) ? null : (Int32?)schemaDataRow["NUMERIC_SCALE"];
            spField.DATETIME_PRECISION = (schemaDataRow["DATETIME_PRECISION"] is DBNull) ? null : (Int16?)schemaDataRow["DATETIME_PRECISION"];
            spField.INTERVAL_TYPE = (schemaDataRow["INTERVAL_TYPE"] is DBNull) ? null : (String)schemaDataRow["INTERVAL_TYPE"];
            spField.INTERVAL_PRECISION = (schemaDataRow["INTERVAL_PRECISION"] is DBNull) ? null : (Int16?)schemaDataRow["INTERVAL_PRECISION"];           
        }

        private string GetObjectCreateText(string storeProcedureName)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

            StringBuilder sbVal = new StringBuilder();
            string strCmd = string.Format("sp_helptext '{0}'", storeProcedureName);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand sqlcmd = new SqlCommand(strCmd, connection))
                {
                    using (SqlDataAdapter sqladp = new SqlDataAdapter(sqlcmd))
                    {
                        DataTable table=new DataTable();
                        sqladp.Fill(table);

                        foreach (DataRow row in table.Rows)
                        {
                            sbVal.Append(row[0].ToString());
                        }
                    }
                }
            }

            return sbVal.ToString();
        }
    }
}