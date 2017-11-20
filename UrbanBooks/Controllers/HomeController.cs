using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrbanBooks.Common;
using UrbanBooks.Service;

namespace UrbanBooks.Controllers
{
    public class HomeController : Controller
    {
        DashboardService service = new DashboardService();

        [HttpGet]
        public ActionResult Index()
        {
            SessionHelper.DefaultLanguageResource = service.GetResourceList("eng");
            SessionHelper.SelectedLanguageResource = service.GetResourceList(SessionHelper.SelectedLanguage);
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (!string.IsNullOrWhiteSpace(form["hdSelectedLanguageId"]))
            {
                SessionHelper.SelectedLanguage = form["hdSelectedLanguageId"];
            }
            return RedirectToAction("Index", "Home");
        }
    }
}