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
    public class LabelResourceController : BaseControllerAdmin
    {

        LabelResourceService objLabelResourceService = new LabelResourceService();

        public ActionResult Index()
        {
            return View(ViewHelper.LabelMaster);
        }

        public ActionResult GetLabelList()
        {
            var result = objLabelResourceService.GetLabelList().ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OpenLabelPopUp(int LabelId = 0)
        {
            LabelModel objModel = new LabelModel();
            if (LabelId > 0)
            {
                LabelModel result = new LabelModel();
                result = objLabelResourceService.GetLabelByLabelId(LabelId);
                objModel = result;
            }
            return View(ViewHelper.AddEditLabel, objModel);
        }

        public ActionResult SaveLabel(LabelModel model)
        {
            model.UserId = SessionHelper.UserId;
            var result = objLabelResourceService.AddEditLabel(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteLabel(int LabelId = 0)
        {
            var result = objLabelResourceService.DeleteLabel(LabelId, SessionHelper.UserId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Label Resource

        public ActionResult AddResource()
        {
            BindLanguageList();
            BindLabelKeyList();
            return View(ViewHelper.Resource);
        }

        public ActionResult GetLabelResourceList(int LabelKey = 0, string Language = null)
        {
            var result = objLabelResourceService.GetLabelResourceList(LabelKey, Language).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OpenLabelResourcePopUp(int ResourceId = 0)
        {
            BindLanguageList();
            BindLabelKeyList();
            LabelResourceModel objModel = new LabelResourceModel();
            if (ResourceId > 0)
            {
                LabelResourceModel result = new LabelResourceModel();
                result = objLabelResourceService.GetLabelResourceByResourceId(ResourceId);
                objModel = result;
            }
            return View(ViewHelper.AddEditResource, objModel);
        }

        public ActionResult SaveLabelResource(LabelResourceModel model)
        {
            model.UserId = SessionHelper.UserId;
            var result = objLabelResourceService.AddEditLabelResource(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteLabelResource(int ResourceId = 0)
        {
            var result = objLabelResourceService.DeleteLabelResource(ResourceId, SessionHelper.UserId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void BindLanguageList()
        {
            DashboardService objDashboardService = new DashboardService();
            List<LanguageModel> result = new List<LanguageModel>();
            result = objDashboardService.GetLanguageList().ToList();
            IEnumerable<SelectListItem> items = result
          .Select(c => new SelectListItem
          {
              Value = c.LanguageCode,
              Text = c.LanguageName
          });
            ViewBag.LanguageList = items;
        }

        public void BindLabelKeyList()
        {
            List<LabelModel> result = new List<LabelModel>();
            result = objLabelResourceService.GetLabelList().ToList();
            IEnumerable<SelectListItem> items = result
          .Select(c => new SelectListItem
          {
              Value = c.LabelId.ToString(),
              Text = c.LabelKey
          });
            ViewBag.LabelKeyList = items;
        }
    }
}
