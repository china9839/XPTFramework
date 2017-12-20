using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 获取标签列表
    /// </summary>
    public class TagListRes : BaseRes
    {
        public List<Tag> taglist { get; set; }
    }

    /// <summary>
    /// 标签
    /// </summary>
    public class Tag
    {
        public int tagid { get; set; }
        public string tagname { get; set; }
    }
}
