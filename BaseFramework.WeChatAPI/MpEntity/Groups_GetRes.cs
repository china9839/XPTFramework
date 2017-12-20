using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 获取全部用户分组
    /// </summary>
    public class Groups_GetRes : BaseRes
    {
        public List<Group> groups { get; set; }
    }
}
