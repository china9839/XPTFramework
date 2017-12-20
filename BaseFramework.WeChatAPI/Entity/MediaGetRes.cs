using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 获取临时素材文件
    /// </summary>
    public class MediaGetRes : BaseRes
    {
        public string filename { get; set; }
    }
}
