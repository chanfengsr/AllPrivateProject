using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Model;
using Codes;

namespace SmartTools
{
    public partial class Main : Form
    {
        public static DockPanel dp;

        public Main()
        {
            InitializeComponent();
            dp = this.dockPanel1;
        }

        private void 获得框架CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show(dp);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void createDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Database db = new Database("Data Source=.;Persist Security Info=True;User ID=sa;Password=;Initial Catalog=TestForSmartTools;");
            db.GetAllTable();
            db.GetAllView();
            db.GetAllStoreProcedure();
            //retVal = db.AddTable("TABLE1");
            //retVal = db.AddView("Invoices");
            //retVal = db.AddStoreProcedure("CustOrderHist3");



            MessageBox.Show(db.StoreProcedures[0].CreateCmdText);
        }

        private void 测试存储过程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database db = new Database("Data Source=.;Persist Security Info=True;User ID=sa;Password=sa;Initial Catalog=RewardLife;");//TestForSmartTools HR_JC
            //db.AddStoreProcedure("CustOrderHist2");
            //db.AddStoreProcedure("CustOrderHist3");
            db.GetAllStoreProcedure();

            //db.AddStoreProcedure("CustOrderHist2");
            //db.GetStoreProcedure("CustOrderHist2").NeedReturnValue = true;
            //db.GetStoreProcedure("CustOrderHist2").ProcExecuteReturnType = Model.StoreProcedure.ExecuteReturnType.DataTable;
            //db.AddStoreProcedure("CustOrderHist3");
            //db.GetStoreProcedure("CustOrderHist3").NeedReturnValue = false;
            //db.GetStoreProcedure("CustOrderHist3").ProcExecuteReturnType = Model.StoreProcedure.ExecuteReturnType.Scalar;

            SqlStorProcExecCode sec = new SqlStorProcExecCode(db.StoreProcedures, false, true, null, null, null, null);

            ShowCSharpCode scc = new ShowCSharpCode(sec.GetCode());
            scc.Show(dp);
        }

        private void 测试生成代码执行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strCnn = "Data Source=.;Persist Security Info=True;User ID=sa;Password=;Initial Catalog=TestForSmartTools;";
            string CustomerID = "a", CustomerID1 = "b";
            int CustomerID2 = 2;
            int intRetVal = 0;
                        
            //DataTable table = SqlStoredProcedureExecute.AccuBaseComp(CustomerID, ref CustomerID1, ref CustomerID2, ref intRetVal, strCnn);

            //ShowTable frmShowTable = new ShowTable(table);

            //frmShowTable.Show(dp);
        }
    }
}