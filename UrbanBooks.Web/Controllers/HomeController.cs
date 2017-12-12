using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrbanBooks.Common;
using UrbanBooks.Entity;
using UrbanBooks.Service;

namespace UrbanBooks.Web.Controllers
{
    public class HomeController : Controller
    {
        DashboardService service = new DashboardService();

        [HttpGet]
        public ActionResult Index()
        {
            SessionHelper.DefaultLanguageResource = service.GetResourceList("eng");
            SessionHelper.SelectedLanguageResource = service.GetResourceList(SessionHelper.getCurrentLanguageCookiesValues());
            SessionHelper.SetCurrentLanguage(SessionHelper.getCurrentLanguageCookiesValues());
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

        public ActionResult ValidateCommand(string product = "Test Product", string totalPrice = "200", string quantity = "2")
        {
            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandbox"]);
            var paypal = new PayPalModel(useSandbox);

            paypal.item_name = product;
            paypal.amount = totalPrice;
            paypal.item_quantity = quantity;
            return View(paypal);
        }

        public ActionResult RedirectFromPaypal()
        {
            return View();
        }

        public ActionResult CancelFromPaypal()
        {
            return View();
        }

        public ActionResult NotifyFromPaypal()
        {
            return View();
        }

        public ActionResult SaveHeaderInformation(HeaderInformationModel model)
        {
            var success = service.SaveHeaderInformation(model);
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateFillOutFlag(int LogId)
        {
            var success = service.UpdateFillOutFlag(LogId);
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdatePaymentFlag(int LogId)
        {
            var success = service.UpdatePaymentFlag(LogId);
            return Json(success, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UpdateVisitedEndTime(int LogId)
        {
            var success = service.UpdateVisitedEndTime(LogId);
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SavePurchaseOrder(PurchaseModel model)
        {
            var success = service.SavePurchaseOrder(model);
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeLanguageCookies(string LanguageId)
        {
            SessionHelper.SetCurrentLanguage(LanguageId);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }


        public ActionResult OpenPrivacyPopUp()
        {
            return View(ViewHelper.TermsAndCondition);
        }
    }
}