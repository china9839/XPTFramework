using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    public class CustomSend
    {
        #region MsgType
        public const string text = "text";
        public const string image = "image";
        public const string voice = "voice";
        public const string video = "video";
        public const string music = "music";
        public const string file = "file";
        public const string news = "news";
        public const string mpnews = "mpnews";
        #endregion

        public string touser { get; set; }
        public string msgtype { get; set; }

        #region text
        public string content { get; set; }
        #endregion

        #region image voice video music mpnews
        public string media_id { get; set; }
        #endregion

        #region video music
        public string thumb_media_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        #endregion

        #region music
        public string musicurl { get; set; }
        public string hqmusicurl { get; set; }
        #endregion

        #region news
        public List<Articles> articles { get; set; }
        #endregion

        #region wxcard
        public string card_id { get; set; }
        public CardExt card_ext { get; set; }
        #endregion

        #region customservice
        public string kf_account { get; set; }
        #endregion
    }
}
