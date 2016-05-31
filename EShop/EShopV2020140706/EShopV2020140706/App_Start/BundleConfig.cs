using System.Web;
using System.Web.Optimization;

namespace EShopV2020140706
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
                      "~/Content/nn-styles.css"));


            //Admin Config Css and Javascript
            bundles.Add(new ScriptBundle("~/bundles/bootstrap_js").Include(
                      "~/Scripts/Admin/jquery-1.10.2.min.js",
                      "~/Scripts/Admin/jquery-ui-1.10.1.custom.min.js",
                      "~/Scripts/Admin/jquery-migrate-1.2.1.min.js",
                      "~/Scripts/Admin/jquery.mousewheel.min.js",
                      "~/Scripts/Admin/jquery.cookies.2.2.0.min.js",
                      "~/Scripts/Admin/excanvas.min.js",
                      "~/Scripts/Admin/jquery.flot.js",
                      "~/Scripts/Admin/jquery.flot.stack.js",
                      "~/Scripts/Admin/jquery.flot.pie.js",
                      "~/Scripts/Admin/jquery.flot.resize.js",

                      "~/Scripts/Admin/jquery.sparkline.min.js",
                      "~/Scripts/Admin/fullcalendar.min.js",
                      "~/Scripts/Admin/select2.min.js",
                      "~/Scripts/Admin/uniform.js",
                      "~/Scripts/Admin/jquery.maskedinput-1.3.min.js",

                      "~/Scripts/Admin/jquery.validationEngine-en.js",
                      "~/Scripts/Admin/jquery.validationEngine.js",

                      "~/Scripts/Admin/jquery.mCustomScrollbar.min.js",
                      "~/Scripts/Admin/animated_progressbar.js",

                      "~/Scripts/Admin/jquery.qtip-1.0.0-rc3.min.js",

                       "~/Scripts/Admin/jquery.cleditor.js",
                      "~/Scripts/Admin/jquery.dataTables.min.js",
                      "~/Scripts/Admin/jquery.fancybox.pack.js",

                      "~/Scripts/Admin/jquery.pnotify.min.js",
                      "~/Scripts/Admin/jquery.ibutton.min.js",

                      "~/Scripts/Admin/jquery.scrollUp.min.js",

                      "~/Scripts/Admin/cookies.js",
                      "~/Scripts/Admin/actions.js",
                      "~/Scripts/Admin/charts.js",
                      "~/Scripts/Admin/plugins.js",
                      "~/Scripts/Admin/settings.js"));


            bundles.Add(new StyleBundle("~/Content/AdminCss").Include(
                      "~/Content/AdminCss/stylesheets.css",
                      "~/Content/AdminCss/fullcalendar.print.css"));
        }
    }
}
