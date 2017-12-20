using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.iUtil;

namespace BaseFramework.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("123456 AES加密后是:::{0}", AESHelper.Encrypt("123456"));
            Console.ReadLine();
        }
    }
}
