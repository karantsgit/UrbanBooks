using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrbanBooks.Common;

namespace UrbanBooks.Web
{
    public static class ExtensionMethods
    {
        public static MvcHtmlString GetResourceValue(this HtmlHelper html, string labelKey)
        {
            var resourceKey = SessionHelper.SelectedLanguageResource.FirstOrDefault(m => m.LabelKey == labelKey);
            if (resourceKey == null)
            {
                resourceKey = SessionHelper.SelectedLanguageResource.FirstOrDefault(m => m.LabelKey == "eng");
            }
            return MvcHtmlString.Create(resourceKey.ResourceValue.ToString());
        }
    }
}