using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 上传临时素材文件
    /// </summary>
    public class MediaUploadRes : BaseRes
    {
        public string type { get; set; }
        public string media_id { get; set; }
        public string created_at { get; set; }
    }
}
