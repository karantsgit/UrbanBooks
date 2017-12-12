using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrbanBooks.Common;
using UrbanBooks.Service;

namespace UrbanBooks.Web.Controllers
{
    public class CommonController : Controller
    {
        DashboardService service = new DashboardService();
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLanguageList()
        {
            var languageList = service.GetLanguageList();
            return PartialView("_LanguageDropDown", languageList);
        }

        public void SetLanguageResource()
        {
            SessionHelper.DefaultLanguageResource = service.GetResourceList("eng");
            SessionHelper.SelectedLanguageResource = service.GetResourceList(SessionHelper.getCurrentLanguageCookiesValues());
        }
    }
}