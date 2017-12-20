using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseFramework.Common;
using BaseFramework.DataAccess;

namespace WebRoot.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        protected string permissionCode;

        public BaseAdminController()
        {
        }

        public BaseAdminController(string permissionCode)
        {
            this.permissionCode = permissionCode;
        }

        /// <summary>
        /// 获得当前登录用户实体
        /// </summary>
        protected virtual T_AdminUser GetAdminUser
        {
            get {
                return Session[ConstantHelper.CURRENTADMINUSERENTITY] as T_AdminUser;
            }
        }
    }
}