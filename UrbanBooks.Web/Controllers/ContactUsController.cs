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
    public class ContactUsController : Controller
    {
        ContactUsService objContactUsService = new ContactUsService();

        public ActionResult Index()
        {
            DashboardService service = new DashboardService();
            SessionHelper.SelectedLanguageResource = service.GetResourceList(SessionHelper.getCurrentLanguageCookiesValues());
            return View(ViewHelper.ContactUs);
        }

        public ActionResult SaveContactDetail(ContactUsModel model)
        {
            var result = objContactUsService.AddEditContactDetails(model);

            var Emailresult = objContactUsService.GetEmailMasterByLanguageId(model.LanguageId);

            string send = "";
            if (Emailresult != "")
            {
                string bodyTemplate = "Name : " + model.Name;
                bodyTemplate = bodyTemplate + "</br>Email : " + model.Email;
                bodyTemplate = bodyTemplate + "</br>Message : " + model.Message;

                EmailLogModel ModelNew = new EmailLogModel();
                ModelNew.EmailBody = bodyTemplate;
                ModelNew.EmailSubject = "Inquiry";
                ModelNew.ToEmail = Emailresult;
                send = EmailHelper.Send(ModelNew);
            }
            return Json(send, JsonRequestBehavior.AllowGet);
        }
    }
}
