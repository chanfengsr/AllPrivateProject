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
    public partial class ShowCSharpCode : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private string _code = "";

        public ShowCSharpCode(string Code)
        {
            InitializeComponent();
            _code = Code;
        }

        private void ShowCSharpCode_Load(object sender, EventArgs e)
        {
            txteCode.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            txteCode.Text = _code;
        }
    }
}