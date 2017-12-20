using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 发送客服消息
    /// </summary>
    public class Custom_SendRes : BaseRes
    {
        public string msg_id { get; set; }
        public string msg_data_id { get; set; }
    }
}
