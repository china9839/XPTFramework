using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 获取客服列表
    /// </summary>
    public class KfAccount_GetkflistRes : BaseRes
    {
        public List<Mp_KF> kf_list { get; set; }
    }

    public class Mp_KF
    {
        public string kf_account { get; set; }
        public string kf_nick { get; set; }
        public string kf_id { get; set; }
        public string kf_headimgurl { get; set; }
    }

}
