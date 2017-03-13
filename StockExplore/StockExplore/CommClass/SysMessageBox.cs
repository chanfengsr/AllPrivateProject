using System;
using System.Windows.Forms;

namespace StockExplore
{
    /// <summary>通用Message框</summary>
    public class SysMessageBox
    {
        private const string Catpion = "System Message";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageDescription"></param>
        /// <param name="moudleName"></param>
        /// <param name="msgButton"></param>
        /// <param name="icon"></param>
        /// <param name="defaultButton"></param>
        /// <returns></returns>
        public static DialogResult ShowMessage(string messageDescription, string moudleName, MessageBoxButtons msgButton, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            string msgString = messageDescription 
                + ( moudleName.Length > 0 ? Environment.NewLine + Environment.NewLine + moudleName : "" );
            
            return MessageBox.Show(msgString, Catpion, msgButton, icon, defaultButton);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageDescription"></param>
        /// <param name="moudleName"></param>
        /// <param name="icon"></param>
        /// <param name="defaultButton"></param>
        public static void ShowMessage(string messageDescription, string moudleName, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            string msgString = messageDescription
                + (moudleName.Length > 0 ? Environment.NewLine + Environment.NewLine + moudleName : "");

            MessageBox.Show(msgString, Catpion, MessageBoxButtons.OK, icon, defaultButton);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageDescription"></param>
        /// <param name="moudleName"></param>
        public static void ErrorMessage(string messageDescription, string moudleName)
        {
            ShowMessage(messageDescription, moudleName, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageDescription"></param>
        /// <param name="moudleName"></param>
        public static void WarningMessage(string messageDescription, string moudleName)
        {
            ShowMessage(messageDescription, moudleName, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageDescription"></param>
        /// <param name="moudleName"></param>
        public static void InfoMessage(string messageDescription, string moudleName)
        {
            ShowMessage(messageDescription, moudleName, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
