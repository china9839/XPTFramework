using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 获取成员
    /// </summary>
    public class UserGetRes : BaseRes
    {
        public string userid { get; set; }
        public string name { get; set; }
        public int[] department { get; set; }
        public string position { get; set; }
        public string mobile { get; set; }
        public int gender { get; set; }
        public string email { get; set; }
        public string weixinid { get; set; }
        public string avatar { get; set; }
        public int status { get; set; }
    }
}
