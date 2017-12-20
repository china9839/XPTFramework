using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRoot.Code;
using BaseFramework.Common;
using BaseFramework.DataAccess;

namespace WebRoot.Areas.WechatHUI.Controllers
{
#if DEBUG
    //[WxSessionFilter]
#else
    [WxSessionFilter]
#endif
    public class WXBaseController : Controller
    {
        /// <summary>
        /// 获得微信端当前登录用户信息
        /// </summary>
        public virtual string GetUser
        {
            get {
#if DEBUG

                return Session[ConstantHelper.WXCURRENTUSERINFO].ToString();
#else
                return Session[ConstantHelper.WXCURRENTUSERINFO] as T_UserInfo;
#endif
            }
        }
    }
}