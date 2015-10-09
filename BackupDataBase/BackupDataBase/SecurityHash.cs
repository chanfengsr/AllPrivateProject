//=================================================================================
//
//文件名（File Name）：                 SecurityHash.cs
//
//功能描述（Description）：             对字符串进行加密
//
//数据表（Tables）：                    Nothing            
//
//作者（Author）：                      王 煜
//
//日期（Create Date）：                 2007.03.23
//
//修改记录（Revision History）：            
//  R1：
//      修改作者：
//      修改日期：
//      修改理由、内容：
//
//=================================================================================

using System;
using System.IO;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Security;
using System.Security.Cryptography;

namespace BackupDataBase
{
    /// <summary>
    /// 类名：HashEncrypt
    /// 作用：对传入的字符串进行Hash运算，返回通过Hash算法加密过的字串。
    /// 属性：［无］
    /// 构造函数额参数：
    /// IsReturnNum:是否返回为加密后字符的Byte代码
    /// IsCaseSensitive：是否区分大小写。
    /// 方法：此类提供MD5，SHA1，SHA256，SHA512，DES，3DES等几种算法，加密字串的长度依次增大。
    /// </summary>
    public class SecurityHash
    {
        //private string strIN;
        private bool isReturnNum;
        private bool isCaseSensitive;

        /// <summary>
        /// 对传入的字符串进行Hash运算，返回通过Hash算法加密过的字串。
        /// </summary>
        /// <param name="IsCaseSensitive">是否区分大小写</param>
        /// <param name="IsReturnNum">是否返回为加密后字符的Byte代码</param>
        public SecurityHash(bool IsCaseSensitive, bool IsReturnNum)
        {
            this.isReturnNum = IsReturnNum;
            this.isCaseSensitive = IsCaseSensitive;
        }

        private string getstrIN(string strIN)
        {
            //string strIN = strIN;
            if (strIN.Length == 0)
            {
                strIN = "~NULL~";
            }
            if (isCaseSensitive == false)
            {
                strIN = strIN.ToUpper();
            }
            return strIN;
        }

        private string GetStringValue(byte[] Byte)
        {
            string tmpString = "";

            if (this.isReturnNum == false)
            {
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < Byte.Length; i++)
                {
                    sBuilder.Append(Byte[i].ToString("x2"));
                }

                tmpString = sBuilder.ToString();
            }
            else
            {
                int iCounter;

                for (iCounter = 0; iCounter < Byte.Length; iCounter++)
                {
                    tmpString = tmpString + Byte[iCounter].ToString();
                }

            }

            return tmpString;
        }

        private byte[] GetKeyByteArray(string strKey)
        {
            byte[] tmpByte = Encoding.Default.GetBytes(strKey);
            return tmpByte;
        }

        public string MD5Encrypt(string strIN)
        {
            //string strIN = getstrIN(strIN);
            byte[] tmpByte;
            MD5 md5 = new MD5CryptoServiceProvider();
            tmpByte = md5.ComputeHash(GetKeyByteArray(getstrIN(strIN)));
            md5.Clear();

            return GetStringValue(tmpByte);

        }

        public string SHA1Encrypt(string strIN)
        {
            //string strIN = getstrIN(strIN);
            byte[] tmpByte;
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            tmpByte = sha1.ComputeHash(GetKeyByteArray(strIN));
            sha1.Clear();

            return GetStringValue(tmpByte);

        }

        public string SHA256Encrypt(string strIN)
        {
            //string strIN = getstrIN(strIN);
            byte[] tmpByte;
            SHA256 sha256 = new SHA256Managed();

            tmpByte = sha256.ComputeHash(GetKeyByteArray(strIN));
            sha256.Clear();

            return GetStringValue(tmpByte);

        }

        public string SHA512Encrypt(string strIN)
        {
            //string strIN = getstrIN(strIN);
            byte[] tmpByte;
            SHA512 sha512 = new SHA512Managed();

            tmpByte = sha512.ComputeHash(GetKeyByteArray(strIN));
            sha512.Clear();

            return GetStringValue(tmpByte);

        }

        /// <summary>
        /// 使用DES加密
        /// </summary>
        /// <param name="OriginalValue">待加密的字符串</param>
        /// <param name="Key">密钥(最大长度8)</param>
        /// <param name="IV">初始化向量(最大长度8)</param>
        /// <returns>加密后的字符串</returns>
        public string DESEncrypt(string OriginalValue, string Key, string IV)
        {
            //将key和IV处理成8个字符
            Key += "12345678";
            IV += "12345678";
            Key = Key.Substring(0, 8);
            IV = IV.Substring(0, 8);

            SymmetricAlgorithm sa;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;

            sa = new DESCryptoServiceProvider();
            sa.Key = Encoding.UTF8.GetBytes(Key);
            sa.IV = Encoding.UTF8.GetBytes(IV);
            ct = sa.CreateEncryptor();

            byt = Encoding.UTF8.GetBytes(OriginalValue);

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Convert.ToBase64String(ms.ToArray());

        }

        public string DESEncrypt(string OriginalValue, string Key)
        {
            return DESEncrypt(OriginalValue, Key, Key);
        }

        /// <summary>
        /// 使用DES解密
        /// </summary>
        /// <param name="EncryptedValue">待解密的字符串</param>
        /// <param name="Key">密钥(最大长度8)</param>
        /// <param name="IV">m初始化向量(最大长度8)</param>
        /// <returns>解密后的字符串</returns>
        public string DESDecrypt(string EncryptedValue, string Key, string IV)
        {
            //将key和IV处理成8个字符
            Key += "12345678";
            IV += "12345678";
            Key = Key.Substring(0, 8);
            IV = IV.Substring(0, 8);

            SymmetricAlgorithm sa;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;

            sa = new DESCryptoServiceProvider();
            sa.Key = Encoding.UTF8.GetBytes(Key);
            sa.IV = Encoding.UTF8.GetBytes(IV);
            ct = sa.CreateDecryptor();

            byt = Convert.FromBase64String(EncryptedValue);

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Encoding.UTF8.GetString(ms.ToArray());

        }

        public string DESDecrypt(string EncryptedValue, string Key)
        {
            return DESDecrypt(EncryptedValue, Key, Key);
        }

        /// <summary>
        /// 使用3DES加密
        /// </summary>
        /// <param name="OriginalValue">待加密的字符串</param>
        /// <param name="Key">密钥(最大长度16)</param>
        /// <param name="IV">初始化向量(最大长度8)</param>
        /// <returns>加密后的字符串</returns>
        public string ThreeDESEncrypt(string OriginalValue, string Key, string IV)
        {
            //将key处理生成16个字符
            //将IV生成8个字符
            Key += "1234567890123456";
            IV += "12345678";
            Key = Key.Substring(0, 16);
            IV = IV.Substring(0, 8);

            SymmetricAlgorithm sa;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;

            sa = new TripleDESCryptoServiceProvider();
            sa.Key = Encoding.UTF8.GetBytes(Key);
            sa.IV = Encoding.UTF8.GetBytes(IV);
            ct = sa.CreateEncryptor();

            byt = Encoding.UTF8.GetBytes(OriginalValue);

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        public string ThreeDESEncrypt(string OriginalValue, string Key)
        {
            return ThreeDESEncrypt(OriginalValue, Key, Key);
        }

        /// <summary>
        /// 使用DES解密
        /// </summary>
        /// <param name="EncryptedValue">待解密的字符串</param>
        /// <param name="Key">密钥(最大长度16)</param>
        /// <param name="IV">m初始化向量(最大长度8)</param>
        /// <returns>解密后的字符串</returns>
        public string ThreeDESDecrypt(string EncryptedValue, string Key, string IV)
        {
            //将key处理生成16个字符
            //将IV生成8个字符
            Key += "1234567890123456";
            IV += "12345678";
            Key = Key.Substring(0, 16);
            IV = IV.Substring(0, 8);

            SymmetricAlgorithm sa;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;

            sa = new TripleDESCryptoServiceProvider();
            sa.Key = Encoding.UTF8.GetBytes(Key);
            sa.IV = Encoding.UTF8.GetBytes(IV);
            ct = sa.CreateDecryptor();

            byt = Convert.FromBase64String(EncryptedValue);

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        public string ThreeDESDecrypt(string EncrypteValue, string key)
        {
            return ThreeDESDecrypt(EncrypteValue, key, key);
        }

        /// <summary>
        /// 杭州矢琦成本核算系统用户密码加密算法
        /// </summary>
        /// <param name="EncrypteValue"></param>
        public string BackupDataBaseEncrypt(string EncrypteValue)
        {
            string strResult = "";

            string Key = "WangYu";
            string IV = "chanfengsr";

            strResult = SHA1Encrypt(MD5Encrypt(SHA512Encrypt(ThreeDESEncrypt(EncrypteValue, Key, IV))));
            
            return strResult;
        }
        /// <summary>
        /// 杭州矢琦成本核算系统用户密码加密算法
        /// </summary>
        /// <param name="UserID">用户编码</param>
        /// <param name="UserName">用户名称</param>
        /// <returns></returns>
        public string BackupDataBaseEncrypt(string UserID, string Password)
        {
            return BackupDataBaseEncrypt(UserID.Trim().ToUpper() + Password);
        }
    }
}
