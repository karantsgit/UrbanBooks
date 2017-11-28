using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UrbanBooks.Common
{
    public class SessionHelper
    {
        public static string SelectedLanguage
        {
            get
            {
                return HttpContext.Current.Session["SelectedLanguage"] == null ? "eng" : (string)HttpContext.Current.Session["SelectedLanguage"];
            }
            set
            {
                HttpContext.Current.Session["SelectedLanguage"] = value;
            }
        }

        public static List<ResourceModel> DefaultLanguageResource
        {
            get
            {
                return HttpContext.Current.Session["DefaultLanguageResource"] != null ? (List<ResourceModel>)HttpContext.Current.Session["DefaultLanguageResource"] : null;
            }
            set
            {
                HttpContext.Current.Session["DefaultLanguageResource"] = value;
            }
        }

        public static List<ResourceModel> SelectedLanguageResource
        {
            get
            {
                return HttpContext.Current.Session["SelectedLanguageResource"] != null ? (List<ResourceModel>)HttpContext.Current.Session["SelectedLanguageResource"] : null;
            }
            set
            {
                HttpContext.Current.Session["SelectedLanguageResource"] = value;
            }
        }

        public static int UserId
        {
            get
            {
                return HttpContext.Current.Session["UserId"] == null ? 0 : (int)HttpContext.Current.Session["UserId"];
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static string UserName
        {
            get
            {
                return HttpContext.Current.Session["UserName"] == null ? "" : (string)HttpContext.Current.Session["UserName"];
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }

        public static bool ShowMenu
        {
            get
            {
                return HttpContext.Current.Session["ShowMenu"] == null ? true : (bool)HttpContext.Current.Session["ShowMenu"];
            }
            set
            {
                HttpContext.Current.Session["ShowMenu"] = value;
            }
        }


        public static void RememberLoginDetails(string Email, string Password)
        {
            HttpCookie objCookie = HttpContext.Current.Request.Cookies["UrbanUserLoginDetails"] ?? new HttpCookie("UrbanUserLoginDetails");
            objCookie.Values["LastVisit"] = DateTime.Now.ToString();
            objCookie.Values["Email"] = Email;
            objCookie.Values["Password"] = Password;
            objCookie.Expires = DateTime.Now.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

        public static HttpCookie GetLoginDetails()
        {
            HttpCookie objCookie = HttpContext.Current.Request.Cookies["UrbanUserLoginDetails"];
            if (objCookie != null)
            {
                return objCookie;
            }
            return null;
        }

        public static void ClearCookie(string Key)
        {
            HttpCookie objCookie = HttpContext.Current.Request.Cookies[Key] ?? new HttpCookie(Key);
            objCookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }
    }
}
