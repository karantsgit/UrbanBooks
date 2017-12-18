using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using UrbanBooks.Entity;
using UrbanBooks.Common;
using UrbanBooks.Service;

namespace UrbanBooks.Web.Controllers.Admin
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            UsersModel objLogin = new UsersModel();
            HttpCookie objCookie = SessionHelper.GetLoginDetails();
            if (objCookie != null)
            {
                objLogin.EmailAddress = Security.Decrypt(objCookie.Values["Email"].ToString());
                objLogin.Password = Security.Decrypt(objCookie.Values["Password"].ToString());
                objLogin.RememberMe = true;
            }
            ViewBag.Message = "";
            return View(ViewHelper.Login, objLogin);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            this.Session.Abandon();
            return RedirectToAction("Index", ControllerHelper.Login);
        }

        [HttpPost]
        public ActionResult DoLogin(UsersModel model)
        {
            try
            {
                UserSessionDetailsModel objUser = new UserSessionDetailsModel();
                LoginService objLoginService = new LoginService();
                objUser = objLoginService.ValidateUserLogin(model);

                if (objUser != null)
                {
                    //if (objUser.UserId > 0 && objUser.UserStatus == 1)
                    //{
                        if (model.RememberMe == true)
                        {
                            SessionHelper.RememberLoginDetails(Security.Encrypt(model.EmailAddress), Security.Encrypt(model.Password));
                        }
                        else
                        {
                            SessionHelper.ClearCookie("UrbanUserLoginDetails");
                        }
                        SessionHelper.UserId = objUser.UserId;
                        SessionHelper.UserName = objUser.UserName;
                        //SessionHelper.UserDesignation = objUser.DesignationName;
                        //SessionHelper.UserDesignationId = objUser.DesignationId;
                       // SessionHelper.UserRoleId = objUser.RoleId;

                        if (TempData["ReturnURL"] != null && TempData["ReturnURL"].ToString() != "")
                        {
                            return Redirect(TempData["ReturnURL"].ToString());
                        }
                        else
                        {
                            return RedirectToAction("Index", ControllerHelper.Dashboard);

                            //if (objUser.RoleId == 1)
                            //{
                            //    return RedirectToAction("Index", ControllerHelper.Home);
                            //}
                            //else
                            //{
                            //    return RedirectToAction("Index", ControllerHelper.Customer);
                            //}
                        }
                    //}
                    //else
                    //{
                    //    ViewBag.Message = Message.UserNoLongerActive;
                    //}
                }
                else
                {
                    ViewBag.Message = Message.InvalidLoginDetails;
                }

                return View(ViewHelper.Login, model);
            }
            catch (Exception ex)
            {
                NotificationMessage msg = new NotificationMessage(Message.SystemErrorOccurred, Enums.NotifyType.SystemErrorMessage);
                TempData["Message"] = msg;
                return View(ViewHelper.Login, model);
            }
        }
    }
}
