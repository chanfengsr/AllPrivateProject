using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UBB代码生成
{
    public partial class frmPersonalityUBB : Form
    {

        CommonDefinition.GlobalProcessStruct _GlobalInfo = new CommonDefinition.GlobalProcessStruct();

        CommonDefinition _cFunction = new CommonDefinition();

        public frmPersonalityUBB()
        {
            InitializeComponent();
        }

        private void frmPersonalityUBB_Load(object sender, EventArgs e)
        {
            #region 颜色控件设置
            DataTable dtColorKind = new DataTable();
            dtColorKind.Columns.Add("Name");
            dtColorKind.Columns.Add("Value");
            dtColorKind.Rows.Add("W3C十六色", "W3C16");
            dtColorKind.Rows.Add("216安全色", "Safe216");
            dtColorKind.Rows.Add("IE4+预命名色", "IE4_PreNamed");
            dtColorKind.Rows.Add("WIN-用户系统色", "WIN");

            cmbColorCategories.DisplayMember = "Name";
            cmbColorCategories.ValueMember = "Value";
            cmbColorCategories.DataSource = dtColorKind;

            ccmbBackgroundColor.SetIE4_PreNamedColor();
            ccmbBackgroundColor.SelectedColor = new ColorComboBox.MColor("white", ColorTranslator.FromHtml("#FFFFFF"));
            ccmbColor.SetW3C16Color();
            ccmbColor.SelectedColor = new ColorComboBox.MColor("Black", ColorTranslator.FromHtml("#000000"));
            #endregion

            this.Text = this.Text + "  V" + Application.ProductVersion + "  ——by 巉沨散人（chanfengsr@163.com）";

            txtOriginalText.Focus();
        }

        private void cmbColorCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColorCategories.SelectedValue.ToString())
            {
                case "W3C16":
                    ccmbColor.SetW3C16Color();
                    ccmbColor.SelectedColor = new ColorComboBox.MColor("Black", Color.Black);
                    break;
                case "Safe216":
                    ccmbColor.SetSafe216Color();
                    ccmbColor.SelectedColor = new ColorComboBox.MColor("#000000", Color.Black);
                    break;
                case "IE4_PreNamed":
                    ccmbColor.SetIE4_PreNamedColor();
                    ccmbColor.SelectedColor = new ColorComboBox.MColor("black", Color.Black);
                    break;
                case "WIN":
                    ccmbColor.SetWINColor();
                    ccmbColor.SelectedColor = new ColorComboBox.MColor("windowtext", Color.Black);
                    break;
            }
        }

        private void chkAsInsertCode_CheckedChanged(object sender, EventArgs e)
        {
            gpbInsTxt.Enabled = chkAsInsertCode.Checked;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLink.Checked || rdbMail.Checked)
            {
                txtShow.Enabled = true;
            }
            else
            {
                txtShow.Text = "";
                txtShow.Enabled = false;
            }

            if ((sender as Control).Name == "cmbList")
            {
                if ((sender as Control).Text.Trim() != "")
                {
                    foreach (Control ctrl in gpbInsTxt.Controls)
                    {
                        if (ctrl is RadioButton)
                        {
                            (ctrl as RadioButton).Checked = false;
                        }
                    }
                }
            }
            else
            {
                if (sender is RadioButton)
                {
                    if ((sender as RadioButton).Checked)
                        cmbList.Text = "";
                }
            }
        }

        private void lnkCellLine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int intSelectionStart = txtResultText.SelectionStart;
            string strHR = _cFunction.GetHRLine(chkLowerTags.Checked);

            txtResultText.Text = txtResultText.Text.Insert(txtResultText.SelectionStart, strHR);
            txtResultText.SelectionStart = intSelectionStart + strHR.Length;
            txtResultText.Focus();

            try
            {
                if (txtResultText.Text.Trim() != "")
                    Clipboard.SetText(txtResultText.Text.Trim());
            }
            catch (Exception)
            { }
        }

        private void lnkSetDefault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (Control ctrl in gpbConfig.Controls)
            {
                if (ctrl is CheckBox)
                {
                    (ctrl as CheckBox).Checked = false;
                }

                if (ctrl is RadioButton)
                {
                    (ctrl as RadioButton).Checked = false;
                }
            }

            foreach (Control ctrl in gpbColor.Controls)
            {
                if (ctrl is CheckBox)
                {
                    (ctrl as CheckBox).Checked = false;
                }

                if (ctrl is RadioButton)
                {
                    (ctrl as RadioButton).Checked = false;
                }
            }

            foreach (Control ctrl in gpbInsTxt.Controls)
            {
                if (ctrl is CheckBox)
                {
                    (ctrl as CheckBox).Checked = false;
                }

                if (ctrl is RadioButton)
                {
                    (ctrl as RadioButton).Checked = false;
                }
            }

            cmbAlignment.Text = "";
            cmbFont.Text = "";
            cmbSize.Text = "";

            cmbColorCategories.SelectedIndex = 0;
            ccmbBackgroundColor.SetIE4_PreNamedColor();
            ccmbBackgroundColor.SelectedColor = new ColorComboBox.MColor("white", ColorTranslator.FromHtml("#FFFFFF"));

            cmbList.Text = "";

            txtShow.Text = "";
            txtMiniOrigText.Text = "";

            chkLowerTags.Checked = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            switch ((sender as Control).Name)
            {
                case "btnClearOriginal":
                    txtOriginalText.Text = "";
                    txtOriginalText.Focus();
                    break;
                case "btnClearResult":
                    txtResultText.Text = "";
                    txtResultText.Focus();
                    break;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string strResultText = "";
            int intSelectionStart = txtResultText.SelectionStart;

            FillGlobalInfomation();

            if (_GlobalInfo.AsInsertCode)
            {
                strResultText = _cFunction.ProcessInformation(_GlobalInfo);
                txtResultText.Text = txtResultText.Text.Insert(txtResultText.SelectionStart, strResultText);
                txtResultText.SelectionStart = intSelectionStart + strResultText.Length;
            }
            else
            {
                txtResultText.Text = _cFunction.ProcessInformation(_GlobalInfo);
                txtResultText.SelectionStart = txtResultText.Text.Length;
            }

            try
            {
                if (txtResultText.Text.Trim() != "")
                    Clipboard.SetText(txtResultText.Text.Trim());
            }
            catch (Exception)
            { }

            if (chkAsInsertCode.Checked)
                txtMiniOrigText.Focus();
            else
                txtOriginalText.Focus();
        }

        private void FillGlobalInfomation()
        {
            _GlobalInfo.Bold = chkBold.Checked;
            _GlobalInfo.Italic = chkItalic.Checked;
            _GlobalInfo.Underline = chkUnderline.Checked;
            _GlobalInfo.Scored = chkScored.Checked;
            _GlobalInfo.Fly = chkFly.Checked;
            _GlobalInfo.Luminescence = chkLuminescence.Checked;
            _GlobalInfo.Shadow = chkShadow.Checked;
            _GlobalInfo.VerbatimFlash = chkVerbatimFlash.Checked;
            _GlobalInfo.Free = chkFree.Checked;

            _GlobalInfo.Alignment = cmbAlignment.Text.Trim();
            _GlobalInfo.Size = cmbSize.Text.Trim();
            _GlobalInfo.Font = cmbFont.Text.Trim();
            _GlobalInfo.BackgroundColor = ccmbBackgroundColor.SelectedColor.Name;

            if (rdbSingle.Checked)
            { _GlobalInfo.ColorPattern = CommonDefinition.ColorPattern.Single; }
            else if (rdbDynamic.Checked)
            { _GlobalInfo.ColorPattern = CommonDefinition.ColorPattern.Dynamic; }
            else if (rdbRainbow.Checked)
            { _GlobalInfo.ColorPattern = CommonDefinition.ColorPattern.Rainbow; }
            else if (rdbGray.Checked)
            { _GlobalInfo.ColorPattern = CommonDefinition.ColorPattern.Gray; }
            else
            { _GlobalInfo.ColorPattern = CommonDefinition.ColorPattern.None; }

            _GlobalInfo.ColorCategories = cmbColorCategories.SelectedValue.ToString();

            //if (cmbColorCategories.SelectedValue.ToString() == "Safe216")
            //{ _GlobalInfo.Color = "#" + ccmbColor.SelectedColor.Name.Trim().Substring(2); }
            _GlobalInfo.ColorName = ccmbColor.SelectedColor.Name;
            _GlobalInfo.Color = ccmbColor.SelectedColor.Color;

            _GlobalInfo.AsInsertCode = chkAsInsertCode.Checked;
            _GlobalInfo.ContainAbove = chkContainAbove.Checked;

            _GlobalInfo.Mail = rdbMail.Checked;
            _GlobalInfo.Link = rdbLink.Checked;
            _GlobalInfo.Picture = rdbPicture.Checked;
            _GlobalInfo.Flash = rdbFlash.Checked;
            _GlobalInfo.Code = rdbCode.Checked;
            _GlobalInfo.Quote = rdbQuote.Checked;
            _GlobalInfo.Superscript = rdbSuperscript.Checked;
            _GlobalInfo.Subscript = rdbSubscript.Checked;
            _GlobalInfo.QQ = rdbQQ.Checked;
            _GlobalInfo.EMule = rdbEMule.Checked;
            _GlobalInfo.Formatted = rdbFormatted.Checked;
            _GlobalInfo.List = cmbList.Text.Trim();

            _GlobalInfo.Show = txtShow.Text.Trim();
            _GlobalInfo.MiniOrigText = txtMiniOrigText.Text.Trim();

            _GlobalInfo.LowerTags = chkLowerTags.Checked;

            _GlobalInfo.OriginalText = txtOriginalText.Text;

            _GlobalInfo.ResultText = txtResultText.Text.Trim();

            _GlobalInfo.StartWithResultText = chkStartWithResultText.Checked;
        }
    }
}