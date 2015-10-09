using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace Codes
{
    public class SqlStorProcExecCode
    {
        const string cnnName = "connection";
        const string cnnStrName = "connectionString";
        const string transactionName = "transaction";
        const string cmdName = "command";
        public enum ConnectType { ConnectionString, SqlConnection }

        private ConnectType connectType = ConnectType.SqlConnection;
        private bool needTransaction = false;
        private string namespaceName = "SmartTools";
        private string className = "SqlStoredProcedureExecute";
        private string functionAuthority = "public static ";
        private string execSqlClassName = "";
        private List<StoreProcedure> storeProcedures;

        #region 构造函数
        public SqlStorProcExecCode(List<StoreProcedure> storeProcedures)
        {
            if (storeProcedures == null) throw new ArgumentNullException("StoreProcedures");
            this.storeProcedures = storeProcedures;
        }

        public SqlStorProcExecCode(List<StoreProcedure> storeProcedures, bool? IsSqlConnection, bool? needTransaction, string namespaceName, string className, string functionAuthority, string execSqlClassName)
        {
            if (storeProcedures == null) throw new ArgumentNullException("StoreProcedures");
            this.storeProcedures = storeProcedures;

            if (IsSqlConnection != null)
            {
                if (!(bool)IsSqlConnection)
                    this.connectType = ConnectType.ConnectionString;
            }
            if (needTransaction != null) { this.needTransaction = (bool)needTransaction; }
            if (namespaceName != null && namespaceName.Length > 0) { this.namespaceName = namespaceName; }
            if (className != null && className.Length > 0) { this.className = className; }
            if (functionAuthority != null && functionAuthority.Length > 0) { this.functionAuthority = functionAuthority; }
            if (execSqlClassName != null && execSqlClassName.Length > 0) { this.execSqlClassName = execSqlClassName; }
        }
        #endregion

        public string GetCode()
        {
            StringBuilder sbRetVal = new StringBuilder();
            StringBuilder sbFun = new StringBuilder();

            foreach (StoreProcedure var in storeProcedures)
            {
                sbFun = sbFun.Append(GetFunctionDefinition(var));
                sbFun.Replace("@@CreateCommand", GetCmdDefinition(var));
                sbFun.Replace("@@CommandExecute", GetCmdExecuteCode(var));
            }

            sbRetVal.Append(Properties.Resources.Resource.StorProcExecClassFile.Replace("@@namespace", this.namespaceName));
            sbRetVal = sbRetVal.Replace("@@class", this.className);
            sbRetVal = sbRetVal.Replace("@@StorProcExecClassFile", sbFun.ToString());

            return sbRetVal.ToString();
        }

        private string GetFunctionDefinition(StoreProcedure storeProcedure)
        {
            if (storeProcedure == null) throw new ArgumentNullException("StoreProcedure");

            int iTabCnt = 2;
            StringBuilder sb = new StringBuilder();
            
            sb.Append(GetFunSummary(storeProcedure));

            sb.Append(CodeHelper.AddTab(2) + functionAuthority);

            switch (storeProcedure.ProcExecuteReturnType)
            {
                case StoreProcedure.ExecuteReturnType.NonQuery:
                    sb.Append("int "); break;
                case StoreProcedure.ExecuteReturnType.DataReader:
                    sb.Append("SqlDataReader "); break;
                case StoreProcedure.ExecuteReturnType.Scalar:
                    sb.Append("object "); break;
                case StoreProcedure.ExecuteReturnType.Dataset:
                    sb.Append("DataSet "); break;
                case StoreProcedure.ExecuteReturnType.DataTable:
                    sb.Append("DataTable "); break;
            }

            #region 添加参数
            sb.Append(storeProcedure.Name.Replace(" ", "") + "(");

            foreach (SPField var in storeProcedure.Parameters)
            {
                sb.Append(", ");

                if (var.PARAMETER_MODE.Trim().ToUpper() == "IN")
                    sb.Append(CodeHelper.ConvertDBTypeToDoNetType(var.DATA_TYPE) + " " + CodeHelper.GetPureParmName(var.PARAMETER_NAME));
                else
                    sb.Append("ref " + CodeHelper.ConvertDBTypeToDoNetType(var.DATA_TYPE) + " " + CodeHelper.GetPureParmName(var.PARAMETER_NAME));
            }

            if (storeProcedure.NeedReturnValue)
                sb.Append(", ref int RETURN_VALUE");

            switch (this.connectType)
            {
                case ConnectType.ConnectionString:
                    sb.Append(", string connectionString"); break;
                case ConnectType.SqlConnection:
                    sb.Append(", SqlConnection connection"); break;
            }

            if (needTransaction && this.connectType == ConnectType.SqlConnection)
                sb.Append(", SqlTransaction transaction");

            sb.Replace("(, ", "(");

            sb.Append(")");
            #endregion

            sb.Append("\r\n" + CodeHelper.AddTab(2) + "{\r\n");

            iTabCnt = 3;

            sb.AppendLine(CodeHelper.AddTab(iTabCnt) + "@@CreateCommand\r\n");

            sb.AppendLine(CodeHelper.AddTab(iTabCnt) + "@@CommandExecute");

            sb.AppendLine(CodeHelper.AddTab(2) + "}\r\n");

            return sb.ToString();
        }

        private string GetFunSummary(StoreProcedure storeProcedure)
        {
            if (storeProcedure == null) throw new ArgumentNullException("StoreProcedure");

            string strTabs = "        /// ";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(strTabs + "<summary>");
            sb.AppendLine(strTabs + storeProcedure.Name);
            sb.AppendLine(strTabs + "</summary>");

            foreach (SPField var in storeProcedure.Parameters)
            {
                sb.AppendLine(strTabs + string.Format("<param name=\"{0}\">{0}</param>", CodeHelper.GetPureParmName(var.PARAMETER_NAME)));
            }

            if (storeProcedure.NeedReturnValue)
                sb.AppendLine(strTabs + string.Format("<param name=\"{0}\">{0}</param>", "RETURN_VALUE"));

            switch (this.connectType)
            {
                case ConnectType.ConnectionString:
                    sb.AppendLine(strTabs + string.Format("<param name=\"{0}\">{0}</param>", "connectionString")); break;
                case ConnectType.SqlConnection:
                    sb.AppendLine(strTabs + string.Format("<param name=\"{0}\">{0}</param>", "connection")); break;
            }

            if (needTransaction && this.connectType == ConnectType.SqlConnection)
                sb.AppendLine(strTabs + string.Format("<param name=\"{0}\">{0}</param>", "transaction"));

            sb.AppendLine(strTabs + "<returns></returns>");

            return sb.ToString();
        }

        private string GetCmdDefinition(StoreProcedure storeProcedure)
        {
            if (storeProcedure == null) throw new ArgumentNullException("StoreProcedure");

            int iTabCnt = 3;
            string strTabs = CodeHelper.AddTab(iTabCnt);
            StringBuilder sb = new StringBuilder("SqlCommand command = new SqlCommand();\r\n");

            sb.AppendLine(strTabs + "command.CommandText = \"" + storeProcedure.Name + "\";");
            sb.AppendLine(strTabs + "command.CommandType = System.Data.CommandType.StoredProcedure;\r\n");

            #region 添加命令参数
            StringBuilder sbCmdParm = new StringBuilder();
            string dbType, size, direction, isNullable = "false", precision, scale, sourceColumn = "", sourceVersion = "DataRowVersion.Current";

            foreach (SPField var in storeProcedure.Parameters)
            {
                string strAddParm = "", strPureName = CodeHelper.GetPureParmName(var.PARAMETER_NAME);

                dbType = CodeHelper.ConvertDBTypeToDoNetSqlDbType(var.DATA_TYPE);
                size = var.CHARACTER_MAXIMUM_LENGTH == null ? "0" : var.CHARACTER_MAXIMUM_LENGTH.ToString();
                direction=var.PARAMETER_MODE.Trim().ToUpper() == "IN"?"ParameterDirection.Input":"ParameterDirection.InputOutput";
                precision = var.NUMERIC_PRECISION == null ? "0" : var.NUMERIC_PRECISION.ToString();
                scale = var.NUMERIC_SCALE == null ? "0" : var.NUMERIC_SCALE.ToString();

                //                                         0              1                  2   3                         4     5  6   7             8                        9
                //command.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 11, ParameterDirection.Input, true, 0, 0, "Description", DataRowVersion.Current, "garden hose"));
                strAddParm = string.Format(strTabs + "command.Parameters.Add(new SqlParameter(\"@{0}\", {1}, {2}, {3}, {4}, {5}, {6}, \"{7}\", {8}, {9}));",
                                           strPureName, dbType, size, direction, isNullable, precision, scale, sourceColumn, sourceVersion, strPureName
                                          );

                sb.AppendLine(strAddParm);
            }

            if (storeProcedure.NeedReturnValue)
            {
                sb.AppendLine(strTabs + "command.Parameters.Add(new SqlParameter(\"@RETURN_VALUE\", SqlDbType.Int));");
                sb.Append(strTabs + "command.Parameters[\"@RETURN_VALUE\"].Direction = ParameterDirection.ReturnValue;");
            }

            #endregion

            return sb.ToString();
        }

        private string GetCmdExecuteCode(StoreProcedure storeProcedure)
        {
            if (storeProcedure == null) throw new ArgumentNullException("StoreProcedure");

            int iTabCnt = 3;
            string strTabs = CodeHelper.AddTab(iTabCnt);
            StringBuilder sb = new StringBuilder();

            switch (storeProcedure.ProcExecuteReturnType)
            {
                case StoreProcedure.ExecuteReturnType.NonQuery:
                    sb.AppendLine("int retVal = 0;"); break;
                case StoreProcedure.ExecuteReturnType.DataReader:
                    sb.AppendLine("SqlDataReader retVal = new SqlDataReader();"); break;
                case StoreProcedure.ExecuteReturnType.Scalar:
                    sb.AppendLine("object retVal;"); break;
                case StoreProcedure.ExecuteReturnType.Dataset:
                    sb.AppendLine("DataSet retVal = new DataSet();"); break;
                case StoreProcedure.ExecuteReturnType.DataTable:
                    sb.AppendLine("DataTable retVal = new DataTable();"); break;
            }

            sb.AppendLine();

            switch (this.connectType)
            {
                case ConnectType.SqlConnection:
                    sb.AppendLine(GetCallExecFuction(storeProcedure, iTabCnt) + "\r\n");
                    sb.Append(GetSetByRefVal(storeProcedure, iTabCnt));
                    break;
                case ConnectType.ConnectionString:
                    sb.AppendLine(CodeHelper.AddTab(iTabCnt) + "using (SqlConnection connection = new SqlConnection(connectionString))");
                    sb.AppendLine(CodeHelper.AddTab(iTabCnt) + "{");
                    sb.AppendLine(CodeHelper.AddTab(iTabCnt + 1) + "connection.Open();");
                    if (needTransaction)
                        sb.AppendLine(CodeHelper.AddTab(iTabCnt + 1) + "SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));");
                    sb.AppendLine();
                    sb.AppendLine(GetCallExecFuction(storeProcedure, iTabCnt + 1) + "\r\n");
                    sb.Append(GetSetByRefVal(storeProcedure, iTabCnt + 1));
                    sb.AppendLine(CodeHelper.AddTab(iTabCnt) + "}");
                    break;
            }

            sb.Append("\r\n" + strTabs + "return retVal;");

            return sb.ToString();
        }

        private string GetCallExecFuction(StoreProcedure storeProcedure, int tabCnt)
        {
            if (storeProcedure == null) throw new ArgumentNullException("StoreProcedure");

            int iTabCnt = tabCnt;
            string strTabs = CodeHelper.AddTab(iTabCnt);
            StringBuilder sb = new StringBuilder();
            string _execSqlClassName = execSqlClassName.Length > 0 ? execSqlClassName + "." : "";

            if (needTransaction)
            {
                switch (storeProcedure.ProcExecuteReturnType)
                {
                    case StoreProcedure.ExecuteReturnType.NonQuery:
                        sb.Append(strTabs + string.Format("retVal = {0}ExecuteNonQuery(command, connection, transaction);", _execSqlClassName)); break;
                    case StoreProcedure.ExecuteReturnType.DataReader:
                        sb.Append(strTabs + string.Format("retVal = {0}ExecuteReader(command, connection, transaction);", _execSqlClassName)); break;
                    case StoreProcedure.ExecuteReturnType.Scalar:
                        sb.Append(strTabs + string.Format("retVal = {0}ExecuteScalar(command, connection, transaction);", _execSqlClassName)); break;
                    case StoreProcedure.ExecuteReturnType.Dataset:
                        sb.Append(strTabs + string.Format("retVal = {0}ExecuteDataset(command, connection, transaction);", _execSqlClassName)); break;
                    case StoreProcedure.ExecuteReturnType.DataTable:
                        sb.Append(strTabs + string.Format("retVal = {0}ExecuteDataTable(command, connection, transaction);", _execSqlClassName)); break;
                }
            }
            else
            {
                switch (storeProcedure.ProcExecuteReturnType)
                {
                    case StoreProcedure.ExecuteReturnType.NonQuery:
                        sb.Append(strTabs + string.Format("retVal = {0}ExecuteNonQuery(command, connection);", _execSqlClassName)); break;
                    case StoreProcedure.ExecuteReturnType.DataReader:
                        sb.Append(strTabs + string.Format("retVal = {0}ExecuteReader(command, connection);", _execSqlClassName)); break;
                    case StoreProcedure.ExecuteReturnType.Scalar:
                        sb.Append(strTabs + string.Format("retVal = {0}ExecuteScalar(command, connection);", _execSqlClassName)); break;
                    case StoreProcedure.ExecuteReturnType.Dataset:
                        sb.Append(strTabs + string.Format("retVal = {0}ExecuteDataset(command, connection);", _execSqlClassName)); break;
                    case StoreProcedure.ExecuteReturnType.DataTable:
                        sb.Append(strTabs + string.Format("retVal = {0}ExecuteDataTable(command, connection);", _execSqlClassName)); break;
                }
            }

            return sb.ToString();
        }

        private string GetSetByRefVal(StoreProcedure storeProcedure, int tabCnt)
        {
            if (storeProcedure == null) throw new ArgumentNullException("StoreProcedure");

            int iTabCnt = tabCnt;
            string strTabs = CodeHelper.AddTab(iTabCnt);
            StringBuilder sb = new StringBuilder();

            foreach (SPField var in storeProcedure.Parameters)
            {
                if (var.PARAMETER_MODE.Trim().ToUpper() != "IN")
                {
                    sb.AppendLine(strTabs + string.Format("{0} = ({1})command.Parameters[\"@{0}\"].Value;", CodeHelper.GetPureParmName(var.PARAMETER_NAME), CodeHelper.ConvertDBTypeToDoNetType(var.DATA_TYPE)));
                }
            }

            if (storeProcedure.NeedReturnValue)
            {
                sb.AppendLine (strTabs + "RETURN_VALUE = (int)command.Parameters[\"@RETURN_VALUE\"].Value;");
            }

            return sb.ToString();
        }
    }
}
