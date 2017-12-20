using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    public class Datacube_GetarticletotalRes : BaseRes
    {
        public List<Articletotal> list { get; set; }
    }

    public class Articletotal
    {
        public string ref_date { get; set; }
        public string msgid { get; set; }
        public string title { get; set; }
        public List<Articletotal_Details> details { get; set; }

    }

    public class  Articletotal_Details
    {
        public string stat_date { get; set; }
        public int target_user { get; set; }
        public int int_page_read_user { get; set; }
        public int int_page_read_count { get; set; }
        public int ori_page_read_user { get; set; }
        public int ori_page_read_count { get; set; }
        public int share_user { get; set; }
        public int share_count { get; set; }
        public int add_to_fav_user { get; set; }
        public int add_to_fav_count { get; set; }
    }

}
