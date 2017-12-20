using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 增加标签成员
    /// </summary>
    public class TagAddtagUsersRes : BaseRes
    {
        public string invalidlist { get; set; }
        public List<int> invalidparty { get; set; }
    }
}
