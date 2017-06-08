using System.Web;
using System.Web.Optimization;

namespace TaskManagerMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
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
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/themeStyle").Include(
                       "~/Content/assets/css/main.css",
                      "~/Content/assets/css/style-switcher.css",
                      "~/Content/assets/css/theme.css",
                      "~/Content/assets/css/countdown.css",
                      "~/Content/assets/lib/bootstrap/css/bootstrap.css",
                      "~/Content/assets/lib/font-awesome/css/font-awesome.css",
                      "~/Content/assets/lib/metismenu/metisMenu.css",
                      "~/Content/assets/lib/onoffcanvas/onoffcanvas.css",
                      "~/Content/assets/lib/animate.css/animate.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/themeScripts").Include(
                "~/Content/assets/lib/jquery/jquery.js",
                "~/Content/assets/lib/bootstrap/js/bootstrap.js",
                "~/Content/assets/lib/metismenu/metisMenu.js",
                "~/Content/assets/lib/onoffcanvas/onoffcanvas.js",
                "~/Content/assets/lib/screenfull/screenfull.js",
                       "~/Content/assets/js/app.js",
                      "~/Content/assets/js/core.js",
                      "~/Content/assets/js/countdown.js",
                      "~/Content/assets/css/style-switcher.js"));

            
        }
    }
}
