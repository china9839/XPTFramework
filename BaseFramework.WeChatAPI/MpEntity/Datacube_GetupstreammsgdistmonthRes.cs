using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    public class Datacube_GetupstreammsgdistmonthRes : BaseRes
    {
        public List<Upstreammsgdistmonth> list { get; set; }
    }

    public class Upstreammsgdistmonth
    {
        public string ref_date { get; set; }
        public int count_interval { get; set; }
        public int msg_user { get; set; }
    }

}
