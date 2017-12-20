using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 发送消息
    /// </summary>
    public class MessageSend
    {
        #region MsgType
        public const string file = "file";
        public const string news = "news";
        public const string mpnews = "mpnews";
        #endregion

        public string touser { get; set; }
        public string toparty { get; set; }
        public string totag { get; set; }
        public string msgtype { get; set; }
        public string agentid { get; set; }
        public string safe { get; set; }

        #region text
        public string content { get; set; }
        #endregion

        #region image voice video file
        public string media_id { get; set; }
        #endregion

        #region video
        public string title { get; set; }
        public string description { get; set; }
        #endregion

        #region news
        public List<Articles> articles { get; set; }
        #endregion

        #region mpnews
        public List<ArticlesMp> articlesMp { get; set; }
        #endregion

    }


}