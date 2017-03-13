using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace StockExplore
{
    public class TextBoxStreamWriter : TextWriter
    {
        private TextBox _output;

        public TextBoxStreamWriter(TextBox output)
        {
            this._output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            this._output.AppendText(value.ToString());
        }

        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}
