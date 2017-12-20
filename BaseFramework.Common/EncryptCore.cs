using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Common
{
    public static class EncryptCore
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        public static string Md5(string orgString)
        {
            byte[] bytes = Encoding.Default.GetBytes(orgString);
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(bytes)).Replace("-", "");
        }

        #region 密钥和向量
        private static byte[] iv = { 89, 33, 12, 34, 45, 56, 67, 78, 89, 91, 102, 113, 124, 135, 146, 157 };
        private static byte[] key = { 2, 21, 28, 73, 47, 95, 96, 79, 98, 93, 102, 114, 251, 133, 142, 157 };
        private static CipherMode cipherMode = CipherMode.CBC;
        private static PaddingMode paddingMode = PaddingMode.PKCS7;
        #endregion

        #region AES加密
        /// <summary>
        /// AES字符串加密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encrypt(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] release = AESEncrypt(data, iv, key, cipherMode, paddingMode);
            return Convert.ToBase64String(release);
        }

        /// <summary>
        /// AES字符串加密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encrypt(string text, byte[] keys)
        {
            var _iv = new byte[16];
            var _key = new byte[16];
            Array.Copy(keys, 0, _iv, 0, 16);
            Array.Copy(keys, 16, _key, 0, 16);

            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] release = AESEncrypt(data, _iv, _key, cipherMode, paddingMode);
            return Convert.ToBase64String(release);
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="inputdata">输入的数据</param>
        /// <param name="iv">向量128位</param>
        /// <param name="strKey">加密密钥</param>
        /// <returns></returns>
        public static byte[] AESEncrypt(byte[] inputdata, byte[] iv, byte[] key, CipherMode cipherMode, PaddingMode paddingMode)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            //设置密钥及密钥向量
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = cipherMode;
            aes.Padding = paddingMode;

            ICryptoTransform transform = aes.CreateEncryptor();
            byte[] data = transform.TransformFinalBlock(inputdata, 0, inputdata.Length);
            aes.Clear();
            return data;

        }
        #endregion

        #region AES解密
        /// <summary>
        /// AES字符串解密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Decrypt(string text)
        {
            try
            {
                byte[] data = Convert.FromBase64String(text);
                byte[] release = AESDecrypt(data, iv, key, cipherMode, paddingMode);
                return Encoding.UTF8.GetString(release);
            }
            catch (Exception e)
            {
                throw new Exception("错误的密文");
            }

        }

        /// <summary>
        /// AES字符串解密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Decrypt(string text, byte[] keys)
        {
            var _iv = new byte[16];
            var _key = new byte[16];
            Array.Copy(keys, 0, _iv, 0, 16);
            Array.Copy(keys, 16, _key, 0, 16);

            try
            {
                byte[] data = Convert.FromBase64String(text);
                byte[] release = AESDecrypt(data, _iv, _key, cipherMode, paddingMode);
                return Encoding.UTF8.GetString(release);
            }
            catch (Exception e)
            {
                throw new Exception("错误的密文");
            }

        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="inputdata">输入的数据</param>
        /// <param name="iv">向量128</param>
        /// <param name="strKey">key</param>
        /// <returns></returns>
        public static byte[] AESDecrypt(byte[] inputdata, byte[] iv, byte[] key, CipherMode cipherMode, PaddingMode paddingMode)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = cipherMode;
            aes.Padding = paddingMode;

            ICryptoTransform transform = aes.CreateDecryptor();
            byte[] data = null;
            data = transform.TransformFinalBlock(inputdata, 0, inputdata.Length);
            aes.Clear();
            return data;
        }
        #endregion
    }
}
