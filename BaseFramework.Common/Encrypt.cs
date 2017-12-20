using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Common
{
    public static class Encrypt
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        public static string Md5(string orgString) {
            byte[] bytes = Encoding.Default.GetBytes(orgString);
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(bytes)).Replace("-", "");
        }
    }
}
