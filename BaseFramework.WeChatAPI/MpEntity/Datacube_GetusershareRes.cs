using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    public class Datacube_GetusershareRes : BaseRes
    {
        public List<Usershare> list { get; set; }
    }

    public class Usershare
    {
        public string ref_date { get; set; }
        public int share_scene { get; set; }
        public int share_count { get; set; }
        public int share_user { get; set; }
    }

}
