using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SmartTools
{
    public class SqlStoredProcedureExecute
    {
        /// <summary>
        /// AccessDetRights_UserScreenRights
        /// </summary>
        /// <param name="ScreenId">ScreenId</param>
        /// <param name="UserId">UserId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AccessDetRights_UserScreenRights(String ScreenId, String UserId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AccessDetRights_UserScreenRights";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ScreenId", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ScreenId));
            command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UserId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AccuBaseComp
        /// </summary>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AccuBaseComp(String Pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AccuBaseComp";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AccuBaseCompS
        /// </summary>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AccuBaseCompS(String Pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AccuBaseCompS";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AccuBaseMonth
        /// </summary>
        /// <param name="Flag">Flag</param>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="sdeptid">sdeptid</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AccuBaseMonth(Int32 Flag, String Pernbr, String sdeptid, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AccuBaseMonth";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Flag));
            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@sdeptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sdeptid));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AccuBaseMonthS
        /// </summary>
        /// <param name="Flag">Flag</param>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="sdeptid">sdeptid</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AccuBaseMonthS(Int32 Flag, String Pernbr, String sdeptid, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AccuBaseMonthS";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Flag));
            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@sdeptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sdeptid));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AnnuityBaseCheck
        /// </summary>
        /// <param name="bj">bj</param>
        /// <param name="C1">C1</param>
        /// <param name="jpernbr">jpernbr</param>
        /// <param name="sdeptid">sdeptid</param>
        /// <param name="sempid">sempid</param>
        /// <param name="Year">Year</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AnnuityBaseCheck(Int32 bj, String C1, String jpernbr, String sdeptid, String sempid, String Year, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AnnuityBaseCheck";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@bj", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, bj));
            command.Parameters.Add(new SqlParameter("@C1", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C1));
            command.Parameters.Add(new SqlParameter("@jpernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, jpernbr));
            command.Parameters.Add(new SqlParameter("@sdeptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sdeptid));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@Year", SqlDbType.NVarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Year));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AnnuityBaseCheckIni
        /// </summary>
        /// <param name="bj">bj</param>
        /// <param name="C1">C1</param>
        /// <param name="jpernbr">jpernbr</param>
        /// <param name="sdeptid">sdeptid</param>
        /// <param name="sempid">sempid</param>
        /// <param name="Year">Year</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AnnuityBaseCheckIni(Int32 bj, String C1, String jpernbr, String sdeptid, String sempid, String Year, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AnnuityBaseCheckIni";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@bj", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, bj));
            command.Parameters.Add(new SqlParameter("@C1", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C1));
            command.Parameters.Add(new SqlParameter("@jpernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, jpernbr));
            command.Parameters.Add(new SqlParameter("@sdeptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sdeptid));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@Year", SqlDbType.NVarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Year));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AnnuityBaseComp
        /// </summary>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AnnuityBaseComp(String Pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AnnuityBaseComp";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AnnuityBaseCompS
        /// </summary>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AnnuityBaseCompS(String Pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AnnuityBaseCompS";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AnnuityBaseMonth
        /// </summary>
        /// <param name="C1">C1</param>
        /// <param name="Flag">Flag</param>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="sdeptid">sdeptid</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AnnuityBaseMonth(String C1, Int32 Flag, String Pernbr, String sdeptid, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AnnuityBaseMonth";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@C1", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C1));
            command.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Flag));
            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@sdeptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sdeptid));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AnnuityBaseMonthS
        /// </summary>
        /// <param name="C1">C1</param>
        /// <param name="Flag">Flag</param>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="sdeptid">sdeptid</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AnnuityBaseMonthS(String C1, Int32 Flag, String Pernbr, String sdeptid, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AnnuityBaseMonthS";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@C1", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C1));
            command.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Flag));
            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@sdeptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sdeptid));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AnnuityNewEmply
        /// </summary>
        /// <param name="C1">C1</param>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="sdeptid">sdeptid</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AnnuityNewEmply(String C1, String Pernbr, String sdeptid, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AnnuityNewEmply";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@C1", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C1));
            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@sdeptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sdeptid));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// ApplianceCrossJoin
        /// </summary>
        /// <param name="Status">Status</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int ApplianceCrossJoin(String Status, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "ApplianceCrossJoin";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Status));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AutoAssignUnuseField
        /// </summary>
        /// <param name="Table">Table</param>
        /// <param name="Type">Type</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AutoAssignUnuseField(String Table, String Type, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AutoAssignUnuseField";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Table", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Table));
            command.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Type));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AutoCalVacaTion
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AutoCalVacaTion(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AutoCalVacaTion";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AutoInit_WA_Assign
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AutoInit_WA_Assign(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AutoInit_WA_Assign";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AutoOverTime
        /// </summary>
        /// <param name="cB1D">cB1D</param>
        /// <param name="cB2D">cB2D</param>
        /// <param name="cB3D">cB3D</param>
        /// <param name="cEmpidD">cEmpidD</param>
        /// <param name="cEmpnameD">cEmpnameD</param>
        /// <param name="cflagD">cflagD</param>
        /// <param name="cOCCURTIMED">cOCCURTIMED</param>
        /// <param name="cstrDateD">cstrDateD</param>
        /// <param name="cT11D">cT11D</param>
        /// <param name="cT12D">cT12D</param>
        /// <param name="cT21D">cT21D</param>
        /// <param name="cT22D">cT22D</param>
        /// <param name="cT31D">cT31D</param>
        /// <param name="cT32D">cT32D</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AutoOverTime(String cB1D, String cB2D, String cB3D, String cEmpidD, String cEmpnameD, String cflagD, String cOCCURTIMED, DateTime cstrDateD, String cT11D, String cT12D, String cT21D, String cT22D, String cT31D, String cT32D, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AutoOverTime";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@cB1D", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cB1D));
            command.Parameters.Add(new SqlParameter("@cB2D", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cB2D));
            command.Parameters.Add(new SqlParameter("@cB3D", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cB3D));
            command.Parameters.Add(new SqlParameter("@cEmpidD", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cEmpidD));
            command.Parameters.Add(new SqlParameter("@cEmpnameD", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cEmpnameD));
            command.Parameters.Add(new SqlParameter("@cflagD", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cflagD));
            command.Parameters.Add(new SqlParameter("@cOCCURTIMED", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cOCCURTIMED));
            command.Parameters.Add(new SqlParameter("@cstrDateD", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, cstrDateD));
            command.Parameters.Add(new SqlParameter("@cT11D", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cT11D));
            command.Parameters.Add(new SqlParameter("@cT12D", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cT12D));
            command.Parameters.Add(new SqlParameter("@cT21D", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cT21D));
            command.Parameters.Add(new SqlParameter("@cT22D", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cT22D));
            command.Parameters.Add(new SqlParameter("@cT31D", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cT31D));
            command.Parameters.Add(new SqlParameter("@cT32D", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cT32D));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// AutoUpdateLevel
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int AutoUpdateLevel(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AutoUpdateLevel";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CheckBusMaxNumbers
        /// </summary>
        /// <param name="BFlag">BFlag</param>
        /// <param name="SpotID">SpotID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CheckBusMaxNumbers(String BFlag, String SpotID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CheckBusMaxNumbers";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@BFlag", SqlDbType.VarChar, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, BFlag));
            command.Parameters.Add(new SqlParameter("@SpotID", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SpotID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CheckMenuNeedLoad
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CheckMenuNeedLoad(String userId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CheckMenuNeedLoad";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@userId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, userId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CountEmployeeField
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CountEmployeeField(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CountEmployeeField";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CountSalaryField
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CountSalaryField(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CountSalaryField";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// cp_CarryOverYearHolidays
        /// </summary>
        /// <param name="Period">Period</param>
        /// <param name="strWhere">strWhere</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int cp_CarryOverYearHolidays(String Period, String strWhere, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "cp_CarryOverYearHolidays";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Period", SqlDbType.NVarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Period));
            command.Parameters.Add(new SqlParameter("@strWhere", SqlDbType.VarChar, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strWhere));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// cp_GetGeneralHolidaysPass
        /// </summary>
        /// <param name="cDate">cDate</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int cp_GetGeneralHolidaysPass(DateTime cDate, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "cp_GetGeneralHolidaysPass";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@cDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, cDate));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// cp_InitYearHolidays
        /// </summary>
        /// <param name="Period">Period</param>
        /// <param name="strWhere">strWhere</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int cp_InitYearHolidays(String Period, String strWhere, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "cp_InitYearHolidays";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Period", SqlDbType.NVarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Period));
            command.Parameters.Add(new SqlParameter("@strWhere", SqlDbType.VarChar, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strWhere));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CreateDeptGroupRpt
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CreateDeptGroupRpt(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CreateDeptGroupRpt";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CreateDeptRelactionAll
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CreateDeptRelactionAll(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CreateDeptRelactionAll";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CreateDeptRelactionText
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CreateDeptRelactionText(String DeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CreateDeptRelactionText";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CreateFullInformationGroupReport
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CreateFullInformationGroupReport(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CreateFullInformationGroupReport";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CreateFullInformationSalaryReport
        /// </summary>
        /// <param name="PerEnd">PerEnd</param>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CreateFullInformationSalaryReport(String PerEnd, String Pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CreateFullInformationSalaryReport";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@PerEnd", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, PerEnd));
            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CreateNewSalaryTable
        /// </summary>
        /// <param name="NewTableName">NewTableName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CreateNewSalaryTable(String NewTableName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CreateNewSalaryTable";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@NewTableName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, NewTableName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CreateTempDeptInfo
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CreateTempDeptInfo(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CreateTempDeptInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// CreateTemplate
        /// </summary>
        /// <param name="Descr">Descr</param>
        /// <param name="Designer">Designer</param>
        /// <param name="Type">Type</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int CreateTemplate(String Descr, String Designer, String Type, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CreateTemplate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Descr", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Descr));
            command.Parameters.Add(new SqlParameter("@Designer", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Designer));
            command.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Type));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Createturndetail
        /// </summary>
        /// <param name="t1">t1</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Createturndetail(String t1, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Createturndetail";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@t1", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, t1));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DataVertify_AccountNo
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DataVertify_AccountNo(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DataVertify_AccountNo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DataVertify_cardno
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DataVertify_cardno(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DataVertify_cardno";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DataVertify_Dept
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DataVertify_Dept(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DataVertify_Dept";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DataVertify_Idcard
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DataVertify_Idcard(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DataVertify_Idcard";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DataVertify_Name
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DataVertify_Name(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DataVertify_Name";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DataVertify_Salary
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DataVertify_Salary(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DataVertify_Salary";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DataVertify_Sex
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DataVertify_Sex(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DataVertify_Sex";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DataVertify_TimeCard
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DataVertify_TimeCard(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DataVertify_TimeCard";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DataVertify_TurnID
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DataVertify_TurnID(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DataVertify_TurnID";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DeleteUnRefEmplyRecord
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DeleteUnRefEmplyRecord(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeleteUnRefEmplyRecord";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Department_DeptId
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Department_DeptId(String DeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Department_DeptId";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Dept_DeleteById
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Dept_DeleteById(String DeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Dept_DeleteById";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Dept_TreeList
        /// </summary>
        /// <param name="DeptID">DeptID</param>
        /// <param name="Level">Level</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Dept_TreeList(String DeptID, Int32 Level, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Dept_TreeList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptID));
            command.Parameters.Add(new SqlParameter("@Level", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Level));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Dept_TreeListWithEmployee
        /// </summary>
        /// <param name="DeptID">DeptID</param>
        /// <param name="Level">Level</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Dept_TreeListWithEmployee(String DeptID, Int32 Level, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Dept_TreeListWithEmployee";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptID));
            command.Parameters.Add(new SqlParameter("@Level", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Level));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DeptAutoList
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DeptAutoList(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeptAutoList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DeptAutoListwithEmployee
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DeptAutoListwithEmployee(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeptAutoListwithEmployee";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DeptCheck
        /// </summary>
        /// <param name="DeptChecked">DeptChecked</param>
        /// <param name="DeptId">DeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DeptCheck(String DeptChecked, String DeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeptCheck";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptChecked", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptChecked));
            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DeptCountCQbyDate
        /// </summary>
        /// <param name="CheckDate">CheckDate</param>
        /// <param name="DeptId">DeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DeptCountCQbyDate(DateTime CheckDate, String DeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeptCountCQbyDate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CheckDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, CheckDate));
            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DeptCountEmply
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="LocalOrForeign">LocalOrForeign</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DeptCountEmply(String DeptId, Int32 LocalOrForeign, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeptCountEmply";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@LocalOrForeign", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, LocalOrForeign));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DeptCountEmplybyDate
        /// </summary>
        /// <param name="CheckDate">CheckDate</param>
        /// <param name="DeptId">DeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DeptCountEmplybyDate(DateTime CheckDate, String DeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeptCountEmplybyDate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CheckDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, CheckDate));
            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DeptCountEmplybyMonth
        /// </summary>
        /// <param name="CheckDate">CheckDate</param>
        /// <param name="DeptId">DeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DeptCountEmplybyMonth(DateTime CheckDate, String DeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeptCountEmplybyMonth";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CheckDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, CheckDate));
            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DeptInfoSync
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DeptInfoSync(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeptInfoSync";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// DeptOldUnActive
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int DeptOldUnActive(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeptOldUnActive";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Emp_TreeList
        /// </summary>
        /// <param name="EmpPId">EmpPId</param>
        /// <param name="Level">Level</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Emp_TreeList(Int32 EmpPId, Int32 Level, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Emp_TreeList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@EmpPId", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpPId));
            command.Parameters.Add(new SqlParameter("@Level", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Level));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// EmpInfoAutoAssignUnuseField
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int EmpInfoAutoAssignUnuseField(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "EmpInfoAutoAssignUnuseField";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// EmployeeAutoList
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int EmployeeAutoList(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "EmployeeAutoList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// EmplyForDept
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int EmplyForDept(String DeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "EmplyForDept";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// EnumDeptList
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int EnumDeptList(String DeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "EnumDeptList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// ExecSp
        /// </summary>
        /// <param name="PName">PName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int ExecSp(String PName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "ExecSp";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@PName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, PName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_bnewEmply
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_bnewEmply(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_bnewEmply";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetAbsentfromworkHours
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetAbsentfromworkHours(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetAbsentfromworkHours";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_getActualCalDays
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_getActualCalDays(String pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_getActualCalDays";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_getActualDiffCalDays
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_getActualDiffCalDays(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_getActualDiffCalDays";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_getActualhours
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_getActualhours(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_getActualhours";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetAllowance
        /// </summary>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetAllowance(String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetAllowance";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetBeginHolidaysDate
        /// </summary>
        /// <param name="currentdate">currentdate</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetBeginHolidaysDate(DateTime currentdate, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetBeginHolidaysDate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@currentdate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, currentdate));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetBornLeave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetBornLeave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetBornLeave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetDeadLeave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetDeadLeave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetDeadLeave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_getdeptname
        /// </summary>
        /// <param name="DeptID">DeptID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_getdeptname(String DeptID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_getdeptname";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_getdeptsalary
        /// </summary>
        /// <param name="amt">amt</param>
        /// <param name="sdeptlist">sdeptlist</param>
        /// <param name="sgzitem">sgzitem</param>
        /// <param name="smonth">smonth</param>
        /// <param name="syear">syear</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_getdeptsalary(ref String amt, String sdeptlist, String sgzitem, String smonth, String syear, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_getdeptsalary";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@amt", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, amt));
            command.Parameters.Add(new SqlParameter("@sdeptlist", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sdeptlist));
            command.Parameters.Add(new SqlParameter("@sgzitem", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sgzitem));
            command.Parameters.Add(new SqlParameter("@smonth", SqlDbType.Char, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, smonth));
            command.Parameters.Add(new SqlParameter("@syear", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, syear));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                amt = (String)command.Parameters["@amt"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetEndHolidaysDate
        /// </summary>
        /// <param name="currentdate">currentdate</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetEndHolidaysDate(DateTime currentdate, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetEndHolidaysDate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@currentdate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, currentdate));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetF45Leave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetF45Leave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetF45Leave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetF46Leave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetF46Leave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetF46Leave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetF47Leave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetF47Leave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetF47Leave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetF48Leave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetF48Leave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetF48Leave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetF49Leave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetF49Leave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetF49Leave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetF50Leave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetF50Leave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetF50Leave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetF51Leave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetF51Leave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetF51Leave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetF52Leave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetF52Leave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetF52Leave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetF53Leave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetF53Leave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetF53Leave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetF54Leave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetF54Leave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetF54Leave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetF55Leave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetF55Leave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetF55Leave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetGeneralHolidays
        /// </summary>
        /// <param name="currentdate">currentdate</param>
        /// <param name="lastyearrate">lastyearrate</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetGeneralHolidays(DateTime currentdate, Double lastyearrate, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetGeneralHolidays";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@currentdate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, currentdate));
            command.Parameters.Add(new SqlParameter("@lastyearrate", SqlDbType.Float, 0, ParameterDirection.Input, false, 53, 0, "", DataRowVersion.Current, lastyearrate));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetGeneralHolidaysHours
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetGeneralHolidaysHours(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetGeneralHolidaysHours";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetGeneralHolidaysPass
        /// </summary>
        /// <param name="begindate">begindate</param>
        /// <param name="enddate">enddate</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetGeneralHolidaysPass(DateTime begindate, DateTime enddate, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetGeneralHolidaysPass";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@begindate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, begindate));
            command.Parameters.Add(new SqlParameter("@enddate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, enddate));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetL12
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetL12(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetL12";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetLastYearRate
        /// </summary>
        /// <param name="currentdate">currentdate</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetLastYearRate(DateTime currentdate, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetLastYearRate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@currentdate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, currentdate));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetMarriedLeave
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetMarriedLeave(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetMarriedLeave";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_getMiddleShift
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_getMiddleShift(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_getMiddleShift";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_getMiddleShift2
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_getMiddleShift2(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_getMiddleShift2";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_getMorningShift
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_getMorningShift(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_getMorningShift";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_getNightShift
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_getNightShift(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_getNightShift";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetNoWorkDay
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetNoWorkDay(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetNoWorkDay";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetOvertime1Hours
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetOvertime1Hours(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetOvertime1Hours";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetOvertime2Hours
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetOvertime2Hours(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetOvertime2Hours";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetOvertime3Hours
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetOvertime3Hours(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetOvertime3Hours";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetPrivateLeaveHours
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetPrivateLeaveHours(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetPrivateLeaveHours";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetSickLeaveHours
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetSickLeaveHours(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetSickLeaveHours";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetSumBJ
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetSumBJ(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetSumBJ";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetYearAmt
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetYearAmt(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetYearAmt";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_GetYearTaxAmt
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_GetYearTaxAmt(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_GetYearTaxAmt";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// f_HEDeptKQRate
        /// </summary>
        /// <param name="Datetime">Datetime</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int f_HEDeptKQRate(DateTime Datetime, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "f_HEDeptKQRate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Datetime", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, Datetime));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// F_IsFiredEmp
        /// </summary>
        /// <param name="perNbr">perNbr</param>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int F_IsFiredEmp(String perNbr, String sEmpId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "F_IsFiredEmp";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@perNbr", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, perNbr));
            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// FieldAdjGetMaxNumbers
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int FieldAdjGetMaxNumbers(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "FieldAdjGetMaxNumbers";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Fog_AMPerfInfo
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Fog_AMPerfInfo(Boolean Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Fog_AMPerfInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Bit, 0, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Fog_BMPerfInfo
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Fog_BMPerfInfo(Boolean Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Fog_BMPerfInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Bit, 0, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Fog_DBPerfInfo
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Fog_DBPerfInfo(Boolean Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Fog_DBPerfInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Bit, 0, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Fog_Jobs
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="LastCollected">LastCollected</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Fog_Jobs(Boolean Debug, DateTime LastCollected, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Fog_Jobs";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Bit, 0, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@LastCollected", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, LastCollected));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Fog_MMPerfInfo
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Fog_MMPerfInfo(Boolean Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Fog_MMPerfInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Bit, 0, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Fog_Trace
        /// </summary>
        /// <param name="Cpu">Cpu</param>
        /// <param name="Deadlocks">Deadlocks</param>
        /// <param name="Debug">Debug</param>
        /// <param name="DummyCall">DummyCall</param>
        /// <param name="Duration">Duration</param>
        /// <param name="EndTrace">EndTrace</param>
        /// <param name="FreqSecs">FreqSecs</param>
        /// <param name="GetGlobalTraceSQL">GetGlobalTraceSQL</param>
        /// <param name="MaxRowsPerRun">MaxRowsPerRun</param>
        /// <param name="MinSecsBetweenDataCollection">MinSecsBetweenDataCollection</param>
        /// <param name="Reads">Reads</param>
        /// <param name="Rpc">Rpc</param>
        /// <param name="Sqlbatch">Sqlbatch</param>
        /// <param name="SqlStatement">SqlStatement</param>
        /// <param name="Writes">Writes</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Fog_Trace(Int32 Cpu, Int32 Deadlocks, String Debug, String DummyCall, Int32 Duration, String EndTrace, Int32 FreqSecs, String GetGlobalTraceSQL, Int32 MaxRowsPerRun, Int32 MinSecsBetweenDataCollection, Int32 Reads, Int32 Rpc, Int32 Sqlbatch, Int32 SqlStatement, Int32 Writes, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Fog_Trace";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Cpu", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Cpu));
            command.Parameters.Add(new SqlParameter("@Deadlocks", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Deadlocks));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DummyCall", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DummyCall));
            command.Parameters.Add(new SqlParameter("@Duration", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Duration));
            command.Parameters.Add(new SqlParameter("@EndTrace", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, EndTrace));
            command.Parameters.Add(new SqlParameter("@FreqSecs", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, FreqSecs));
            command.Parameters.Add(new SqlParameter("@GetGlobalTraceSQL", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GetGlobalTraceSQL));
            command.Parameters.Add(new SqlParameter("@MaxRowsPerRun", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxRowsPerRun));
            command.Parameters.Add(new SqlParameter("@MinSecsBetweenDataCollection", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MinSecsBetweenDataCollection));
            command.Parameters.Add(new SqlParameter("@Reads", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Reads));
            command.Parameters.Add(new SqlParameter("@Rpc", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Rpc));
            command.Parameters.Add(new SqlParameter("@Sqlbatch", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Sqlbatch));
            command.Parameters.Add(new SqlParameter("@SqlStatement", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, SqlStatement));
            command.Parameters.Add(new SqlParameter("@Writes", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Writes));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Fog_TraceControl
        /// </summary>
        /// <param name="CalledBySpid">CalledBySpid</param>
        /// <param name="CheckQueueExists">CheckQueueExists</param>
        /// <param name="Cleanup">Cleanup</param>
        /// <param name="Debug">Debug</param>
        /// <param name="DeleteFile">DeleteFile</param>
        /// <param name="EndTrace">EndTrace</param>
        /// <param name="FreqSecs">FreqSecs</param>
        /// <param name="GetGlobalTraceSQL">GetGlobalTraceSQL</param>
        /// <param name="MaxRowsPerRun">MaxRowsPerRun</param>
        /// <param name="MinSecsBetweenDataCollection">MinSecsBetweenDataCollection</param>
        /// <param name="RefreshEventNames">RefreshEventNames</param>
        /// <param name="RetainMins">RetainMins</param>
        /// <param name="StartTrace">StartTrace</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Fog_TraceControl(Int32 CalledBySpid, String CheckQueueExists, String Cleanup, String Debug, String DeleteFile, String EndTrace, Int32 FreqSecs, String GetGlobalTraceSQL, Int32 MaxRowsPerRun, Int32 MinSecsBetweenDataCollection, String RefreshEventNames, Int32 RetainMins, String StartTrace, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Fog_TraceControl";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CalledBySpid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, CalledBySpid));
            command.Parameters.Add(new SqlParameter("@CheckQueueExists", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CheckQueueExists));
            command.Parameters.Add(new SqlParameter("@Cleanup", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Cleanup));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DeleteFile", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeleteFile));
            command.Parameters.Add(new SqlParameter("@EndTrace", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, EndTrace));
            command.Parameters.Add(new SqlParameter("@FreqSecs", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, FreqSecs));
            command.Parameters.Add(new SqlParameter("@GetGlobalTraceSQL", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GetGlobalTraceSQL));
            command.Parameters.Add(new SqlParameter("@MaxRowsPerRun", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxRowsPerRun));
            command.Parameters.Add(new SqlParameter("@MinSecsBetweenDataCollection", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MinSecsBetweenDataCollection));
            command.Parameters.Add(new SqlParameter("@RefreshEventNames", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, RefreshEventNames));
            command.Parameters.Add(new SqlParameter("@RetainMins", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, RetainMins));
            command.Parameters.Add(new SqlParameter("@StartTrace", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, StartTrace));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Fog_TraceEnd
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="DeleteFile">DeleteFile</param>
        /// <param name="MsgOut">MsgOut</param>
        /// <param name="MySpid">MySpid</param>
        /// <param name="SQL2KTraceFileName">SQL2KTraceFileName</param>
        /// <param name="TraceQueueNbr">TraceQueueNbr</param>
        /// <param name="TraceTBName">TraceTBName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Fog_TraceEnd(String Debug, String DeleteFile, ref String MsgOut, Int32 MySpid, String SQL2KTraceFileName, Int32 TraceQueueNbr, String TraceTBName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Fog_TraceEnd";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DeleteFile", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeleteFile));
            command.Parameters.Add(new SqlParameter("@MsgOut", SqlDbType.VarChar, 100, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, MsgOut));
            command.Parameters.Add(new SqlParameter("@MySpid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MySpid));
            command.Parameters.Add(new SqlParameter("@SQL2KTraceFileName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SQL2KTraceFileName));
            command.Parameters.Add(new SqlParameter("@TraceQueueNbr", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, TraceQueueNbr));
            command.Parameters.Add(new SqlParameter("@TraceTBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TraceTBName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                MsgOut = (String)command.Parameters["@MsgOut"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Fog_TraceMaintainSQL
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="InsertCnt">InsertCnt</param>
        /// <param name="WorkTBName">WorkTBName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Fog_TraceMaintainSQL(String Debug, Int32 InsertCnt, String WorkTBName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Fog_TraceMaintainSQL";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@InsertCnt", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, InsertCnt));
            command.Parameters.Add(new SqlParameter("@WorkTBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, WorkTBName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Fog_TraceRefreshEventNames
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Fog_TraceRefreshEventNames(String Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Fog_TraceRefreshEventNames";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Fog_TraceStart
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="FreqSecs">FreqSecs</param>
        /// <param name="GetGlobalTraceSQL">GetGlobalTraceSQL</param>
        /// <param name="MySpid">MySpid</param>
        /// <param name="TraceQueueNbr">TraceQueueNbr</param>
        /// <param name="TraceTBName">TraceTBName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Fog_TraceStart(String Debug, Int32 FreqSecs, String GetGlobalTraceSQL, Int32 MySpid, ref Int32 TraceQueueNbr, String TraceTBName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Fog_TraceStart";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@FreqSecs", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, FreqSecs));
            command.Parameters.Add(new SqlParameter("@GetGlobalTraceSQL", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GetGlobalTraceSQL));
            command.Parameters.Add(new SqlParameter("@MySpid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MySpid));
            command.Parameters.Add(new SqlParameter("@TraceQueueNbr", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, TraceQueueNbr));
            command.Parameters.Add(new SqlParameter("@TraceTBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TraceTBName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                TraceQueueNbr = (Int32)command.Parameters["@TraceQueueNbr"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// GetBusSpotsPersons
        /// </summary>
        /// <param name="Bangchi">Bangchi</param>
        /// <param name="BusId">BusId</param>
        /// <param name="sEmpDeptId">sEmpDeptId</param>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="SpotID">SpotID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int GetBusSpotsPersons(String Bangchi, String BusId, String sEmpDeptId, String sEmpId, String SpotID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "GetBusSpotsPersons";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Bangchi", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Bangchi));
            command.Parameters.Add(new SqlParameter("@BusId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, BusId));
            command.Parameters.Add(new SqlParameter("@sEmpDeptId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpDeptId));
            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@SpotID", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SpotID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// GetColumnTypeName
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="TableName">TableName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int GetColumnTypeName(String ColumnName, String TableName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "GetColumnTypeName";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ColumnName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ColumnName));
            command.Parameters.Add(new SqlParameter("@TableName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TableName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// GetDeptlistSub
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int GetDeptlistSub(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "GetDeptlistSub";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// GetExtendFromAccessDetRights
        /// </summary>
        /// <param name="ScreenId">ScreenId</param>
        /// <param name="UserId">UserId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int GetExtendFromAccessDetRights(String ScreenId, String UserId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "GetExtendFromAccessDetRights";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ScreenId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ScreenId));
            command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UserId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// GetFunctionValue
        /// </summary>
        /// <param name="C2">C2</param>
        /// <param name="funnum">funnum</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int GetFunctionValue(String C2, Int32 funnum, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "GetFunctionValue";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@C2", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C2));
            command.Parameters.Add(new SqlParameter("@funnum", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, funnum));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// GetLWStat
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int GetLWStat(String pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "GetLWStat";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// GetsEmpId
        /// </summary>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int GetsEmpId(String sEmpId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "GetsEmpId";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// GetTimeStampIndex
        /// </summary>
        /// <param name="Table">Table</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int GetTimeStampIndex(String Table, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "GetTimeStampIndex";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Table", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Table));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// HolidayCount
        /// </summary>
        /// <param name="cD1">cD1</param>
        /// <param name="cD7">cD7</param>
        /// <param name="cEmpid">cEmpid</param>
        /// <param name="cEmpname">cEmpname</param>
        /// <param name="cGUID">cGUID</param>
        /// <param name="cHireDate">cHireDate</param>
        /// <param name="cUserid">cUserid</param>
        /// <param name="cYear">cYear</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int HolidayCount(DateTime cD1, DateTime cD7, String cEmpid, String cEmpname, Int32 cGUID, DateTime cHireDate, String cUserid, String cYear, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "HolidayCount";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@cD1", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, cD1));
            command.Parameters.Add(new SqlParameter("@cD7", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, cD7));
            command.Parameters.Add(new SqlParameter("@cEmpid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cEmpid));
            command.Parameters.Add(new SqlParameter("@cEmpname", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cEmpname));
            command.Parameters.Add(new SqlParameter("@cGUID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, cGUID));
            command.Parameters.Add(new SqlParameter("@cHireDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, cHireDate));
            command.Parameters.Add(new SqlParameter("@cUserid", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cUserid));
            command.Parameters.Add(new SqlParameter("@cYear", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cYear));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// HolidayEndPass
        /// </summary>
        /// <param name="cUserid">cUserid</param>
        /// <param name="cYear">cYear</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int HolidayEndPass(String cUserid, String cYear, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "HolidayEndPass";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@cUserid", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cUserid));
            command.Parameters.Add(new SqlParameter("@cYear", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cYear));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// HRS08008_CheckBirthdate
        /// </summary>
        /// <param name="DateBefore">DateBefore</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int HRS08008_CheckBirthdate(Int32 DateBefore, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "HRS08008_CheckBirthdate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DateBefore", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, DateBefore));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// HRS08008_CheckisFullYear
        /// </summary>
        /// <param name="DateBefore">DateBefore</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int HRS08008_CheckisFullYear(Int32 DateBefore, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "HRS08008_CheckisFullYear";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DateBefore", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, DateBefore));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// HXHandel
        /// </summary>
        /// <param name="CurDate">CurDate</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int HXHandel(DateTime CurDate, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "HXHandel";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CurDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, CurDate));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// IDFromEmpId
        /// </summary>
        /// <param name="EmpId">EmpId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int IDFromEmpId(String EmpId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "IDFromEmpId";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@EmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, EmpId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Init_WA_Assign
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Init_WA_Assign(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Init_WA_Assign";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// InitMonthLock
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int InitMonthLock(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "InitMonthLock";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// InitPerformanceByID
        /// </summary>
        /// <param name="PerNbr">PerNbr</param>
        /// <param name="TemplateId">TemplateId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int InitPerformanceByID(String PerNbr, String TemplateId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "InitPerformanceByID";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@PerNbr", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, PerNbr));
            command.Parameters.Add(new SqlParameter("@TemplateId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TemplateId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// InitPurview
        /// </summary>
        /// <param name="chvnRoleId">chvnRoleId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int InitPurview(String chvnRoleId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "InitPurview";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@chvnRoleId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, chvnRoleId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// KQCheckVersion1
        /// </summary>
        /// <param name="CheckTime">CheckTime</param>
        /// <param name="EmpId">EmpId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int KQCheckVersion1(DateTime CheckTime, String EmpId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "KQCheckVersion1";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CheckTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, CheckTime));
            command.Parameters.Add(new SqlParameter("@EmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, EmpId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// KQCheckVesion1
        /// </summary>
        /// <param name="CheckTime">CheckTime</param>
        /// <param name="EmpId">EmpId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int KQCheckVesion1(DateTime CheckTime, String EmpId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "KQCheckVesion1";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CheckTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, CheckTime));
            command.Parameters.Add(new SqlParameter("@EmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, EmpId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// KQExec
        /// </summary>
        /// <param name="MaxDate">MaxDate</param>
        /// <param name="MinDate">MinDate</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int KQExec(DateTime MaxDate, DateTime MinDate, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "KQExec";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@MaxDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, MaxDate));
            command.Parameters.Add(new SqlParameter("@MinDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, MinDate));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// ListEmplyFields
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int ListEmplyFields(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "ListEmplyFields";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// ListFormulaReferenceFields
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int ListFormulaReferenceFields(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "ListFormulaReferenceFields";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// ListPurview
        /// </summary>
        /// <param name="ModuleId">ModuleId</param>
        /// <param name="UserId">UserId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int ListPurview(String ModuleId, String UserId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "ListPurview";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ModuleId", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ModuleId));
            command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UserId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// ListSalaryTable
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int ListSalaryTable(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "ListSalaryTable";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// ListSalaryUpdateFields
        /// </summary>
        /// <param name="MapTable">MapTable</param>
        /// <param name="UserID">UserID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int ListSalaryUpdateFields(String MapTable, String UserID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "ListSalaryUpdateFields";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@MapTable", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, MapTable));
            command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UserID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// LockUserAccount
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int LockUserAccount(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "LockUserAccount";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// LogScreen
        /// </summary>
        /// <param name="ScreenNumber">ScreenNumber</param>
        /// <param name="userId">userId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int LogScreen(String ScreenNumber, String userId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "LogScreen";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ScreenNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ScreenNumber));
            command.Parameters.Add(new SqlParameter("@userId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, userId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// LostInit
        /// </summary>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int LostInit(String Pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "LostInit";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// MonthSummarize
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="EmpId">EmpId</param>
        /// <param name="PerNbr">PerNbr</param>
        /// <param name="WhereSql">WhereSql</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int MonthSummarize(String DeptId, String EmpId, String PerNbr, String WhereSql, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "MonthSummarize";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@EmpId", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, EmpId));
            command.Parameters.Add(new SqlParameter("@PerNbr", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, PerNbr));
            command.Parameters.Add(new SqlParameter("@WhereSql", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, WhereSql));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// p_GetOrgDeptSub
        /// </summary>
        /// <param name="ParCode">ParCode</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int p_GetOrgDeptSub(String ParCode, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "p_GetOrgDeptSub";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ParCode", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ParCode));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// p_GetSickLeaveComparison
        /// </summary>
        /// <param name="bitContainFired">bitContainFired</param>
        /// <param name="bitContainNatural">bitContainNatural</param>
        /// <param name="bitContainSubDept">bitContainSubDept</param>
        /// <param name="chrEndHireDate">chrEndHireDate</param>
        /// <param name="chrStartHireDate">chrStartHireDate</param>
        /// <param name="fltDaysInMon">fltDaysInMon</param>
        /// <param name="nvchrEmpDeptId">nvchrEmpDeptId</param>
        /// <param name="vchrEmpID">vchrEmpID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int p_GetSickLeaveComparison(Boolean bitContainFired, Boolean bitContainNatural, Boolean bitContainSubDept, String chrEndHireDate, String chrStartHireDate, Double fltDaysInMon, String nvchrEmpDeptId, String vchrEmpID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "p_GetSickLeaveComparison";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@bitContainFired", SqlDbType.Bit, 0, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, bitContainFired));
            command.Parameters.Add(new SqlParameter("@bitContainNatural", SqlDbType.Bit, 0, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, bitContainNatural));
            command.Parameters.Add(new SqlParameter("@bitContainSubDept", SqlDbType.Bit, 0, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, bitContainSubDept));
            command.Parameters.Add(new SqlParameter("@chrEndHireDate", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, chrEndHireDate));
            command.Parameters.Add(new SqlParameter("@chrStartHireDate", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, chrStartHireDate));
            command.Parameters.Add(new SqlParameter("@fltDaysInMon", SqlDbType.Float, 0, ParameterDirection.Input, false, 53, 0, "", DataRowVersion.Current, fltDaysInMon));
            command.Parameters.Add(new SqlParameter("@nvchrEmpDeptId", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nvchrEmpDeptId));
            command.Parameters.Add(new SqlParameter("@vchrEmpID", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vchrEmpID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// p_OrgComp
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int p_OrgComp(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "p_OrgComp";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// p_OrgDept
        /// </summary>
        /// <param name="DeptID">DeptID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int p_OrgDept(String DeptID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "p_OrgDept";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// p_OrgDeptMonth
        /// </summary>
        /// <param name="Pernbr">Pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int p_OrgDeptMonth(String Pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "p_OrgDeptMonth";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Pernbr", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// p_PriceAvg
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int p_PriceAvg(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "p_PriceAvg";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// PerformanceCrossJoin
        /// </summary>
        /// <param name="PerNbr">PerNbr</param>
        /// <param name="TemplateId">TemplateId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int PerformanceCrossJoin(String PerNbr, String TemplateId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "PerformanceCrossJoin";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@PerNbr", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, PerNbr));
            command.Parameters.Add(new SqlParameter("@TemplateId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TemplateId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_DayBanchi
        /// </summary>
        /// <param name="intGuid">intGuid</param>
        /// <param name="vchrYM">vchrYM</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_DayBanchi(Int32 intGuid, String vchrYM, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_DayBanchi";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@intGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, intGuid));
            command.Parameters.Add(new SqlParameter("@vchrYM", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vchrYM));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_EmplyLgn
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_EmplyLgn(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_EmplyLgn";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_GetBangchi
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_GetBangchi(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_GetBangchi";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_GetSysParm
        /// </summary>
        /// <param name="nchrName">nchrName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_GetSysParm(String nchrName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_GetSysParm";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@nchrName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nchrName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_InputMiss_RestData
        /// </summary>
        /// <param name="MaxDt">MaxDt</param>
        /// <param name="MinDt">MinDt</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_InputMiss_RestData(DateTime MaxDt, DateTime MinDt, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_InputMiss_RestData";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@MaxDt", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, MaxDt));
            command.Parameters.Add(new SqlParameter("@MinDt", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, MinDt));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_InsertHandledCarddata
        /// </summary>
        /// <param name="dtServerTime">dtServerTime</param>
        /// <param name="iEffect">iEffect</param>
        /// <param name="vchrCardData">vchrCardData</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_InsertHandledCarddata(DateTime dtServerTime, ref Int32 iEffect, String vchrCardData, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_InsertHandledCarddata";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@dtServerTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, dtServerTime));
            command.Parameters.Add(new SqlParameter("@iEffect", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, iEffect));
            command.Parameters.Add(new SqlParameter("@vchrCardData", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vchrCardData));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                iEffect = (Int32)command.Parameters["@iEffect"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_OverTimePerMonth
        /// </summary>
        /// <param name="DateOfStat">DateOfStat</param>
        /// <param name="sDeptId">sDeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_OverTimePerMonth(DateTime DateOfStat, String sDeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_OverTimePerMonth";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DateOfStat", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, DateOfStat));
            command.Parameters.Add(new SqlParameter("@sDeptId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sDeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_PsnSumMonth
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="dt">dt</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_PsnSumMonth(String DeptId, DateTime dt, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_PsnSumMonth";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, dt));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_ReasonOfFire
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="dt">dt</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_ReasonOfFire(String DeptId, DateTime dt, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_ReasonOfFire";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, dt));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_RtnAthrByUser
        /// </summary>
        /// <param name="nchvUser">nchvUser</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_RtnAthrByUser(String nchvUser, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_RtnAthrByUser";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@nchvUser", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nchvUser));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_RtnMenu
        /// </summary>
        /// <param name="nchvModule">nchvModule</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_RtnMenu(String nchvModule, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_RtnMenu";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@nchvModule", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nchvModule));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_SearchBanChi
        /// </summary>
        /// <param name="sTimeAfter">sTimeAfter</param>
        /// <param name="sTimeBefore">sTimeBefore</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_SearchBanChi(String sTimeAfter, String sTimeBefore, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_SearchBanChi";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@sTimeAfter", SqlDbType.NVarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sTimeAfter));
            command.Parameters.Add(new SqlParameter("@sTimeBefore", SqlDbType.NVarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sTimeBefore));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_StatisticChart
        /// </summary>
        /// <param name="intEmpCount">intEmpCount</param>
        /// <param name="nchvMonth">nchvMonth</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_StatisticChart(ref Int32 intEmpCount, String nchvMonth, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_StatisticChart";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@intEmpCount", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, intEmpCount));
            command.Parameters.Add(new SqlParameter("@nchvMonth", SqlDbType.NVarChar, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nchvMonth));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                intEmpCount = (Int32)command.Parameters["@intEmpCount"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_SumOfEduBack
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="dt">dt</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_SumOfEduBack(String DeptId, DateTime dt, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_SumOfEduBack";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, dt));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_SumOfFiredPsn
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="dt">dt</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_SumOfFiredPsn(String DeptId, DateTime dt, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_SumOfFiredPsn";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, dt));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_SumOfHiredPsn
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="dt">dt</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_SumOfHiredPsn(String DeptId, DateTime dt, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_SumOfHiredPsn";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, dt));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_SumOfSex
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="dt">dt</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_SumOfSex(String DeptId, DateTime dt, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_SumOfSex";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, dt));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_Top20PSN
        /// </summary>
        /// <param name="dt">dt</param>
        /// <param name="sDeptId">sDeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_Top20PSN(DateTime dt, String sDeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_Top20PSN";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, dt));
            command.Parameters.Add(new SqlParameter("@sDeptId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sDeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_TurnDetail
        /// </summary>
        /// <param name="dtBegin">dtBegin</param>
        /// <param name="dtEnd">dtEnd</param>
        /// <param name="tblNbr">tblNbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_TurnDetail(String dtBegin, String dtEnd, String tblNbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_TurnDetail";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@dtBegin", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dtBegin));
            command.Parameters.Add(new SqlParameter("@dtEnd", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dtEnd));
            command.Parameters.Add(new SqlParameter("@tblNbr", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, tblNbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_TurnDetailOfPsn
        /// </summary>
        /// <param name="iRowCount">iRowCount</param>
        /// <param name="nvchrDateBegin">nvchrDateBegin</param>
        /// <param name="nvchrDateEnd">nvchrDateEnd</param>
        /// <param name="nvchrEmpId">nvchrEmpId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_TurnDetailOfPsn(ref Int32 iRowCount, String nvchrDateBegin, String nvchrDateEnd, String nvchrEmpId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_TurnDetailOfPsn";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@iRowCount", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, iRowCount));
            command.Parameters.Add(new SqlParameter("@nvchrDateBegin", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nvchrDateBegin));
            command.Parameters.Add(new SqlParameter("@nvchrDateEnd", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nvchrDateEnd));
            command.Parameters.Add(new SqlParameter("@nvchrEmpId", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, nvchrEmpId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                iRowCount = (Int32)command.Parameters["@iRowCount"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// pr_WageCompare
        /// </summary>
        /// <param name="chrDeptId">chrDeptId</param>
        /// <param name="chrEmpId">chrEmpId</param>
        /// <param name="chrYearMonth">chrYearMonth</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int pr_WageCompare(String chrDeptId, String chrEmpId, String chrYearMonth, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "pr_WageCompare";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@chrDeptId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, chrDeptId));
            command.Parameters.Add(new SqlParameter("@chrEmpId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, chrEmpId));
            command.Parameters.Add(new SqlParameter("@chrYearMonth", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, chrYearMonth));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// qs_spc_calc_actually_used
        /// </summary>
        /// <param name="DbName">DbName</param>
        /// <param name="obj_name">obj_name</param>
        /// <param name="pages_actually_used">pages_actually_used</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int qs_spc_calc_actually_used(String DbName, String obj_name, ref Decimal pages_actually_used, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "qs_spc_calc_actually_used";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DbName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DbName));
            command.Parameters.Add(new SqlParameter("@obj_name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, obj_name));
            command.Parameters.Add(new SqlParameter("@pages_actually_used", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 19, 2, "", DataRowVersion.Current, pages_actually_used));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                pages_actually_used = (Decimal)command.Parameters["@pages_actually_used"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// qs_spc_collect_data_files
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int qs_spc_collect_data_files(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "qs_spc_collect_data_files";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// qs_spc_collect_databases
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int qs_spc_collect_databases(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "qs_spc_collect_databases";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// qs_spc_collect_disks
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int qs_spc_collect_disks(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "qs_spc_collect_disks";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// qs_spc_collect_filegroups
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int qs_spc_collect_filegroups(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "qs_spc_collect_filegroups";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// qs_spc_collect_logfiles
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int qs_spc_collect_logfiles(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "qs_spc_collect_logfiles";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// qs_spc_collect_object_data
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int qs_spc_collect_object_data(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "qs_spc_collect_object_data";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// qs_spc_min_version
        /// </summary>
        /// <param name="min_version">min_version</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int qs_spc_min_version(Int32 min_version, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "qs_spc_min_version";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@min_version", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, min_version));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// QueryAttend
        /// </summary>
        /// <param name="BeginDate">BeginDate</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int QueryAttend(DateTime BeginDate, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "QueryAttend";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@BeginDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, BeginDate));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// RequestColPosition
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int RequestColPosition(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "RequestColPosition";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// S_KQAllRate
        /// </summary>
        /// <param name="BeginDate">BeginDate</param>
        /// <param name="EndDate">EndDate</param>
        /// <param name="SubSql">SubSql</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int S_KQAllRate(String BeginDate, String EndDate, String SubSql, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "S_KQAllRate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@BeginDate", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, BeginDate));
            command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, EndDate));
            command.Parameters.Add(new SqlParameter("@SubSql", SqlDbType.VarChar, 400, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SubSql));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// S_KQWorkRateEnd
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int S_KQWorkRateEnd(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "S_KQWorkRateEnd";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Salary_EmployeeMonthList
        /// </summary>
        /// <param name="EmployeeId">EmployeeId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Salary_EmployeeMonthList(String EmployeeId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Salary_EmployeeMonthList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@EmployeeId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, EmployeeId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// SalaryInfoAutoAssignUnuseField
        /// </summary>
        /// <param name="Type">Type</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int SalaryInfoAutoAssignUnuseField(String Type, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SalaryInfoAutoAssignUnuseField";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Type));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// SKE2034
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int SKE2034(Double a, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SKE2034";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@a", SqlDbType.Float, 0, ParameterDirection.Input, false, 53, 0, "", DataRowVersion.Current, a));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// SKEBJ
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int SKEBJ(Int32 a, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SKEBJ";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@a", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, a));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// SP_CompressDB
        /// </summary>
        /// <param name="bkdatabase">bkdatabase</param>
        /// <param name="bkfname">bkfname</param>
        /// <param name="dbname">dbname</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int SP_CompressDB(Boolean bkdatabase, String bkfname, String dbname, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SP_CompressDB";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@bkdatabase", SqlDbType.Bit, 0, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, bkdatabase));
            command.Parameters.Add(new SqlParameter("@bkfname", SqlDbType.NVarChar, 260, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, bkfname));
            command.Parameters.Add(new SqlParameter("@dbname", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, dbname));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// SP_DropTab
        /// </summary>
        /// <param name="strTabName">strTabName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int SP_DropTab(String strTabName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SP_DropTab";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@strTabName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strTabName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// SP_DropView
        /// </summary>
        /// <param name="strViewName">strViewName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int SP_DropView(String strViewName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SP_DropView";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@strViewName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strViewName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// SporadicCalculate
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="EmpId">EmpId</param>
        /// <param name="PerNbr">PerNbr</param>
        /// <param name="WhereSql">WhereSql</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int SporadicCalculate(String DeptId, String EmpId, String PerNbr, String WhereSql, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SporadicCalculate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@EmpId", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, EmpId));
            command.Parameters.Add(new SqlParameter("@PerNbr", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, PerNbr));
            command.Parameters.Add(new SqlParameter("@WhereSql", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, WhereSql));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// SporadicData
        /// </summary>
        /// <param name="PerNbr">PerNbr</param>
        /// <param name="whereSql">whereSql</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int SporadicData(String PerNbr, String whereSql, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SporadicData";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@PerNbr", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, PerNbr));
            command.Parameters.Add(new SqlParameter("@whereSql", SqlDbType.VarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, whereSql));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// SporadicHaltData
        /// </summary>
        /// <param name="PerNbr">PerNbr</param>
        /// <param name="WhereSql">WhereSql</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int SporadicHaltData(String PerNbr, String WhereSql, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SporadicHaltData";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@PerNbr", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, PerNbr));
            command.Parameters.Add(new SqlParameter("@WhereSql", SqlDbType.VarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, WhereSql));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_AccessMethods
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_AccessMethods(String Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_AccessMethods";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_AgentAlertList
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_AgentAlertList(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_AgentAlertList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_BackupHistory
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_BackupHistory(String DBName, String OutputFormat, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_BackupHistory";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_BinToString
        /// </summary>
        /// <param name="BinValue">BinValue</param>
        /// <param name="CharValue">CharValue</param>
        /// <param name="Print">Print</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_BinToString(Byte[] BinValue, ref String CharValue, String Print, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_BinToString";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@BinValue", SqlDbType.VarBinary, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, BinValue));
            command.Parameters.Add(new SqlParameter("@CharValue", SqlDbType.VarChar, 256, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, CharValue));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                CharValue = (String)command.Parameters["@CharValue"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_BufferCacheContents
        /// </summary>
        /// <param name="BufferCacheRowCount">BufferCacheRowCount</param>
        /// <param name="Debug">Debug</param>
        /// <param name="FeatureSuppressed">FeatureSuppressed</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="Print">Print</param>
        /// <param name="Priority">Priority</param>
        /// <param name="TableCollect">TableCollect</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_BufferCacheContents(Int32 BufferCacheRowCount, String Debug, ref String FeatureSuppressed, String ForceRefresh, String OutputFormat, String Print, String Priority, String TableCollect, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_BufferCacheContents";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@BufferCacheRowCount", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, BufferCacheRowCount));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@FeatureSuppressed", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, FeatureSuppressed));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@Priority", SqlDbType.Char, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Priority));
            command.Parameters.Add(new SqlParameter("@TableCollect", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TableCollect));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                FeatureSuppressed = (String)command.Parameters["@FeatureSuppressed"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_BufferManager
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_BufferManager(String Debug, String OutputFormat, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_BufferManager";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_CheckCluster
        /// </summary>
        /// <param name="CheckOLAPStatus">CheckOLAPStatus</param>
        /// <param name="ClusterNodeName">ClusterNodeName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="Print">Print</param>
        /// <param name="RunningOnACluster">RunningOnACluster</param>
        /// <param name="SQLOLAPStatus">SQLOLAPStatus</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_CheckCluster(String CheckOLAPStatus, ref String ClusterNodeName, String Debug, String ForceRefresh, String Print, ref String RunningOnACluster, ref Int32 SQLOLAPStatus, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_CheckCluster";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CheckOLAPStatus", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CheckOLAPStatus));
            command.Parameters.Add(new SqlParameter("@ClusterNodeName", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ClusterNodeName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RunningOnACluster", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, RunningOnACluster));
            command.Parameters.Add(new SqlParameter("@SQLOLAPStatus", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, SQLOLAPStatus));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                ClusterNodeName = (String)command.Parameters["@ClusterNodeName"].Value;
                RunningOnACluster = (String)command.Parameters["@RunningOnACluster"].Value;
                SQLOLAPStatus = (Int32)command.Parameters["@SQLOLAPStatus"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_CheckErrorlogSize
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="LogNumber">LogNumber</param>
        /// <param name="LogType">LogType</param>
        /// <param name="MaxFileSizeWeCanProcessKB">MaxFileSizeWeCanProcessKB</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_CheckErrorlogSize(String Debug, Int16 LogNumber, String LogType, Int32 MaxFileSizeWeCanProcessKB, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_CheckErrorlogSize";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@LogNumber", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, LogNumber));
            command.Parameters.Add(new SqlParameter("@LogType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LogType));
            command.Parameters.Add(new SqlParameter("@MaxFileSizeWeCanProcessKB", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxFileSizeWeCanProcessKB));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_CheckFileExists
        /// </summary>
        /// <param name="CheckForDirectory">CheckForDirectory</param>
        /// <param name="Debug">Debug</param>
        /// <param name="FileName">FileName</param>
        /// <param name="Print">Print</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_CheckFileExists(String CheckForDirectory, String Debug, String FileName, String Print, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_CheckFileExists";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CheckForDirectory", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CheckForDirectory));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@FileName", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FileName));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_CheckIfFeatureSuppressed
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="Feature">Feature</param>
        /// <param name="Print">Print</param>
        /// <param name="spid">spid</param>
        /// <param name="Suppressed">Suppressed</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_CheckIfFeatureSuppressed(String Debug, String Feature, String Print, Int32 spid, ref String Suppressed, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_CheckIfFeatureSuppressed";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Feature", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Feature));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@spid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, spid));
            command.Parameters.Add(new SqlParameter("@Suppressed", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, Suppressed));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                Suppressed = (String)command.Parameters["@Suppressed"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_CheckIfReplicationInstalled
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="DistributionServer">DistributionServer</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="Print">Print</param>
        /// <param name="ReplicationIsInstalled">ReplicationIsInstalled</param>
        /// <param name="ThisServerIsADistributor">ThisServerIsADistributor</param>
        /// <param name="ThisServerIsAPublisher">ThisServerIsAPublisher</param>
        /// <param name="ThisServerIsASubscriber">ThisServerIsASubscriber</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_CheckIfReplicationInstalled(String Debug, ref String DistributionServer, String ForceRefresh, String Print, ref String ReplicationIsInstalled, ref String ThisServerIsADistributor, ref String ThisServerIsAPublisher, ref String ThisServerIsASubscriber, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_CheckIfReplicationInstalled";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DistributionServer", SqlDbType.NVarChar, 128, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, DistributionServer));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@ReplicationIsInstalled", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ReplicationIsInstalled));
            command.Parameters.Add(new SqlParameter("@ThisServerIsADistributor", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ThisServerIsADistributor));
            command.Parameters.Add(new SqlParameter("@ThisServerIsAPublisher", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ThisServerIsAPublisher));
            command.Parameters.Add(new SqlParameter("@ThisServerIsASubscriber", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ThisServerIsASubscriber));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                DistributionServer = (String)command.Parameters["@DistributionServer"].Value;
                ReplicationIsInstalled = (String)command.Parameters["@ReplicationIsInstalled"].Value;
                ThisServerIsADistributor = (String)command.Parameters["@ThisServerIsADistributor"].Value;
                ThisServerIsAPublisher = (String)command.Parameters["@ThisServerIsAPublisher"].Value;
                ThisServerIsASubscriber = (String)command.Parameters["@ThisServerIsASubscriber"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_CheckRefresh
        /// </summary>
        /// <param name="CounterName">CounterName</param>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="ExtraDataDecimal">ExtraDataDecimal</param>
        /// <param name="ExtraDataDecimal2">ExtraDataDecimal2</param>
        /// <param name="ExtraDataTime">ExtraDataTime</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="Indent">Indent</param>
        /// <param name="LastRefreshTime">LastRefreshTime</param>
        /// <param name="MinSecsBetweenRefresh">MinSecsBetweenRefresh</param>
        /// <param name="Print">Print</param>
        /// <param name="Priority">Priority</param>
        /// <param name="TimeForRefresh">TimeForRefresh</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_CheckRefresh(String CounterName, String DBName, String Debug, ref Decimal ExtraDataDecimal, ref Decimal ExtraDataDecimal2, ref DateTime ExtraDataTime, String ForceRefresh, Int16 Indent, ref DateTime LastRefreshTime, ref Int32 MinSecsBetweenRefresh, String Print, String Priority, ref String TimeForRefresh, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_CheckRefresh";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CounterName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CounterName));
            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ExtraDataDecimal", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 13, 0, "", DataRowVersion.Current, ExtraDataDecimal));
            command.Parameters.Add(new SqlParameter("@ExtraDataDecimal2", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 13, 0, "", DataRowVersion.Current, ExtraDataDecimal2));
            command.Parameters.Add(new SqlParameter("@ExtraDataTime", SqlDbType.DateTime, 0, ParameterDirection.InputOutput, false, 23, 3, "", DataRowVersion.Current, ExtraDataTime));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@Indent", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, Indent));
            command.Parameters.Add(new SqlParameter("@LastRefreshTime", SqlDbType.DateTime, 0, ParameterDirection.InputOutput, false, 23, 3, "", DataRowVersion.Current, LastRefreshTime));
            command.Parameters.Add(new SqlParameter("@MinSecsBetweenRefresh", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, MinSecsBetweenRefresh));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@Priority", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Priority));
            command.Parameters.Add(new SqlParameter("@TimeForRefresh", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, TimeForRefresh));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                ExtraDataDecimal = (Decimal)command.Parameters["@ExtraDataDecimal"].Value;
                ExtraDataDecimal2 = (Decimal)command.Parameters["@ExtraDataDecimal2"].Value;
                ExtraDataTime = (DateTime)command.Parameters["@ExtraDataTime"].Value;
                LastRefreshTime = (DateTime)command.Parameters["@LastRefreshTime"].Value;
                MinSecsBetweenRefresh = (Int32)command.Parameters["@MinSecsBetweenRefresh"].Value;
                TimeForRefresh = (String)command.Parameters["@TimeForRefresh"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_CheckSettings
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="SettingName">SettingName</param>
        /// <param name="Test">Test</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_CheckSettings(String Debug, String SettingName, String Test, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_CheckSettings";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@SettingName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SettingName));
            command.Parameters.Add(new SqlParameter("@Test", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Test));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_Cleanup1
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_Cleanup1(String Debug, String ForceRefresh, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_Cleanup1";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ClearCache
        /// </summary>
        /// <param name="CacheType">CacheType</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ClearCache(String CacheType, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ClearCache";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CacheType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CacheType));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ClusterInfo
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="OutputType">OutputType</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ClusterInfo(String Debug, String ForceRefresh, String OutputType, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ClusterInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@OutputType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputType));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ConfigSuggestions
        /// </summary>
        /// <param name="CheckAll">CheckAll</param>
        /// <param name="Debug">Debug</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ConfigSuggestions(String CheckAll, String Debug, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ConfigSuggestions";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CheckAll", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CheckAll));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_Configure
        /// </summary>
        /// <param name="ConfigName">ConfigName</param>
        /// <param name="NewValue">NewValue</param>
        /// <param name="Print">Print</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_Configure(String ConfigName, Int32 NewValue, String Print, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_Configure";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ConfigName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ConfigName));
            command.Parameters.Add(new SqlParameter("@NewValue", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, NewValue));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ConnectionDetails
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="Print">Print</param>
        /// <param name="spid">spid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ConnectionDetails(String Debug, String Print, Int32 spid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ConnectionDetails";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@spid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, spid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ConnectionList
        /// </summary>
        /// <param name="Active">Active</param>
        /// <param name="Debug">Debug</param>
        /// <param name="FilterDBName">FilterDBName</param>
        /// <param name="FilterNTUser">FilterNTUser</param>
        /// <param name="FilterProgramName">FilterProgramName</param>
        /// <param name="FilterSQLUser">FilterSQLUser</param>
        /// <param name="GetResourceNames">GetResourceNames</param>
        /// <param name="MaxRowsForFullResourceInfo">MaxRowsForFullResourceInfo</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="ShowInactiveSessions">ShowInactiveSessions</param>
        /// <param name="ShowResourceInfo">ShowResourceInfo</param>
        /// <param name="ShowSystemObjects">ShowSystemObjects</param>
        /// <param name="spid">spid</param>
        /// <param name="TopUsers">TopUsers</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ConnectionList(String Active, String Debug, String FilterDBName, String FilterNTUser, String FilterProgramName, String FilterSQLUser, String GetResourceNames, Int32 MaxRowsForFullResourceInfo, String OutputFormat, String ShowInactiveSessions, String ShowResourceInfo, String ShowSystemObjects, Int32 spid, Int32 TopUsers, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ConnectionList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Active", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Active));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@FilterDBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterDBName));
            command.Parameters.Add(new SqlParameter("@FilterNTUser", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterNTUser));
            command.Parameters.Add(new SqlParameter("@FilterProgramName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterProgramName));
            command.Parameters.Add(new SqlParameter("@FilterSQLUser", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterSQLUser));
            command.Parameters.Add(new SqlParameter("@GetResourceNames", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GetResourceNames));
            command.Parameters.Add(new SqlParameter("@MaxRowsForFullResourceInfo", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxRowsForFullResourceInfo));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@ShowInactiveSessions", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowInactiveSessions));
            command.Parameters.Add(new SqlParameter("@ShowResourceInfo", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowResourceInfo));
            command.Parameters.Add(new SqlParameter("@ShowSystemObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowSystemObjects));
            command.Parameters.Add(new SqlParameter("@spid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, spid));
            command.Parameters.Add(new SqlParameter("@TopUsers", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, TopUsers));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_Connections
        /// </summary>
        /// <param name="ClientMachineCnt">ClientMachineCnt</param>
        /// <param name="ConnectionCnt">ConnectionCnt</param>
        /// <param name="Debug">Debug</param>
        /// <param name="MinBlockedWaitTimeMS">MinBlockedWaitTimeMS</param>
        /// <param name="Print">Print</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_Connections(ref Decimal ClientMachineCnt, ref Decimal ConnectionCnt, String Debug, Int32 MinBlockedWaitTimeMS, String Print, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_Connections";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ClientMachineCnt", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, ClientMachineCnt));
            command.Parameters.Add(new SqlParameter("@ConnectionCnt", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, ConnectionCnt));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@MinBlockedWaitTimeMS", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MinBlockedWaitTimeMS));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                ClientMachineCnt = (Decimal)command.Parameters["@ClientMachineCnt"].Value;
                ConnectionCnt = (Decimal)command.Parameters["@ConnectionCnt"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_DatabaseInfo
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_DatabaseInfo(String Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_DatabaseInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_DatabaseList
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="Debug2">Debug2</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="Print">Print</param>
        /// <param name="TableCollect">TableCollect</param>
        /// <param name="Type">Type</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_DatabaseList(String Debug, String Debug2, String OutputFormat, String Print, String TableCollect, String Type, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_DatabaseList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Debug2", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug2));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@TableCollect", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TableCollect));
            command.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Type));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_Errorlog
        /// </summary>
        /// <param name="CountOnly">CountOnly</param>
        /// <param name="Debug">Debug</param>
        /// <param name="DummyCall">DummyCall</param>
        /// <param name="MaxLogFileSize">MaxLogFileSize</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="SamplePeriod">SamplePeriod</param>
        /// <param name="SearchStrings">SearchStrings</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_Errorlog(String CountOnly, String Debug, String DummyCall, Int32 MaxLogFileSize, String OutputFormat, Int32 SamplePeriod, String SearchStrings, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_Errorlog";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CountOnly", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CountOnly));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DummyCall", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DummyCall));
            command.Parameters.Add(new SqlParameter("@MaxLogFileSize", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxLogFileSize));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@SamplePeriod", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, SamplePeriod));
            command.Parameters.Add(new SqlParameter("@SearchStrings", SqlDbType.VarChar, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SearchStrings));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_FilesGroupsDisksList
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="OutputType">OutputType</param>
        /// <param name="TableCollect">TableCollect</param>
        /// <param name="Type">Type</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_FilesGroupsDisksList(String Debug, String ForceRefresh, String OutputFormat, String OutputType, String TableCollect, String Type, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_FilesGroupsDisksList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@OutputType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputType));
            command.Parameters.Add(new SqlParameter("@TableCollect", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TableCollect));
            command.Parameters.Add(new SqlParameter("@Type", SqlDbType.Char, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Type));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_FulltextCatalogs
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_FulltextCatalogs(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_FulltextCatalogs";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GeneralCounters
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="Print">Print</param>
        /// <param name="Type">Type</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GeneralCounters(String Debug, String ForceRefresh, String OutputFormat, String Print, String Type, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GeneralCounters";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Type));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GeneralDBStats
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="Print">Print</param>
        /// <param name="SkipCheck">SkipCheck</param>
        /// <param name="SQLDatabaseCnt">SQLDatabaseCnt</param>
        /// <param name="SQLDataFileMB">SQLDataFileMB</param>
        /// <param name="SQLLogFileMB">SQLLogFileMB</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GeneralDBStats(String Debug, String ForceRefresh, String Print, String SkipCheck, ref Int32 SQLDatabaseCnt, ref Decimal SQLDataFileMB, ref Decimal SQLLogFileMB, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GeneralDBStats";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@SkipCheck", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SkipCheck));
            command.Parameters.Add(new SqlParameter("@SQLDatabaseCnt", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, SQLDatabaseCnt));
            command.Parameters.Add(new SqlParameter("@SQLDataFileMB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 17, 1, "", DataRowVersion.Current, SQLDataFileMB));
            command.Parameters.Add(new SqlParameter("@SQLLogFileMB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 17, 1, "", DataRowVersion.Current, SQLLogFileMB));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                SQLDatabaseCnt = (Int32)command.Parameters["@SQLDatabaseCnt"].Value;
                SQLDataFileMB = (Decimal)command.Parameters["@SQLDataFileMB"].Value;
                SQLLogFileMB = (Decimal)command.Parameters["@SQLLogFileMB"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetAllDBList
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetAllDBList(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetAllDBList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetDBOldestTrans
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="MultiCallFlag">MultiCallFlag</param>
        /// <param name="Print">Print</param>
        /// <param name="RunningInBatch">RunningInBatch</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetDBOldestTrans(String Debug, String MultiCallFlag, String Print, String RunningInBatch, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetDBOldestTrans";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@MultiCallFlag", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, MultiCallFlag));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RunningInBatch", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, RunningInBatch));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetDBProperties
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetDBProperties(String Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetDBProperties";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetDBStatus
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Print">Print</param>
        /// <param name="ReadAllowed">ReadAllowed</param>
        /// <param name="ReadOnly">ReadOnly</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetDBStatus(String DBName, String Print, ref String ReadAllowed, ref String ReadOnly, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetDBStatus";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@ReadAllowed", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ReadAllowed));
            command.Parameters.Add(new SqlParameter("@ReadOnly", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ReadOnly));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                ReadAllowed = (String)command.Parameters["@ReadAllowed"].Value;
                ReadOnly = (String)command.Parameters["@ReadOnly"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetErrorlogEntries
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="LogNumber">LogNumber</param>
        /// <param name="LogType">LogType</param>
        /// <param name="MaxFileSizeWeCanProcessKB">MaxFileSizeWeCanProcessKB</param>
        /// <param name="MaxRows">MaxRows</param>
        /// <param name="MinSeverity">MinSeverity</param>
        /// <param name="SkipRefresh">SkipRefresh</param>
        /// <param name="Sort">Sort</param>
        /// <param name="StartTime">StartTime</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetErrorlogEntries(String Debug, String ForceRefresh, Int16 LogNumber, String LogType, Int32 MaxFileSizeWeCanProcessKB, Int16 MaxRows, Int32 MinSeverity, String SkipRefresh, String Sort, DateTime StartTime, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetErrorlogEntries";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@LogNumber", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, LogNumber));
            command.Parameters.Add(new SqlParameter("@LogType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LogType));
            command.Parameters.Add(new SqlParameter("@MaxFileSizeWeCanProcessKB", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxFileSizeWeCanProcessKB));
            command.Parameters.Add(new SqlParameter("@MaxRows", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, MaxRows));
            command.Parameters.Add(new SqlParameter("@MinSeverity", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MinSeverity));
            command.Parameters.Add(new SqlParameter("@SkipRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SkipRefresh));
            command.Parameters.Add(new SqlParameter("@Sort", SqlDbType.Char, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Sort));
            command.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, StartTime));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetErrorlogFileInfo
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="EndDate">EndDate</param>
        /// <param name="FileSize">FileSize</param>
        /// <param name="LogFileName">LogFileName</param>
        /// <param name="LogNumber">LogNumber</param>
        /// <param name="LogType">LogType</param>
        /// <param name="Print">Print</param>
        /// <param name="StartDate">StartDate</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetErrorlogFileInfo(String Debug, ref DateTime EndDate, ref Decimal FileSize, ref String LogFileName, Int32 LogNumber, String LogType, String Print, ref DateTime StartDate, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetErrorlogFileInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime, 0, ParameterDirection.InputOutput, false, 23, 3, "", DataRowVersion.Current, EndDate));
            command.Parameters.Add(new SqlParameter("@FileSize", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 13, 0, "", DataRowVersion.Current, FileSize));
            command.Parameters.Add(new SqlParameter("@LogFileName", SqlDbType.VarChar, 2000, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, LogFileName));
            command.Parameters.Add(new SqlParameter("@LogNumber", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, LogNumber));
            command.Parameters.Add(new SqlParameter("@LogType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LogType));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime, 0, ParameterDirection.InputOutput, false, 23, 3, "", DataRowVersion.Current, StartDate));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                EndDate = (DateTime)command.Parameters["@EndDate"].Value;
                FileSize = (Decimal)command.Parameters["@FileSize"].Value;
                LogFileName = (String)command.Parameters["@LogFileName"].Value;
                StartDate = (DateTime)command.Parameters["@StartDate"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetErrorlogPath
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="LogNumber">LogNumber</param>
        /// <param name="LogType">LogType</param>
        /// <param name="Path">Path</param>
        /// <param name="Print">Print</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetErrorlogPath(String Debug, Int32 LogNumber, String LogType, ref String Path, String Print, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetErrorlogPath";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@LogNumber", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, LogNumber));
            command.Parameters.Add(new SqlParameter("@LogType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LogType));
            command.Parameters.Add(new SqlParameter("@Path", SqlDbType.VarChar, 2000, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, Path));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                Path = (String)command.Parameters["@Path"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetFileDetails
        /// </summary>
        /// <param name="CreateDate">CreateDate</param>
        /// <param name="Debug">Debug</param>
        /// <param name="FileName">FileName</param>
        /// <param name="FileSize">FileSize</param>
        /// <param name="LastChangeDate">LastChangeDate</param>
        /// <param name="LastRefDate">LastRefDate</param>
        /// <param name="Print">Print</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetFileDetails(ref DateTime CreateDate, String Debug, String FileName, ref Decimal FileSize, ref DateTime LastChangeDate, ref DateTime LastRefDate, String Print, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetFileDetails";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime, 0, ParameterDirection.InputOutput, false, 23, 3, "", DataRowVersion.Current, CreateDate));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@FileName", SqlDbType.VarChar, 2000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FileName));
            command.Parameters.Add(new SqlParameter("@FileSize", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 13, 0, "", DataRowVersion.Current, FileSize));
            command.Parameters.Add(new SqlParameter("@LastChangeDate", SqlDbType.DateTime, 0, ParameterDirection.InputOutput, false, 23, 3, "", DataRowVersion.Current, LastChangeDate));
            command.Parameters.Add(new SqlParameter("@LastRefDate", SqlDbType.DateTime, 0, ParameterDirection.InputOutput, false, 23, 3, "", DataRowVersion.Current, LastRefDate));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                CreateDate = (DateTime)command.Parameters["@CreateDate"].Value;
                FileSize = (Decimal)command.Parameters["@FileSize"].Value;
                LastChangeDate = (DateTime)command.Parameters["@LastChangeDate"].Value;
                LastRefDate = (DateTime)command.Parameters["@LastRefDate"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetMemoryDetails
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="GetPhysicalRAMOnly">GetPhysicalRAMOnly</param>
        /// <param name="PhysicalRAMKB">PhysicalRAMKB</param>
        /// <param name="Print">Print</param>
        /// <param name="SQLBufferCacheActiveKB">SQLBufferCacheActiveKB</param>
        /// <param name="SQLBufferCacheFreeKB">SQLBufferCacheFreeKB</param>
        /// <param name="SQLBufferCacheKB">SQLBufferCacheKB</param>
        /// <param name="SQLCurrentMemoryKB">SQLCurrentMemoryKB</param>
        /// <param name="SQLExtendedMemoryKB">SQLExtendedMemoryKB</param>
        /// <param name="SQLFreeListKB">SQLFreeListKB</param>
        /// <param name="SQLLogicalReads">SQLLogicalReads</param>
        /// <param name="SQLLogicalReadsInCache">SQLLogicalReadsInCache</param>
        /// <param name="SQLMemoryConnectionsKB">SQLMemoryConnectionsKB</param>
        /// <param name="SQLMemoryLocksKB">SQLMemoryLocksKB</param>
        /// <param name="SQLMemoryMaxKB">SQLMemoryMaxKB</param>
        /// <param name="SQLMemoryMinKB">SQLMemoryMinKB</param>
        /// <param name="SQLMemoryOptimizerKB">SQLMemoryOptimizerKB</param>
        /// <param name="SQLMemorySortHashKB">SQLMemorySortHashKB</param>
        /// <param name="SQLProcCacheActiveKB">SQLProcCacheActiveKB</param>
        /// <param name="SQLProcCacheKB">SQLProcCacheKB</param>
        /// <param name="SQLProcCacheLogicalReads">SQLProcCacheLogicalReads</param>
        /// <param name="SQLProcCacheLogicalReadsInCache">SQLProcCacheLogicalReadsInCache</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetMemoryDetails(String Debug, String ForceRefresh, String GetPhysicalRAMOnly, ref Decimal PhysicalRAMKB, String Print, ref Decimal SQLBufferCacheActiveKB, ref Decimal SQLBufferCacheFreeKB, ref Decimal SQLBufferCacheKB, ref Decimal SQLCurrentMemoryKB, ref Decimal SQLExtendedMemoryKB, ref Decimal SQLFreeListKB, ref Decimal SQLLogicalReads, ref Decimal SQLLogicalReadsInCache, ref Decimal SQLMemoryConnectionsKB, ref Decimal SQLMemoryLocksKB, ref Decimal SQLMemoryMaxKB, ref Decimal SQLMemoryMinKB, ref Decimal SQLMemoryOptimizerKB, ref Decimal SQLMemorySortHashKB, ref Decimal SQLProcCacheActiveKB, ref Decimal SQLProcCacheKB, ref Decimal SQLProcCacheLogicalReads, ref Decimal SQLProcCacheLogicalReadsInCache, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetMemoryDetails";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@GetPhysicalRAMOnly", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GetPhysicalRAMOnly));
            command.Parameters.Add(new SqlParameter("@PhysicalRAMKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, PhysicalRAMKB));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@SQLBufferCacheActiveKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLBufferCacheActiveKB));
            command.Parameters.Add(new SqlParameter("@SQLBufferCacheFreeKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLBufferCacheFreeKB));
            command.Parameters.Add(new SqlParameter("@SQLBufferCacheKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLBufferCacheKB));
            command.Parameters.Add(new SqlParameter("@SQLCurrentMemoryKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLCurrentMemoryKB));
            command.Parameters.Add(new SqlParameter("@SQLExtendedMemoryKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLExtendedMemoryKB));
            command.Parameters.Add(new SqlParameter("@SQLFreeListKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLFreeListKB));
            command.Parameters.Add(new SqlParameter("@SQLLogicalReads", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLLogicalReads));
            command.Parameters.Add(new SqlParameter("@SQLLogicalReadsInCache", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLLogicalReadsInCache));
            command.Parameters.Add(new SqlParameter("@SQLMemoryConnectionsKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLMemoryConnectionsKB));
            command.Parameters.Add(new SqlParameter("@SQLMemoryLocksKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLMemoryLocksKB));
            command.Parameters.Add(new SqlParameter("@SQLMemoryMaxKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLMemoryMaxKB));
            command.Parameters.Add(new SqlParameter("@SQLMemoryMinKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLMemoryMinKB));
            command.Parameters.Add(new SqlParameter("@SQLMemoryOptimizerKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLMemoryOptimizerKB));
            command.Parameters.Add(new SqlParameter("@SQLMemorySortHashKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLMemorySortHashKB));
            command.Parameters.Add(new SqlParameter("@SQLProcCacheActiveKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLProcCacheActiveKB));
            command.Parameters.Add(new SqlParameter("@SQLProcCacheKB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLProcCacheKB));
            command.Parameters.Add(new SqlParameter("@SQLProcCacheLogicalReads", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLProcCacheLogicalReads));
            command.Parameters.Add(new SqlParameter("@SQLProcCacheLogicalReadsInCache", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, SQLProcCacheLogicalReadsInCache));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                PhysicalRAMKB = (Decimal)command.Parameters["@PhysicalRAMKB"].Value;
                SQLBufferCacheActiveKB = (Decimal)command.Parameters["@SQLBufferCacheActiveKB"].Value;
                SQLBufferCacheFreeKB = (Decimal)command.Parameters["@SQLBufferCacheFreeKB"].Value;
                SQLBufferCacheKB = (Decimal)command.Parameters["@SQLBufferCacheKB"].Value;
                SQLCurrentMemoryKB = (Decimal)command.Parameters["@SQLCurrentMemoryKB"].Value;
                SQLExtendedMemoryKB = (Decimal)command.Parameters["@SQLExtendedMemoryKB"].Value;
                SQLFreeListKB = (Decimal)command.Parameters["@SQLFreeListKB"].Value;
                SQLLogicalReads = (Decimal)command.Parameters["@SQLLogicalReads"].Value;
                SQLLogicalReadsInCache = (Decimal)command.Parameters["@SQLLogicalReadsInCache"].Value;
                SQLMemoryConnectionsKB = (Decimal)command.Parameters["@SQLMemoryConnectionsKB"].Value;
                SQLMemoryLocksKB = (Decimal)command.Parameters["@SQLMemoryLocksKB"].Value;
                SQLMemoryMaxKB = (Decimal)command.Parameters["@SQLMemoryMaxKB"].Value;
                SQLMemoryMinKB = (Decimal)command.Parameters["@SQLMemoryMinKB"].Value;
                SQLMemoryOptimizerKB = (Decimal)command.Parameters["@SQLMemoryOptimizerKB"].Value;
                SQLMemorySortHashKB = (Decimal)command.Parameters["@SQLMemorySortHashKB"].Value;
                SQLProcCacheActiveKB = (Decimal)command.Parameters["@SQLProcCacheActiveKB"].Value;
                SQLProcCacheKB = (Decimal)command.Parameters["@SQLProcCacheKB"].Value;
                SQLProcCacheLogicalReads = (Decimal)command.Parameters["@SQLProcCacheLogicalReads"].Value;
                SQLProcCacheLogicalReadsInCache = (Decimal)command.Parameters["@SQLProcCacheLogicalReadsInCache"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetMinPotentialAvailable
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="MinFGPotentialAvailablePct">MinFGPotentialAvailablePct</param>
        /// <param name="MinLogPotentialAvailablePct">MinLogPotentialAvailablePct</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetMinPotentialAvailable(String Debug, ref Decimal MinFGPotentialAvailablePct, ref Decimal MinLogPotentialAvailablePct, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetMinPotentialAvailable";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@MinFGPotentialAvailablePct", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 16, 2, "", DataRowVersion.Current, MinFGPotentialAvailablePct));
            command.Parameters.Add(new SqlParameter("@MinLogPotentialAvailablePct", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 16, 2, "", DataRowVersion.Current, MinLogPotentialAvailablePct));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                MinFGPotentialAvailablePct = (Decimal)command.Parameters["@MinFGPotentialAvailablePct"].Value;
                MinLogPotentialAvailablePct = (Decimal)command.Parameters["@MinLogPotentialAvailablePct"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetResourceName
        /// </summary>
        /// <param name="dbid">dbid</param>
        /// <param name="Description">Description</param>
        /// <param name="indid">indid</param>
        /// <param name="LastWaitType">LastWaitType</param>
        /// <param name="LockResource">LockResource</param>
        /// <param name="LockType">LockType</param>
        /// <param name="LockTypeDescription">LockTypeDescription</param>
        /// <param name="obid">obid</param>
        /// <param name="Print">Print</param>
        /// <param name="ResourceText">ResourceText</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetResourceName(Int32 dbid, ref String Description, Int32 indid, String LastWaitType, String LockResource, String LockType, ref String LockTypeDescription, Int32 obid, String Print, String ResourceText, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetResourceName";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@dbid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, dbid));
            command.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, Description));
            command.Parameters.Add(new SqlParameter("@indid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, indid));
            command.Parameters.Add(new SqlParameter("@LastWaitType", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LastWaitType));
            command.Parameters.Add(new SqlParameter("@LockResource", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LockResource));
            command.Parameters.Add(new SqlParameter("@LockType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LockType));
            command.Parameters.Add(new SqlParameter("@LockTypeDescription", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, LockTypeDescription));
            command.Parameters.Add(new SqlParameter("@obid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, obid));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@ResourceText", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ResourceText));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                Description = (String)command.Parameters["@Description"].Value;
                LockTypeDescription = (String)command.Parameters["@LockTypeDescription"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetServerInfo
        /// </summary>
        /// <param name="CurrCollation">CurrCollation</param>
        /// <param name="PerfmonObjectName">PerfmonObjectName</param>
        /// <param name="Print">Print</param>
        /// <param name="SQLAgentServiceName">SQLAgentServiceName</param>
        /// <param name="SQLInstanceName">SQLInstanceName</param>
        /// <param name="SQLName">SQLName</param>
        /// <param name="SQLServiceName">SQLServiceName</param>
        /// <param name="SQLVersion">SQLVersion</param>
        /// <param name="WindowsMachineName">WindowsMachineName</param>
        /// <param name="WindowsVersion">WindowsVersion</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetServerInfo(ref String CurrCollation, ref String PerfmonObjectName, String Print, ref String SQLAgentServiceName, ref String SQLInstanceName, ref String SQLName, ref String SQLServiceName, ref Decimal SQLVersion, ref String WindowsMachineName, ref Decimal WindowsVersion, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetServerInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CurrCollation", SqlDbType.NVarChar, 128, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, CurrCollation));
            command.Parameters.Add(new SqlParameter("@PerfmonObjectName", SqlDbType.NVarChar, 128, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, PerfmonObjectName));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@SQLAgentServiceName", SqlDbType.NVarChar, 128, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, SQLAgentServiceName));
            command.Parameters.Add(new SqlParameter("@SQLInstanceName", SqlDbType.NVarChar, 128, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, SQLInstanceName));
            command.Parameters.Add(new SqlParameter("@SQLName", SqlDbType.NVarChar, 128, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, SQLName));
            command.Parameters.Add(new SqlParameter("@SQLServiceName", SqlDbType.NVarChar, 128, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, SQLServiceName));
            command.Parameters.Add(new SqlParameter("@SQLVersion", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 5, 1, "", DataRowVersion.Current, SQLVersion));
            command.Parameters.Add(new SqlParameter("@WindowsMachineName", SqlDbType.NVarChar, 128, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, WindowsMachineName));
            command.Parameters.Add(new SqlParameter("@WindowsVersion", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 5, 1, "", DataRowVersion.Current, WindowsVersion));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                CurrCollation = (String)command.Parameters["@CurrCollation"].Value;
                PerfmonObjectName = (String)command.Parameters["@PerfmonObjectName"].Value;
                SQLAgentServiceName = (String)command.Parameters["@SQLAgentServiceName"].Value;
                SQLInstanceName = (String)command.Parameters["@SQLInstanceName"].Value;
                SQLName = (String)command.Parameters["@SQLName"].Value;
                SQLServiceName = (String)command.Parameters["@SQLServiceName"].Value;
                SQLVersion = (Decimal)command.Parameters["@SQLVersion"].Value;
                WindowsMachineName = (String)command.Parameters["@WindowsMachineName"].Value;
                WindowsVersion = (Decimal)command.Parameters["@WindowsVersion"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetTableCollation
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetTableCollation(Boolean Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetTableCollation";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Bit, 0, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GetTraceTableName
        /// </summary>
        /// <param name="CalledBySpid">CalledBySpid</param>
        /// <param name="GlobalTrace">GlobalTrace</param>
        /// <param name="MySpid">MySpid</param>
        /// <param name="Print">Print</param>
        /// <param name="TraceTBName">TraceTBName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GetTraceTableName(Int32 CalledBySpid, String GlobalTrace, Int32 MySpid, String Print, ref String TraceTBName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GetTraceTableName";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CalledBySpid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, CalledBySpid));
            command.Parameters.Add(new SqlParameter("@GlobalTrace", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GlobalTrace));
            command.Parameters.Add(new SqlParameter("@MySpid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MySpid));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@TraceTBName", SqlDbType.NVarChar, 128, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, TraceTBName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                TraceTBName = (String)command.Parameters["@TraceTBName"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_GlobalVariables
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_GlobalVariables(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_GlobalVariables";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_IndexStats
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="IXName">IXName</param>
        /// <param name="OutputType">OutputType</param>
        /// <param name="ShowStats">ShowStats</param>
        /// <param name="TBName">TBName</param>
        /// <param name="TBOwner">TBOwner</param>
        /// <param name="UpdateStats">UpdateStats</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_IndexStats(String DBName, String Debug, String IXName, String OutputType, String ShowStats, String TBName, String TBOwner, String UpdateStats, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_IndexStats";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@IXName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, IXName));
            command.Parameters.Add(new SqlParameter("@OutputType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputType));
            command.Parameters.Add(new SqlParameter("@ShowStats", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowStats));
            command.Parameters.Add(new SqlParameter("@TBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TBName));
            command.Parameters.Add(new SqlParameter("@TBOwner", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TBOwner));
            command.Parameters.Add(new SqlParameter("@UpdateStats", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UpdateStats));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_IWCodeList
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="Name">Name</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="Owner">Owner</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_IWCodeList(String DBName, String Debug, String Name, String OutputFormat, String Owner, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_IWCodeList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Name));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@Owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Owner));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_IWInstanceStatus
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="OutputType">OutputType</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_IWInstanceStatus(String Debug, String OutputFormat, String OutputType, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_IWInstanceStatus";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@OutputType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputType));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_IWObjectColumns
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="Name">Name</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="Owner">Owner</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_IWObjectColumns(String DBName, String Debug, String Name, String OutputFormat, String Owner, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_IWObjectColumns";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Name));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@Owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Owner));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_IWObjectDepends
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="Name">Name</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="Owner">Owner</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_IWObjectDepends(String DBName, String Debug, String Name, String OutputFormat, String Owner, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_IWObjectDepends";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Name));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@Owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Owner));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_IWObjectIndexes
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="Name">Name</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="Owner">Owner</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_IWObjectIndexes(String DBName, String Debug, String Name, String OutputFormat, String Owner, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_IWObjectIndexes";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Name));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@Owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Owner));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_IWObjectList
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="Name">Name</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="Owner">Owner</param>
        /// <param name="Type">Type</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_IWObjectList(String DBName, String Debug, String Name, String OutputFormat, String Owner, String Type, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_IWObjectList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Name));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@Owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Owner));
            command.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Type));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_IWObjectPermissions
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="Name">Name</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="Owner">Owner</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_IWObjectPermissions(String DBName, String Debug, String Name, String OutputFormat, String Owner, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_IWObjectPermissions";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Name));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@Owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Owner));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_IWOldestTransactions
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_IWOldestTransactions(String Debug, String OutputFormat, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_IWOldestTransactions";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_Jobs
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="Format">Format</param>
        /// <param name="JobName">JobName</param>
        /// <param name="ListJobs">ListJobs</param>
        /// <param name="MaxJobNameLength">MaxJobNameLength</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="PrevCallTime">PrevCallTime</param>
        /// <param name="StartTime">StartTime</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_Jobs(String Debug, Int16 Format, String JobName, String ListJobs, Int16 MaxJobNameLength, String OutputFormat, String PrevCallTime, DateTime StartTime, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_Jobs";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Format", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, Format));
            command.Parameters.Add(new SqlParameter("@JobName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, JobName));
            command.Parameters.Add(new SqlParameter("@ListJobs", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ListJobs));
            command.Parameters.Add(new SqlParameter("@MaxJobNameLength", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, MaxJobNameLength));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@PrevCallTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, PrevCallTime));
            command.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, StartTime));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_LatchesLocks
        /// </summary>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_LatchesLocks(String OutputFormat, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_LatchesLocks";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ListErrorlogs
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="LogNumber">LogNumber</param>
        /// <param name="Print">Print</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ListErrorlogs(String Debug, Int16 LogNumber, String Print, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ListErrorlogs";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@LogNumber", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, LogNumber));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_Locks
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_Locks(String Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_Locks";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_LocksList
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="FilterDBName">FilterDBName</param>
        /// <param name="FilterNTUser">FilterNTUser</param>
        /// <param name="FilterObjectName">FilterObjectName</param>
        /// <param name="FilterProgramName">FilterProgramName</param>
        /// <param name="FilterSQLUser">FilterSQLUser</param>
        /// <param name="LockDBName">LockDBName</param>
        /// <param name="LockObjectName">LockObjectName</param>
        /// <param name="MaxLocks">MaxLocks</param>
        /// <param name="MaxLocksForFullResourceInfo">MaxLocksForFullResourceInfo</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="Print">Print</param>
        /// <param name="ShowDBShareLocks">ShowDBShareLocks</param>
        /// <param name="ShowIntentLocks">ShowIntentLocks</param>
        /// <param name="ShowSpotlightObjects">ShowSpotlightObjects</param>
        /// <param name="ShowSystemObjects">ShowSystemObjects</param>
        /// <param name="ShowTempDBLocks">ShowTempDBLocks</param>
        /// <param name="spid">spid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_LocksList(String Debug, String FilterDBName, String FilterNTUser, String FilterObjectName, String FilterProgramName, String FilterSQLUser, String LockDBName, String LockObjectName, Int32 MaxLocks, Int32 MaxLocksForFullResourceInfo, String OutputFormat, String Print, String ShowDBShareLocks, String ShowIntentLocks, String ShowSpotlightObjects, String ShowSystemObjects, String ShowTempDBLocks, Int32 spid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_LocksList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@FilterDBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterDBName));
            command.Parameters.Add(new SqlParameter("@FilterNTUser", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterNTUser));
            command.Parameters.Add(new SqlParameter("@FilterObjectName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterObjectName));
            command.Parameters.Add(new SqlParameter("@FilterProgramName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterProgramName));
            command.Parameters.Add(new SqlParameter("@FilterSQLUser", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterSQLUser));
            command.Parameters.Add(new SqlParameter("@LockDBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LockDBName));
            command.Parameters.Add(new SqlParameter("@LockObjectName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LockObjectName));
            command.Parameters.Add(new SqlParameter("@MaxLocks", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxLocks));
            command.Parameters.Add(new SqlParameter("@MaxLocksForFullResourceInfo", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxLocksForFullResourceInfo));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@ShowDBShareLocks", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowDBShareLocks));
            command.Parameters.Add(new SqlParameter("@ShowIntentLocks", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowIntentLocks));
            command.Parameters.Add(new SqlParameter("@ShowSpotlightObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowSpotlightObjects));
            command.Parameters.Add(new SqlParameter("@ShowSystemObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowSystemObjects));
            command.Parameters.Add(new SqlParameter("@ShowTempDBLocks", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowTempDBLocks));
            command.Parameters.Add(new SqlParameter("@spid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, spid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_LockStats
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_LockStats(String Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_LockStats";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_LogMessage
        /// </summary>
        /// <param name="DaysToKeep">DaysToKeep</param>
        /// <param name="Debug">Debug</param>
        /// <param name="Message">Message</param>
        /// <param name="MessageNbr">MessageNbr</param>
        /// <param name="Proc">Proc</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_LogMessage(Int32 DaysToKeep, String Debug, String Message, Int32 MessageNbr, String Proc, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_LogMessage";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DaysToKeep", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, DaysToKeep));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Message", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Message));
            command.Parameters.Add(new SqlParameter("@MessageNbr", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MessageNbr));
            command.Parameters.Add(new SqlParameter("@Proc", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Proc));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_LogShippingInSync
        /// </summary>
        /// <param name="compare_with">compare_with</param>
        /// <param name="delta">delta</param>
        /// <param name="enabled">enabled</param>
        /// <param name="last_updated">last_updated</param>
        /// <param name="outage_end_time">outage_end_time</param>
        /// <param name="outage_start_time">outage_start_time</param>
        /// <param name="outage_weekday_mask">outage_weekday_mask</param>
        /// <param name="threshold">threshold</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_LogShippingInSync(DateTime compare_with, ref Int32 delta, Boolean enabled, DateTime last_updated, Int32 outage_end_time, Int32 outage_start_time, Int32 outage_weekday_mask, Int32 threshold, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_LogShippingInSync";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@compare_with", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, compare_with));
            command.Parameters.Add(new SqlParameter("@delta", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, delta));
            command.Parameters.Add(new SqlParameter("@enabled", SqlDbType.Bit, 0, ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, enabled));
            command.Parameters.Add(new SqlParameter("@last_updated", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, last_updated));
            command.Parameters.Add(new SqlParameter("@outage_end_time", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, outage_end_time));
            command.Parameters.Add(new SqlParameter("@outage_start_time", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, outage_start_time));
            command.Parameters.Add(new SqlParameter("@outage_weekday_mask", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, outage_weekday_mask));
            command.Parameters.Add(new SqlParameter("@threshold", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, threshold));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                delta = (Int32)command.Parameters["@delta"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_LogShippingMonitorInfo
        /// </summary>
        /// <param name="CheckOnly">CheckOnly</param>
        /// <param name="primary_database_name">primary_database_name</param>
        /// <param name="primary_server_name">primary_server_name</param>
        /// <param name="secondary_database_name">secondary_database_name</param>
        /// <param name="secondary_server_name">secondary_server_name</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_LogShippingMonitorInfo(String CheckOnly, String primary_database_name, String primary_server_name, String secondary_database_name, String secondary_server_name, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_LogShippingMonitorInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CheckOnly", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CheckOnly));
            command.Parameters.Add(new SqlParameter("@primary_database_name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, primary_database_name));
            command.Parameters.Add(new SqlParameter("@primary_server_name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, primary_server_name));
            command.Parameters.Add(new SqlParameter("@secondary_database_name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, secondary_database_name));
            command.Parameters.Add(new SqlParameter("@secondary_server_name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, secondary_server_name));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ObjectsByDatabase
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="IncludeUserInfo">IncludeUserInfo</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ObjectsByDatabase(String Debug, String IncludeUserInfo, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ObjectsByDatabase";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@IncludeUserInfo", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, IncludeUserInfo));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ProcCacheByType
        /// </summary>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ProcCacheByType(String OutputFormat, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ProcCacheByType";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ProcCacheContents
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="FilterDBName">FilterDBName</param>
        /// <param name="FilterObjectName">FilterObjectName</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="MaxRows">MaxRows</param>
        /// <param name="ShowAdhocObjects">ShowAdhocObjects</param>
        /// <param name="ShowSpotlightObjects">ShowSpotlightObjects</param>
        /// <param name="ShowSystemObjects">ShowSystemObjects</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ProcCacheContents(String Debug, String FilterDBName, String FilterObjectName, String ForceRefresh, Int32 MaxRows, String ShowAdhocObjects, String ShowSpotlightObjects, String ShowSystemObjects, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ProcCacheContents";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@FilterDBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterDBName));
            command.Parameters.Add(new SqlParameter("@FilterObjectName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterObjectName));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@MaxRows", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxRows));
            command.Parameters.Add(new SqlParameter("@ShowAdhocObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowAdhocObjects));
            command.Parameters.Add(new SqlParameter("@ShowSpotlightObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowSpotlightObjects));
            command.Parameters.Add(new SqlParameter("@ShowSystemObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowSystemObjects));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RecordRefreshTime
        /// </summary>
        /// <param name="CounterName">CounterName</param>
        /// <param name="CreateRowIfNecessary">CreateRowIfNecessary</param>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="ExtraDataDecimal">ExtraDataDecimal</param>
        /// <param name="ExtraDataDecimal2">ExtraDataDecimal2</param>
        /// <param name="ExtraDataTime">ExtraDataTime</param>
        /// <param name="Print">Print</param>
        /// <param name="RefreshStartTime">RefreshStartTime</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RecordRefreshTime(String CounterName, String CreateRowIfNecessary, String DBName, String Debug, Decimal ExtraDataDecimal, Decimal ExtraDataDecimal2, DateTime ExtraDataTime, String Print, DateTime RefreshStartTime, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RecordRefreshTime";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CounterName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CounterName));
            command.Parameters.Add(new SqlParameter("@CreateRowIfNecessary", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CreateRowIfNecessary));
            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ExtraDataDecimal", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 13, 0, "", DataRowVersion.Current, ExtraDataDecimal));
            command.Parameters.Add(new SqlParameter("@ExtraDataDecimal2", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 13, 0, "", DataRowVersion.Current, ExtraDataDecimal2));
            command.Parameters.Add(new SqlParameter("@ExtraDataTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, ExtraDataTime));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RefreshStartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, RefreshStartTime));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshDB_DBStatus
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="DBStatusInt">DBStatusInt</param>
        /// <param name="Debug">Debug</param>
        /// <param name="ReadAllowed">ReadAllowed</param>
        /// <param name="ReadOnly">ReadOnly</param>
        /// <param name="SQLVersion">SQLVersion</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshDB_DBStatus(String DBName, Int32 DBStatusInt, String Debug, String ReadAllowed, String ReadOnly, Decimal SQLVersion, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshDB_DBStatus";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@DBStatusInt", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, DBStatusInt));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ReadAllowed", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ReadAllowed));
            command.Parameters.Add(new SqlParameter("@ReadOnly", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ReadOnly));
            command.Parameters.Add(new SqlParameter("@SQLVersion", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 5, 1, "", DataRowVersion.Current, SQLVersion));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshDB_FileChange
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshDB_FileChange(String DBName, String Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshDB_FileChange";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshDB_FileOrDiskChange
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshDB_FileOrDiskChange(String DBName, String Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshDB_FileOrDiskChange";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshDB_IXChange
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="TableCollect">TableCollect</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshDB_IXChange(String DBName, String Debug, String TableCollect, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshDB_IXChange";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@TableCollect", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TableCollect));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshDB_MaintainFGInfo
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshDB_MaintainFGInfo(String DBName, String Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshDB_MaintainFGInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshDBInfo
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="MinFlushRefreshMins">MinFlushRefreshMins</param>
        /// <param name="Print">Print</param>
        /// <param name="QuickRefresh">QuickRefresh</param>
        /// <param name="SkipCheck">SkipCheck</param>
        /// <param name="TableCollect">TableCollect</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshDBInfo(String Debug, String ForceRefresh, Int32 MinFlushRefreshMins, String Print, String QuickRefresh, String SkipCheck, String TableCollect, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshDBInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@MinFlushRefreshMins", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MinFlushRefreshMins));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@QuickRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, QuickRefresh));
            command.Parameters.Add(new SqlParameter("@SkipCheck", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SkipCheck));
            command.Parameters.Add(new SqlParameter("@TableCollect", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TableCollect));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshDiskInfo
        /// </summary>
        /// <param name="DataChanged">DataChanged</param>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="Print">Print</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshDiskInfo(ref String DataChanged, String Debug, String ForceRefresh, String Print, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshDiskInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DataChanged", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, DataChanged));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                DataChanged = (String)command.Parameters["@DataChanged"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshFile_Full
        /// </summary>
        /// <param name="DataChanged">DataChanged</param>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="MultiFG">MultiFG</param>
        /// <param name="MultiFGOnly">MultiFGOnly</param>
        /// <param name="RefreshStartTime">RefreshStartTime</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshFile_Full(ref String DataChanged, String DBName, String Debug, String MultiFG, String MultiFGOnly, ref DateTime RefreshStartTime, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshFile_Full";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DataChanged", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, DataChanged));
            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@MultiFG", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, MultiFG));
            command.Parameters.Add(new SqlParameter("@MultiFGOnly", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, MultiFGOnly));
            command.Parameters.Add(new SqlParameter("@RefreshStartTime", SqlDbType.DateTime, 0, ParameterDirection.InputOutput, false, 23, 3, "", DataRowVersion.Current, RefreshStartTime));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                DataChanged = (String)command.Parameters["@DataChanged"].Value;
                RefreshStartTime = (DateTime)command.Parameters["@RefreshStartTime"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshFileInfo
        /// </summary>
        /// <param name="DataChanged">DataChanged</param>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="DiskDataChanged">DiskDataChanged</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="Print">Print</param>
        /// <param name="QuickRefresh">QuickRefresh</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshFileInfo(ref String DataChanged, String DBName, String Debug, String DiskDataChanged, String ForceRefresh, String Print, String QuickRefresh, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshFileInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DataChanged", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, DataChanged));
            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DiskDataChanged", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DiskDataChanged));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@QuickRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, QuickRefresh));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                DataChanged = (String)command.Parameters["@DataChanged"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshIXInfo
        /// </summary>
        /// <param name="DataChanged">DataChanged</param>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="OutputType">OutputType</param>
        /// <param name="Owner">Owner</param>
        /// <param name="Print">Print</param>
        /// <param name="TBName">TBName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshIXInfo(ref String DataChanged, String DBName, String Debug, String ForceRefresh, String OutputFormat, String OutputType, String Owner, String Print, String TBName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshIXInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DataChanged", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, DataChanged));
            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@OutputType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputType));
            command.Parameters.Add(new SqlParameter("@Owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Owner));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@TBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TBName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                DataChanged = (String)command.Parameters["@DataChanged"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshLogUsageInfo
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="Print">Print</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshLogUsageInfo(String DBName, String Debug, String Print, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshLogUsageInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_RefreshReplData
        /// </summary>
        /// <param name="ConflictsOnly">ConflictsOnly</param>
        /// <param name="Debug">Debug</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="Print">Print</param>
        /// <param name="ReplicationIsInstalled">ReplicationIsInstalled</param>
        /// <param name="TotalConflictCnt">TotalConflictCnt</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_RefreshReplData(String ConflictsOnly, String Debug, String ForceRefresh, String Print, String ReplicationIsInstalled, ref Int32 TotalConflictCnt, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_RefreshReplData";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ConflictsOnly", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ConflictsOnly));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@ReplicationIsInstalled", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ReplicationIsInstalled));
            command.Parameters.Add(new SqlParameter("@TotalConflictCnt", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, TotalConflictCnt));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                TotalConflictCnt = (Int32)command.Parameters["@TotalConflictCnt"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_Replication
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="DummyCall">DummyCall</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="OutputType">OutputType</param>
        /// <param name="Print">Print</param>
        /// <param name="TotalConflictCnt">TotalConflictCnt</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_Replication(String Debug, String DummyCall, String ForceRefresh, String OutputFormat, String OutputType, String Print, ref Int32 TotalConflictCnt, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_Replication";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DummyCall", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DummyCall));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@OutputType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputType));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@TotalConflictCnt", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, TotalConflictCnt));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                TotalConflictCnt = (Int32)command.Parameters["@TotalConflictCnt"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ReplicationAgentMessages
        /// </summary>
        /// <param name="AgentName">AgentName</param>
        /// <param name="AgentType">AgentType</param>
        /// <param name="Debug">Debug</param>
        /// <param name="DistributionDBName">DistributionDBName</param>
        /// <param name="DummyCall">DummyCall</param>
        /// <param name="Print">Print</param>
        /// <param name="StartTime">StartTime</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ReplicationAgentMessages(String AgentName, String AgentType, String Debug, String DistributionDBName, String DummyCall, String Print, DateTime StartTime, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ReplicationAgentMessages";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@AgentName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, AgentName));
            command.Parameters.Add(new SqlParameter("@AgentType", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, AgentType));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DistributionDBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DistributionDBName));
            command.Parameters.Add(new SqlParameter("@DummyCall", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DummyCall));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 23, 3, "", DataRowVersion.Current, StartTime));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ReplicationAgents
        /// </summary>
        /// <param name="AgentType">AgentType</param>
        /// <param name="AtLeastOneAgentFailed">AtLeastOneAgentFailed</param>
        /// <param name="Debug">Debug</param>
        /// <param name="DummyCall">DummyCall</param>
        /// <param name="ForceRefresh">ForceRefresh</param>
        /// <param name="OutputType">OutputType</param>
        /// <param name="Print">Print</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ReplicationAgents(String AgentType, ref Int32 AtLeastOneAgentFailed, String Debug, String DummyCall, String ForceRefresh, String OutputType, String Print, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ReplicationAgents";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@AgentType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, AgentType));
            command.Parameters.Add(new SqlParameter("@AtLeastOneAgentFailed", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, AtLeastOneAgentFailed));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DummyCall", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DummyCall));
            command.Parameters.Add(new SqlParameter("@ForceRefresh", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ForceRefresh));
            command.Parameters.Add(new SqlParameter("@OutputType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputType));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                AtLeastOneAgentFailed = (Int32)command.Parameters["@AtLeastOneAgentFailed"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ReplicationReinit
        /// </summary>
        /// <param name="AgentName">AgentName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="DummyCall">DummyCall</param>
        /// <param name="NoExec">NoExec</param>
        /// <param name="SubscriptionID">SubscriptionID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ReplicationReinit(String AgentName, String Debug, String DummyCall, String NoExec, Int32 SubscriptionID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ReplicationReinit";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@AgentName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, AgentName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DummyCall", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DummyCall));
            command.Parameters.Add(new SqlParameter("@NoExec", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, NoExec));
            command.Parameters.Add(new SqlParameter("@SubscriptionID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, SubscriptionID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ReplicationStats
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="DummyCall">DummyCall</param>
        /// <param name="MaxInstanceLength">MaxInstanceLength</param>
        /// <param name="Name">Name</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="OutputType">OutputType</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ReplicationStats(String Debug, String DummyCall, Int32 MaxInstanceLength, String Name, String OutputFormat, String OutputType, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ReplicationStats";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DummyCall", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DummyCall));
            command.Parameters.Add(new SqlParameter("@MaxInstanceLength", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxInstanceLength));
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Name));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@OutputType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputType));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_ServiceControl
        /// </summary>
        /// <param name="ClusterType">ClusterType</param>
        /// <param name="Debug">Debug</param>
        /// <param name="MoveTo">MoveTo</param>
        /// <param name="ServiceAction">ServiceAction</param>
        /// <param name="ServiceName">ServiceName</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_ServiceControl(String ClusterType, String Debug, String MoveTo, String ServiceAction, String ServiceName, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_ServiceControl";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ClusterType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ClusterType));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@MoveTo", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, MoveTo));
            command.Parameters.Add(new SqlParameter("@ServiceAction", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ServiceAction));
            command.Parameters.Add(new SqlParameter("@ServiceName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ServiceName));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_SetDBMonList
        /// </summary>
        /// <param name="DBList">DBList</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_SetDBMonList(String DBList, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_SetDBMonList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBList", SqlDbType.VarChar, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBList));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_SQL2K_IOByFile
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_SQL2K_IOByFile(String DBName, String Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_SQL2K_IOByFile";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_Statistics
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="GlobalTraceSpid">GlobalTraceSpid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_Statistics(String Debug, Int32 GlobalTraceSpid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_Statistics";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@GlobalTraceSpid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, GlobalTraceSpid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_SuppressFeature
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="Feature">Feature</param>
        /// <param name="Print">Print</param>
        /// <param name="spid">spid</param>
        /// <param name="Suppress">Suppress</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_SuppressFeature(String Debug, String Feature, String Print, Int32 spid, String Suppress, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_SuppressFeature";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@Feature", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Feature));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@spid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, spid));
            command.Parameters.Add(new SqlParameter("@Suppress", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Suppress));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_TableFragInfo
        /// </summary>
        /// <param name="DBList">DBList</param>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="FilterDBName">FilterDBName</param>
        /// <param name="FilterObjectName">FilterObjectName</param>
        /// <param name="HideIrrelevantStats">HideIrrelevantStats</param>
        /// <param name="IXName">IXName</param>
        /// <param name="Owner">Owner</param>
        /// <param name="RecordCountOnly">RecordCountOnly</param>
        /// <param name="ShowSpotlightObjects">ShowSpotlightObjects</param>
        /// <param name="ShowStats">ShowStats</param>
        /// <param name="ShowSystemObjects">ShowSystemObjects</param>
        /// <param name="TBName">TBName</param>
        /// <param name="UpdateData">UpdateData</param>
        /// <param name="UpdateStats">UpdateStats</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_TableFragInfo(String DBList, String DBName, String Debug, String FilterDBName, String FilterObjectName, String HideIrrelevantStats, String IXName, String Owner, String RecordCountOnly, String ShowSpotlightObjects, String ShowStats, String ShowSystemObjects, String TBName, String UpdateData, String UpdateStats, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_TableFragInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBList", SqlDbType.VarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBList));
            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@FilterDBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterDBName));
            command.Parameters.Add(new SqlParameter("@FilterObjectName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterObjectName));
            command.Parameters.Add(new SqlParameter("@HideIrrelevantStats", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, HideIrrelevantStats));
            command.Parameters.Add(new SqlParameter("@IXName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, IXName));
            command.Parameters.Add(new SqlParameter("@Owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Owner));
            command.Parameters.Add(new SqlParameter("@RecordCountOnly", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, RecordCountOnly));
            command.Parameters.Add(new SqlParameter("@ShowSpotlightObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowSpotlightObjects));
            command.Parameters.Add(new SqlParameter("@ShowStats", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowStats));
            command.Parameters.Add(new SqlParameter("@ShowSystemObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowSystemObjects));
            command.Parameters.Add(new SqlParameter("@TBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TBName));
            command.Parameters.Add(new SqlParameter("@UpdateData", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UpdateData));
            command.Parameters.Add(new SqlParameter("@UpdateStats", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UpdateStats));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_TableSize
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="List">List</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_TableSize(String Debug, String List, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_TableSize";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@List", SqlDbType.VarChar, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, List));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_TablesList
        /// </summary>
        /// <param name="DBList">DBList</param>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="FilterDBName">FilterDBName</param>
        /// <param name="FilterObjectName">FilterObjectName</param>
        /// <param name="IncludeSystemTables">IncludeSystemTables</param>
        /// <param name="Owner">Owner</param>
        /// <param name="RecordCountOnly">RecordCountOnly</param>
        /// <param name="ShowSpotlightObjects">ShowSpotlightObjects</param>
        /// <param name="ShowSystemObjects">ShowSystemObjects</param>
        /// <param name="TBName">TBName</param>
        /// <param name="Type">Type</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_TablesList(String DBList, String DBName, String Debug, String FilterDBName, String FilterObjectName, String IncludeSystemTables, String Owner, String RecordCountOnly, String ShowSpotlightObjects, String ShowSystemObjects, String TBName, String Type, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_TablesList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBList", SqlDbType.VarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBList));
            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@FilterDBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterDBName));
            command.Parameters.Add(new SqlParameter("@FilterObjectName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, FilterObjectName));
            command.Parameters.Add(new SqlParameter("@IncludeSystemTables", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, IncludeSystemTables));
            command.Parameters.Add(new SqlParameter("@Owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Owner));
            command.Parameters.Add(new SqlParameter("@RecordCountOnly", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, RecordCountOnly));
            command.Parameters.Add(new SqlParameter("@ShowSpotlightObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowSpotlightObjects));
            command.Parameters.Add(new SqlParameter("@ShowSystemObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowSystemObjects));
            command.Parameters.Add(new SqlParameter("@TBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TBName));
            command.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Type));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_Trace
        /// </summary>
        /// <param name="CheckMins">CheckMins</param>
        /// <param name="Debug">Debug</param>
        /// <param name="DummyCall">DummyCall</param>
        /// <param name="EndTrace">EndTrace</param>
        /// <param name="GetGlobalTraceSQL">GetGlobalTraceSQL</param>
        /// <param name="GlobalTrace">GlobalTrace</param>
        /// <param name="IncludeAutoStats">IncludeAutoStats</param>
        /// <param name="IncludeDeadlocks">IncludeDeadlocks</param>
        /// <param name="IncludeEscalations">IncludeEscalations</param>
        /// <param name="IncludeRecompiles">IncludeRecompiles</param>
        /// <param name="IncludeTimeouts">IncludeTimeouts</param>
        /// <param name="indent">indent</param>
        /// <param name="LastCallID">LastCallID</param>
        /// <param name="MaxIDReturned">MaxIDReturned</param>
        /// <param name="MaxRowsPerRun">MaxRowsPerRun</param>
        /// <param name="MinSecsBetweenDataCollection">MinSecsBetweenDataCollection</param>
        /// <param name="NbrEventsPerLoop">NbrEventsPerLoop</param>
        /// <param name="RetainMins">RetainMins</param>
        /// <param name="ShowSpotlightObjects">ShowSpotlightObjects</param>
        /// <param name="ShowSystemObjects">ShowSystemObjects</param>
        /// <param name="SkipCheck">SkipCheck</param>
        /// <param name="spid">spid</param>
        /// <param name="xp_cmdshell_available">xp_cmdshell_available</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_Trace(Int32 CheckMins, String Debug, String DummyCall, String EndTrace, String GetGlobalTraceSQL, String GlobalTrace, String IncludeAutoStats, String IncludeDeadlocks, String IncludeEscalations, String IncludeRecompiles, String IncludeTimeouts, Int16 indent, Int32 LastCallID, ref Int32 MaxIDReturned, Int32 MaxRowsPerRun, Int32 MinSecsBetweenDataCollection, Int32 NbrEventsPerLoop, Int32 RetainMins, String ShowSpotlightObjects, String ShowSystemObjects, String SkipCheck, Int32 spid, String xp_cmdshell_available, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_Trace";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CheckMins", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, CheckMins));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DummyCall", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DummyCall));
            command.Parameters.Add(new SqlParameter("@EndTrace", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, EndTrace));
            command.Parameters.Add(new SqlParameter("@GetGlobalTraceSQL", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GetGlobalTraceSQL));
            command.Parameters.Add(new SqlParameter("@GlobalTrace", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GlobalTrace));
            command.Parameters.Add(new SqlParameter("@IncludeAutoStats", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, IncludeAutoStats));
            command.Parameters.Add(new SqlParameter("@IncludeDeadlocks", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, IncludeDeadlocks));
            command.Parameters.Add(new SqlParameter("@IncludeEscalations", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, IncludeEscalations));
            command.Parameters.Add(new SqlParameter("@IncludeRecompiles", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, IncludeRecompiles));
            command.Parameters.Add(new SqlParameter("@IncludeTimeouts", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, IncludeTimeouts));
            command.Parameters.Add(new SqlParameter("@indent", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, indent));
            command.Parameters.Add(new SqlParameter("@LastCallID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, LastCallID));
            command.Parameters.Add(new SqlParameter("@MaxIDReturned", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, MaxIDReturned));
            command.Parameters.Add(new SqlParameter("@MaxRowsPerRun", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxRowsPerRun));
            command.Parameters.Add(new SqlParameter("@MinSecsBetweenDataCollection", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MinSecsBetweenDataCollection));
            command.Parameters.Add(new SqlParameter("@NbrEventsPerLoop", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, NbrEventsPerLoop));
            command.Parameters.Add(new SqlParameter("@RetainMins", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, RetainMins));
            command.Parameters.Add(new SqlParameter("@ShowSpotlightObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowSpotlightObjects));
            command.Parameters.Add(new SqlParameter("@ShowSystemObjects", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ShowSystemObjects));
            command.Parameters.Add(new SqlParameter("@SkipCheck", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SkipCheck));
            command.Parameters.Add(new SqlParameter("@spid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, spid));
            command.Parameters.Add(new SqlParameter("@xp_cmdshell_available", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, xp_cmdshell_available));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                MaxIDReturned = (Int32)command.Parameters["@MaxIDReturned"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_TraceCheck
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_TraceCheck(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_TraceCheck";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_TraceControl
        /// </summary>
        /// <param name="CalledBySpid">CalledBySpid</param>
        /// <param name="CheckQueueExists">CheckQueueExists</param>
        /// <param name="Cleanup">Cleanup</param>
        /// <param name="Debug">Debug</param>
        /// <param name="DeleteFile">DeleteFile</param>
        /// <param name="EndTrace">EndTrace</param>
        /// <param name="GetGlobalTraceSQL">GetGlobalTraceSQL</param>
        /// <param name="GlobalTrace">GlobalTrace</param>
        /// <param name="MaxRowsPerRun">MaxRowsPerRun</param>
        /// <param name="MinSecsBetweenDataCollection">MinSecsBetweenDataCollection</param>
        /// <param name="RefreshEventNames">RefreshEventNames</param>
        /// <param name="RetainMins">RetainMins</param>
        /// <param name="spid">spid</param>
        /// <param name="StartTrace">StartTrace</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_TraceControl(Int32 CalledBySpid, String CheckQueueExists, String Cleanup, String Debug, String DeleteFile, String EndTrace, String GetGlobalTraceSQL, String GlobalTrace, Int32 MaxRowsPerRun, Int32 MinSecsBetweenDataCollection, String RefreshEventNames, Int32 RetainMins, Int32 spid, String StartTrace, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_TraceControl";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CalledBySpid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, CalledBySpid));
            command.Parameters.Add(new SqlParameter("@CheckQueueExists", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CheckQueueExists));
            command.Parameters.Add(new SqlParameter("@Cleanup", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Cleanup));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DeleteFile", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeleteFile));
            command.Parameters.Add(new SqlParameter("@EndTrace", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, EndTrace));
            command.Parameters.Add(new SqlParameter("@GetGlobalTraceSQL", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GetGlobalTraceSQL));
            command.Parameters.Add(new SqlParameter("@GlobalTrace", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GlobalTrace));
            command.Parameters.Add(new SqlParameter("@MaxRowsPerRun", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MaxRowsPerRun));
            command.Parameters.Add(new SqlParameter("@MinSecsBetweenDataCollection", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MinSecsBetweenDataCollection));
            command.Parameters.Add(new SqlParameter("@RefreshEventNames", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, RefreshEventNames));
            command.Parameters.Add(new SqlParameter("@RetainMins", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, RetainMins));
            command.Parameters.Add(new SqlParameter("@spid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, spid));
            command.Parameters.Add(new SqlParameter("@StartTrace", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, StartTrace));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_TraceEnd
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="DeleteFile">DeleteFile</param>
        /// <param name="GlobalTrace">GlobalTrace</param>
        /// <param name="MsgOut">MsgOut</param>
        /// <param name="MySpid">MySpid</param>
        /// <param name="SQL2KTraceFileName">SQL2KTraceFileName</param>
        /// <param name="TraceQueueNbr">TraceQueueNbr</param>
        /// <param name="TraceTBName">TraceTBName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_TraceEnd(String Debug, String DeleteFile, String GlobalTrace, ref String MsgOut, Int32 MySpid, String SQL2KTraceFileName, Int32 TraceQueueNbr, String TraceTBName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_TraceEnd";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DeleteFile", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeleteFile));
            command.Parameters.Add(new SqlParameter("@GlobalTrace", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GlobalTrace));
            command.Parameters.Add(new SqlParameter("@MsgOut", SqlDbType.VarChar, 100, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, MsgOut));
            command.Parameters.Add(new SqlParameter("@MySpid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MySpid));
            command.Parameters.Add(new SqlParameter("@SQL2KTraceFileName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SQL2KTraceFileName));
            command.Parameters.Add(new SqlParameter("@TraceQueueNbr", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, TraceQueueNbr));
            command.Parameters.Add(new SqlParameter("@TraceTBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TraceTBName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                MsgOut = (String)command.Parameters["@MsgOut"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_TraceFilterUpdate
        /// </summary>
        /// <param name="cpu">cpu</param>
        /// <param name="Debug">Debug</param>
        /// <param name="duration">duration</param>
        /// <param name="reads">reads</param>
        /// <param name="rpc">rpc</param>
        /// <param name="sql">sql</param>
        /// <param name="sqlbatch">sqlbatch</param>
        /// <param name="writes">writes</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_TraceFilterUpdate(Int32 cpu, String Debug, Int32 duration, Int32 reads, Int32 rpc, Int32 sql, Int32 sqlbatch, Int32 writes, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_TraceFilterUpdate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@cpu", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, cpu));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@duration", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, duration));
            command.Parameters.Add(new SqlParameter("@reads", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, reads));
            command.Parameters.Add(new SqlParameter("@rpc", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, rpc));
            command.Parameters.Add(new SqlParameter("@sql", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, sql));
            command.Parameters.Add(new SqlParameter("@sqlbatch", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, sqlbatch));
            command.Parameters.Add(new SqlParameter("@writes", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, writes));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_TraceMaintainSQL
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="InsertCnt">InsertCnt</param>
        /// <param name="WorkTBName">WorkTBName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_TraceMaintainSQL(String Debug, Int32 InsertCnt, String WorkTBName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_TraceMaintainSQL";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@InsertCnt", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, InsertCnt));
            command.Parameters.Add(new SqlParameter("@WorkTBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, WorkTBName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_TraceRefreshEventNames
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_TraceRefreshEventNames(String Debug, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_TraceRefreshEventNames";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_TraceStart
        /// </summary>
        /// <param name="Debug">Debug</param>
        /// <param name="GetGlobalTraceSQL">GetGlobalTraceSQL</param>
        /// <param name="GlobalTrace">GlobalTrace</param>
        /// <param name="MySpid">MySpid</param>
        /// <param name="spid">spid</param>
        /// <param name="SQL2KTraceFileName">SQL2KTraceFileName</param>
        /// <param name="TraceQueueNbr">TraceQueueNbr</param>
        /// <param name="TraceTBName">TraceTBName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_TraceStart(String Debug, String GetGlobalTraceSQL, String GlobalTrace, Int32 MySpid, Int32 spid, String SQL2KTraceFileName, ref Int32 TraceQueueNbr, String TraceTBName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_TraceStart";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@GetGlobalTraceSQL", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GetGlobalTraceSQL));
            command.Parameters.Add(new SqlParameter("@GlobalTrace", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, GlobalTrace));
            command.Parameters.Add(new SqlParameter("@MySpid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, MySpid));
            command.Parameters.Add(new SqlParameter("@spid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, spid));
            command.Parameters.Add(new SqlParameter("@SQL2KTraceFileName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SQL2KTraceFileName));
            command.Parameters.Add(new SqlParameter("@TraceQueueNbr", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, TraceQueueNbr));
            command.Parameters.Add(new SqlParameter("@TraceTBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TraceTBName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                TraceQueueNbr = (Int32)command.Parameters["@TraceQueueNbr"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_VersionInfo
        /// </summary>
        /// <param name="CaseSensitive">CaseSensitive</param>
        /// <param name="ClusterMachineName">ClusterMachineName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="NTVersion">NTVersion</param>
        /// <param name="OutputFormat">OutputFormat</param>
        /// <param name="PhysicalMemoryMB">PhysicalMemoryMB</param>
        /// <param name="Print">Print</param>
        /// <param name="ProcessorType">ProcessorType</param>
        /// <param name="RunningOnACluster">RunningOnACluster</param>
        /// <param name="ServerName">ServerName</param>
        /// <param name="SPVersion">SPVersion</param>
        /// <param name="SQLEdition">SQLEdition</param>
        /// <param name="SQLVersion">SQLVersion</param>
        /// <param name="VersionID">VersionID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_VersionInfo(ref Int32 CaseSensitive, ref String ClusterMachineName, String Debug, ref String NTVersion, String OutputFormat, ref Decimal PhysicalMemoryMB, String Print, ref String ProcessorType, ref String RunningOnACluster, ref String ServerName, ref String SPVersion, ref String SQLEdition, ref String SQLVersion, ref String VersionID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_VersionInfo";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CaseSensitive", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, CaseSensitive));
            command.Parameters.Add(new SqlParameter("@ClusterMachineName", SqlDbType.NVarChar, 128, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ClusterMachineName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@NTVersion", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, NTVersion));
            command.Parameters.Add(new SqlParameter("@OutputFormat", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OutputFormat));
            command.Parameters.Add(new SqlParameter("@PhysicalMemoryMB", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, false, 18, 0, "", DataRowVersion.Current, PhysicalMemoryMB));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@ProcessorType", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ProcessorType));
            command.Parameters.Add(new SqlParameter("@RunningOnACluster", SqlDbType.Char, 1, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, RunningOnACluster));
            command.Parameters.Add(new SqlParameter("@ServerName", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ServerName));
            command.Parameters.Add(new SqlParameter("@SPVersion", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, SPVersion));
            command.Parameters.Add(new SqlParameter("@SQLEdition", SqlDbType.VarChar, 100, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, SQLEdition));
            command.Parameters.Add(new SqlParameter("@SQLVersion", SqlDbType.VarChar, 100, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, SQLVersion));
            command.Parameters.Add(new SqlParameter("@VersionID", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, VersionID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                CaseSensitive = (Int32)command.Parameters["@CaseSensitive"].Value;
                ClusterMachineName = (String)command.Parameters["@ClusterMachineName"].Value;
                NTVersion = (String)command.Parameters["@NTVersion"].Value;
                PhysicalMemoryMB = (Decimal)command.Parameters["@PhysicalMemoryMB"].Value;
                ProcessorType = (String)command.Parameters["@ProcessorType"].Value;
                RunningOnACluster = (String)command.Parameters["@RunningOnACluster"].Value;
                ServerName = (String)command.Parameters["@ServerName"].Value;
                SPVersion = (String)command.Parameters["@SPVersion"].Value;
                SQLEdition = (String)command.Parameters["@SQLEdition"].Value;
                SQLVersion = (String)command.Parameters["@SQLVersion"].Value;
                VersionID = (String)command.Parameters["@VersionID"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_VirtualLogFileList
        /// </summary>
        /// <param name="DBName">DBName</param>
        /// <param name="Debug">Debug</param>
        /// <param name="DeleteDataAtEnd">DeleteDataAtEnd</param>
        /// <param name="Print">Print</param>
        /// <param name="SortPhysically">SortPhysically</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_VirtualLogFileList(String DBName, String Debug, String DeleteDataAtEnd, String Print, String SortPhysically, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_VirtualLogFileList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DBName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DBName));
            command.Parameters.Add(new SqlParameter("@Debug", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Debug));
            command.Parameters.Add(new SqlParameter("@DeleteDataAtEnd", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeleteDataAtEnd));
            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@SortPhysically", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SortPhysically));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Spot_WaitsList
        /// </summary>
        /// <param name="Print">Print</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Spot_WaitsList(String Print, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Spot_WaitsList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Print", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Print));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Synhrjctohistory
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Synhrjctohistory(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Synhrjctohistory";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// test
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int test(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "test";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// up_Check_Emply
        /// </summary>
        /// <param name="C21">C21</param>
        /// <param name="datParms">datParms</param>
        /// <param name="F2">F2</param>
        /// <param name="F4">F4</param>
        /// <param name="HireDate">HireDate</param>
        /// <param name="HomeTown">HomeTown</param>
        /// <param name="keyParms">keyParms</param>
        /// <param name="LastErr">LastErr</param>
        /// <param name="sEmpDeptId">sEmpDeptId</param>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="sEmpName">sEmpName</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int up_Check_Emply(String C21, String datParms, Double F2, Double F4, DateTime HireDate, String HomeTown, String keyParms, ref String LastErr, String sEmpDeptId, String sEmpId, String sEmpName, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "up_Check_Emply";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@C21", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C21));
            command.Parameters.Add(new SqlParameter("@datParms", SqlDbType.VarChar, 300, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, datParms));
            command.Parameters.Add(new SqlParameter("@F2", SqlDbType.Float, 0, ParameterDirection.Input, false, 53, 0, "", DataRowVersion.Current, F2));
            command.Parameters.Add(new SqlParameter("@F4", SqlDbType.Float, 0, ParameterDirection.Input, false, 53, 0, "", DataRowVersion.Current, F4));
            command.Parameters.Add(new SqlParameter("@HireDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, HireDate));
            command.Parameters.Add(new SqlParameter("@HomeTown", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, HomeTown));
            command.Parameters.Add(new SqlParameter("@keyParms", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, keyParms));
            command.Parameters.Add(new SqlParameter("@LastErr", SqlDbType.NVarChar, 255, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, LastErr));
            command.Parameters.Add(new SqlParameter("@sEmpDeptId", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpDeptId));
            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@sEmpName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpName));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                LastErr = (String)command.Parameters["@LastErr"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// UpdateCardDataToHistory
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int UpdateCardDataToHistory(String pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UpdateCardDataToHistory";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// UpdateDinnerToHistory
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int UpdateDinnerToHistory(String pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UpdateDinnerToHistory";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// UpdateEmpC56
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int UpdateEmpC56(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UpdateEmpC56";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// UpdateEmpDeptToHisRecord
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int UpdateEmpDeptToHisRecord(String pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UpdateEmpDeptToHisRecord";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// UpdateEmpDeptToHistory
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int UpdateEmpDeptToHistory(String pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UpdateEmpDeptToHistory";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// UpdateEmpDeptToRecord
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int UpdateEmpDeptToRecord(String pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UpdateEmpDeptToRecord";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// UpdateSalaryToHistory
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int UpdateSalaryToHistory(String pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UpdateSalaryToHistory";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// UpdateSqhToHistory
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int UpdateSqhToHistory(String pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UpdateSqhToHistory";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// UpdateTurnToHistory
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int UpdateTurnToHistory(String pernbr, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UpdateTurnToHistory";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Wg_AddCardDataLog
        /// </summary>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="LogUser">LogUser</param>
        /// <param name="Operation">Operation</param>
        /// <param name="PurposeID">PurposeID</param>
        /// <param name="strDate">strDate</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Wg_AddCardDataLog(Int32 EmpGuid, String LogUser, String Operation, Byte PurposeID, DateTime strDate, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Wg_AddCardDataLog";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@LogUser", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LogUser));
            command.Parameters.Add(new SqlParameter("@Operation", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Operation));
            command.Parameters.Add(new SqlParameter("@PurposeID", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, PurposeID));
            command.Parameters.Add(new SqlParameter("@strDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, strDate));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Wg_AddEmpTurnsLog
        /// </summary>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="LogUser">LogUser</param>
        /// <param name="NewTurnID">NewTurnID</param>
        /// <param name="OldTurnID">OldTurnID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Wg_AddEmpTurnsLog(Int32 EmpGuid, String LogUser, String NewTurnID, String OldTurnID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Wg_AddEmpTurnsLog";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@LogUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LogUser));
            command.Parameters.Add(new SqlParameter("@NewTurnID", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, NewTurnID));
            command.Parameters.Add(new SqlParameter("@OldTurnID", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OldTurnID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Wg_AddSqhLog
        /// </summary>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="LogUser">LogUser</param>
        /// <param name="Operation">Operation</param>
        /// <param name="SqHDate1">SqHDate1</param>
        /// <param name="SqHID">SqHID</param>
        /// <param name="SqHTurnID">SqHTurnID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Wg_AddSqhLog(Int32 EmpGuid, String LogUser, String Operation, DateTime SqHDate1, String SqHID, String SqHTurnID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Wg_AddSqhLog";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@LogUser", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LogUser));
            command.Parameters.Add(new SqlParameter("@Operation", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Operation));
            command.Parameters.Add(new SqlParameter("@SqHDate1", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, SqHDate1));
            command.Parameters.Add(new SqlParameter("@SqHID", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHID));
            command.Parameters.Add(new SqlParameter("@SqHTurnID", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHTurnID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_AfterFinallyList
        /// </summary>
        /// <param name="pDate">pDate</param>
        /// <param name="pEmpid">pEmpid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_AfterFinallyList(String pDate, String pEmpid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_AfterFinallyList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pDate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pDate));
            command.Parameters.Add(new SqlParameter("@pEmpid", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pEmpid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_CheckUserIsThreeMonth
        /// </summary>
        /// <param name="IsTrue">IsTrue</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_CheckUserIsThreeMonth(ref Int32 IsTrue, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_CheckUserIsThreeMonth";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@IsTrue", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, IsTrue));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                IsTrue = (Int32)command.Parameters["@IsTrue"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_DeleteConCurrentPost
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_DeleteConCurrentPost(Int32 ID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_DeleteConCurrentPost";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_DeleteRptID
        /// </summary>
        /// <param name="rptid">rptid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_DeleteRptID(Int16 rptid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_DeleteRptID";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@rptid", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, rptid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_DeleteSqh
        /// </summary>
        /// <param name="LoginUser">LoginUser</param>
        /// <param name="RecordId">RecordId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_DeleteSqh(String LoginUser, Int32 RecordId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_DeleteSqh";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@LoginUser", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LoginUser));
            command.Parameters.Add(new SqlParameter("@RecordId", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, RecordId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_DeleteWGRptRunTime
        /// </summary>
        /// <param name="RI_ID">RI_ID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_DeleteWGRptRunTime(Int16 RI_ID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_DeleteWGRptRunTime";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RI_ID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, RI_ID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_DeleteWorkerDeptBills
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_DeleteWorkerDeptBills(Int32 ID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_DeleteWorkerDeptBills";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Wg_ErrCarddataRelease
        /// </summary>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="strdate">strdate</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Wg_ErrCarddataRelease(Int32 EmpGuid, DateTime strdate, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Wg_ErrCarddataRelease";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@strdate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, strdate));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Wg_FiredCarddataRelease
        /// </summary>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="strdate">strdate</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Wg_FiredCarddataRelease(Int32 EmpGuid, DateTime strdate, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Wg_FiredCarddataRelease";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@strdate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, strdate));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// wg_get_timemgr_data
        /// </summary>
        /// <param name="bDate">bDate</param>
        /// <param name="eDate">eDate</param>
        /// <param name="ExcludeDeptList">ExcludeDeptList</param>
        /// <param name="IncludeDeptList">IncludeDeptList</param>
        /// <param name="UserId">UserId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int wg_get_timemgr_data(String bDate, String eDate, String ExcludeDeptList, String IncludeDeptList, String UserId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "wg_get_timemgr_data";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@bDate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, bDate));
            command.Parameters.Add(new SqlParameter("@eDate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, eDate));
            command.Parameters.Add(new SqlParameter("@ExcludeDeptList", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ExcludeDeptList));
            command.Parameters.Add(new SqlParameter("@IncludeDeptList", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, IncludeDeptList));
            command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UserId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// wg_GetEmployeeByCode
        /// </summary>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="UserId">UserId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int wg_GetEmployeeByCode(String sEmpId, String UserId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "wg_GetEmployeeByCode";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UserId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_GetStdWorkDays
        /// </summary>
        /// <param name="beginDay">beginDay</param>
        /// <param name="endDay">endDay</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_GetStdWorkDays(DateTime beginDay, DateTime endDay, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_GetStdWorkDays";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@beginDay", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, beginDay));
            command.Parameters.Add(new SqlParameter("@endDay", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, endDay));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Wg_GetSubDeptWithTop
        /// </summary>
        /// <param name="TopDeptId">TopDeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Wg_GetSubDeptWithTop(String TopDeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Wg_GetSubDeptWithTop";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@TopDeptId", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TopDeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// wg_getYearRest
        /// </summary>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int wg_getYearRest(String sEmpId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "wg_getYearRest";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_InsertConCurrentPost
        /// </summary>
        /// <param name="C33">C33</param>
        /// <param name="C34">C34</param>
        /// <param name="C35">C35</param>
        /// <param name="C36">C36</param>
        /// <param name="C37">C37</param>
        /// <param name="C38">C38</param>
        /// <param name="C39">C39</param>
        /// <param name="C40">C40</param>
        /// <param name="C41">C41</param>
        /// <param name="C42">C42</param>
        /// <param name="C43">C43</param>
        /// <param name="C44">C44</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="Note">Note</param>
        /// <param name="OccurDate">OccurDate</param>
        /// <param name="UpdatedUser">UpdatedUser</param>
        /// <param name="WorkFlowId">WorkFlowId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_InsertConCurrentPost(String C33, String C34, String C35, String C36, String C37, String C38, String C39, String C40, String C41, String C42, String C43, String C44, String CreatedUser, Int32 EmpGuid, String Note, DateTime OccurDate, String UpdatedUser, Int32 WorkFlowId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_InsertConCurrentPost";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@C33", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C33));
            command.Parameters.Add(new SqlParameter("@C34", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C34));
            command.Parameters.Add(new SqlParameter("@C35", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C35));
            command.Parameters.Add(new SqlParameter("@C36", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C36));
            command.Parameters.Add(new SqlParameter("@C37", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C37));
            command.Parameters.Add(new SqlParameter("@C38", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C38));
            command.Parameters.Add(new SqlParameter("@C39", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C39));
            command.Parameters.Add(new SqlParameter("@C40", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C40));
            command.Parameters.Add(new SqlParameter("@C41", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C41));
            command.Parameters.Add(new SqlParameter("@C42", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C42));
            command.Parameters.Add(new SqlParameter("@C43", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C43));
            command.Parameters.Add(new SqlParameter("@C44", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C44));
            command.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CreatedUser));
            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Note));
            command.Parameters.Add(new SqlParameter("@OccurDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, OccurDate));
            command.Parameters.Add(new SqlParameter("@UpdatedUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UpdatedUser));
            command.Parameters.Add(new SqlParameter("@WorkFlowId", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkFlowId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_InsertEmpyTurnDetail
        /// </summary>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="sUserId">sUserId</param>
        /// <param name="sYearMonth">sYearMonth</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_InsertEmpyTurnDetail(String sEmpId, String sUserId, String sYearMonth, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_InsertEmpyTurnDetail";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@sUserId", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sUserId));
            command.Parameters.Add(new SqlParameter("@sYearMonth", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sYearMonth));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_InsertReportParams
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="Empid">Empid</param>
        /// <param name="Empidlist">Empidlist</param>
        /// <param name="KqBeginDate">KqBeginDate</param>
        /// <param name="KqEndDate">KqEndDate</param>
        /// <param name="RI_ID">RI_ID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="vaDeptId">vaDeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_InsertReportParams(String DeptId, String Empid, String Empidlist, DateTime KqBeginDate, DateTime KqEndDate, ref Int16 RI_ID, String UserID, String vaDeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_InsertReportParams";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@Empid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Empid));
            command.Parameters.Add(new SqlParameter("@Empidlist", SqlDbType.NVarChar, 4000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Empidlist));
            command.Parameters.Add(new SqlParameter("@KqBeginDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, KqBeginDate));
            command.Parameters.Add(new SqlParameter("@KqEndDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, KqEndDate));
            command.Parameters.Add(new SqlParameter("@RI_ID", SqlDbType.SmallInt, 0, ParameterDirection.InputOutput, false, 5, 0, "", DataRowVersion.Current, RI_ID));
            command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UserID));
            command.Parameters.Add(new SqlParameter("@vaDeptId", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vaDeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RI_ID = (Int16)command.Parameters["@RI_ID"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_InsertSqH
        /// </summary>
        /// <param name="GUID">GUID</param>
        /// <param name="SqHDate1">SqHDate1</param>
        /// <param name="SqHEmpId">SqHEmpId</param>
        /// <param name="SqHEmpname">SqHEmpname</param>
        /// <param name="SqHID">SqHID</param>
        /// <param name="SqHMemo">SqHMemo</param>
        /// <param name="SqHTurnID">SqHTurnID</param>
        /// <param name="Sqstatus">Sqstatus</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_InsertSqH(Int32 GUID, DateTime SqHDate1, String SqHEmpId, String SqHEmpname, String SqHID, String SqHMemo, String SqHTurnID, Int32 Sqstatus, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_InsertSqH";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@GUID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, GUID));
            command.Parameters.Add(new SqlParameter("@SqHDate1", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, SqHDate1));
            command.Parameters.Add(new SqlParameter("@SqHEmpId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHEmpId));
            command.Parameters.Add(new SqlParameter("@SqHEmpname", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHEmpname));
            command.Parameters.Add(new SqlParameter("@SqHID", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHID));
            command.Parameters.Add(new SqlParameter("@SqHMemo", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHMemo));
            command.Parameters.Add(new SqlParameter("@SqHTurnID", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHTurnID));
            command.Parameters.Add(new SqlParameter("@Sqstatus", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Sqstatus));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Wg_InsertSql
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <param name="LoginUser">LoginUser</param>
        /// <param name="RecordId">RecordId</param>
        /// <param name="Ret">Ret</param>
        /// <param name="SqHDate1">SqHDate1</param>
        /// <param name="SqHDate2">SqHDate2</param>
        /// <param name="SqhEmpId">SqhEmpId</param>
        /// <param name="SqHEmpName">SqHEmpName</param>
        /// <param name="SqHfalg2">SqHfalg2</param>
        /// <param name="SqHHours">SqHHours</param>
        /// <param name="SqHID">SqHID</param>
        /// <param name="SqHTime1">SqHTime1</param>
        /// <param name="SqHTime2">SqHTime2</param>
        /// <param name="SqHTurnId">SqHTurnId</param>
        /// <param name="SqStatus">SqStatus</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Wg_InsertSql(Int32 Guid, String LoginUser, ref Int32 RecordId, ref Int32 Ret, DateTime SqHDate1, DateTime SqHDate2, String SqhEmpId, String SqHEmpName, String SqHfalg2, Double SqHHours, String SqHID, String SqHTime1, String SqHTime2, String SqHTurnId, Int32 SqStatus, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Wg_InsertSql";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Guid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Guid));
            command.Parameters.Add(new SqlParameter("@LoginUser", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LoginUser));
            command.Parameters.Add(new SqlParameter("@RecordId", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, RecordId));
            command.Parameters.Add(new SqlParameter("@Ret", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Current, Ret));
            command.Parameters.Add(new SqlParameter("@SqHDate1", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, SqHDate1));
            command.Parameters.Add(new SqlParameter("@SqHDate2", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, SqHDate2));
            command.Parameters.Add(new SqlParameter("@SqhEmpId", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqhEmpId));
            command.Parameters.Add(new SqlParameter("@SqHEmpName", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHEmpName));
            command.Parameters.Add(new SqlParameter("@SqHfalg2", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHfalg2));
            command.Parameters.Add(new SqlParameter("@SqHHours", SqlDbType.Float, 0, ParameterDirection.Input, false, 53, 0, "", DataRowVersion.Current, SqHHours));
            command.Parameters.Add(new SqlParameter("@SqHID", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHID));
            command.Parameters.Add(new SqlParameter("@SqHTime1", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHTime1));
            command.Parameters.Add(new SqlParameter("@SqHTime2", SqlDbType.NVarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHTime2));
            command.Parameters.Add(new SqlParameter("@SqHTurnId", SqlDbType.NVarChar, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHTurnId));
            command.Parameters.Add(new SqlParameter("@SqStatus", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, SqStatus));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RecordId = (Int32)command.Parameters["@RecordId"].Value;
                Ret = (Int32)command.Parameters["@Ret"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Wg_InsertTurnDetail
        /// </summary>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="sEmpDeptId">sEmpDeptId</param>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="sEmpName">sEmpName</param>
        /// <param name="SYearMonth">SYearMonth</param>
        /// <param name="tblIndex">tblIndex</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Wg_InsertTurnDetail(Int32 EmpGuid, String sEmpDeptId, String sEmpId, String sEmpName, String SYearMonth, Int32 tblIndex, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Wg_InsertTurnDetail";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@sEmpDeptId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpDeptId));
            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@sEmpName", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpName));
            command.Parameters.Add(new SqlParameter("@SYearMonth", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SYearMonth));
            command.Parameters.Add(new SqlParameter("@tblIndex", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, tblIndex));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_InsertWGRptRunTime
        /// </summary>
        /// <param name="Empid">Empid</param>
        /// <param name="ExcludeDeptList">ExcludeDeptList</param>
        /// <param name="IncludeDeptList">IncludeDeptList</param>
        /// <param name="JDFlag">JDFlag</param>
        /// <param name="Kack">Kack</param>
        /// <param name="ReportName">ReportName</param>
        /// <param name="RI_ID">RI_ID</param>
        /// <param name="sDate">sDate</param>
        /// <param name="UserId">UserId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_InsertWGRptRunTime(String Empid, String ExcludeDeptList, String IncludeDeptList, Int32 JDFlag, Int32 Kack, String ReportName, ref Int16 RI_ID, DateTime sDate, String UserId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_InsertWGRptRunTime";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Empid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Empid));
            command.Parameters.Add(new SqlParameter("@ExcludeDeptList", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ExcludeDeptList));
            command.Parameters.Add(new SqlParameter("@IncludeDeptList", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, IncludeDeptList));
            command.Parameters.Add(new SqlParameter("@JDFlag", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, JDFlag));
            command.Parameters.Add(new SqlParameter("@Kack", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Kack));
            command.Parameters.Add(new SqlParameter("@ReportName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ReportName));
            command.Parameters.Add(new SqlParameter("@RI_ID", SqlDbType.SmallInt, 0, ParameterDirection.InputOutput, false, 5, 0, "", DataRowVersion.Current, RI_ID));
            command.Parameters.Add(new SqlParameter("@sDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, sDate));
            command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UserId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RI_ID = (Int16)command.Parameters["@RI_ID"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_JiaBanhours
        /// </summary>
        /// <param name="pernbr">pernbr</param>
        /// <param name="sempid">sempid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_JiaBanhours(String pernbr, String sempid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_JiaBanhours";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pernbr", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pernbr));
            command.Parameters.Add(new SqlParameter("@sempid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sempid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_K9
        /// </summary>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_K9(ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_K9";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_P_ImpToWGCarddataex
        /// </summary>
        /// <param name="DateBegin">DateBegin</param>
        /// <param name="DateEnd">DateEnd</param>
        /// <param name="sDeptId">sDeptId</param>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="sKack1">sKack1</param>
        /// <param name="sKack2">sKack2</param>
        /// <param name="WorkFlowID">WorkFlowID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_P_ImpToWGCarddataex(String DateBegin, String DateEnd, String sDeptId, String sEmpId, String sKack1, String sKack2, Int32 WorkFlowID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_P_ImpToWGCarddataex";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DateBegin", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DateBegin));
            command.Parameters.Add(new SqlParameter("@DateEnd", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DateEnd));
            command.Parameters.Add(new SqlParameter("@sDeptId", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sDeptId));
            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@sKack1", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sKack1));
            command.Parameters.Add(new SqlParameter("@sKack2", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sKack2));
            command.Parameters.Add(new SqlParameter("@WorkFlowID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkFlowID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_p_SaveWorkerDeptBills
        /// </summary>
        /// <param name="Flag">Flag</param>
        /// <param name="ID">ID</param>
        /// <param name="NewDeptId">NewDeptId</param>
        /// <param name="Note">Note</param>
        /// <param name="OldDeptId">OldDeptId</param>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="User">User</param>
        /// <param name="WorkFlowId">WorkFlowId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_p_SaveWorkerDeptBills(Int32 Flag, Int32 ID, String NewDeptId, String Note, String OldDeptId, String sEmpId, String User, Int32 WorkFlowId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_p_SaveWorkerDeptBills";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Flag));
            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ID));
            command.Parameters.Add(new SqlParameter("@NewDeptId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, NewDeptId));
            command.Parameters.Add(new SqlParameter("@Note", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Note));
            command.Parameters.Add(new SqlParameter("@OldDeptId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OldDeptId));
            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@User", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, User));
            command.Parameters.Add(new SqlParameter("@WorkFlowId", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkFlowId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_P_UpdateTables
        /// </summary>
        /// <param name="B1">B1</param>
        /// <param name="B2">B2</param>
        /// <param name="B3">B3</param>
        /// <param name="Flag">Flag</param>
        /// <param name="Jt1">Jt1</param>
        /// <param name="Jt2">Jt2</param>
        /// <param name="Jt3">Jt3</param>
        /// <param name="Kack">Kack</param>
        /// <param name="ModificationID">ModificationID</param>
        /// <param name="OccurTime">OccurTime</param>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="StrDate">StrDate</param>
        /// <param name="T11">T11</param>
        /// <param name="T12">T12</param>
        /// <param name="T21">T21</param>
        /// <param name="T22">T22</param>
        /// <param name="T31">T31</param>
        /// <param name="T32">T32</param>
        /// <param name="UpdatedUser">UpdatedUser</param>
        /// <param name="WorkFlowID">WorkFlowID</param>
        /// <param name="WorkFlowIDSave">WorkFlowIDSave</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_P_UpdateTables(String B1, String B2, String B3, String Flag, Int32 Jt1, Int32 Jt2, Int32 Jt3, String Kack, Int32 ModificationID, String OccurTime, String sEmpId, String StrDate, String T11, String T12, String T21, String T22, String T31, String T32, String UpdatedUser, Int32 WorkFlowID, Int32 WorkFlowIDSave, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_P_UpdateTables";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@B1", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B1));
            command.Parameters.Add(new SqlParameter("@B2", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B2));
            command.Parameters.Add(new SqlParameter("@B3", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B3));
            command.Parameters.Add(new SqlParameter("@Flag", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Flag));
            command.Parameters.Add(new SqlParameter("@Jt1", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Jt1));
            command.Parameters.Add(new SqlParameter("@Jt2", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Jt2));
            command.Parameters.Add(new SqlParameter("@Jt3", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Jt3));
            command.Parameters.Add(new SqlParameter("@Kack", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Kack));
            command.Parameters.Add(new SqlParameter("@ModificationID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ModificationID));
            command.Parameters.Add(new SqlParameter("@OccurTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OccurTime));
            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@StrDate", SqlDbType.VarChar, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, StrDate));
            command.Parameters.Add(new SqlParameter("@T11", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T11));
            command.Parameters.Add(new SqlParameter("@T12", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T12));
            command.Parameters.Add(new SqlParameter("@T21", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T21));
            command.Parameters.Add(new SqlParameter("@T22", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T22));
            command.Parameters.Add(new SqlParameter("@T31", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T31));
            command.Parameters.Add(new SqlParameter("@T32", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T32));
            command.Parameters.Add(new SqlParameter("@UpdatedUser", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UpdatedUser));
            command.Parameters.Add(new SqlParameter("@WorkFlowID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkFlowID));
            command.Parameters.Add(new SqlParameter("@WorkFlowIDSave", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkFlowIDSave));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// wg_p_WGConCurrentPost
        /// </summary>
        /// <param name="Duty">Duty</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int wg_p_WGConCurrentPost(String Duty, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "wg_p_WGConCurrentPost";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Duty", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Duty));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_pr_GetChildDeptName
        /// </summary>
        /// <param name="DeptId">DeptId</param>
        /// <param name="pDeptId">pDeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_pr_GetChildDeptName(String DeptId, String pDeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_pr_GetChildDeptName";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DeptId", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DeptId));
            command.Parameters.Add(new SqlParameter("@pDeptId", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pDeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_pr_GetSubMenu
        /// </summary>
        /// <param name="sModuleEx">sModuleEx</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_pr_GetSubMenu(String sModuleEx, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_pr_GetSubMenu";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@sModuleEx", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sModuleEx));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// wg_pr_insertBanciLog
        /// </summary>
        /// <param name="BanciDate">BanciDate</param>
        /// <param name="BanciType">BanciType</param>
        /// <param name="CurUserId">CurUserId</param>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="NewBanciId">NewBanciId</param>
        /// <param name="sDeptId">sDeptId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int wg_pr_insertBanciLog(DateTime BanciDate, Int16 BanciType, String CurUserId, Int32 EmpGuid, String NewBanciId, String sDeptId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "wg_pr_insertBanciLog";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@BanciDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, BanciDate));
            command.Parameters.Add(new SqlParameter("@BanciType", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, BanciType));
            command.Parameters.Add(new SqlParameter("@CurUserId", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CurUserId));
            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@NewBanciId", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, NewBanciId));
            command.Parameters.Add(new SqlParameter("@sDeptId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sDeptId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_QueryFinallyList
        /// </summary>
        /// <param name="pDate">pDate</param>
        /// <param name="pEmpid">pEmpid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_QueryFinallyList(String pDate, String pEmpid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_QueryFinallyList";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@pDate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pDate));
            command.Parameters.Add(new SqlParameter("@pEmpid", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pEmpid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_QueryFormerEmployee
        /// </summary>
        /// <param name="deptid">deptid</param>
        /// <param name="empid">empid</param>
        /// <param name="LoginID">LoginID</param>
        /// <param name="sDeptID">sDeptID</param>
        /// <param name="strDateBegin">strDateBegin</param>
        /// <param name="strDateEnd">strDateEnd</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_QueryFormerEmployee(String deptid, String empid, String LoginID, String sDeptID, String strDateBegin, String strDateEnd, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_QueryFormerEmployee";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@deptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, deptid));
            command.Parameters.Add(new SqlParameter("@empid", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, empid));
            command.Parameters.Add(new SqlParameter("@LoginID", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LoginID));
            command.Parameters.Add(new SqlParameter("@sDeptID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sDeptID));
            command.Parameters.Add(new SqlParameter("@strDateBegin", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strDateBegin));
            command.Parameters.Add(new SqlParameter("@strDateEnd", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strDateEnd));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_QWReport
        /// </summary>
        /// <param name="ri_id">ri_id</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_QWReport(Int32 ri_id, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_QWReport";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ri_id", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ri_id));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_ReturnWorkDate
        /// </summary>
        /// <param name="endTime">endTime</param>
        /// <param name="fireDate">fireDate</param>
        /// <param name="startTime">startTime</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_ReturnWorkDate(ref String endTime, String fireDate, ref String startTime, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_ReturnWorkDate";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@endTime", SqlDbType.NVarChar, 10, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, endTime));
            command.Parameters.Add(new SqlParameter("@fireDate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, fireDate));
            command.Parameters.Add(new SqlParameter("@startTime", SqlDbType.NVarChar, 10, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, startTime));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                endTime = (String)command.Parameters["@endTime"].Value;
                startTime = (String)command.Parameters["@startTime"].Value;
                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_SaveSendSqhData
        /// </summary>
        /// <param name="GUID">GUID</param>
        /// <param name="LoginUser">LoginUser</param>
        /// <param name="RecordId">RecordId</param>
        /// <param name="sEmpid">sEmpid</param>
        /// <param name="sEmpName">sEmpName</param>
        /// <param name="SqHDate1">SqHDate1</param>
        /// <param name="SqhDate2">SqhDate2</param>
        /// <param name="SqHfalg1">SqHfalg1</param>
        /// <param name="SqHfalg2">SqHfalg2</param>
        /// <param name="SqHHours">SqHHours</param>
        /// <param name="SqHID">SqHID</param>
        /// <param name="SqhKack">SqhKack</param>
        /// <param name="SqHMemo">SqHMemo</param>
        /// <param name="SqHTime1">SqHTime1</param>
        /// <param name="SqHTime2">SqHTime2</param>
        /// <param name="SqhTurnID">SqhTurnID</param>
        /// <param name="Sqstatus">Sqstatus</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_SaveSendSqhData(Int32 GUID, String LoginUser, Int32 RecordId, String sEmpid, String sEmpName, DateTime SqHDate1, DateTime SqhDate2, String SqHfalg1, String SqHfalg2, Double SqHHours, String SqHID, String SqhKack, String SqHMemo, String SqHTime1, String SqHTime2, String SqhTurnID, Int32 Sqstatus, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_SaveSendSqhData";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@GUID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, GUID));
            command.Parameters.Add(new SqlParameter("@LoginUser", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LoginUser));
            command.Parameters.Add(new SqlParameter("@RecordId", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, RecordId));
            command.Parameters.Add(new SqlParameter("@sEmpid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpid));
            command.Parameters.Add(new SqlParameter("@sEmpName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpName));
            command.Parameters.Add(new SqlParameter("@SqHDate1", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, SqHDate1));
            command.Parameters.Add(new SqlParameter("@SqhDate2", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, SqhDate2));
            command.Parameters.Add(new SqlParameter("@SqHfalg1", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHfalg1));
            command.Parameters.Add(new SqlParameter("@SqHfalg2", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHfalg2));
            command.Parameters.Add(new SqlParameter("@SqHHours", SqlDbType.Float, 0, ParameterDirection.Input, false, 53, 0, "", DataRowVersion.Current, SqHHours));
            command.Parameters.Add(new SqlParameter("@SqHID", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHID));
            command.Parameters.Add(new SqlParameter("@SqhKack", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqhKack));
            command.Parameters.Add(new SqlParameter("@SqHMemo", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHMemo));
            command.Parameters.Add(new SqlParameter("@SqHTime1", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHTime1));
            command.Parameters.Add(new SqlParameter("@SqHTime2", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHTime2));
            command.Parameters.Add(new SqlParameter("@SqhTurnID", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqhTurnID));
            command.Parameters.Add(new SqlParameter("@Sqstatus", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Sqstatus));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_SaveSqhData
        /// </summary>
        /// <param name="Bangchi_name">Bangchi_name</param>
        /// <param name="GUID">GUID</param>
        /// <param name="LoginUser">LoginUser</param>
        /// <param name="RecordId">RecordId</param>
        /// <param name="sEmpid">sEmpid</param>
        /// <param name="sEmpName">sEmpName</param>
        /// <param name="SqHDate1">SqHDate1</param>
        /// <param name="SqHDate2">SqHDate2</param>
        /// <param name="SqHfalg1">SqHfalg1</param>
        /// <param name="SqHfalg2">SqHfalg2</param>
        /// <param name="SqHHours">SqHHours</param>
        /// <param name="SqHID">SqHID</param>
        /// <param name="SqhKack">SqhKack</param>
        /// <param name="SqHMemo">SqHMemo</param>
        /// <param name="SqHTime1">SqHTime1</param>
        /// <param name="SqHTime2">SqHTime2</param>
        /// <param name="Sqstatus">Sqstatus</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_SaveSqhData(String Bangchi_name, Int32 GUID, String LoginUser, Int32 RecordId, String sEmpid, String sEmpName, DateTime SqHDate1, DateTime SqHDate2, String SqHfalg1, String SqHfalg2, Double SqHHours, String SqHID, String SqhKack, String SqHMemo, String SqHTime1, String SqHTime2, Int32 Sqstatus, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_SaveSqhData";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Bangchi_name", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Bangchi_name));
            command.Parameters.Add(new SqlParameter("@GUID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, GUID));
            command.Parameters.Add(new SqlParameter("@LoginUser", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LoginUser));
            command.Parameters.Add(new SqlParameter("@RecordId", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, RecordId));
            command.Parameters.Add(new SqlParameter("@sEmpid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpid));
            command.Parameters.Add(new SqlParameter("@sEmpName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpName));
            command.Parameters.Add(new SqlParameter("@SqHDate1", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, SqHDate1));
            command.Parameters.Add(new SqlParameter("@SqHDate2", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, SqHDate2));
            command.Parameters.Add(new SqlParameter("@SqHfalg1", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHfalg1));
            command.Parameters.Add(new SqlParameter("@SqHfalg2", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHfalg2));
            command.Parameters.Add(new SqlParameter("@SqHHours", SqlDbType.Float, 0, ParameterDirection.Input, false, 53, 0, "", DataRowVersion.Current, SqHHours));
            command.Parameters.Add(new SqlParameter("@SqHID", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHID));
            command.Parameters.Add(new SqlParameter("@SqhKack", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqhKack));
            command.Parameters.Add(new SqlParameter("@SqHMemo", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHMemo));
            command.Parameters.Add(new SqlParameter("@SqHTime1", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHTime1));
            command.Parameters.Add(new SqlParameter("@SqHTime2", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHTime2));
            command.Parameters.Add(new SqlParameter("@Sqstatus", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Sqstatus));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_SaveUpdateCarddataexLog
        /// </summary>
        /// <param name="B1">B1</param>
        /// <param name="B2">B2</param>
        /// <param name="CreatedDate">CreatedDate</param>
        /// <param name="createdUser">createdUser</param>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="Flag">Flag</param>
        /// <param name="ID">ID</param>
        /// <param name="Jt1">Jt1</param>
        /// <param name="Jt2">Jt2</param>
        /// <param name="Jt3">Jt3</param>
        /// <param name="Kack">Kack</param>
        /// <param name="LogDate">LogDate</param>
        /// <param name="Loguser">Loguser</param>
        /// <param name="ModificationID">ModificationID</param>
        /// <param name="OccurTime">OccurTime</param>
        /// <param name="Operation">Operation</param>
        /// <param name="StrDate">StrDate</param>
        /// <param name="T11">T11</param>
        /// <param name="T12">T12</param>
        /// <param name="T21">T21</param>
        /// <param name="T22">T22</param>
        /// <param name="T31">T31</param>
        /// <param name="T32">T32</param>
        /// <param name="UpdatedDate">UpdatedDate</param>
        /// <param name="UpdatedUser">UpdatedUser</param>
        /// <param name="WorkFlowID">WorkFlowID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_SaveUpdateCarddataexLog(String B1, String B2, DateTime CreatedDate, String createdUser, Int32 EmpGuid, String Flag, Int32 ID, Byte Jt1, Byte Jt2, Byte Jt3, String Kack, DateTime LogDate, String Loguser, Int16 ModificationID, String OccurTime, String Operation, DateTime StrDate, String T11, String T12, String T21, String T22, String T31, String T32, DateTime UpdatedDate, String UpdatedUser, Int32 WorkFlowID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_SaveUpdateCarddataexLog";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@B1", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B1));
            command.Parameters.Add(new SqlParameter("@B2", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B2));
            command.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, CreatedDate));
            command.Parameters.Add(new SqlParameter("@createdUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, createdUser));
            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Flag));
            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ID));
            command.Parameters.Add(new SqlParameter("@Jt1", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt1));
            command.Parameters.Add(new SqlParameter("@Jt2", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt2));
            command.Parameters.Add(new SqlParameter("@Jt3", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt3));
            command.Parameters.Add(new SqlParameter("@Kack", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Kack));
            command.Parameters.Add(new SqlParameter("@LogDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, LogDate));
            command.Parameters.Add(new SqlParameter("@Loguser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Loguser));
            command.Parameters.Add(new SqlParameter("@ModificationID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, ModificationID));
            command.Parameters.Add(new SqlParameter("@OccurTime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OccurTime));
            command.Parameters.Add(new SqlParameter("@Operation", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Operation));
            command.Parameters.Add(new SqlParameter("@StrDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, StrDate));
            command.Parameters.Add(new SqlParameter("@T11", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T11));
            command.Parameters.Add(new SqlParameter("@T12", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T12));
            command.Parameters.Add(new SqlParameter("@T21", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T21));
            command.Parameters.Add(new SqlParameter("@T22", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T22));
            command.Parameters.Add(new SqlParameter("@T31", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T31));
            command.Parameters.Add(new SqlParameter("@T32", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T32));
            command.Parameters.Add(new SqlParameter("@UpdatedDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, UpdatedDate));
            command.Parameters.Add(new SqlParameter("@UpdatedUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UpdatedUser));
            command.Parameters.Add(new SqlParameter("@WorkFlowID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkFlowID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_SaveWorkerDeptBills
        /// </summary>
        /// <param name="CreatedDate">CreatedDate</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="ID">ID</param>
        /// <param name="MoveDate">MoveDate</param>
        /// <param name="NewDeptId">NewDeptId</param>
        /// <param name="Note">Note</param>
        /// <param name="OldDeptId">OldDeptId</param>
        /// <param name="UpdatedDate">UpdatedDate</param>
        /// <param name="UpdatedUser">UpdatedUser</param>
        /// <param name="WorkFlowID">WorkFlowID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_SaveWorkerDeptBills(DateTime CreatedDate, String CreatedUser, Int32 EmpGuid, Int32 ID, DateTime MoveDate, String NewDeptId, String Note, String OldDeptId, DateTime UpdatedDate, String UpdatedUser, Int32 WorkFlowID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_SaveWorkerDeptBills";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, CreatedDate));
            command.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CreatedUser));
            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ID));
            command.Parameters.Add(new SqlParameter("@MoveDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, MoveDate));
            command.Parameters.Add(new SqlParameter("@NewDeptId", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, NewDeptId));
            command.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Note));
            command.Parameters.Add(new SqlParameter("@OldDeptId", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OldDeptId));
            command.Parameters.Add(new SqlParameter("@UpdatedDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, UpdatedDate));
            command.Parameters.Add(new SqlParameter("@UpdatedUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UpdatedUser));
            command.Parameters.Add(new SqlParameter("@WorkFlowID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkFlowID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_SpView_OvertimeSqh
        /// </summary>
        /// <param name="dateBegin">dateBegin</param>
        /// <param name="dateEnd">dateEnd</param>
        /// <param name="deptid">deptid</param>
        /// <param name="empid">empid</param>
        /// <param name="LoginID">LoginID</param>
        /// <param name="sDeptID">sDeptID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_SpView_OvertimeSqh(DateTime dateBegin, DateTime dateEnd, String deptid, String empid, String LoginID, String sDeptID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_SpView_OvertimeSqh";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@dateBegin", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, dateBegin));
            command.Parameters.Add(new SqlParameter("@dateEnd", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, dateEnd));
            command.Parameters.Add(new SqlParameter("@deptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, deptid));
            command.Parameters.Add(new SqlParameter("@empid", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, empid));
            command.Parameters.Add(new SqlParameter("@LoginID", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LoginID));
            command.Parameters.Add(new SqlParameter("@sDeptID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sDeptID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_SpView_QueryAllSqh
        /// </summary>
        /// <param name="deptid">deptid</param>
        /// <param name="empid">empid</param>
        /// <param name="Fired">Fired</param>
        /// <param name="LoginID">LoginID</param>
        /// <param name="sDeptID">sDeptID</param>
        /// <param name="sqhid">sqhid</param>
        /// <param name="strDateBegin">strDateBegin</param>
        /// <param name="strDateEnd">strDateEnd</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_SpView_QueryAllSqh(String deptid, String empid, String Fired, String LoginID, String sDeptID, String sqhid, String strDateBegin, String strDateEnd, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_SpView_QueryAllSqh";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@deptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, deptid));
            command.Parameters.Add(new SqlParameter("@empid", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, empid));
            command.Parameters.Add(new SqlParameter("@Fired", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Fired));
            command.Parameters.Add(new SqlParameter("@LoginID", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LoginID));
            command.Parameters.Add(new SqlParameter("@sDeptID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sDeptID));
            command.Parameters.Add(new SqlParameter("@sqhid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sqhid));
            command.Parameters.Add(new SqlParameter("@strDateBegin", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strDateBegin));
            command.Parameters.Add(new SqlParameter("@strDateEnd", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strDateEnd));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_SpView_QuerySqh
        /// </summary>
        /// <param name="deptid">deptid</param>
        /// <param name="empid">empid</param>
        /// <param name="Fired">Fired</param>
        /// <param name="LoginID">LoginID</param>
        /// <param name="sDeptID">sDeptID</param>
        /// <param name="sqhid">sqhid</param>
        /// <param name="strDateBegin">strDateBegin</param>
        /// <param name="strDateEnd">strDateEnd</param>
        /// <param name="WorkflowID">WorkflowID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_SpView_QuerySqh(String deptid, String empid, String Fired, String LoginID, String sDeptID, String sqhid, String strDateBegin, String strDateEnd, Int32 WorkflowID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_SpView_QuerySqh";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@deptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, deptid));
            command.Parameters.Add(new SqlParameter("@empid", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, empid));
            command.Parameters.Add(new SqlParameter("@Fired", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Fired));
            command.Parameters.Add(new SqlParameter("@LoginID", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LoginID));
            command.Parameters.Add(new SqlParameter("@sDeptID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sDeptID));
            command.Parameters.Add(new SqlParameter("@sqhid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sqhid));
            command.Parameters.Add(new SqlParameter("@strDateBegin", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strDateBegin));
            command.Parameters.Add(new SqlParameter("@strDateEnd", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strDateEnd));
            command.Parameters.Add(new SqlParameter("@WorkflowID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkflowID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_SpView_QueryUnRightData
        /// </summary>
        /// <param name="dateBegin">dateBegin</param>
        /// <param name="dateEnd">dateEnd</param>
        /// <param name="deptid">deptid</param>
        /// <param name="empid">empid</param>
        /// <param name="kack">kack</param>
        /// <param name="LoginID">LoginID</param>
        /// <param name="sDeptID">sDeptID</param>
        /// <param name="WorkflowID">WorkflowID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_SpView_QueryUnRightData(DateTime dateBegin, DateTime dateEnd, String deptid, String empid, String kack, String LoginID, String sDeptID, Int32 WorkflowID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_SpView_QueryUnRightData";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@dateBegin", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, dateBegin));
            command.Parameters.Add(new SqlParameter("@dateEnd", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, dateEnd));
            command.Parameters.Add(new SqlParameter("@deptid", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, deptid));
            command.Parameters.Add(new SqlParameter("@empid", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, empid));
            command.Parameters.Add(new SqlParameter("@kack", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, kack));
            command.Parameters.Add(new SqlParameter("@LoginID", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LoginID));
            command.Parameters.Add(new SqlParameter("@sDeptID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sDeptID));
            command.Parameters.Add(new SqlParameter("@WorkflowID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkflowID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_SpView_QueryWorkerDeptBills
        /// </summary>
        /// <param name="deptid">deptid</param>
        /// <param name="empid">empid</param>
        /// <param name="LoginID">LoginID</param>
        /// <param name="sDeptID">sDeptID</param>
        /// <param name="strDateBegin">strDateBegin</param>
        /// <param name="strDateEnd">strDateEnd</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_SpView_QueryWorkerDeptBills(String deptid, String empid, String LoginID, String sDeptID, String strDateBegin, String strDateEnd, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_SpView_QueryWorkerDeptBills";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@deptid", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, deptid));
            command.Parameters.Add(new SqlParameter("@empid", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, empid));
            command.Parameters.Add(new SqlParameter("@LoginID", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, LoginID));
            command.Parameters.Add(new SqlParameter("@sDeptID", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sDeptID));
            command.Parameters.Add(new SqlParameter("@strDateBegin", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strDateBegin));
            command.Parameters.Add(new SqlParameter("@strDateEnd", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, strDateEnd));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Wg_SqhRelease
        /// </summary>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="recordId">recordId</param>
        /// <param name="SqhDate1">SqhDate1</param>
        /// <param name="SqHId">SqHId</param>
        /// <param name="SqhTurnId">SqhTurnId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Wg_SqhRelease(Int32 EmpGuid, Int32 recordId, DateTime SqhDate1, String SqHId, String SqhTurnId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Wg_SqhRelease";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, recordId));
            command.Parameters.Add(new SqlParameter("@SqhDate1", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, SqhDate1));
            command.Parameters.Add(new SqlParameter("@SqHId", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHId));
            command.Parameters.Add(new SqlParameter("@SqhTurnId", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqhTurnId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_TMCReport
        /// </summary>
        /// <param name="bdate">bdate</param>
        /// <param name="bdate1">bdate1</param>
        /// <param name="Deptid">Deptid</param>
        /// <param name="edate">edate</param>
        /// <param name="edate1">edate1</param>
        /// <param name="vaDeptid">vaDeptid</param>
        /// <param name="vdDeptid">vdDeptid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_TMCReport(String bdate, String bdate1, String Deptid, String edate, String edate1, String vaDeptid, String vdDeptid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_TMCReport";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@bdate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, bdate));
            command.Parameters.Add(new SqlParameter("@bdate1", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, bdate1));
            command.Parameters.Add(new SqlParameter("@Deptid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Deptid));
            command.Parameters.Add(new SqlParameter("@edate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, edate));
            command.Parameters.Add(new SqlParameter("@edate1", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, edate1));
            command.Parameters.Add(new SqlParameter("@vaDeptid", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vaDeptid));
            command.Parameters.Add(new SqlParameter("@vdDeptid", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vdDeptid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_TMReport
        /// </summary>
        /// <param name="bdate">bdate</param>
        /// <param name="Deptid">Deptid</param>
        /// <param name="edate">edate</param>
        /// <param name="vaDeptid">vaDeptid</param>
        /// <param name="vdDeptid">vdDeptid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_TMReport(String bdate, String Deptid, String edate, String vaDeptid, String vdDeptid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_TMReport";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@bdate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, bdate));
            command.Parameters.Add(new SqlParameter("@Deptid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Deptid));
            command.Parameters.Add(new SqlParameter("@edate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, edate));
            command.Parameters.Add(new SqlParameter("@vaDeptid", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vaDeptid));
            command.Parameters.Add(new SqlParameter("@vdDeptid", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vdDeptid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_TMReport1
        /// </summary>
        /// <param name="bdate">bdate</param>
        /// <param name="Deptid">Deptid</param>
        /// <param name="edate">edate</param>
        /// <param name="vaDeptid">vaDeptid</param>
        /// <param name="vdDeptid">vdDeptid</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_TMReport1(String bdate, String Deptid, String edate, String vaDeptid, String vdDeptid, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_TMReport1";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@bdate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, bdate));
            command.Parameters.Add(new SqlParameter("@Deptid", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Deptid));
            command.Parameters.Add(new SqlParameter("@edate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, edate));
            command.Parameters.Add(new SqlParameter("@vaDeptid", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vaDeptid));
            command.Parameters.Add(new SqlParameter("@vdDeptid", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, vdDeptid));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_TurnRelease
        /// </summary>
        /// <param name="bcId">bcId</param>
        /// <param name="bcType">bcType</param>
        /// <param name="empGuid">empGuid</param>
        /// <param name="turnDate">turnDate</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_TurnRelease(String bcId, Int32 bcType, Int32 empGuid, DateTime turnDate, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_TurnRelease";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@bcId", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, bcId));
            command.Parameters.Add(new SqlParameter("@bcType", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, bcType));
            command.Parameters.Add(new SqlParameter("@empGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, empGuid));
            command.Parameters.Add(new SqlParameter("@turnDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, turnDate));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_UpdateCarddataEx
        /// </summary>
        /// <param name="B1">B1</param>
        /// <param name="B2">B2</param>
        /// <param name="DirtyFlag">DirtyFlag</param>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="Flag">Flag</param>
        /// <param name="ID">ID</param>
        /// <param name="Jt1">Jt1</param>
        /// <param name="Jt2">Jt2</param>
        /// <param name="Jt3">Jt3</param>
        /// <param name="Kack">Kack</param>
        /// <param name="ModificationID">ModificationID</param>
        /// <param name="OccurTime">OccurTime</param>
        /// <param name="StrDate">StrDate</param>
        /// <param name="T11">T11</param>
        /// <param name="T12">T12</param>
        /// <param name="T21">T21</param>
        /// <param name="T22">T22</param>
        /// <param name="T31">T31</param>
        /// <param name="T32">T32</param>
        /// <param name="UpdatedUser">UpdatedUser</param>
        /// <param name="WorkFlowID">WorkFlowID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_UpdateCarddataEx(String B1, String B2, String DirtyFlag, Int32 EmpGuid, String Flag, Int32 ID, Byte Jt1, Byte Jt2, Byte Jt3, String Kack, Int16 ModificationID, String OccurTime, DateTime StrDate, String T11, String T12, String T21, String T22, String T31, String T32, String UpdatedUser, Int32 WorkFlowID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_UpdateCarddataEx";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@B1", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B1));
            command.Parameters.Add(new SqlParameter("@B2", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B2));
            command.Parameters.Add(new SqlParameter("@DirtyFlag", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DirtyFlag));
            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Flag));
            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ID));
            command.Parameters.Add(new SqlParameter("@Jt1", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt1));
            command.Parameters.Add(new SqlParameter("@Jt2", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt2));
            command.Parameters.Add(new SqlParameter("@Jt3", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt3));
            command.Parameters.Add(new SqlParameter("@Kack", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Kack));
            command.Parameters.Add(new SqlParameter("@ModificationID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, ModificationID));
            command.Parameters.Add(new SqlParameter("@OccurTime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OccurTime));
            command.Parameters.Add(new SqlParameter("@StrDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, StrDate));
            command.Parameters.Add(new SqlParameter("@T11", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T11));
            command.Parameters.Add(new SqlParameter("@T12", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T12));
            command.Parameters.Add(new SqlParameter("@T21", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T21));
            command.Parameters.Add(new SqlParameter("@T22", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T22));
            command.Parameters.Add(new SqlParameter("@T31", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T31));
            command.Parameters.Add(new SqlParameter("@T32", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T32));
            command.Parameters.Add(new SqlParameter("@UpdatedUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UpdatedUser));
            command.Parameters.Add(new SqlParameter("@WorkFlowID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkFlowID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_UpdateConCurrentPost
        /// </summary>
        /// <param name="C33">C33</param>
        /// <param name="C34">C34</param>
        /// <param name="C35">C35</param>
        /// <param name="C36">C36</param>
        /// <param name="C37">C37</param>
        /// <param name="C38">C38</param>
        /// <param name="C39">C39</param>
        /// <param name="C40">C40</param>
        /// <param name="C41">C41</param>
        /// <param name="C42">C42</param>
        /// <param name="C43">C43</param>
        /// <param name="C44">C44</param>
        /// <param name="EmpGuid">EmpGuid</param>
        /// <param name="ID">ID</param>
        /// <param name="Note">Note</param>
        /// <param name="OccurDate">OccurDate</param>
        /// <param name="UpdatedUser">UpdatedUser</param>
        /// <param name="WorkFlowId">WorkFlowId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_UpdateConCurrentPost(String C33, String C34, String C35, String C36, String C37, String C38, String C39, String C40, String C41, String C42, String C43, String C44, Int32 EmpGuid, Int32 ID, String Note, DateTime OccurDate, String UpdatedUser, Int32 WorkFlowId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_UpdateConCurrentPost";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@C33", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C33));
            command.Parameters.Add(new SqlParameter("@C34", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C34));
            command.Parameters.Add(new SqlParameter("@C35", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C35));
            command.Parameters.Add(new SqlParameter("@C36", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C36));
            command.Parameters.Add(new SqlParameter("@C37", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C37));
            command.Parameters.Add(new SqlParameter("@C38", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C38));
            command.Parameters.Add(new SqlParameter("@C39", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C39));
            command.Parameters.Add(new SqlParameter("@C40", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C40));
            command.Parameters.Add(new SqlParameter("@C41", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C41));
            command.Parameters.Add(new SqlParameter("@C42", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C42));
            command.Parameters.Add(new SqlParameter("@C43", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C43));
            command.Parameters.Add(new SqlParameter("@C44", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, C44));
            command.Parameters.Add(new SqlParameter("@EmpGuid", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, EmpGuid));
            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ID));
            command.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Note));
            command.Parameters.Add(new SqlParameter("@OccurDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, OccurDate));
            command.Parameters.Add(new SqlParameter("@UpdatedUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UpdatedUser));
            command.Parameters.Add(new SqlParameter("@WorkFlowId", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkFlowId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_UpdateEmpTurns
        /// </summary>
        /// <param name="sEmpId">sEmpId</param>
        /// <param name="TurnId">TurnId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_UpdateEmpTurns(String sEmpId, String TurnId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_UpdateEmpTurns";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@sEmpId", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, sEmpId));
            command.Parameters.Add(new SqlParameter("@TurnId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, TurnId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_UpdateFire
        /// </summary>
        /// <param name="B1">B1</param>
        /// <param name="B2">B2</param>
        /// <param name="B3">B3</param>
        /// <param name="CreatedDate">CreatedDate</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <param name="Flag">Flag</param>
        /// <param name="ID">ID</param>
        /// <param name="Jt1">Jt1</param>
        /// <param name="Jt2">Jt2</param>
        /// <param name="Jt3">Jt3</param>
        /// <param name="Kack">Kack</param>
        /// <param name="ModificationID">ModificationID</param>
        /// <param name="OccurTime">OccurTime</param>
        /// <param name="StrDate">StrDate</param>
        /// <param name="T11">T11</param>
        /// <param name="T12">T12</param>
        /// <param name="T21">T21</param>
        /// <param name="T22">T22</param>
        /// <param name="T31">T31</param>
        /// <param name="T32">T32</param>
        /// <param name="tag">tag</param>
        /// <param name="UpdatedDate">UpdatedDate</param>
        /// <param name="UpdatedUser">UpdatedUser</param>
        /// <param name="WorkFlowID">WorkFlowID</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_UpdateFire(String B1, String B2, String B3, DateTime CreatedDate, String CreatedUser, String Flag, Int32 ID, Byte Jt1, Byte Jt2, Byte Jt3, String Kack, Int16 ModificationID, String OccurTime, DateTime StrDate, String T11, String T12, String T21, String T22, String T31, String T32, Int32 tag, DateTime UpdatedDate, String UpdatedUser, Int32 WorkFlowID, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_UpdateFire";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@B1", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B1));
            command.Parameters.Add(new SqlParameter("@B2", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B2));
            command.Parameters.Add(new SqlParameter("@B3", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B3));
            command.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, CreatedDate));
            command.Parameters.Add(new SqlParameter("@CreatedUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, CreatedUser));
            command.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Flag));
            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ID));
            command.Parameters.Add(new SqlParameter("@Jt1", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt1));
            command.Parameters.Add(new SqlParameter("@Jt2", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt2));
            command.Parameters.Add(new SqlParameter("@Jt3", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt3));
            command.Parameters.Add(new SqlParameter("@Kack", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Kack));
            command.Parameters.Add(new SqlParameter("@ModificationID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Current, ModificationID));
            command.Parameters.Add(new SqlParameter("@OccurTime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OccurTime));
            command.Parameters.Add(new SqlParameter("@StrDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, StrDate));
            command.Parameters.Add(new SqlParameter("@T11", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T11));
            command.Parameters.Add(new SqlParameter("@T12", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T12));
            command.Parameters.Add(new SqlParameter("@T21", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T21));
            command.Parameters.Add(new SqlParameter("@T22", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T22));
            command.Parameters.Add(new SqlParameter("@T31", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T31));
            command.Parameters.Add(new SqlParameter("@T32", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T32));
            command.Parameters.Add(new SqlParameter("@tag", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, tag));
            command.Parameters.Add(new SqlParameter("@UpdatedDate", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, UpdatedDate));
            command.Parameters.Add(new SqlParameter("@UpdatedUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UpdatedUser));
            command.Parameters.Add(new SqlParameter("@WorkFlowID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkFlowID));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// Wg_UpdateFiredCarddata
        /// </summary>
        /// <param name="B1">B1</param>
        /// <param name="B2">B2</param>
        /// <param name="DirtyFlag">DirtyFlag</param>
        /// <param name="Flag">Flag</param>
        /// <param name="ID">ID</param>
        /// <param name="Jt1">Jt1</param>
        /// <param name="Jt2">Jt2</param>
        /// <param name="Jt3">Jt3</param>
        /// <param name="Kack">Kack</param>
        /// <param name="ModificationID">ModificationID</param>
        /// <param name="OccurTime">OccurTime</param>
        /// <param name="T11">T11</param>
        /// <param name="T12">T12</param>
        /// <param name="T21">T21</param>
        /// <param name="T22">T22</param>
        /// <param name="T31">T31</param>
        /// <param name="T32">T32</param>
        /// <param name="UpdatedUser">UpdatedUser</param>
        /// <param name="WorkFlowId">WorkFlowId</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int Wg_UpdateFiredCarddata(String B1, String B2, String DirtyFlag, String Flag, Int32 ID, Byte Jt1, Byte Jt2, Byte Jt3, String Kack, Int32 ModificationID, String OccurTime, String T11, String T12, String T21, String T22, String T31, String T32, String UpdatedUser, Int32 WorkFlowId, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Wg_UpdateFiredCarddata";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@B1", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B1));
            command.Parameters.Add(new SqlParameter("@B2", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, B2));
            command.Parameters.Add(new SqlParameter("@DirtyFlag", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, DirtyFlag));
            command.Parameters.Add(new SqlParameter("@Flag", SqlDbType.VarChar, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Flag));
            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ID));
            command.Parameters.Add(new SqlParameter("@Jt1", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt1));
            command.Parameters.Add(new SqlParameter("@Jt2", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt2));
            command.Parameters.Add(new SqlParameter("@Jt3", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 3, 0, "", DataRowVersion.Current, Jt3));
            command.Parameters.Add(new SqlParameter("@Kack", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, Kack));
            command.Parameters.Add(new SqlParameter("@ModificationID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, ModificationID));
            command.Parameters.Add(new SqlParameter("@OccurTime", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, OccurTime));
            command.Parameters.Add(new SqlParameter("@T11", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T11));
            command.Parameters.Add(new SqlParameter("@T12", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T12));
            command.Parameters.Add(new SqlParameter("@T21", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T21));
            command.Parameters.Add(new SqlParameter("@T22", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T22));
            command.Parameters.Add(new SqlParameter("@T31", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T31));
            command.Parameters.Add(new SqlParameter("@T32", SqlDbType.VarChar, 6, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, T32));
            command.Parameters.Add(new SqlParameter("@UpdatedUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, UpdatedUser));
            command.Parameters.Add(new SqlParameter("@WorkFlowId", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, WorkFlowId));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }

        /// <summary>
        /// WG_UpdateSqH
        /// </summary>
        /// <param name="GUID">GUID</param>
        /// <param name="RecordId">RecordId</param>
        /// <param name="SqHDate1">SqHDate1</param>
        /// <param name="SqHEmpId">SqHEmpId</param>
        /// <param name="SqHEmpname">SqHEmpname</param>
        /// <param name="SqHMemo">SqHMemo</param>
        /// <param name="SqHTurnID">SqHTurnID</param>
        /// <param name="Sqstatus">Sqstatus</param>
        /// <param name="RETURN_VALUE">RETURN_VALUE</param>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static int WG_UpdateSqH(Int32 GUID, Int32 RecordId, DateTime SqHDate1, String SqHEmpId, String SqHEmpname, String SqHMemo, String SqHTurnID, Int32 Sqstatus, ref int RETURN_VALUE, string connectionString)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "WG_UpdateSqH";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@GUID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, GUID));
            command.Parameters.Add(new SqlParameter("@RecordId", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, RecordId));
            command.Parameters.Add(new SqlParameter("@SqHDate1", SqlDbType.SmallDateTime, 0, ParameterDirection.Input, false, 16, 0, "", DataRowVersion.Current, SqHDate1));
            command.Parameters.Add(new SqlParameter("@SqHEmpId", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHEmpId));
            command.Parameters.Add(new SqlParameter("@SqHEmpname", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHEmpname));
            command.Parameters.Add(new SqlParameter("@SqHMemo", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHMemo));
            command.Parameters.Add(new SqlParameter("@SqHTurnID", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, SqHTurnID));
            command.Parameters.Add(new SqlParameter("@Sqstatus", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Current, Sqstatus));
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            int retVal = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(System.Guid.NewGuid().ToString().Substring(1, 32));

                retVal = ExecuteNonQuery(command, connection, transaction);

                RETURN_VALUE = (int)command.Parameters["@RETURN_VALUE"].Value;
            }

            return retVal;
        }



        #region CommonExecuteCommand
        public static int ExecuteNonQuery(SqlCommand command, SqlConnection connection)
        {
            return ExecuteNonQuery(command, connection, null);
        }

        public static int ExecuteNonQuery(SqlCommand command, SqlConnection connection, SqlTransaction transaction)
        {
            bool mustCloseConnection = false;

            #region Check
            if (connection == null) throw new ArgumentNullException("connection");

            if (command == null) throw new ArgumentNullException("command");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }
            #endregion

            command.Connection = connection;

            command.Transaction = transaction;

            int retval;

            if (transaction == null)
            {
                retval = command.ExecuteNonQuery();
            }
            else
            {
                try
                {
                    retval = command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

            if (mustCloseConnection)
                connection.Close();

            return retval;
        }

        public static SqlDataReader ExecuteReader(SqlCommand command, SqlConnection connection)
        {
            return ExecuteReader(command, connection, null);
        }

        public static SqlDataReader ExecuteReader(SqlCommand command, SqlConnection connection, SqlTransaction transaction)
        {
            bool mustCloseConnection = false;

            #region Check
            if (connection == null) throw new ArgumentNullException("connection");

            if (command == null) throw new ArgumentNullException("command");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }
            #endregion

            command.Connection = connection;

            command.Transaction = transaction;

            SqlDataReader retval;

            if (transaction == null)
            {
                retval = command.ExecuteReader();
            }
            else
            {
                try
                {
                    retval = command.ExecuteReader();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

            if (mustCloseConnection)
                connection.Close();

            return retval;
        }

        public static object ExecuteScalar(SqlCommand command, SqlConnection connection)
        {
            return ExecuteScalar(command, connection, null);
        }

        public static object ExecuteScalar(SqlCommand command, SqlConnection connection, SqlTransaction transaction)
        {
            bool mustCloseConnection = false;

            #region Check
            if (connection == null) throw new ArgumentNullException("connection");

            if (command == null) throw new ArgumentNullException("command");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }
            #endregion

            command.Connection = connection;

            command.Transaction = transaction;

            object retval = new object();

            if (transaction == null)
            {
                retval = command.ExecuteScalar();
            }
            else
            {
                try
                {
                    retval = command.ExecuteScalar();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

            if (mustCloseConnection)
                connection.Close();

            return retval;
        }

        public static DataSet ExecuteDataset(SqlCommand command, SqlConnection connection)
        {
            return ExecuteDataset(command, connection, null);
        }

        public static DataSet ExecuteDataset(SqlCommand command, SqlConnection connection, SqlTransaction transaction)
        {
            bool mustCloseConnection = false;

            #region Check
            if (connection == null) throw new ArgumentNullException("connection");

            if (command == null) throw new ArgumentNullException("command");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }
            #endregion

            command.Connection = connection;

            command.Transaction = transaction;

            using (SqlDataAdapter da = new SqlDataAdapter(command))
            {
                DataSet retval = new DataSet();

                if (transaction == null)
                {
                    da.Fill(retval);
                }
                else
                {
                    try
                    {
                        da.Fill(retval);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }

                if (mustCloseConnection)
                    connection.Close();

                return retval;
            }
        }

        public static DataTable ExecuteDataTable(SqlCommand command, SqlConnection connection)
        {
            return ExecuteDataset(command, connection).Tables[0];
        }

        public static DataTable ExecuteDataTable(SqlCommand command, SqlConnection connection, SqlTransaction transaction)
        {
            return ExecuteDataset(command, connection, transaction).Tables[0];
        }
        #endregion
    }
}
