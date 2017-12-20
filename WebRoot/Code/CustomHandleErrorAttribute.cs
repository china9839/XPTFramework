using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseFramework.Common;

namespace WebRoot.Code
{
    /// <summary>
    /// 自定义异常类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                this.SaveExceptionAndError(filterContext);
                //跳转到错误页面
                var routeValues = new System.Web.Routing.RouteValueDictionary();
                routeValues.Add("area", null);
                routeValues.Add("controller", "ErrorHome");
                routeValues.Add("action", "Error");
                filterContext.Result = new RedirectToRouteResult(routeValues);
                filterContext.ExceptionHandled = true;
            }
            base.OnException(filterContext);
        }
        private void SaveExceptionAndError(ExceptionContext exceptionContext)
        {
            string errortime = string.Empty;
            string erroraddr = string.Empty;
            string errorinfo = string.Empty;
            string errorsource = string.Empty;
            string errortrace = string.Empty;
            errortime = "发生时间: " + System.DateTime.Now.ToString();
            erroraddr = "异常位置: " + exceptionContext.RequestContext.HttpContext.Request.Url.ToString();
            errorinfo = "异常信息: " + exceptionContext.Exception.Message;
            errorsource = "错误源:" + exceptionContext.Exception.Source;
            errortrace = "堆栈信息:" + exceptionContext.Exception.StackTrace;
            var errorinfoStr = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}",System.Environment.NewLine,
                errortime,
                erroraddr,
                errorinfo,
                errorsource,
                errortrace);
            LogHelper.Error(errorinfoStr, exceptionContext.Exception);
        }
    }
}