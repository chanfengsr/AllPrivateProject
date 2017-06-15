// ==================================================================================
//
//	文件名(File Name):		
//
//	功能描述(Description):	修改微软的类，通用SQL执行类
//
//	数据表(Tables):			
//
//	作者(Author):			王煜
//
//	日期(Create Date):		2012-4-16
//
//	修改日期(Alter Date):	
//  2017-3-16   修改 TestConnectString 方法，线程检测，只等待 5 秒钟
//	备注(Remark):			
//
// ==================================================================================
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace StockExplore
{
    public class SQLHelper
    {
        #region private utility methods & constructors

        // Since this class provides only static methods, make the default constructor private to prevent 
        // instances from being created with "new SqlHelper()"
        private SQLHelper() { }

        /// <summary>
        /// This method is used to attach array of SqlParameters to a SqlCommand.
        /// 
        /// This method will assign a value of DbNull to any parameter with a direction of
        /// InputOutput and a value of null.  
        /// 
        /// This behavior will prevent default values from being used, but
        /// this will be the less common case than an intended pure output parameter (derived as InputOutput)
        /// where the user provided no input value.
        /// </summary>
        /// <param name="command">The command to which the parameters will be added</param>
        /// <param name="commandParameters">An array of SqlParameters to be added to command</param>
        public static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// This method assigns dataRow column values to an array of SqlParameters
        /// </summary>
        /// <param name="commandParameters">Array of SqlParameters to be assigned values</param>
        /// <param name="dataRow">The dataRow used to hold the stored procedure's parameter values</param>
        public static void AssignParameterValues(SqlParameter[] commandParameters, DataRow dataRow)
        {
            if ((commandParameters == null) || (dataRow == null))
            {
                // Do nothing if we get no data
                return;
            }

            int i = 0;
            // Set the parameters values
            foreach (SqlParameter commandParameter in commandParameters)
            {
                // Check the parameter name
                if (commandParameter.ParameterName == null ||
                    commandParameter.ParameterName.Length <= 1)
                    throw new Exception(
                        string.Format(
                            "Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.",
                            i, commandParameter.ParameterName));
                if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) != -1)
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
                i++;
            }
        }

        /// <summary>
        /// This method assigns an array of values to an array of SqlParameters
        /// </summary>
        /// <param name="commandParameters">Array of SqlParameters to be assigned values</param>
        /// <param name="parameterValues">Array of objects holding the values to be assigned</param>
        public static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                // Do nothing if we get no data
                return;
            }

            // We must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            // Iterate through the SqlParameters, assigning the values from the corresponding position in the 
            // value array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                // If the current array value derives from IDbDataParameter, then assign its Value property
                if (parameterValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
                    if (paramInstance.Value == null)
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = paramInstance.Value;
                    }
                }
                else if (parameterValues[i] == null)
                {
                    commandParameters[i].Value = DBNull.Value;
                }
                else
                {
                    commandParameters[i].Value = parameterValues[i];
                }
            }
        }

        /// <summary>
        /// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
        /// to the provided command
        /// </summary>
        /// <param name="command">The SqlCommand to be prepared</param>
        /// <param name="connection">A valid SqlConnection, on which to execute this command</param>
        /// <param name="transaction">A valid SqlTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="mustCloseConnection"><c>true</c> if the connection was opened by the method, otherwose is false.</param>
        public static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // Associate the connection with the command
            command.Connection = connection;

            // Set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            // If we were provided a transaction, assign it
            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            // Set the command type
            command.CommandType = commandType;

            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }
        #endregion private utility methods & constructors

        #region SQLExecute
        #region ExecuteNonQuery
        /// <summary>执行一条无返回值的SQL命令
        /// </summary>
        /// <param name="command">SqlCommand</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlCommand command, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
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
                if (transaction.Connection == null)
                    throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

                command.Transaction = transaction;
            }
            #endregion

            command.Connection = connection;

            if (transaction != null)
                command.Transaction = transaction;

            int retval;

            try
            {
                if (transaction == null)
                {
                    retval = command.ExecuteNonQuery();
                }
                else
                {
                    try
                    {
                        retval = command.ExecuteNonQuery();

                        if (operateTransaction)
                            transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (operateTransaction)
                            transaction.Rollback();

                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }

            return retval;
        }

        /// <summary>执行一组无返回值的SQL命令执行
        /// </summary>
        /// <param name="commands">SqlCommand数组</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlCommand[] commands, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
        {
            int retVal = 0;
            bool mustCloseConnection = false;

            #region Check
            if (connection == null) throw new ArgumentNullException("connection");

            if (commands == null) throw new ArgumentNullException("command");

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
                if (transaction.Connection == null)
                    throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            #endregion

            try
            {
                foreach (SqlCommand cmd in commands)
                {
                    if (transaction != null)
                        cmd.Transaction = transaction;

                    retVal += ExecuteNonQuery(cmd, connection, null, false);
                }

                if (transaction != null && operateTransaction)
                    transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null && operateTransaction)
                    transaction.Rollback();

                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }

            return retVal;
        }

        /// <summary>执行一组无返回值的SQL命令执行
        /// </summary>
        /// <param name="commands">SqlCommand数组</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlCommand[] commands, SqlTransaction transaction, bool operateTransaction = false)
        {
            int retVal = 0;

            #region Check
            if (transaction == null) throw new ArgumentNullException("transaction");

            if (transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            #endregion Check

            try
            {
                foreach (SqlCommand cmd in commands)
                {
                    cmd.Transaction = transaction;
                    retVal += ExecuteNonQuery(cmd, transaction.Connection, null, false);
                }

                if (transaction != null && operateTransaction)
                    transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null && operateTransaction)
                    transaction.Rollback();

                throw ex;
            }

            return retVal;
        }

        /// <summary>执行一条无返回值的SQL命令
        /// </summary>
        /// <param name="commandText">CommandText</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="commandParameters">commandParameters</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] commandParameters, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
        {
            try
            {
                if (commandText.Trim() == string.Empty)
                    return 0;

                using (SqlCommand cmd = new SqlCommand(commandText))
                {
                    cmd.CommandType = commandType;
                    AttachParameters(cmd, commandParameters);

                    return ExecuteNonQuery(cmd, connection, transaction, operateTransaction);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>执行一条无返回值的SQL命令
        /// </summary>
        /// <param name="commandText">CommandText</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string commandText, CommandType commandType, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
        {
            return ExecuteNonQuery(commandText, commandType, null, connection, transaction, operateTransaction);
        }

        /// <summary>执行一组无返回值的SQL命令
        /// </summary>
        /// <param name="commandTexts">CommandText</param>
        /// <param name="commandTypes">CommandType</param>
        /// <param name="commandParameterss">commandParameters</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string[] commandTexts, CommandType[] commandTypes, SqlParameter[][] commandParameterss, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
        {
            int retVal = 0;
            bool mustCloseConnection = false;

            #region Check
            if (connection == null) throw new ArgumentNullException("connection");

            if (commandParameterss != null)
            {
                if (commandTexts.Length != commandTypes.Length ||
                    commandTexts.Length != commandParameterss.Length ||
                    commandTexts.Length == 0)
                    throw new ArgumentException("commandTexts、commandTypes、commandParameterss 数组数量必须相同！");
            }
            else
            {
                if (commandTexts.Length != commandTypes.Length || commandTexts.Length == 0)
                    throw new ArgumentException("commandTexts 与 commandTypes 数组数量必须相同！");
            }

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
                if (transaction.Connection == null)
                    throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }
            #endregion

            try
            {
                for (int i = 0; i < commandTexts.Length; i++)
                {
                    if (commandTexts[i].Trim() == string.Empty)
                        continue;

                    SqlCommand cmd = new SqlCommand(commandTexts[i]);
                    cmd.CommandType = commandTypes[i];
                    if (commandParameterss != null)
                        AttachParameters(cmd, commandParameterss[i]);
                    if (transaction != null)
                        cmd.Transaction = transaction;

                    retVal += ExecuteNonQuery(cmd, connection, null, false);
                }

                if (transaction != null && operateTransaction)
                    transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null && operateTransaction)
                    transaction.Rollback();

                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }

            return retVal;
        }

        /// <summary>执行一组无返回值的SQL命令
        /// </summary>
        /// <param name="commandTexts">CommandText数组</param>
        /// <param name="commandTypes">CommandType数组</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string[] commandTexts, CommandType[] commandTypes, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
        {
            return ExecuteNonQuery(commandTexts, commandTypes, null, connection, transaction, operateTransaction);
        }


        /// <summary>执行一组无返回值的SQL命令执行（自动开启事务）
        /// </summary>
        /// <param name="commands">SqlCommand数组</param>
        /// <param name="connection">SqlConnection</param>
        /// <returns></returns>
        public static int ExecuteNonQueryAutoTrans(SqlCommand[] commands, SqlConnection connection)
        {
            int retVal = 0;
            bool mustCloseConnection = false;

            #region Check
            if (connection == null) throw new ArgumentNullException("connection");

            if (commands == null) throw new ArgumentNullException("command");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            #endregion

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                foreach (SqlCommand cmd in commands)
                {
                    cmd.Transaction = transaction;

                    retVal += ExecuteNonQuery(cmd, connection, null);
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }

            return retVal;
        }

        /// <summary>执行一组无返回值的SQL命令（自动开启事务）
        /// </summary>
        /// <param name="commandTexts">CommandText</param>
        /// <param name="commandTypes">CommandType</param>
        /// <param name="commandParameterss">commandParameters</param>
        /// <param name="connection">SqlConnection</param>
        /// <returns></returns>
        public static int ExecuteNonQueryAutoTrans(string[] commandTexts, CommandType[] commandTypes, SqlParameter[][] commandParameterss, SqlConnection connection)
        {
            int retVal = 0;
            bool mustCloseConnection = false;

            #region Check
            if (connection == null) throw new ArgumentNullException("connection");

            if (commandParameterss != null)
            {
                if (commandTexts.Length != commandTypes.Length ||
                    commandTexts.Length != commandParameterss.Length ||
                    commandTexts.Length == 0)
                    throw new ArgumentException("commandTexts、commandTypes、commandParameterss 数组数量必须相同！");
            }
            else
            {
                if (commandTexts.Length != commandTypes.Length || commandTexts.Length == 0)
                    throw new ArgumentException("commandTexts 与 commandTypes 数组数量必须相同！");
            }

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            #endregion

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                for (int i = 0; i < commandTexts.Length; i++)
                {
                    if (commandTexts[i].Trim() == string.Empty)
                        continue;

                    SqlCommand cmd = new SqlCommand(commandTexts[i]);
                    cmd.CommandType = commandTypes[i];
                    if (commandParameterss != null)
                        AttachParameters(cmd, commandParameterss[i]);

                    cmd.Transaction = transaction;

                    retVal += ExecuteNonQuery(cmd, connection, null);
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }

            return retVal;
        }

        /// <summary>执行一组无返回值的SQL命令（自动开启事务）
        /// </summary>
        /// <param name="commandTexts">CommandText数组</param>
        /// <param name="commandTypes">CommandType数组</param>
        /// <param name="connection">SqlConnection</param>
        /// <returns></returns>
        public static int ExecuteNonQueryAutoTrans(string[] commandTexts, CommandType[] commandTypes, SqlConnection connection)
        {
            return ExecuteNonQueryAutoTrans(commandTexts, commandTypes, null, connection);
        }
        #endregion ExecuteNonQuery

        #region ExecuteReader
        /// <summary>
        /// 返回SqlDataReader
        /// </summary>
        /// <param name="command">SqlCommand</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(SqlCommand command, SqlConnection connection, SqlTransaction transaction = null)
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

            try
            {
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }

            return retval;
        }

        /// <summary>
        /// 返回SqlDataReader
        /// </summary>
        /// <param name="commandText">T-SQL command</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, SqlConnection connection, SqlTransaction transaction = null)
        {
            return ExecuteReader(commandText, commandType, null, connection, transaction);
        }

        /// <summary>
        /// 返回SqlDataReader
        /// </summary>
        /// <param name="commandText">T-SQL command</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="commandParameters">命令参数数组</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, SqlParameter[] commandParameters, SqlConnection connection, SqlTransaction transaction = null)
        {
            using (SqlCommand cmd = new SqlCommand(commandText))
            {
                cmd.CommandType = commandType;
                AttachParameters(cmd, commandParameters);

                return ExecuteReader(cmd, connection, transaction);
            }
        }
        #endregion ExecuteReader

        #region ExecuteScalar
        /// <summary>
        /// 返回一行一列的数据
        /// </summary>
        /// <param name="command">SqlCommand</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <returns></returns>
        public static object ExecuteScalar(SqlCommand command, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
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

            try
            {
                if (transaction == null)
                {
                    retval = command.ExecuteScalar();
                }
                else
                {
                    try
                    {
                        retval = command.ExecuteScalar();

                        if (operateTransaction)
                            transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (operateTransaction)
                            transaction.Rollback();

                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }

            return retval;
        }

        /// <summary>
        /// 返回一行一列的数据
        /// </summary>
        /// <param name="commandText">T-SQL command</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="commandParameters">命令参数数组</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <returns></returns>
        public static object ExecuteScalar(string commandText, CommandType commandType, SqlParameter[] commandParameters, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
        {
            using (SqlCommand cmd = new SqlCommand(commandText))
            {
                cmd.CommandType = commandType;
                AttachParameters(cmd, commandParameters);

                return ExecuteScalar(cmd, connection, transaction, operateTransaction);
            }
        }

        /// <summary>
        /// 返回一行一列的数据
        /// </summary>
        /// <param name="commandText">T-SQL command</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <returns></returns>
        public static object ExecuteScalar(string commandText, CommandType commandType, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
        {
            return ExecuteScalar(commandText, commandType, null, connection, transaction, operateTransaction);
        }
        #endregion ExecuteScalar

        #region ExecuteDataset
        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="command">SqlCommand</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <param name="relatePhysicalTable">是否对应物理表</param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(SqlCommand command, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false, bool relatePhysicalTable = false)
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
                if (transaction.Connection == null)
                    throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

                command.Transaction = transaction;
            }
            #endregion

            command.Connection = connection;

            command.Transaction = transaction;


            using (SqlDataAdapter da = new SqlDataAdapter(command))
            {
                DataSet retval = new DataSet();
                try
                {
                    if (relatePhysicalTable)
                    {
                        using (SqlCommandBuilder sqlcmdbd = new SqlCommandBuilder(da))
                        {
                            sqlcmdbd.ConflictOption = ConflictOption.CompareAllSearchableValues;

                            da.InsertCommand = sqlcmdbd.GetInsertCommand();
                            da.UpdateCommand = sqlcmdbd.GetUpdateCommand();
                            da.DeleteCommand = sqlcmdbd.GetDeleteCommand();
                        }
                    }

                    if (transaction == null)
                    {
                        da.Fill(retval);
                    }
                    else
                    {
                        try
                        {
                            da.Fill(retval);

                            if (operateTransaction)
                                transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            if (operateTransaction)
                                transaction.Rollback();

                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (mustCloseConnection)
                        connection.Close();
                }

                return retval;
            }
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="commandText">T-SQL command</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <param name="relatePhysicalTable">是否对应物理表</param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string commandText, CommandType commandType, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false, bool relatePhysicalTable = false)
        {
            return ExecuteDataset(commandText, commandType, null, connection, transaction, operateTransaction, relatePhysicalTable);
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="commandText">T-SQL command</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="commandParameters">命令参数数组</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <param name="relatePhysicalTable">是否对应物理表</param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string commandText, CommandType commandType, SqlParameter[] commandParameters, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false, bool relatePhysicalTable = false)
        {
            using (SqlCommand cmd = new SqlCommand(commandText))
            {
                cmd.CommandType = commandType;
                AttachParameters(cmd, commandParameters);

                return ExecuteDataset(cmd, connection, transaction, operateTransaction, relatePhysicalTable);
            }
        }
        #endregion ExecuteDataset

        #region ExecuteDataTable
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="command">SqlCommand</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <param name="relatePhysicalTable">是否对应物理表</param>
        /// <param name="tableName">TableName</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(SqlCommand command, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false, bool relatePhysicalTable = false, string tableName = "")
        {
            DataTable retVal = ExecuteDataset(command, connection, transaction, operateTransaction, relatePhysicalTable).Tables[0];
            if (tableName != "") retVal.TableName = tableName;

            return retVal;
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="commandText">T-SQL command</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <param name="relatePhysicalTable">是否对应物理表</param>
        /// <param name="tableName">TableName</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false, bool relatePhysicalTable = false, string tableName = "")
        {
            return ExecuteDataTable(commandText, commandType, null, connection, transaction, operateTransaction, relatePhysicalTable, tableName);
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="commandText">T-SQL command</param>
        /// <param name="commandType">CommandType</param>
        /// <param name="commandParameters">命令参数数组</param>
        /// <param name="connection">SqlConnection</param>
        /// <param name="transaction">SqlTransaction</param>
        /// <param name="operateTransaction">是否操作事务的提交与回滚</param>
        /// <param name="relatePhysicalTable">是否对应物理表</param>
        /// <param name="tableName">TableName</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType, SqlParameter[] commandParameters, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false, bool relatePhysicalTable = false, string tableName = "")
        {
            using (SqlCommand cmd = new SqlCommand(commandText))
            {
                cmd.CommandType = commandType;
                AttachParameters(cmd, commandParameters);

                return ExecuteDataTable(cmd, connection, transaction, operateTransaction, relatePhysicalTable, tableName);
            }
        }
        #endregion ExecuteDataTable
        #endregion

        #region 拿到数据库物理表结构
        /// <summary>
        /// 拿到数据库物理表结构
        /// </summary>
        /// <param name="tableName">TableName</param>
        /// <param name="connection">Connection</param>
        /// <returns></returns>
        public static DataTable GetSchemaTable(string tableName, SqlConnection connection)
        {
            DataTable retVal = null;
            bool mustCloseConnection = false;

            #region Check
            if (connection == null) throw new ArgumentNullException("connection");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            #endregion

            try
            {
                string strSQL = string.Format("Select Top 0 * From [{0}]", tableName);
                SqlCommand sqlCmd = new SqlCommand(strSQL, connection);
                SqlDataReader da = sqlCmd.ExecuteReader(CommandBehavior.SchemaOnly);
                if (da != null)
                {
                    retVal = da.GetSchemaTable();
                }
            }
            catch (Exception) { }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }

            return retVal;
        }
        #endregion

        #region 测试数据库连接字符串
        /// <summary>测试数据库连接字符串</summary>
        public static bool TestConnectString(string connectionString)
        {
            Task<bool> t1 = Task.Factory.StartNew(() =>
            #region MainTask

            {
                SqlConnection cnn = new SqlConnection(connectionString);

                try
                {
                    cnn.Open();
                    cnn.Close();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    if (cnn != null)
                    {
                        if (cnn.State != System.Data.ConnectionState.Closed)
                        {
                            cnn.Close();
                        }
                        cnn.Dispose();
                    }
                }
            });

            #endregion MainTask

            Task<bool> t2 = Task.Factory.StartNew(() =>
            #region 延时监测进程，超过5秒则报失败
            {
                Thread.Sleep(5000);
                return false;
            });
            # endregion 延时监测进程，超过5秒则报失败

            Task.WaitAny(t1, t2);
            
            return t1.Status == TaskStatus.RanToCompletion && t1.Result;
        }
        #endregion 测试数据库连接字符串

        #region 保存数据表所做的更改
        #region 保存数据表所做的更改（不带事务）
        /// <summary>保存数据表所做的更改（不带事务）
        /// </summary>
        /// <param name="connection">SqlConnection</param>
        /// <param name="commandText">SQL查询语句</param>
        /// <param name="dt">DataGridView的DataSource的DataTable</param>
        public static void SaveChanges(SqlConnection connection, string commandText, DataTable dt)
        {
            bool mustCloseConnection = false;

            #region Check
            if (connection == null) throw new ArgumentNullException("connection");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            #endregion

            try
            {
                using (SqlCommand sqlcmd = new SqlCommand(commandText, connection))
                {
                    using (SqlDataAdapter sqladp = new SqlDataAdapter(sqlcmd))
                    {
                        using (SqlCommandBuilder sqlcmdbd = new SqlCommandBuilder(sqladp))
                        {
                            sqlcmdbd.ConflictOption = ConflictOption.CompareAllSearchableValues;

                            sqladp.InsertCommand = sqlcmdbd.GetInsertCommand();
                            sqladp.UpdateCommand = sqlcmdbd.GetUpdateCommand();
                            sqladp.DeleteCommand = sqlcmdbd.GetDeleteCommand();

                            sqladp.Update(dt);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }
        }
        #endregion

        #region 保存数据表所做的更改
        /// <summary>保存数据表所做的更改（带事务）
        /// </summary>
        /// <param name="connection">SqlConnection</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="commandText">需要更新的表的SQL语句</param>
        /// <param name="dt">需要更新的DataTable</param>
        public static void SaveChanges(SqlConnection connection, SqlTransaction trans, string commandText, DataTable dt)
        {
            bool mustCloseConnection = false;

            #region Check
            if (connection == null) throw new ArgumentNullException("connection");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            #endregion

            try
            {
                using (SqlCommand sqlcmd = new SqlCommand(commandText, connection, trans))
                {
                    using (SqlDataAdapter sqladp = new SqlDataAdapter(sqlcmd))
                    {
                        //sqladp.InsertCommand.Transaction = trans;
                        using (SqlCommandBuilder sqlcmdbd = new SqlCommandBuilder(sqladp))
                        {
                            sqlcmdbd.ConflictOption = ConflictOption.CompareRowVersion;

                            sqladp.InsertCommand = sqlcmdbd.GetInsertCommand();
                            sqladp.UpdateCommand = sqlcmdbd.GetUpdateCommand();
                            sqladp.DeleteCommand = sqlcmdbd.GetDeleteCommand();

                            sqladp.Update(dt);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }
        }
        #endregion 保存数据表所做的更改

        #region 保存多数据表所做的更改
        /// <summary>保存多数据表所做的更改
        /// </summary>
        /// <param name="connection">SqlConnection</param>
        /// <param name="commandTexts">需要更新的表的SQL语句集</param>
        /// <param name="dts">需要更新的DataTable集</param>
        public static void SaveChanges(SqlConnection connection, string[] commandTexts, DataTable[] dts)
        {
            bool mustCloseConnection = false;

            #region Check
            if (commandTexts.Length != dts.Length || commandTexts.Length == 0)
                throw new ArgumentException("commandTexts 与 dts 数组数量必须相同！");

            if (connection == null) throw new ArgumentNullException("connection");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            #endregion Check

            //SqlTransaction trans = connection.BeginTransaction();

            try
            {
                for (int i = 0; i < commandTexts.Length; i++)
                {
                    SaveChanges(connection, commandTexts[i], dts[i]);
                }

                //trans.Commit();
            }
            catch (Exception ex)
            {
                //trans.Rollback();
                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }
        }

        /// <summary>保存多数据表所做的更改
        /// </summary>
        /// <param name="connection">SqlConnection</param>
        /// <param name="trans">SqlTransaction</param>
        /// <param name="commandTexts">需要更新的表的SQL语句集</param>
        /// <param name="dts">需要更新的DataTable集</param>
        public static void SaveChanges(SqlConnection connection, SqlTransaction trans, string[] commandTexts, DataTable[] dts)
        {
            bool mustCloseConnection = false;

            #region Check
            if (commandTexts.Length != dts.Length || commandTexts.Length == 0)
                throw new ArgumentException("commandTexts 与 dts 数组数量必须相同！");

            if (connection == null) throw new ArgumentNullException("connection");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            #endregion Check

            try
            {
                for (int i = 0; i < commandTexts.Length; i++)
                    SaveChanges(connection, trans, commandTexts[i], dts[i]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }
        }
        #endregion 保存多数据表所做的更改
        #endregion

        #region Exists
        /// <summary>判断执行是否有返回
        /// </summary>
        public static bool Exists(SqlCommand command, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
        {
            object obj = ExecuteScalar(command, connection, transaction, operateTransaction);

            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                cmdresult = 0;
            else
                cmdresult = int.Parse(obj.ToString()); //也可能=0

            if (cmdresult == 0)
                return false;
            else
                return true;
        }

        /// <summary>判断执行是否有返回
        /// </summary>
        public static bool Exists(string commandText, CommandType commandType, SqlParameter[] commandParameters, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
        {
            using (SqlCommand cmd = new SqlCommand(commandText))
            {
                cmd.CommandType = commandType;
                AttachParameters(cmd, commandParameters);

                return Exists(cmd, connection, transaction, operateTransaction);
            }
        }

        /// <summary>判断执行是否有返回
        /// </summary>
        public static bool Exists(string commandText, CommandType commandType, SqlConnection connection, SqlTransaction transaction = null, bool operateTransaction = false)
        {
            return Exists(commandText, commandType, null, connection, transaction, operateTransaction);
        }
        #endregion Exists

        public static int ZeroValue { get { return 0; } }
    }

    /// <summary>
    /// SqlHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
    /// ability to discover parameters for stored procedures at run-time.
    /// </summary>
    public sealed class SqlHelperParameterCache
    {
        #region private methods, variables, and constructors

        //Since this class provides only static methods, make the default constructor private to prevent 
        //instances from being created with "new SqlHelperParameterCache()"
        private SqlHelperParameterCache() { }

        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Resolve at run time the appropriate set of SqlParameters for a stored procedure
        /// </summary>
        /// <param name="connection">A valid SqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">Whether or not to include their return value parameter</param>
        /// <returns>The parameter array discovered.</returns>
        private static SqlParameter[] DiscoverSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            SqlCommand cmd = new SqlCommand(spName, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlCommandBuilder.DeriveParameters(cmd);
            connection.Close();

            if (!includeReturnValueParameter)
            {
                cmd.Parameters.RemoveAt(0);
            }

            SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];

            cmd.Parameters.CopyTo(discoveredParameters, 0);

            // Init the parameters with a DBNull value
            foreach (SqlParameter discoveredParameter in discoveredParameters)
            {
                discoveredParameter.Value = DBNull.Value;
            }
            return discoveredParameters;
        }

        /// <summary>
        /// Deep copy of cached SqlParameter array
        /// </summary>
        /// <param name="originalParameters"></param>
        /// <returns></returns>
        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        #endregion private methods, variables, and constructors

        #region caching functions

        /// <summary>
        /// Add parameter array to the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters to be cached</param>
        public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = connectionString + ":" + commandText;

            paramCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve a parameter array from the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An array of SqlParamters</returns>
        public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = connectionString + ":" + commandText;

            SqlParameter[] cachedParameters = paramCache[hashKey] as SqlParameter[];
            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        #endregion caching functions

        #region Parameter Discovery Functions

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <returns>An array of SqlParameters</returns>
        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            return GetSpParameterSet(connectionString, spName, false);
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of SqlParameters</returns>
        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">A valid SqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <returns>An array of SqlParameters</returns>
        internal static SqlParameter[] GetSpParameterSet(SqlConnection connection, string spName)
        {
            return GetSpParameterSet(connection, spName, false);
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connection">A valid SqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of SqlParameters</returns>
        internal static SqlParameter[] GetSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            using (SqlConnection clonedConnection = (SqlConnection)((ICloneable)connection).Clone())
            {
                return GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <param name="connection">A valid SqlConnection object</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>An array of SqlParameters</returns>
        private static SqlParameter[] GetSpParameterSetInternal(SqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

            string hashKey = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");

            SqlParameter[] cachedParameters;

            cachedParameters = paramCache[hashKey] as SqlParameter[];
            if (cachedParameters == null)
            {
                SqlParameter[] spParameters = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
                paramCache[hashKey] = spParameters;
                cachedParameters = spParameters;
            }

            return CloneParameters(cachedParameters);
        }

        #endregion Parameter Discovery Functions

    }
}