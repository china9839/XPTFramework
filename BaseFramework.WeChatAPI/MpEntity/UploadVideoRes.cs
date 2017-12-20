using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 获取视频资源ID
    /// </summary>
    public class UploadVideoRes : BaseRes
    {
        public string type { get; set; }
        public string media_id { get; set; }
        public string created_at { get; set; }
    }
}
