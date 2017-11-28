using System;
using System.IO.Compression;
using System.Net;
using System.Web;
using System.Web.Optimization;
using UrbanBooks.Web.App_Start;

namespace UrbanBooks
{
    #region GZip Compression

    /// <summary>
    /// Class GZipBundle.
    /// </summary>
    public class GZipBundle : Bundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GZipBundle" /> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path used to reference the <see cref="T:System.Web.Optimization.Bundle" /> from within a view or Web page.</param>
        /// <param name="transforms">A list of <see cref="T:System.Web.Optimization.IBundleTransform" /> objects which process the contents of the bundle in the order which they are added.</param>
        public GZipBundle(string virtualPath, params IBundleTransform[] transforms)
            : base(virtualPath, null, transforms)
        {
        }

        /// <summary>
        /// GS the zip encode page.
        /// Sets up the current page or handler to use GZip through a Response.Filter.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        public static void GZipEncodePage(HttpContextBase httpContext)
        {
            if (null != httpContext && null != httpContext.Request && null != httpContext.Response && (null == httpContext.Response.Filter || !(httpContext.Response.Filter is GZipStream || httpContext.Response.Filter is DeflateStream)))
            {
                // Is GZip supported?
                string acceptEncoding = httpContext.Request.Headers["Accept-Encoding"];
                if (null != acceptEncoding && acceptEncoding.IndexOf(DecompressionMethods.GZip.ToString(), StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    httpContext.Response.Filter = new GZipStream(httpContext.Response.Filter, CompressionMode.Compress);
                    httpContext.Response.AddHeader("Content-Encoding", DecompressionMethods.GZip.ToString().ToLowerInvariant());
                }
                else if (null != acceptEncoding && acceptEncoding.IndexOf(DecompressionMethods.Deflate.ToString(), StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    httpContext.Response.Filter = new DeflateStream(httpContext.Response.Filter, CompressionMode.Compress);
                    httpContext.Response.AddHeader("Content-Encoding", DecompressionMethods.Deflate.ToString().ToLowerInvariant());
                }

                // Allow proxy servers to cache encoded and decoded versions separately
                httpContext.Response.AppendHeader("Vary", "Content-Encoding");
            }
        }

        /// <summary>
        /// Overrides this to implement own caching logic.
        /// </summary>
        /// <param name="context">The bundle context.</param>
        /// <returns>A bundle response.</returns>
        public override BundleResponse CacheLookup(BundleContext context)
        {
            if (null != context)
            {
                GZipEncodePage(context.HttpContext);
            }

            return base.CacheLookup(context);
        }
    }

    /// <summary>
    /// Class GZipStyleBundle. This class cannot be inherited.
    /// Represents a bundle that does CSS minification and GZip compression.
    /// </summary>
    public sealed class GZipStyleBundle : GZipBundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GZipStyleBundle"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        /// <param name="transforms">The transforms.</param>
        public GZipStyleBundle(string virtualPath, params IBundleTransform[] transforms)
            : base(virtualPath, transforms)
        {
        }
    }

    /// <summary>
    /// Class GZipScriptBundle. This class cannot be inherited.
    /// Represents a bundle that does JS minification and GZip compression.
    /// </summary>
    public sealed class GZipScriptBundle : GZipBundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GZipScriptBundle"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        /// <param name="transforms">The transforms.</param>
        public GZipScriptBundle(string virtualPath, params IBundleTransform[] transforms)
            : base(virtualPath, transforms)
        {
            this.ConcatenationToken = ";" + Environment.NewLine;
        }
    }

    #endregion

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            bundles.Add(new GZipScriptBundle("~/bundles/common", new JsMinify()).Include("~/Scripts/jquery-1.10.2.min.js", "~/Scripts/Common.js", "~/Scripts/nicescroll.min.js", "~/Scripts/bootbox.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Custom.css"
                      ));

            bundles.Add(new GZipScriptBundle("~/bundles/kendo", new JsMinify()).Include(
              "~/Scripts/kendo.all.min.js",
              "~/Scripts/kendo.aspnetmvc.min.js",
              "~/Scripts/kendo.culture.en-IN.min.js"
             ));

            bundles.Add(new GZipStyleBundle("~/bundles/kendo-css", new CssMinify())
             .Include("~/Content/kendo.common-material.min.css", new CssRewriteUrlTransformWrapper())
             .Include("~/Content/kendo.material.min.css", new CssRewriteUrlTransformWrapper()));


            bundles.Add(new GZipScriptBundle("~/bundles/bootstrap-kendo", new JsMinify()).Include(
             "~/Scripts/bootstrap.min.js",
             "~/Scripts/app.js"));


            bundles.Add(new GZipStyleBundle("~/bundles/common-css", new CssMinify())
            .Include("~/Content/bootbox.css", new CssRewriteUrlTransformWrapper())
                .Include("~/Content/styles.css", new CssRewriteUrlTransformWrapper())
                .Include("~/Content/bootstrap.css", new CssRewriteUrlTransformWrapper())
                .Include("~/Content/core.css", new CssRewriteUrlTransformWrapper())
                .Include("~/Content/components.css", new CssRewriteUrlTransformWrapper())
                .Include("~/Content/colors.css", new CssRewriteUrlTransformWrapper()));


            bundles.Add(new GZipStyleBundle("~/bundles/Client-css", new CssMinify())
          .Include("~/Content/Client_css/bootstrap.min.css", new CssRewriteUrlTransformWrapper())
              .Include("~/Content/Client_css/custom.min.css", new CssRewriteUrlTransformWrapper())
              .Include("~/Content/Client_css/font-awesome.min.css", new CssRewriteUrlTransformWrapper()));

            bundles.Add(new GZipScriptBundle("~/bundles/Client-Script", new JsMinify()).Include(
                "~/Scripts/jquery-1.10.2.min.js",
            "~/Scripts/Client_Script/bootstrap.min.js",
            "~/Scripts/Client_Script/jquery.min.js"));
        }
    }
}
