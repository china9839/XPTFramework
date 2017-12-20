using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 创造二维码
    /// </summary>
    public class Qrcode_CreateRes : BaseRes
    {
        public string ticket { get; set; }
        public int expire_seconds { get; set; }
        public string url { get; set; }
    }
}
