// ==================================================================================
//
//	文件名(File Name):		
//
//	功能描述(Description):	加密、解密、散列类
//
//	数据表(Tables):			
//
//	作者(Author):			王煜
//
//	日期(Create Date):		2011-5-6
//
//	修改日期(Alter Date):	
//
//	备注(Remark):			
//
// ==================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace StockExplore
{
    /// <summary>
    /// 类名：SysSecurityFactory
    /// 作用：对传入的字符串进行Hash运算，返回通过Hash算法加密过的字串。
    /// 属性：［无］
    /// 构造函数额参数：
    /// IsReturnNum:是否返回为加密后字符的Byte代码
    /// IsCaseSensitive：是否区分大小写。
    /// 方法：此类提供MD5，SHA1，SHA256，SHA512，DES，3DES等几种算法，加密字串的长度依次增大。
    /// </summary>
    public class SysSecurityFactory
    {
        private bool isReturnNum;
        private bool isCaseSensitive;
        private const string _EncryptKey = "ChanFengSanRen026";

        /// <summary>
        /// 对传入的字符串进行Hash运算，返回通过Hash算法加密过的字串。
        /// </summary>
        /// <param name="IsCaseSensitive">是否区分大小写</param>
        /// <param name="IsReturnNum">是否返回为加密后字符的Byte代码</param>
        public SysSecurityFactory(bool IsCaseSensitive = true, bool IsReturnNum = false)
        {
            this.isReturnNum = IsReturnNum;
            this.isCaseSensitive = IsCaseSensitive;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strIN"></param>
        /// <returns></returns>
        private string getstrIN(string strIN)
        {
            //string strIN = strIN;
            if (strIN.Length == 0)
                strIN = "~NULL~";

            if (isCaseSensitive == false)
                strIN = strIN.ToUpper();

            return strIN;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Byte"></param>
        /// <returns></returns>
        private string GetStringValue(byte[] Byte)
        {
            string tmpString = "";

            if (this.isReturnNum == false)
            {
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < Byte.Length; i++)
                    sBuilder.Append(Byte[i].ToString("x2"));

                tmpString = sBuilder.ToString();
            }
            else
            {
                int iCounter;

                for (iCounter = 0; iCounter < Byte.Length; iCounter++)
                    tmpString = tmpString + Byte[iCounter].ToString();
            }

            return tmpString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        private byte[] GetKeyByteArray(string strKey)
        {
            byte[] tmpByte = Encoding.UTF8.GetBytes(strKey);
            return tmpByte;
        }

        #region 散列
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strIN"></param>
        /// <returns></returns>
        public string MD5Encrypt(string strIN)
        {
            strIN = getstrIN(strIN);

            return MD5Encrypt(GetKeyByteArray(getstrIN(strIN)));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytIN"></param>
        /// <returns></returns>
        public string MD5Encrypt(byte[] bytIN)
        {
            byte[] tmpByte;
            MD5 md5 = new MD5CryptoServiceProvider();
            tmpByte = md5.ComputeHash(bytIN);
            md5.Clear();

            return GetStringValue(tmpByte);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strIN"></param>
        /// <returns></returns>
        public string SHA1Encrypt(string strIN)
        {
            strIN = getstrIN(strIN);

            return SHA1Encrypt(GetKeyByteArray(strIN));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytIN"></param>
        /// <returns></returns>
        public string SHA1Encrypt(byte[] bytIN)
        {
            byte[] tmpByte;
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            tmpByte = sha1.ComputeHash(bytIN);
            sha1.Clear();

            return GetStringValue(tmpByte);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strIN"></param>
        /// <returns></returns>
        public string SHA256Encrypt(string strIN)
        {
            strIN = getstrIN(strIN);

            return SHA256Encrypt(GetKeyByteArray(strIN));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytIN"></param>
        /// <returns></returns>
        public string SHA256Encrypt(byte[] bytIN)
        {
            byte[] tmpByte;
            SHA256 sha256 = new SHA256Managed();

            tmpByte = sha256.ComputeHash(bytIN);
            sha256.Clear();

            return GetStringValue(tmpByte);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strIN"></param>
        /// <returns></returns>
        public string SHA512Encrypt(string strIN)
        {
            strIN = getstrIN(strIN);

            return SHA512Encrypt(GetKeyByteArray(strIN));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytIN"></param>
        /// <returns></returns>
        public string SHA512Encrypt(byte[] bytIN)
        {
            byte[] tmpByte;
            SHA512 sha512 = new SHA512Managed();

            tmpByte = sha512.ComputeHash(bytIN);
            sha512.Clear();

            return GetStringValue(tmpByte);
        }
        #endregion 散列

        #region 加解密
        #region DES
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="OriginalValue"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EncryptedValue"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string DESDecrypt(string EncryptedValue, string Key)
        {
            return DESDecrypt(EncryptedValue, Key, Key);
        }
        #endregion DES

        #region TripleDES
        /// <summary>
        /// 使用3DES加密
        /// </summary>
        /// <param name="OriginalValue">待加密的字符串</param>
        /// <param name="Key">密钥(最大长度16)</param>
        /// <param name="IV">初始化向量(最大长度8)</param>
        /// <returns>加密后的字符串</returns>
        public string TripleDESEncrypt(string OriginalValue, string Key, string IV)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OriginalValue"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string TripleDESEncrypt(string OriginalValue, string Key)
        {
            return TripleDESEncrypt(OriginalValue, Key, Key);
        }

        /// <summary>
        /// 使用DES解密
        /// </summary>
        /// <param name="EncryptedValue">待解密的字符串</param>
        /// <param name="Key">密钥(最大长度16)</param>
        /// <param name="IV">m初始化向量(最大长度8)</param>
        /// <returns>解密后的字符串</returns>
        public string TripleDESDecrypt(string EncryptedValue, string Key, string IV)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EncrypteValue"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string TripleDESDecrypt(string EncrypteValue, string key)
        {
            return TripleDESDecrypt(EncrypteValue, key, key);
        }
        #endregion TripleDES

        #region AES
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private AesCryptoServiceProvider GetProvider(byte[] key)
        {
            //Set up the encryption objects
            AesCryptoServiceProvider result = new AesCryptoServiceProvider();
            byte[] RealKey = GetKey(key, result);
            result.Key = RealKey;
            result.IV = RealKey;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="suggestedKey"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private byte[] GetKey(byte[] suggestedKey, AesCryptoServiceProvider p)
        {
            byte[] kRaw = suggestedKey;
            List<byte> kList = new List<byte>();
            for (int i = 0; i < p.LegalKeySizes[0].MinSize / 8; i++)
                kList.Add(kRaw[(i / 8) % kRaw.Length]);

            byte[] k = kList.ToArray();
            return k;
        }

        /// <summary>
        /// Encrypts the sourceString, returns this result as an Aes encrypted, BASE64 encoded string
        ///
        /// a plain, Framework string (ASCII, null terminated)
        /// returns an Aes encrypted, BASE64 encoded string
        /// </summary>
        /// <param name="OriginalValue">OriginalValue</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public string AESEncrypt(string OriginalValue, byte[] key)
        {
            //Set up the encryption objects
            AesCryptoServiceProvider acsp = GetProvider(key);
            byte[] sourceBytes = Encoding.UTF8.GetBytes(OriginalValue); //System.Text.ASCIIEncoding.ASCII.GetBytes(OriginalValue);
            ICryptoTransform ictE = acsp.CreateEncryptor();

            //Set up stream to contain the encryption
            System.IO.MemoryStream msS = new System.IO.MemoryStream();

            //Perform the encrpytion, storing output into the stream
            CryptoStream csS = new CryptoStream(msS, ictE, CryptoStreamMode.Write);
            csS.Write(sourceBytes, 0, sourceBytes.Length);
            csS.FlushFinalBlock();

            //sourceBytes are now encrypted as an array of secure bytes
            byte[] encryptedBytes = msS.ToArray(); //.ToArray() is important, don't mess with the buffer

            //return the encrypted bytes as a BASE64 encoded string
            return System.Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// Decrypts a BASE64 encoded string of encrypted data, returns a plain string
        ///
        /// an Aes encrypted AND base64 encoded string
        /// any byte array (16 bytes long is optimal)
        /// returns a plain string
        /// </summary>
        /// <param name="EncryptedValue">EncryptedValue</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public string AESDecrypt(string EncryptedValue, byte[] key)
        {
            //Set up the encryption objects
            AesCryptoServiceProvider acsp = GetProvider(key);
            byte[] RawBytes = System.Convert.FromBase64String(EncryptedValue);
            ICryptoTransform ictD = acsp.CreateDecryptor();
            //RawBytes now contains original byte array, still in Encrypted state

            //Decrypt into stream
            System.IO.MemoryStream msD = new System.IO.MemoryStream(RawBytes, 0, RawBytes.Length);
            CryptoStream csD = new CryptoStream(msD, ictD, CryptoStreamMode.Read);
            //csD now contains original byte array, fully decrypted

            //return the content of msD as a regular string
            return (new System.IO.StreamReader(csD)).ReadToEnd();
        }
        #endregion AES
        #endregion 加解密

        #region 字符串加解密
        /// <summary>字符串加密
        /// </summary>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public string StringEncrypt(string originalValue)
        {
            byte[] key = Encoding.Default.GetBytes(_EncryptKey);
            return AESEncrypt(originalValue, key);
        }

        /// <summary>字符串解密
        /// </summary>
        /// <param name="encryptedValue"></param>
        /// <returns></returns>
        public string StringDecrypt(string encryptedValue)
        {
            byte[] key = Encoding.Default.GetBytes(_EncryptKey);
            return AESDecrypt(encryptedValue, key);
        }
        #endregion 字符串加解密
    }
}
