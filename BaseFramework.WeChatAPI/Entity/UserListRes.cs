using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 获取部门成员(详情)
    /// </summary>
    public class UserListRes :  BaseRes
    {
        public List<UserGetRes> userlist { get; set; }
    }
}
