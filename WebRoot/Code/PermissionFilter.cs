using BaseFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRoot.Code
{
    /// <summary>
    /// 权限过滤
    /// </summary>
    public class PermissionFilter : ActionFilterAttribute
    {
        public string PermissionValue { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase Session = filterContext.HttpContext.Session;
            var permissionString = Session[ConstantHelper.CURRENTPERMISSION].ToString();
            if (!permissionString.Contains(PermissionValue))
            {
                // 反馈给浏览器
                if (filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    filterContext.Result = new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                        {
                            state = -100001,
                            txt = "您没有权限执行当前的操作"
                        }
                    };
                }
                else
                {
                    var viewResult = new ViewResult();
                    viewResult.ViewName = "Error";
                    viewResult.ViewData["errorinfo"] = "您没有权限执行当前的操作!";
                    filterContext.Result = viewResult;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}