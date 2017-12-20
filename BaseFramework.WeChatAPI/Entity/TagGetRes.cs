using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 获取标签成员
    /// </summary>
    public class TagGetRes :  BaseRes
    {
        public List<UserSimple> userlist { get; set; }
        public List<int> partylist { get; set; }
    }
}
