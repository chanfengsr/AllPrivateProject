using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace SmartTools
{
    // 存储过程调用助手。
    public class StoreProcedure
    {
        // 存储过程名称。
        private string _name;
        // 数据库连接字符串。
        private string _conStr;

        // 构造函数
        // sprocName: 存储过程名称；
        // conStr: 数据库连接字符串。
        public StoreProcedure(string sprocName, string conStr)
        {
            _conStr = conStr;
            _name = sprocName;
        }

        //  执行存储过程，不返回值。
        //  paraValues: 参数值列表。
        //  return: void
        public void ExecuteNoQuery(params object[] paraValues)
        {
            using (SqlConnection con = new SqlConnection(_conStr))
            {
                SqlCommand comm = new SqlCommand(_name, con);
                comm.CommandType = CommandType.StoredProcedure;

                AddInParaValues(comm, paraValues);

                con.Open();
                comm.ExecuteNonQuery();
                con.Close();
            }
        }

        // 执行存储过程返回一个表。
        // paraValues: 参数值列表。
        // return: DataTable
        public DataTable ExecuteDataTable(params object[] paraValues)
        {
            SqlCommand comm = new SqlCommand(_name, new SqlConnection(_conStr));
            comm.CommandType = CommandType.StoredProcedure;
            AddInParaValues(comm, paraValues);

            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }

        // 执行存储过程，返回SqlDataReader对象，
        // 在SqlDataReader对象关闭的同时，数据库连接自动关闭。
        // paraValues: 要传递给给存储过程的参数值类表。
        // return: SqlDataReader
        public SqlDataReader ExecuteDataReader(params object[] paraValues)
        {
            SqlConnection con = new SqlConnection(_conStr);
            SqlCommand comm = new SqlCommand(_name, con);
            comm.CommandType = CommandType.StoredProcedure;
            AddInParaValues(comm, paraValues);
            con.Open();
            return comm.ExecuteReader(CommandBehavior.CloseConnection);
        }

        // 获取存储过程的参数列表。
        private ArrayList GetParas()
        {
            SqlCommand comm = new SqlCommand("dbo.sp_sproc_columns_90",
                       new SqlConnection(_conStr));
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@procedure_name", (object)_name);
            SqlDataAdapter sda = new SqlDataAdapter(comm);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            ArrayList al = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                al.Add(dt.Rows[i][3].ToString());
            }
            return al;
        }

        // 为 SqlCommand 添加参数及赋值。
        private void AddInParaValues(SqlCommand comm, params object[] paraValues)
        {
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            comm.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            if (paraValues != null)
            {
                ArrayList al = GetParas();
                for (int i = 0; i < paraValues.Length; i++)
                {
                    comm.Parameters.AddWithValue(al[i + 1].ToString(),
                         paraValues[i]);
                }
            }
        }
    }
}
