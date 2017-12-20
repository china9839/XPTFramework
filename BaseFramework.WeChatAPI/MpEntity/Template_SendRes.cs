using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 平台消息发送结果
    /// </summary>
    public class Template_SendRes : BaseRes
    {
        public string msgid { get; set; }
    }
}
