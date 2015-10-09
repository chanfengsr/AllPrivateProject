using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;

namespace SmartTools
{
    public partial class ShowSQLScript : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private string _code = "";

        public ShowSQLScript(string Code)
        {
            InitializeComponent();
            _code = Code;
        }

        private void ShowSQLScript_Load(object sender, EventArgs e)
        {
            txteCode.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            txteCode.Text = _code;
        }
    }
}