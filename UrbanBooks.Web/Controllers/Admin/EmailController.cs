using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrbanBooks.Common;
using UrbanBooks.Entity;
using UrbanBooks.Service;
using UrbanBooks.Web.Controllers.Admin;


namespace UrbanBooks.Web.Controllers.Admin
{
    public class EmailController : BaseControllerAdmin
    {
        EmailMasterService objEmailService = new EmailMasterService();

        public ActionResult Index()
        {
            BindLanguageList();
            return View(ViewHelper.EmailMaster);
        }

        public ActionResult OpenEmailMasterPopUp(int EmailId = 0)
        {
            BindLanguageList();
            EmailMasterModel objModel = new EmailMasterModel();
            if (EmailId > 0)
            {
                EmailMasterModel result = new EmailMasterModel();
                result = objEmailService.GetEmailMasterByEmailId(EmailId);
                objModel = result;
            }
            return View(ViewHelper.AddEditEmail, objModel);
        }

        public void BindLanguageList()
        {
            DashboardService objDashboardService = new DashboardService();
            List<LanguageModel> result = new List<LanguageModel>();
            result = objDashboardService.GetLanguageList().ToList();
            IEnumerable<SelectListItem> items = result
          .Select(c => new SelectListItem
          {
              Value = c.LanguageId.ToString(),
              Text = c.LanguageName
          });
            ViewBag.LanguageList = items;
        }

        public ActionResult GetEmailMasterList(int Language = 0)
        {
            var result = objEmailService.GetEmailMasterList(Language).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveEmailMaster(EmailMasterModel model)
        {
            model.UserId = SessionHelper.UserId;
            var result = objEmailService.AddEditEmailMaster(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteEmailMaster(int EmailId = 0)
        {
            var result = objEmailService.DeleteEmailMaster(EmailId, SessionHelper.UserId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
