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
    public class FAQMasterController : BaseControllerAdmin
    {
        FAQService objFAQService = new FAQService();

        public ActionResult Index()
        {
            //BindQuestionList();
            //BindLanguageList();
            return View(ViewHelper.QuestionAnswerMaster);
        }

        public ActionResult Question()
        {
            return View(ViewHelper.QuestionMaster);
        }

        public void BindQuestionList()
        {
            List<FAQQuestionModel> result = new List<FAQQuestionModel>();
            result = objFAQService.GetQuestionList().ToList();
            IEnumerable<SelectListItem> items = result
          .Select(c => new SelectListItem
          {
              Value = c.QuestionId.ToString(),
              Text = c.Question
          });
            ViewBag.QuestionList = items;
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

        public ActionResult GetFAQList(int Question = 0, int Language = 0)
        {
            var result = objFAQService.GetFAQList(Question, Language).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OpenQuestionPopUp(int QuestionId = 0)
        {
            FAQQuestionModel objModel = new FAQQuestionModel();
            if (QuestionId > 0)
            {
                FAQQuestionModel result = new FAQQuestionModel();
                result = objFAQService.GetQuestionByQuestionId(QuestionId);
                objModel = result;
            }
            return View(ViewHelper.AddEditQuestionMaster, objModel);
        }

        public ActionResult GetQuestionList(string Question = null)
        {
            var result = objFAQService.GetQuestionList(Question).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveQuestion(FAQQuestionModel model)
        {
            model.UserId = SessionHelper.UserId;
            var result = objFAQService.AddEditQuestion(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteQuestion(int QuestionId = 0)
        {
            var result = objFAQService.DeleteQuestion(QuestionId, SessionHelper.UserId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // FAQ Portion

        public ActionResult OpenFAQPopUp(int FAQId = 0)
        {
            BindQuestionList();
            BindLanguageList();
            FAQModel objModel = new FAQModel();
            if (FAQId > 0)
            {
                FAQModel result = new FAQModel();
                result = objFAQService.GetFAQByFAQId(FAQId);
                objModel = result;
            }
            return View(ViewHelper.AddEditFAQ, objModel);
        }

        public ActionResult SaveFAQ(FAQModel model)
        {
            model.UserId = SessionHelper.UserId;
            var result = objFAQService.AddEditFAQ(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteFAQ(int FAQId = 0)
        {
            var result = objFAQService.DeleteFAQ(FAQId, SessionHelper.UserId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult OpenQuestionAnswerPopUp(int QuestionId = 0)
        {
            FAQQuestionModel objModel = new FAQQuestionModel();
            return View(ViewHelper.AddEditQuestionAnswer, objModel);
        }

        public ActionResult SaveAnserQuestion(FAQQuestionModel model)
        {
            model.UserId = SessionHelper.UserId;
            var result = objFAQService.AddEditAnswerQuestion(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult OpenQuestionAnswerByLanguangePopUp(int QuestionId = 0)
        {
            BindLanguageList();
            FAQModel objModel = new FAQModel();
            objModel.QuestionId = QuestionId;
            return View(ViewHelper.AddEditQuestionAnswerByLanguange, objModel);
        }

        public ActionResult GetQuestionAnswerByLanguange(int LanguangeId = 0, int QuestionId = 0)
        {
            var result = objFAQService.GetQuestionAnswerByLanguange(LanguangeId, QuestionId);

            if (result == null)
            {
                FAQModel Model = new FAQModel();
                result = Model;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveAnserForLanguage(FAQModel model)
        {
            model.UserId = SessionHelper.UserId;
            var result = objFAQService.AddEditQuestionAnswerByLanguange(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteQuestionAnswer(int QuestionId = 0)
        {
            var result = objFAQService.DeleteQuestionAnswer(QuestionId, SessionHelper.UserId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetQuestionAnswerList(string Question = null)
        {
            var result = objFAQService.GetQuestionAnswerList(Question).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
