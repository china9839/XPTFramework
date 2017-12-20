using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    public class Datacube_GetupstreammsgdistweekRes : BaseRes
    {
        public List<Upstreammsgdistweek> list { get; set; }
    }

    public class Upstreammsgdistweek
    {
        public string ref_date { get; set; }
        public int count_interval { get; set; }
        public int msg_user { get; set; }
    }

}
