using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace SmartTools
{
    // �洢���̵������֡�
    public class StoreProcedure
    {
        // �洢�������ơ�
        private string _name;
        // ���ݿ������ַ�����
        private string _conStr;

        // ���캯��
        // sprocName: �洢�������ƣ�
        // conStr: ���ݿ������ַ�����
        public StoreProcedure(string sprocName, string conStr)
        {
            _conStr = conStr;
            _name = sprocName;
        }

        //  ִ�д洢���̣�������ֵ��
        //  paraValues: ����ֵ�б�
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

        // ִ�д洢���̷���һ����
        // paraValues: ����ֵ�б�
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

        // ִ�д洢���̣�����SqlDataReader����
        // ��SqlDataReader����رյ�ͬʱ�����ݿ������Զ��رա�
        // paraValues: Ҫ���ݸ����洢���̵Ĳ���ֵ���
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

        // ��ȡ�洢���̵Ĳ����б�
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

        // Ϊ SqlCommand ��Ӳ�������ֵ��
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
