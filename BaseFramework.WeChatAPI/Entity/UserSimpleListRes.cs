using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 获取部门成员
    /// </summary>
    public class UserSimpleListRes : BaseRes
    {
        public List<UserSimple> userlist { get; set; }
    }

    /// <summary>
    /// 简化企业员工类
    /// </summary>
    public class UserSimple
    {
        public string userid { get; set; }
        public string name { get; set; }
        public int[] department { get; set; }
    }

}
