using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Collections.Generic;

namespace UBB代码生成
{
    public partial class ColorComboBox : System.Windows.Forms.ComboBox
    {
        private bool IsCustomerSet = false;

        /// <summary>
        /// Color，增加 Name 属性
        /// </summary>
        public struct MColor
        {
            public string Name;
            public Color Color;

            public MColor(string _Name, Color _Color)
            {
                this.Name = _Name;
                this.Color = _Color;
            }
        }

        /// <summary>
        /// 预定义颜色
        /// </summary>
        public enum ColorGroup { W3C16, Safe216, IE4_PreNamed, WIN }

        #region 构造函数
        public ColorComboBox()
        {
            InitializeComponent();
        }

        public ColorComboBox(ColorGroup colorGroup)
        {
            InitializeComponent();
            mColors = GetPredefinedColor(colorGroup);
        }

        public ColorComboBox(MColor[] colors)
        {
            InitializeComponent();
            mColors = colors;
        }

        #endregion

        #region 巉沨散人增加函数

        /// <summary>
        /// 返回预定义的几种颜色
        /// </summary>
        /// <param name="colorGroup">预定义颜色</param>
        /// <returns></returns>
        private static MColor[] GetPredefinedColor(ColorGroup colorGroup)
        {
            List<MColor> retVal = new List<MColor>();

            switch (colorGroup)
            {
                case ColorGroup.W3C16:
                    foreach (string[] var in ColorDefined.GetW3C16Color())
                    {
                        retVal.Add(new MColor(var[1], ColorTranslator.FromHtml(var[0])));
                    }
                    break;
                case ColorGroup.Safe216:
                    foreach (string var in ColorDefined.GetSafe216Color())
                    {
                        retVal.Add(new MColor(var, ColorTranslator.FromHtml(var)));
                    }
                    break;
                case ColorGroup.IE4_PreNamed:
                    foreach (string[] var in ColorDefined.GetIE4_PreNamedColor())
                    {
                        retVal.Add(new MColor(var[1], ColorTranslator.FromHtml(var[0])));
                    }
                    break;
                case ColorGroup.WIN:
                    foreach (string var in ColorDefined.GetWINColor())
                    {
                        retVal.Add(new MColor(var, Color.FromName(var)));
                    }
                    break;
            }

            return retVal.ToArray();
        }

        /// <summary>
        /// 设置成W3C十六色
        /// </summary>
        public void SetW3C16Color()
        {
            this.Items.Clear();
            foreach (MColor var in GetPredefinedColor(ColorGroup.W3C16))
            {
                this.Items.Add(var);
            }
            IsCustomerSet = true;
            this.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置成216安全色
        /// </summary>
        public void SetSafe216Color()
        {
            this.Items.Clear();
            foreach (MColor var in GetPredefinedColor(ColorGroup.Safe216))
            {
                this.Items.Add(var);
            }
            IsCustomerSet = true;
            this.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置成IE4+预命名色
        /// </summary>
        public void SetIE4_PreNamedColor()
        {
            this.Items.Clear();
            foreach (MColor var in GetPredefinedColor(ColorGroup.IE4_PreNamed))
            {
                this.Items.Add(var);
            }
            IsCustomerSet = true;
            this.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置成WIN - 用户系统色
        /// </summary>
        public void SetWINColor()
        {
            this.Items.Clear();
            foreach (MColor var in GetPredefinedColor(ColorGroup.WIN))
            {
                this.Items.Add(var);
            }
            IsCustomerSet = true;
            this.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置成
        /// </summary>
        public void SetDefaultColor()
        {
            this.Items.Clear();
            foreach (MColor var in GetPredefinedColor(ColorGroup.W3C16))
            {
                this.Items.Add(var);
            }
            this.Items.Add(new MColor("Other", Color.White));

            IsCustomerSet = false;
            this.SelectedIndex = 0;
        }

        #endregion

        [Browsable(false)]
        [Category("Property")]
        public MColor SelectedColor
        {
            get
            {
                return this.resultCol;
            }
            set
            {
                this.resultCol = value;
                int i = 0;
                int j = IsCustomerSet ? this.Items.Count : this.Items.Count - 1;

                for (i = 0; i < j; i++)
                {
                    if (i >= this.Items.Count) break;
                    if (((MColor)this.Items[i]).Name.Trim().ToLower() == this.resultCol.Name.Trim().ToLower())
                    {
                        this.SelectedIndex = i;
                        break;
                    }
                }
                if (i == j && !IsCustomerSet)
                {
                    this.colDlg = false;
                    this.otherCol = value.Color;
                    if (this.SelectedIndex != i) this.SelectedIndex = i;
                    else this.ColorComboBox_SelectedIndexChanged(this, null);
                }
            }
        }


        [Browsable(true)]
        [DefaultValue(1)]
        [Category("Property")]
        [Description("The color of control when the appearance set to Skinned.")]
        public Color ControlColor
        {
            get
            {
                return this.cColor;
            }
            set
            {
                if (this.Enabled)
                    this.cColor = value;
                else
                    this.cColor = SystemColors.ControlDark;

                this.bColor = value;
                this.Refresh();
            }
        }


        [Browsable(true)]
        [Category("Property")]
        [Description("Determines if the control display skinned or standard.")]
        public ControlView Appearance
        {
            get
            {
                return this.app;
            }
            set
            {
                this.app = value;
                this.Refresh();
            }
        }


        [Browsable(true)]
        [Category("Property")]
        [Description("Amir创建，巉沨散人修改(chanfengsr@163.com)")]
        public string About
        {
            get
            {
                return "Amir创建，巉沨散人修改(chanfengsr@163.com)";
            }
        }

        public enum ControlView : int
        {
            Standard = 0,
            Skinned = 1,
        }

        private bool colDlg = true;
        private ControlView app = ControlView.Skinned;
        private Color otherCol = Color.White;
        private MColor resultCol = new MColor("White", Color.White);
        private Color cColor = SystemColors.ActiveCaption;
        private Color bColor = SystemColors.ActiveCaption;

        private MColor[] mColors = GetPredefinedColor(ColorGroup.W3C16);

        private void DrawCombo(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {

            Graphics g = e.Graphics;
            Rectangle rd = e.Bounds;

            int rr = this.cColor.R;
            int gg = this.cColor.G;
            int bb = this.cColor.B;
            Color cll = Color.White;
            Color cl = Color.FromArgb(rr + (255 - rr) * 2 / 3, gg + (255 - gg) * 2 / 3, bb + (255 - bb) * 2 / 3);
            Color cc = Color.FromArgb(rr + (255 - rr) * 1 / 3, gg + (255 - gg) * 1 / 3, bb + (255 - bb) * 1 / 3);
            Color cd = Color.FromArgb(rr, gg, bb);
            Color cdd = Color.FromArgb(rr * 2 / 3, gg * 2 / 3, bb * 2 / 3);

            LinearGradientBrush br = new LinearGradientBrush(new Rectangle(e.Bounds.Left - 1, e.Bounds.Top - 1, e.Bounds.Width + 4, e.Bounds.Height + 4), cd, cll, 65f);

            if (e.Index >= 0)
            {
                //				Console.WriteLine(e.State.ToString());
                if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), rd);
                    e.DrawFocusRectangle();
                }
                else
                {
                    if (this.app == ControlView.Skinned)
                    {
                        e.Graphics.FillRectangle(br, rd);
                        br = new LinearGradientBrush(e.Bounds, cc, cll, 65f);
                        rd.Width = e.Bounds.Width - 2;
                        rd.Height = e.Bounds.Height - 2;
                        rd.X = e.Bounds.X + 1;
                        rd.Y = e.Bounds.Y + 1;
                        e.Graphics.FillRectangle(br, rd);
                        e.DrawFocusRectangle();
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), rd);
                        e.DrawFocusRectangle();
                    }
                }
            }

            rd.Width = 20;
            rd.Height = this.ItemHeight - 5;
            rd.X = 4;
            rd.Y += 1;

            if (IsCustomerSet)
            {
                if (e.Index >= 0 && e.Index < this.Items.Count)
                {
                    g.FillRectangle(new SolidBrush(((MColor)this.Items[e.Index]).Color), rd);
                    g.DrawRectangle(new Pen(Color.Black), rd);
                    if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect) || this.app == ControlView.Skinned)
                        g.DrawString(((MColor)this.Items[e.Index]).Name, this.Font, new SolidBrush(Color.Black), rd.Width + 5, rd.Top - 1);
                    else
                        g.DrawString(((MColor)this.Items[e.Index]).Name, this.Font, new SolidBrush(SystemColors.HighlightText), rd.Width + 5, rd.Top - 1);
                }
            }
            else
            {
                if (e.Index >= 0 && e.Index < this.Items.Count - 1)
                {
                    g.FillRectangle(new SolidBrush(((MColor)this.Items[e.Index]).Color), rd);
                    g.DrawRectangle(new Pen(Color.Black), rd);
                    if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect) || this.app == ControlView.Skinned)
                        g.DrawString(((MColor)this.Items[e.Index]).Name, this.Font, new SolidBrush(Color.Black), rd.Width + 5, rd.Top - 1);
                    else
                        g.DrawString(((MColor)this.Items[e.Index]).Name, this.Font, new SolidBrush(SystemColors.HighlightText), rd.Width + 5, rd.Top - 1);
                }
                else if (e.Index == this.Items.Count - 1)
                {
                    g.FillRectangle(new SolidBrush(otherCol), rd);
                    g.DrawRectangle(new Pen(Color.Black), rd);
                    if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect) || this.app == ControlView.Skinned)
                        g.DrawString(((MColor)this.Items[e.Index]).Name, this.Font, new SolidBrush(Color.Black), rd.Width + 5, rd.Top - 1);
                    else
                        g.DrawString(((MColor)this.Items[e.Index]).Name, this.Font, new SolidBrush(SystemColors.HighlightText), rd.Width + 5, rd.Top - 1);
                }
            }

            //if (this.app == ControlView.Skinned)
            //{
            //    Graphics gr = this.CreateGraphics();
            //    gr.DrawRectangle(new Pen(cd), 0, 0, this.Width - 1, this.Height - 1);
            //    gr.DrawRectangle(new Pen(cl), 1, 1, this.Width - 3, this.Height - 3);
            //    gr.FillRectangle(new SolidBrush(cll), this.Width - this.Height + 1, 2, this.Height - 3, this.Height - 4);

            //    br = new LinearGradientBrush(new Rectangle(this.Width - this.Height + 1, 2, this.Height, this.Height), cl, cd, 45f);
            //    gr.FillRectangle(br, this.Width - this.Height + 2, 3, this.Height - 5, this.Height - 6);

            //    br = new LinearGradientBrush(new Rectangle(this.Width - this.Height + 1, 2, this.Height, this.Height), cll, cc, 45f);
            //    gr.FillRectangle(br, this.Width - this.Height + 3, 4, this.Height - 7, this.Height - 8);

            //    gr.FillRectangle(new SolidBrush(cll), this.Width - this.Height + 2, 3, 1, 1);
            //    gr.FillRectangle(new SolidBrush(cll), this.Width - this.Height + 2, 3 + this.Height - 7, 1, 1);
            //    gr.FillRectangle(new SolidBrush(cll), this.Width - this.Height + 2 + this.Height - 6, 3, 1, 1);
            //    gr.FillRectangle(new SolidBrush(cl), this.Width - this.Height + 2 + this.Height - 6, 3 + this.Height - 7, 1, 1);

            //    gr.DrawLine(new Pen(cd, 1), (this.Width - this.Height / 2) - 4, this.Height / 2 - 1, (this.Width - this.Height / 2) - 1, this.Height / 2 + 2);
            //    gr.DrawLine(new Pen(cd, 1), (this.Width - this.Height / 2) - 1, this.Height / 2 + 2, (this.Width - this.Height / 2) + 2, this.Height / 2 - 1);
            //    gr.DrawLine(new Pen(cc, 1), (this.Width - this.Height / 2) - 4, this.Height / 2 - 0, (this.Width - this.Height / 2) - 1, this.Height / 2 + 3);
            //    gr.DrawLine(new Pen(cc, 1), (this.Width - this.Height / 2) - 1, this.Height / 2 + 3, (this.Width - this.Height / 2) + 2, this.Height / 2 - 0);
            //    gr.DrawLine(new Pen(cl, 1), (this.Width - this.Height / 2) - 4, this.Height / 2 + 1, (this.Width - this.Height / 2) - 1, this.Height / 2 + 4);
            //    gr.DrawLine(new Pen(cl, 1), (this.Width - this.Height / 2) - 1, this.Height / 2 + 4, (this.Width - this.Height / 2) + 2, this.Height / 2 + 1);
            //}

            br.Dispose();


            //gr.DrawRectangle(new Pen(cd),this.Width-this.Height-2,3,15,this.Height-7);
            //			int i = int.Parse(this.Parent.Text);
            //			this.Parent.Text = (i+1).ToString();
        }

        private void ColorComboBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            //Console.WriteLine("bb"+e.Index.ToString());

            if (this.Height < 21) this.Height = 21;
            if (this.ItemHeight < 15) this.ItemHeight = 15;

            if (!IsCustomerSet && this.Items.Count < mColors.Length)
            {
                for (int j = this.Items.Count; j < mColors.Length; j++)
                    this.Items.Add(mColors[j]);
                this.Items.Add(new MColor("Other", Color.White));

                this.SelectedIndex = 0;
            }

            //int i = 0;
            //for (i = 0; i < this.Items.Count - 1; i++)
            //{
            //    if (((MColor)this.Items[i]).Name == this.resultCol.Name && this.SelectedIndex != i)
            //    {
            //        this.SelectedIndex = i;
            //        break;
            //    }
            //}
            //if (i == this.Items.Count - 1)
            //{
            //    this.colDlg = false;
            //    this.SelectedIndex = i;
            //}

            DrawCombo(sender, e);

        }

        private void ColorComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //Console.WriteLine("aa");
            try
            {
                if (this.SelectedIndex == this.Items.Count - 1 && !IsCustomerSet)
                {
                    if (this.colDlg)
                    {
                        ColorDialog cDlg = new ColorDialog();
                        cDlg.FullOpen = true;
                        cDlg.ShowDialog();
                        otherCol = cDlg.Color;
                        resultCol.Color = cDlg.Color;
                        resultCol.Name = cDlg.Color.Name;
                    }
                    else
                    {
                        this.colDlg = true;
                        this.Refresh();
                    }
                }
                else resultCol = (MColor)this.Items[this.SelectedIndex];

            }
            catch
            {
                //MessageBox.Show("ERRR");
            }

        }

        private void ColorComboBox_MouseEnter(object sender, System.EventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            gr.FillRectangle(new SolidBrush(Color.FromArgb(90, 255, 255, 255)), this.Width - this.Height + 2, 3, this.Height - 5, this.Height - 6);
        }

        private void ColorComboBox_MouseLeave(object sender, System.EventArgs e)
        {
            this.Invalidate(new Rectangle(this.Width - this.Height + 2, 3, this.Height - 5, this.Height - 6));
            this.Update();
        }

        private void ColorComboBox_EnabledChanged(object sender, System.EventArgs e)
        {
            if (this.Enabled)
                this.cColor = this.bColor;
            else
                this.cColor = SystemColors.ControlDark;
        }
    }
}
