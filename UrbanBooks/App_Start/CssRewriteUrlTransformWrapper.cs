using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace UrbanBooks.Web.App_Start
{
    public class CssRewriteUrlTransformWrapper : IItemTransform
    {
        /// <summary>
        /// Process the CSS rewrite Url.
        /// </summary>
        /// <param name="includedVirtualPath">To include virtual path.</param>
        /// <param name="input">CSS file data.</param>
        /// <returns>CSS file data with updated virtual path.</returns>
        public string Process(string includedVirtualPath, string input)
        {
            return new CssRewriteUrlTransform().Process("~" + VirtualPathUtility.ToAbsolute(includedVirtualPath), input);
        }
    }
}