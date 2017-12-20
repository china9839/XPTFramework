using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 获取应用概况列表
    /// </summary>
    public class AgentListRes : BaseRes
    {
        public List<Agentlist> agentlist { get; set; }
    }
    public class Agentlist
    {
        public string agentid { get; set; }
        public string name { get; set; }
        public string square_logo_url { get; set; }
        public string round_logo_url { get; set; }
    }

}
