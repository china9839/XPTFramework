using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// news消息体
    /// </summary>
    public class Articles
    {
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string picurl { get; set; }
    }

    /// <summary>
    /// mpnews消息体
    /// </summary>
    public class ArticlesMp : Articles
    {
        public string thumb_media_id { get; set; }
        public string author { get; set; }
        public string content_source_url { get; set; }
        public string content { get; set; }
        public string digest { get; set; }
        public string show_cover_pic { get; set; }
    }
}
