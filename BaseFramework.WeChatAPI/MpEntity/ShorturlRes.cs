using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 长连接转短连接
    /// </summary>
    public class ShorturlRes : BaseRes
    {
        public string short_url { get; set; }
    }
}
