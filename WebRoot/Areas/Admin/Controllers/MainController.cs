using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRoot.Code;
using BaseFramework.Common;
using BaseFramework.Service.Admin;
using WeChatAPI.iUtil;

namespace WebRoot.Areas.Admin.Controllers
{
    public class MainController : BaseAdminController
    {
        #region 系统登录
        /// <summary>
        /// 系统后台登录界面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            Session.Clear();
            Session[ConstantHelper.LOGINRANDOMSTR] = Guid.NewGuid().ToString();
            return View();
        }

        /// <summary>
        /// 用户登录请求
        /// </summary>
        /// <param name="usr"></param>
        /// <param name="pwd"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UserLogin(string usr, string pwd, string random)
        {
            var LoginRandomStr = Session[ConstantHelper.LOGINRANDOMSTR] as string;
            if (string.IsNullOrEmpty(LoginRandomStr) || random != LoginRandomStr)
            {
                // 随机子串过期，需要重新登录
                Session[ConstantHelper.LOGINRANDOMSTR] = Guid.NewGuid().ToString();
                LoginRandomStr = Session[ConstantHelper.LOGINRANDOMSTR] as string;
                return Json(new { state = 2, txt = "页面过期", data = LoginRandomStr });
            }
            var user = AdminService.Instance.Login(usr);
            if (user == null)
            {
                return Json(new { state = 0, txt = "不存在该账号信息" });
            }
            var _pwd = usr + AESHelper.Decrypt(user.Pwz) + LoginRandomStr;
            _pwd = StringHelper.MD5(_pwd);
            if (pwd.ToUpper() == _pwd.ToUpper())
            {
                Session[ConstantHelper.CURRENTPERMISSION] = user.PermissionInfo;
                Session[ConstantHelper.CURRENTADMINUSERENTITY] = user;
                Session[ConstantHelper.CURRENTADMINUSER] = user.UserName;
                return Json(new { state = 1 });
            }
            else
            {
                return Json(new { state = 0, txt = "帐号或密码错误" });
            }
        }

        /// <summary>
        /// 后台管理主页
        /// </summary>
        /// <returns></returns>
        [AdminSessionFilter]
        [HttpGet]
        public ActionResult MainIndex()
        {
            return View();
        }
        #endregion

        #region 转到修改密码页
        /// <summary>
        /// 转到修改密码页
        /// </summary>
        /// <returns></returns>
        [AdminSessionFilter]
        public ActionResult ChangePwd()
        {
            return View();
        }
        #endregion

        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ChangePwd")]
        [AdminSessionFilter]
        public JsonResult _ChangePwd(string old_pwd, string new_pwd)
        {
            var rel = AdminService.Instance.ChangePwd(base.GetAdminUser.id, old_pwd,new_pwd);
            return Json(new { state = rel > 0 ? 1 : 0 });
        }
        #endregion
    }
}