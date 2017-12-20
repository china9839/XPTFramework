using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Common
{
    public static class ConstantHelper
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public const string CURRENTADMINUSER = "CURRENTADMINUSER";

        /// <summary>
        /// 当前登录用户实体
        /// </summary>
        public const string CURRENTADMINUSERENTITY = "CURRENTADMINUSERENTITY";

        /// <summary>
        /// 每次登录生成的登录随机字符串
        /// </summary>
        public const string LOGINRANDOMSTR = "LOGINRANDOMSTR";

        /// <summary>
        /// 当前用户权限
        /// </summary>
        public const string CURRENTPERMISSION = "CURRENTPERMISSION";

        /// <summary>
        /// 微信当前userid
        /// </summary>
        public const string WXCURRENTUSERID = "WXCURRENTUSERID";

        /// <summary>
        /// 微信当前USER信息
        /// </summary>
        public const string WXCURRENTUSERINFO = "WXCURRENTUSERINFO";

        /// <summary>
        /// 微信当前USER角色
        /// </summary>
        public const string WXCURRENTUSERROLE = "WXCURRENTUSERROLE";
    }
}
