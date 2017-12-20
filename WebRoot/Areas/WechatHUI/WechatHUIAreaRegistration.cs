using System.Web.Mvc;

namespace WebRoot.Areas.WechatHUI
{
    public class WechatHUIAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WechatHUI";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WechatHUI_default",
                "WechatHUI/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}