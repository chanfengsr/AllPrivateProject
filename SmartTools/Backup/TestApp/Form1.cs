using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using Model;
using ICSharpCode.TextEditor.Document;

namespace SmartTools
{
    public partial class Form1 : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txte1.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
        }

        private void Action1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcnn = new SqlConnection("Data Source=.;Persist Security Info=True;User ID=sa;Password=;Initial Catalog=TestForSmartTools;");
            SqlConnection sqlcnn2 = new SqlConnection("Data Source=.;Persist Security Info=True;User ID=sa;Password=;Initial Catalog=TestForSmartTools;");
            OleDbConnection olecnn = new OleDbConnection();

            //olecnn.GetOleDbSchemaTable(
            //sqlcnn.GetSchema( 

            SqlCommand sqlcmd = new SqlCommand("select TOP 1 * from TABLE1", sqlcnn2);
            SqlCommand sqlcmd2 = new SqlCommand("CustOrderHist2", sqlcnn);
            sqlcmd2.CommandType = CommandType.StoredProcedure;
            sqlcmd2.Parameters.Add(new SqlParameter("@CustomerID", "AROUT"));

            sqlcnn.Open();
            sqlcnn2.Open();

            SqlDataReader sqldr = sqlcmd.ExecuteReader(CommandBehavior.KeyInfo);
            DataTable stb = sqldr.GetSchemaTable();
            sqldr.Close();
            /*
                        SqlCommand sqlcmd3 = new SqlCommand("CustOrderHist2", sqlcnn);
                        sqlcmd3.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(sqlcmd3); 
            */
            DataTable stb2;
            DataTable stb3;
            stb2 = sqlcnn2.GetSchema("ProcedureParameters", new string[] { "Northwind", null, "CustOrderHist3", null });
            //stb2 = sqlcnn2.GetSchema("Restrictions");
            /*
                        stb3 = sqlcnn2.GetSchema("Columns", new string[] { "Northwind", "dbo", "TABLE1", null });

                        foreach (DataColumn dc in stb.Columns)
                        {
                            Console.WriteLine(dc.DataType.ToString());
                        }
             */

            dataGridView1.DataSource = stb2;
            dataGridView2.DataSource = stb;

            sqlcnn.Close();
            sqlcnn2.Close();


            //SqlConnection sqlcnn3 = new SqlConnection(@"Data Source=WANGY\SQLEXPRESS;Initial Catalog=temp;Integrated Security=True");
            //SqlCommand sqlcmd3 = new SqlCommand("select TOP 0 * from Table_3", sqlcnn3);
            //sqlcnn3.Open();
            //SqlDataReader sqldr3 = sqlcmd3.ExecuteReader(CommandBehavior.KeyInfo);
            //DataTable stb4 = sqldr3.GetSchemaTable();
            //sqldr3.Close();
            //dataGridView3.DataSource = stb4;
            //sqlcnn3.Close();
        }

        private void Action2_Click(object sender, EventArgs e)
        {
            string gVarStr = "";
            string PropStr = "";
            string newLine = "";
            StringBuilder sb = new StringBuilder();
            DataTable tb = (dataGridView2.DataSource as DataTable);

            foreach (DataColumn dc in tb.Columns)
            {
                string sType = dc.DataType.ToString().Replace("System.", "");

                if (sType != "String" && sType != "Type")
                    sType = sType + "?";

                /*
                                string sPropStr = textBox2.Text.Replace("{0}", sType);
                                sPropStr = sPropStr.Replace("{1}", dc.ColumnName);

                                gVarStr = gVarStr + string.Format("        private {0} _{1};", sType, dc.ColumnName) + Environment.NewLine;
                                PropStr = PropStr + sPropStr + Environment.NewLine;

            
                               */
                string strDefault = "";

                switch (sType)
                {
                    case "String":
                        strDefault = "\"\"";
                        break;
                    case "Boolean":
                        strDefault = "false";
                        break;
                    case "Type":
                        strDefault = "typeof(int)";
                        break;
                    //case  "Byte":
                    //    sType = "Byte[]";
                    //    strDefault = "new Byte[] { 0}";
                    //    break;
                    default:
                        strDefault = "(" + sType + ")0";
                        break;
                }

                strDefault = "null";
                newLine = "tableField." + dc.ColumnName + " = " + "(schemaDataRow[\"" + dc.ColumnName + "\"] is DBNull) ? " + strDefault + " : " + "(" + sType + ")schemaDataRow[\"" + dc.ColumnName + "\"];";
                newLine = "tableField." + dc.ColumnName + " = " + "(" + sType + ")schemaDataRow[\"" + dc.ColumnName + "\"];";
                sb.AppendLine(newLine);

            }

            txte1.Text = gVarStr + PropStr + sb.ToString();
        }

        private void Action3_Click(object sender, EventArgs e)
        {
            string strResult = "";

            foreach (DataRow dr in (dataGridView3.DataSource as DataTable).Rows)
            {
                strResult = strResult + "case \"" + dr["DataTypeName"].ToString().Trim() + "\":" + Environment.NewLine;
                strResult = strResult + "retVal = \"" + dr["ProviderSpecificDataType"].ToString().Trim() + "\"; break;" + Environment.NewLine;
            }

            textBox2.Text = strResult;
        }
    }
}