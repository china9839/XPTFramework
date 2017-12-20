using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 群发反馈
    /// </summary>
    public class Mass_SendallRes : BaseRes
    {
        public string msg_id { get; set; }
        public string msg_data_id { get; set; }
    }
}
