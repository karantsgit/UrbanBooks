using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UrbanBooks.Entity;

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
    }
}
