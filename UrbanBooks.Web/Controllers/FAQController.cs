using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrbanBooks.Common;
using UrbanBooks.Entity;
using UrbanBooks.Service;
using UrbanBooks.Web.Common;


namespace UrbanBooks.Web.Controllers
{
    public class FAQController : Controller
    {
        FAQClientService objFAQService = new FAQClientService();
        public ActionResult Index()
        {
            FAQCLientModel FAQModel = new FAQCLientModel();
            FAQModel = GetFAQList();
            return View(ViewHelper.FAQCLient, FAQModel);
        }

        public FAQCLientModel GetFAQList()
        {
            var result = objFAQService.GetFAQList(SessionHelper.getCurrentLanguageCookiesValues()).ToList();
            FAQCLientModel Model = new FAQCLientModel();
            Model.FAQList = result;
            return Model;
        }
    }
}
