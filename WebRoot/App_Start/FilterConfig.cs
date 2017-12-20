using System.Web;
using System.Web.Mvc;
using WebRoot.Code;

namespace WebRoot
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
        }
    }
}
