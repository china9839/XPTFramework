using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 发送接口说明
    /// </summary>
    public class MessageSendRes : BaseRes
    {
        public string invaliduser { get; set; }
        public string invalidparty { get; set; }
        public string invalidtag { get; set; }
    }
}
