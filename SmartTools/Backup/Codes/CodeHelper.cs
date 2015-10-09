using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Codes
{
    public class CodeHelper
    {
        public static void AppendFormat(StringBuilder code, int tabCount, string format, params object[] args)
        {
            for (int i = 0; i < tabCount; i++)
            {
                format = format.Insert(0, "\t");
            }
            if ((args != null) && (args.Length > 0))
            {
                code.Append(string.Format(format, args));
            }
            else
            {
                code.Append(format);
            }
        }

        public static void AppendFormatLine(StringBuilder code, int tabCount, string format, params object[] args)
        {
            for (int i = 0; i < tabCount; i++)
            {
                format = format.Insert(0, "\t");
            }
            if ((args != null) && (args.Length > 0))
            {
                code.AppendLine(string.Format(format, args));
            }
            else
            {
                code.AppendLine(format);
            }
        }

        public static string AddTab(int tabCount)
        {
            if (tabCount <= 0) return "";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < tabCount; i++)
            {
                sb.Append("\t");
            }

            return sb.ToString();
        }

        public static string ConvertDBTypeToDoNetType(string TypeName)
        {
            string retVal = "";
            switch (TypeName.Trim().ToLower())
            {
                case "bigint":
                    retVal = "Int64"; break;
                case "binary":
                    retVal = "Byte[]"; break;
                case "bit":
                    retVal = "Boolean"; break;
                case "char":
                    retVal = "String"; break;
                case "datetime":
                    retVal = "DateTime"; break;
                case "decimal":
                    retVal = "Decimal"; break;
                case "float":
                    retVal = "Double"; break;
                case "image":
                    retVal = "Byte[]"; break;
                case "int":
                    retVal = "Int32"; break;
                case "money":
                    retVal = "Decimal"; break;
                case "nchar":
                    retVal = "String"; break;
                case "ntext":
                    retVal = "String"; break;
                case "numeric":
                    retVal = "Decimal"; break;
                case "nvarchar":
                    retVal = "String"; break;
                case "real":
                    retVal = "Single"; break;
                case "smalldatetime":
                    retVal = "DateTime"; break;
                case "smallint":
                    retVal = "Int16"; break;
                case "smallmoney":
                    retVal = "Decimal"; break;
                case "sql_variant":
                    retVal = "Object"; break;
                case "sysname":
                    retVal = "String"; break;
                case "text":
                    retVal = "String"; break;
                case "timestamp":
                    retVal = "Byte[]"; break;
                case "tinyint":
                    retVal = "Byte"; break;
                case "uniqueidentifier":
                    retVal = "Guid"; break;
                case "varbinary":
                    retVal = "Byte[]"; break;
                case "varchar":
                    retVal = "String"; break;
                case "xml":
                    retVal = "String"; break;
                default:
                    break;
            }

            return retVal;
        }

        public static string ConvertDBTypeToDoNetSqlType(string TypeName)
        {
            string retVal = "";
            switch (TypeName.Trim().ToLower())
            {
                case "bigint":
                    retVal = "SqlTypes.SqlInt64"; break;
                case "binary":
                    retVal = "SqlTypes.SqlBinary"; break;
                case "bit":
                    retVal = "SqlTypes.SqlBoolean"; break;
                case "char":
                    retVal = "SqlTypes.SqlString"; break;
                case "datetime":
                    retVal = "SqlTypes.SqlDateTime"; break;
                case "decimal":
                    retVal = "SqlTypes.SqlDecimal"; break;
                case "float":
                    retVal = "SqlTypes.SqlDouble"; break;
                case "image":
                    retVal = "SqlTypes.SqlBinary"; break;
                case "int":
                    retVal = "SqlTypes.SqlInt32"; break;
                case "money":
                    retVal = "SqlTypes.SqlMoney"; break;
                case "nchar":
                    retVal = "SqlTypes.SqlString"; break;
                case "ntext":
                    retVal = "SqlTypes.SqlString"; break;
                case "numeric":
                    retVal = "SqlTypes.SqlDecimal"; break;
                case "nvarchar":
                    retVal = "SqlTypes.SqlString"; break;
                case "real":
                    retVal = "SqlTypes.SqlSingle"; break;
                case "smalldatetime":
                    retVal = "SqlTypes.SqlDateTime"; break;
                case "smallint":
                    retVal = "SqlTypes.SqlInt16"; break;
                case "smallmoney":
                    retVal = "SqlTypes.SqlMoney"; break;
                case "sql_variant":
                    retVal = "System.Object"; break;
                case "sysname":
                    retVal = "SqlTypes.SqlString"; break;
                case "text":
                    retVal = "SqlTypes.SqlString"; break;
                case "timestamp":
                    retVal = "SqlTypes.SqlBinary"; break;
                case "tinyint":
                    retVal = "SqlTypes.SqlByte"; break;
                case "uniqueidentifier":
                    retVal = "SqlTypes.SqlGuid"; break;
                case "varbinary":
                    retVal = "SqlTypes.SqlBinary"; break;
                case "varchar":
                    retVal = "SqlTypes.SqlString"; break;
                case "xml":
                    retVal = "SqlTypes.SqlXml"; break;
                default:
                    break;
            }

            return retVal;
        }

        public static string ConvertDBTypeToDoNetSqlDbType(string TypeName)
        {
            string retVal = "";
            switch (TypeName.Trim().ToLower())
            {
                case "bigint":
                    retVal = "SqlDbType.BigInt"; break;
                case "binary":
                    retVal = "SqlDbType.Binary"; break;
                case "bit":
                    retVal = "SqlDbType.Bit"; break;
                case "char":
                    retVal = "SqlDbType.Char"; break;
                case "datetime":
                    retVal = "SqlDbType.DateTime"; break;
                case "decimal":
                    retVal = "SqlDbType.Decimal"; break;
                case "float":
                    retVal = "SqlDbType.Float"; break;
                case "image":
                    retVal = "SqlDbType.Image"; break;
                case "int":
                    retVal = "SqlDbType.Int"; break;
                case "money":
                    retVal = "SqlDbType.Money"; break;
                case "nchar":
                    retVal = "SqlDbType.NChar"; break;
                case "ntext":
                    retVal = "SqlDbType.NText"; break;
                case "numeric":
                    retVal = "SqlDbType.Decimal"; break;      //没有"numeric"
                case "nvarchar":
                    retVal = "SqlDbType.NVarChar"; break;
                case "real":
                    retVal = "SqlDbType.Real"; break;
                case "smalldatetime":
                    retVal = "SqlDbType.SmallDateTime"; break;
                case "smallint":
                    retVal = "SqlDbType.SmallInt"; break;
                case "smallmoney":
                    retVal = "SqlDbType.SmallMoney"; break;
                case "sql_variant":
                    retVal = "SqlDbType.Variant"; break;
                case "sysname":
                    retVal = "SqlDbType.Text"; break;     //没有"sysname"
                case "text":
                    retVal = "SqlDbType.Text"; break;
                case "timestamp":
                    retVal = "SqlDbType.Timestamp"; break;
                case "tinyint":
                    retVal = "SqlDbType.TinyInt"; break;
                case "uniqueidentifier":
                    retVal = "SqlDbType.UniqueIdentifier"; break;
                case "varbinary":
                    retVal = "SqlDbType.VarBinary"; break;
                case "varchar":
                    retVal = "SqlDbType.VarChar"; break;
                case "xml":
                    retVal = "SqlDbType.Xml"; break;
                default:
                    retVal = "SqlDbType.Udt"; break;
            }

            return retVal;
        }

        public static string GetPureParmName(string ParmName)
        {
            return ParmName.Trim().Replace("@", "");
        }
    }
}
