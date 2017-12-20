using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    public class Datacube_GetusersummaryRes : BaseRes
    {
        public List<Datacube> list { get; set; }
    }

    public class Datacube
    {
        public string ref_date { get; set; }
        public int user_source { get; set; }
        public int new_user { get; set; }
        public int cancel_user { get; set; }
        public int cumulate_user { get; set; }
    }

}
