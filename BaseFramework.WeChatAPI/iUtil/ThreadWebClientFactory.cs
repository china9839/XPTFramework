using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Remoting.Messaging;

namespace WeChatAPI.iUtil
{
    public class ThreadWebClientFactory
    {
        public const string WEBCLIENT = "WebClient";

        #region 获取一个WebClient对象
        /// <summary>
        /// 获取一个WebClient对象
        /// </summary>
        /// <returns></returns>
        public static TimeoutWebClient GetWebClient()
        {
            return GetWebClient(WEBCLIENT);
        }

        /// <summary>
        /// 获取一个WebClient对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TimeoutWebClient GetWebClient(string key)
        {
            TimeoutWebClient wc = (TimeoutWebClient)CallContext.GetData(key);
            if (wc == null)
            {
                wc = new TimeoutWebClient(100);

                CallContext.SetData(key, wc);
            }
            return wc;
        }
        #endregion
    }


}
