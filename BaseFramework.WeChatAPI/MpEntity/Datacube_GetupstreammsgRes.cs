using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    public class Datacube_GetupstreammsgRes : BaseRes
    {
        public List<Upstreammsg> list { get; set; }
    }

    public class Upstreammsg
    {
        public string ref_date { get; set; }
        public int msg_type { get; set; }
        public int msg_user { get; set; }
        public int msg_count { get; set; }
    }

}
