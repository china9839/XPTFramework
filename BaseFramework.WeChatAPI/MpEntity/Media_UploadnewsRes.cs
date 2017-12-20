using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 上传多图文素材
    /// </summary>
    public class Media_UploadnewsRes : BaseRes
    {
        public string type { get; set; }
        public string media_id { get; set; }
        public string created_at { get; set; }
    }
}
