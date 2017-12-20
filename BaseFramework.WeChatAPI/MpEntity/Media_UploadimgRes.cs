using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 上传图文消息内的图片获取URL
    /// </summary>
    public class Media_UploadimgRes : BaseRes
    {
        public string url { get; set; }
    }
}
