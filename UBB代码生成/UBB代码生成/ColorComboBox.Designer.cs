namespace UBB代码生成
{
    partial class ColorComboBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Size = new System.Drawing.Size(120, 24);
            this.EnabledChanged += new System.EventHandler(this.ColorComboBox_EnabledChanged);
            this.SelectedIndexChanged += new System.EventHandler(this.ColorComboBox_SelectedIndexChanged);
            this.MouseEnter += new System.EventHandler(this.ColorComboBox_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ColorComboBox_MouseLeave);
            this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ColorComboBox_DrawItem);            
        }

        #endregion
    }
}
