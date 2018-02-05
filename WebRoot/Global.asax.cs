using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebRoot.Code;
using BaseFramework.Common;
using BaseFramework.DataAccess;
using System.IO;
using System.Xml.Linq;
using WeChatAPI;

namespace WebRoot
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LogHelper.Init();
            //QyApiHandler.Init(ConfigManger.CorpID, ConfigManger.Secret, ConfigManger.agentid);
            this.InitPermission();   
        }

        /// <summary>
        /// 初始化全局菜单权限
        /// </summary>
        protected virtual void InitPermission()
        {
            var permissionXml = System.IO.Path.Combine(Server.MapPath("~/"), "PermissionInfo.xml");
            var xmlLinq = System.Xml.Linq.XDocument.Load(permissionXml);
            var permissionNode = xmlLinq.Element("Permission");
            //权限集合
            var permissionInfoList = new List<PermissionInfo>();
            permissionNode.Elements("p").ToList().ForEach(t=> {
                var permissionInfo = new PermissionInfo() {
                    Name = t.Attribute("name").Value,
                    Value = t.Attribute("value").Value,
                    ChildPermissionInfo = new List<PermissionInfo>()
                };
                //加入二级菜单
                t.Elements("p").ToList().ForEach(child=> {
                    var childPermissionInfo = new PermissionInfo() {
                        Name = child.Attribute("name").Value,
                        Value = child.Attribute("value").Value,
                        ChildPermissionInfo = new List<PermissionInfo>()
                    };
                    permissionInfo.ChildPermissionInfo.Add(childPermissionInfo);
                });
                permissionInfoList.Add(permissionInfo);
            });
            Application["PERMISSIONINFO"] = permissionInfoList;
        }
    }
}
