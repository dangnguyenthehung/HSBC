using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace HSCB
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/jquery-1.12.4.min.js",
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                "~/Scripts/jquery.easing.1.3.js",
                "~/Scripts/jquery.fancybox.pack.js",
                "~/Scripts/jquery.fancybox-media.js",
                "~/Scripts/google-code-prettify/prettify.js",
                "~/Scripts/portfolio/jquery.quicksand.js",
                "~/Scripts/portfolio/setting.js",
                "~/Scripts/jquery.flexslider.js",
                "~/Content/owlcarousel/owl.carousel.min.js",
                "~/Scripts/custom.js"));


            bundles.Add(new StyleBundle("~/Styles/css").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/flexslider.css",
                "~/Content/css/style.css",
                "~/Content/css/site.css"));

            bundles.Add(new StyleBundle("~/Styles/css/fancybox").Include(
                "~/Content/css/fancybox/jquery.fancybox.css"));

            bundles.Add(new StyleBundle("~/Styles/owlcarousel/assets").Include(
                "~/Content/owlcarousel/assets/owl.carousel.min.css",
                "~/Content/owlcarousel/assets/owl.theme.default.min.css"));

            bundles.Add(new StyleBundle("~/Styles/css/skins").Include(
                "~/Content/css/skins/default.css"));

        }
    }
}