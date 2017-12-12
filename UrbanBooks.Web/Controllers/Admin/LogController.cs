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
    public class LogController : BaseControllerAdmin
    {
        LogMasterService objLogMasterService = new LogMasterService();

        public ActionResult Index()
        {
            return View(ViewHelper.LogMaster);
        }

        public ActionResult GetLogList(string IPAddress = null, string FromDate=null, string ToDate=null)
        {
            var result = objLogMasterService.GetLogMasterList(IPAddress,FromDate,ToDate).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
