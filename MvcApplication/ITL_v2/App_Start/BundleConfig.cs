using System.Web;
using System.Web.Optimization;

namespace ITL_v2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                 "~/Content/assets/global/plugins/jquery.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/plugin").Include(
                "~/Content/assets/global/plugins/jquery-migrate.min.js",
                      "~/Content/assets/global/plugins/jquery-ui/jquery-ui.min.js",
                      "~/Content/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                      "~/Content/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                      "~/Content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                      "~/Content/assets/global/plugins/jquery.blockui.min.js",
                      "~/Content/assets/global/plugins/jquery.cokie.min.js",
                      "~/Content/assets/global/plugins/uniform/jquery.uniform.min.js",
                      "~/Content/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/jquery.vmap.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js",
                      "~/Content/assets/global/plugins/flot/jquery.flot.min.js",
                      "~/Content/assets/global/plugins/flot/jquery.flot.resize.min.js",
                      "~/Content/assets/global/plugins/flot/jquery.flot.categories.min.js",
                      "~/Content/assets/global/plugins/jquery.pulsate.min.js",
                      "~/Content/assets/global/plugins/bootstrap-daterangepicker/moment.min.js",
                      "~/Content/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.js",
                      "~/Content/assets/global/plugins/fullcalendar/fullcalendar.min.js",
                      "~/Content/assets/global/plugins/jquery-easypiechart/jquery.easypiechart.min.js",
                      "~/Content/assets/global/plugins/jquery.sparkline.min.js",
                      "~/Content/assets/global/scripts/metronic.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                "~/Content/assets/admin/layout/scripts/layout.js",
                "~/Content/assets/admin/layout/scripts/quick-sidebar.js",
                "~/Content/assets/admin/layout/scripts/demo.js",
                "~/Content/assets/admin/pages/scripts/index.js",
                "~/Content/assets/admin/pages/scripts/tasks.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                      "~/Content/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                      "~/Content/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                      "~/Content/assets/global/plugins/uniform/css/uniform.default.css",
                      "~/Content/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css",
                      "~/Content/assets/global/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css",
                      "~/Content/assets/global/plugins/fullcalendar/fullcalendar.min.css",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/jqvmap.css",
                      "~/Content/assets/admin/pages/css/tasks.css",
                      "~/Content/assets/global/css/components.css",
                      "~/Content/assets/global/css/plugins.css",
                      "~/Content/assets/admin/layout/css/layout.css",
                      "~/Content/assets/admin/layout/css/themes/darkblue.css",
                      "~/Content/assets/admin/layout/css/custom.css"
            ));
        }
    }
}
