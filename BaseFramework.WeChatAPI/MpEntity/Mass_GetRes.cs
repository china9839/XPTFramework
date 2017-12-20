using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 群发进度
    /// </summary>
    public class Mass_GetRes : BaseRes
    {
        public string msg_id { get; set; }
        public string msg_status { get; set; }
    }
}
