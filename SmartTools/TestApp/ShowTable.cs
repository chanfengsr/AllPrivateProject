using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartTools
{
    public partial class ShowTable : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        DataTable _table = new DataTable();

        public ShowTable(DataTable table)
        {
            this._table = table;
            InitializeComponent();
        }

        private void ShowTable_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this._table;
        }
    }
}