using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 查询用户所在分组
    /// </summary>
    public class Groups_GetidRes : BaseRes
    {
        public int groupid { get; set; }
    }
}
