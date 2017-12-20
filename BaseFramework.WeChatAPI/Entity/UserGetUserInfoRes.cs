using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 根据code获取成员信息
    /// </summary>
    public class UserGetUserInfoRes : BaseRes
    {
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public string OpenId { get; set; }
    }
}
