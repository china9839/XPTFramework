using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 获取异步任务结果
    /// </summary>
    public class BatchGetResultRes : BaseRes
    {
        public int status { get; set; }
        public string type { get; set; }
        public int total { get; set; }
        public int percentage { get; set; }
        public int remaintime { get; set; }
        public List<BathResult> result { get; set; }
    }

    /// <summary>
    /// 异步结果
    /// </summary>
    public class BathResult
    {
        public string userid { get; set; }
        public int invitetype { get; set; }

        public int action { get; set; }

        public int partyid { get; set; }

        public int errcode { get; set; }
        public string errmsg { get; set; }
    }
}
