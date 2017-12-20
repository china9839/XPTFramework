using BaseFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public static class MVCExtends
    {
        /// <summary>
        /// 节点权限
        /// </summary>
        /// <param name="mvcExtends"></param>
        /// <param name="permissionValue">权限值</param>
        /// <param name="has_out_htmlString">有权限输出的html</param>
        /// <param name="nohas_out_htmlString">没有权限输出的html</param>
        /// <returns></returns>
        public static IHtmlString ElementPermission(this HtmlHelper htmlHelper, string permissionValue, string has_out_htmlString, string nohas_out_htmlString = "")
        {
            var userP = System.Web.HttpContext.Current.Session[ConstantHelper.CURRENTPERMISSION] ?? "";
            var hasPList = userP.ToString().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            var hasp = hasPList.Contains(permissionValue);
            if (hasp)
            {
                return htmlHelper.Raw(has_out_htmlString);
            }
            else {
                return htmlHelper.Raw(nohas_out_htmlString);
            }
        }

        /// <summary>
        /// 判断是否有权限
        /// </summary>
        /// <param name="mvcExtends"></param>
        /// <param name="permissionValue">权限值</param>
        /// <returns></returns>
        public static bool HasPermission(this HtmlHelper htmlHelper, string permissionValue)
        {
            var userP = System.Web.HttpContext.Current.Session[ConstantHelper.CURRENTPERMISSION] ?? "";
            var hasPList = userP.ToString().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            return hasPList.Contains(permissionValue);
        }
    }
}