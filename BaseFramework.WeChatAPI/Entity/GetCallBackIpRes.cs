using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 获取微信服务器的ip段
    /// </summary>
    public class GetCallBackIpRes : BaseRes
    {
        public List<string> ip_list { get; set; }
    }
}
