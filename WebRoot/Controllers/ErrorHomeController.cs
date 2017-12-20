using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRoot.Controllers
{
    public class ErrorHomeController : Controller
    {
        // GET: ErrorHome
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult AuthError()
        {
            return View();
        }
    }
}