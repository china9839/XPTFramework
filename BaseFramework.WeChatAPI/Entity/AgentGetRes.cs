using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 获取企业号应用
    /// </summary>
    public class AgentGetRes : BaseRes
    {
        public string agentid { get; set; }
        public string name { get; set; }
        public string square_logo_url { get; set; }
        public string round_logo_url { get; set; }
        public string description { get; set; }

        public Allow_userinfos allow_userinfos { get; set; }
        public Allow_partys allow_partys { get; set; }
        public Allow_tags allow_tags { get; set; }

        public int close { get; set; }
        public string redirect_domain { get; set; }
        public int report_location_flag { get; set; }
        public int isreportuser { get; set; }
        public int isreportenter { get; set; }
    }

    public class Allow_userinfos
    {
        public List<User> user { get; set; }

    }

    public class User
    {
        public string userid { get; set; }
        public string status { get; set; }
    }

    public class Allow_partys
    {
        public List<int> partyid { get; set; }
    }

    public class Allow_tags
    {
        public List<int> tagid { get; set; }
    }

}
