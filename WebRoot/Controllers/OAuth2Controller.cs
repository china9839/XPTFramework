using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRoot.Code;
using BaseFramework.Common;
using BaseFramework.DataAccess;
using WeChatAPI;

namespace WebRoot.Controllers
{
    public class OAuth2Controller : Controller
    {
        #region WxOauth2获取当前人基本信息
        /// <summary>
        /// WxOauth2获取当前人基本信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ActionResult Index(string code, string state)
        {
            QyApiHandler handler = QyApiHandler.Instance;
            var wxuser = handler.User_GetUserInfo(code);
            if (wxuser == null || string.IsNullOrEmpty(wxuser.UserId))
            {
                // 提示：你没有权限  
                //throw new Exception("你没有权限");
                Response.Redirect("~/ErrorHome/AuthError", true);
                return null;
            }
            Session[ConstantHelper.WXCURRENTUSERID] = wxuser.UserId;
            Session[ConstantHelper.WXCURRENTUSERINFO] = wxuser;
            // 重定向到应有的界面
            var url = ConfigManger.WebSiteUrl + state.Replace('|', '/');
            Response.Redirect(url, true);
            return null;
        }
        #endregion
    }
}