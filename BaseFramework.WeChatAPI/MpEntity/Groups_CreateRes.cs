using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 创建组
    /// </summary>
    public class Groups_CreateRes : BaseRes
    {
        public Group group { get; set; }
    }
}
