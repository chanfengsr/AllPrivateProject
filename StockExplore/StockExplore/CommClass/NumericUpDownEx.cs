using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace StockExplore
{
    public class NumericUpDownEx : NumericUpDown
    {
        private bool _DefaultNullText = false;
        private bool _ValueChanged = false;
        private bool _HasSetDefault = false;

        #region 重载基类方法
        protected override void OnTextBoxResize(object source, EventArgs e)
        {
            //base.OnTextBoxResize(source, e);
            //this.Controls[0].Size = new Size(0, ClientSize.Height);
            //this.Controls[1].Size = new Size(ClientSize.Width, ClientSize.Height);

            this.Controls[0].Visible = false;
            this.Controls[1].Size = new Size(this.Width - 3, this.Height);
        }

        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            _ValueChanged = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!_HasSetDefault && _DefaultNullText && this.Value == this.DefaultNullValue)
            {
                this.ControlText = "";
                _HasSetDefault = true;
            }
        }
        #endregion 重载基类方法

        [Description("控件中的显示文字"), Category("Common Properties")]
        public string ControlText
        {
            get { return this.Controls[1].Text; }
            set { this.Controls[1].Text = value; }
        }

        [Description("初始值是否为空"), DefaultValue(false), Category("Common Properties")]
        public bool DefaultIsNullText
        {
            get { return _DefaultNullText; }
            set
            {
                _DefaultNullText = value;
                this.ControlText = _DefaultNullText ? "" : this.Value.ToString();
            }
        }

        private int _DefaultNullValue = -99999;
        [Description("初始为空的判断数值"), DefaultValue(-99999), Category("Common Properties")]
        public int DefaultNullValue
        {
            get { return _DefaultNullValue; }
            set { _DefaultNullValue = value; }
        }

    }
}
