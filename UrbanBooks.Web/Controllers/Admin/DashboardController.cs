using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using UrbanBooks.Entity;
using UrbanBooks.Common;
using UrbanBooks.Service;
using UrbanBooks.Web.Controllers.Admin;

namespace UrbanBooks.Web.Controllers.Admin
{
    public class DashboardController : BaseControllerAdmin
    {
        public ActionResult Index()
        {
            return View(ViewHelper.Dashboard);
        }
    }
}
