using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRoot.Code;
using BaseFramework.Common;
using BaseFramework.DataAccess;
using BaseFramework.Service.Admin;

namespace WebRoot.Areas.Admin.Controllers
{
    [AdminSessionFilter]
    public class AccountController : BaseAdminController
    {
        public AccountController():base("sysconfig_001")
        {
        }

        // GET: Admin/Account
        public ActionResult AccountIndex()
        {
            return View();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadData(int rows, int page) {
            var total = 0;
            var list = AdminService.Instance.LoadData(rows,page,out total);
            return Json(new { state = 1, rows = list, total = total });
        }

        /// <summary>
        /// 账户信息页面
        /// </summary>
        /// <param name="adminUser"></param>
        /// <returns></returns>
        public ActionResult AccountInfo(string id) {
            var user = new T_AdminUser();
            if (string.IsNullOrEmpty(id))
            {
                user.id = Guid.Empty;
                user.CreateDate = System.DateTime.Now;
                user.Creator = "admin";
                user.PermissionInfo = null;
            }
            else {
                user = AdminService.Instance.GetUserByID(id);
            }
            ViewBag.TreeData = this.GetPermissionInfo(user.PermissionInfo);
            return View(user);
        }

        /// <summary>
        /// 获得权限信息
        /// </summary>
        /// <param name="userPermissionInfo">用户应有权限</param>
        /// <returns></returns>
        private string GetPermissionInfo(string userPermissionInfo) {
            string[] hasPList = null;
            if (!string.IsNullOrEmpty(userPermissionInfo)) {
                hasPList = userPermissionInfo.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            }
            //系统权限
            var pList = System.Web.HttpContext.Current.Application["PERMISSIONINFO"] as List<PermissionInfo>;
            //系统权限初始化选中
            this.SetPermissionInfoChecked(hasPList, pList);
            return Newtonsoft.Json.JsonConvert.SerializeObject(pList);
        }

        /// <summary>
        /// 递归设置用户权限选中
        /// </summary>
        /// <param name="hasPList"></param>
        /// <param name="pList"></param>
        private void SetPermissionInfoChecked(string[] hasPList , List<PermissionInfo> pList) {
            foreach (var m in pList)
            {
                if (hasPList != null && hasPList.Contains(m.Value))
                {
                    m.IsChecked = true;
                }
                else {
                    m.IsChecked = false;
                }
                if (m.ChildPermissionInfo.Count > 0)
                {
                    this.SetPermissionInfoChecked(hasPList, m.ChildPermissionInfo);
                }
            }
        }

        /// <summary>
        /// 保存会议数据
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveAccountInfo(T_AdminUser user) {
            var newPwz = Request.Params["NewPwz"];
            var r = AdminService.Instance.SaveAccountInfo(user, newPwz);
            return Json(new { state = r});
        }

        [HttpPost]
        public ActionResult Remove(string id)
        {
            var r = AdminService.Instance.Remove(id);
            return Json(new { state = r });
        }
    }
}