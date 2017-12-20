using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeChatAPI
{
    public class BusinessBaseException : Exception
    {
        public string ExceptionCode { get; set; }

        public BusinessBaseException(string code)
        {
            ExceptionCode = code;
        }

    }

    public class ExceptionCode
    {
        public const string WechatCannotDelete = "200001";
        public const string DiDiAccessTokenError = "200002";
        public const string InvokeWCFError = "200003";
        public const string InvokeWechatError = "200004";
        public const string InvokeDiDiError = "200005";
        public const string WaitCarError = "200006";
    }
}
