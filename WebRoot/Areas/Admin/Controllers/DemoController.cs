﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRoot.Areas.Admin.Controllers
{
    public class DemoController : Controller
    {
        // GET: Admin/Demo
        public ActionResult Index()
        {
            return View();
        }
    }
}