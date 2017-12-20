using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseFramework.Common;

namespace WebRoot.Code
{
    /// <summary>
    /// 微信身份认证
    /// </summary>
    public class WxSessionFilter : ActionFilterAttribute
    {
        #region 进入Action之前进行拦截
        /// <summary>
        /// 进入Action之前进行拦截
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase Session = filterContext.HttpContext.Session;
            string openid = Session[ConstantHelper.WXCURRENTUSERID] as string;
            if (string.IsNullOrEmpty(openid))
            {
                // 如果是ajax请求，应直接反馈json提示手动刷新页面
                if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest"
                || filterContext.HttpContext.Request["IsJsonCall"] == "1")
                {
                    filterContext.Result = new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                        {
                            state = 0,
                            txt = "操作失败！页面超时失效，请重新打开当前页面"
                        }
                    };
                }
                else
                {

                    // 还未通过oauth2取得openid
                    var Response = filterContext.HttpContext.Response;
                    var state = filterContext.HttpContext.Request.RawUrl;
                    var redirect_uri = ConfigManger.WebSiteUrl + ConfigManger.VirtualUrl + "/OAuth2/Index";
                    redirect_uri = HttpUtility.UrlEncode(redirect_uri);

                    state = state.Replace('/', '|');
                    var oauth2url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid="
                        + ConfigManger.CorpID + "&redirect_uri="
                        + redirect_uri + "&response_type=code&scope=snsapi_base&state=" + state + "#wechat_redirect";

                    filterContext.Result = new RedirectResult(oauth2url);
                }
            }
        }
        #endregion
    }
}