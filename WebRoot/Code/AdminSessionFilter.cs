using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseFramework.Common;

namespace WebRoot.Code
{
    /// <summary>
    /// 后台身份认证
    /// </summary>
    public class AdminSessionFilter : ActionFilterAttribute
    {
        #region 进入Action之前进行拦截
        /// <summary>
        /// 进入Action之前进行拦截
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase Session = filterContext.HttpContext.Session;
            var adminUser = Session[ConstantHelper.CURRENTADMINUSER];
            if (adminUser == null)
            {
                //跳到登录页面
                var routeValues = new System.Web.Routing.RouteValueDictionary();
                routeValues.Add("area", "Admin");
                routeValues.Add("controller", "Main");
                routeValues.Add("action", "Login");
                filterContext.Result = new RedirectToRouteResult(routeValues);
            }
        }
        #endregion
    }
}