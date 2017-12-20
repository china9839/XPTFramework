using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    public class Datacube_GetusersharehourRes : BaseRes
    {
        public List<Usersharehour> list { get; set; }
    }

    public class Usersharehour
    {
        public string ref_date { get; set; }
        public int ref_hour { get; set; }
        public int share_scene { get; set; }
        public int share_count { get; set; }
        public int share_user { get; set; }
    }

}
