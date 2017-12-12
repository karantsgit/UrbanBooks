
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UrbanBooks.Common;

namespace UrbanBooks.Web.Controllers.Admin
{
    public class BaseControllerAdmin : Controller
    {
        #region

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = System.Web.HttpContext.Current;
            string ControllerName = filterContext.Controller.ToString().ToLower();
            string ActionName = filterContext.ActionDescriptor.ActionName.ToString().ToLower();

            if ((int)SessionHelper.UserId > 0)
            {
                //if (SessionHelper.RoleId != 1)
                //{
                //    if (ControllerName.IndexOf("DashBoard") != -1)
                //    {
                //        filterContext.Result = new RedirectResult("~/DashBoard/Index");
                //    }
                //}

                //if (ControllerName.IndexOf("error") == -1 && !AuthorizationHelper.IsAuthorized(filterContext))
                //{
                //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Error" }, { "Action", "Error403" } });
                //}
            }
            else
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new HttpStatusCodeResult(401, "Unauthorized, Access Denied!");
                }
                else
                {
                    string url = filterContext.HttpContext.Request.RawUrl.ToString();
                    if (url.ToLower().IndexOf("login") == -1 && url != "/")
                    {
                        TempData["ReturnURL"] = url;
                    }
                    else
                    {
                        TempData["ReturnURL"] = "";
                    }
                    filterContext.Result = new RedirectResult("~/Login");
                }
                return;
            }

            //if ((ControllerName.IndexOf("vehicle") != -1 && ActionName.IndexOf("index") != -1) || (ActionName.IndexOf("index") != -1 && ControllerName.IndexOf("dealer") != -1))
            //{
            //    SessionHelper.ShowMenu = false;
            //}
            //else
            //{
            //    SessionHelper.ShowMenu = true;
            //}

            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
            base.OnActionExecuting(filterContext);
        }

        #endregion
    }
}