using System.Web;
using System.Web.Optimization;

namespace ITL_v2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*Scripts*/
            //<!-- BEGIN CORE PLUGINS -->
            bundles.Add(new ScriptBundle("~/bundles/CORE").Include(
                "~/Content/assets/global/plugins/jquery.min.js",
                "~/Content/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                "~/Content/assets/global/plugins/jquery.cokie.min.js",
                "~/Content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/assets/global/plugins/jquery.blockui.min.js",
                "~/Content/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
                ));
            //<!-- END CORE PLUGINS -->
            //<!-- BEGIN PAGE LEVEL SCRIPTS -->
            bundles.Add(new ScriptBundle("~/bundles/PAGE").Include(
                /*morris*/
                "~/Content/assets/global/plugins/morris/morris.min.js",
                "~/Content/assets/global/plugins/morris/raphael-min.js",
                /*counterup*/
                "~/Content/assets/global/plugins/counterup/jquery.counterup.min.js",
                "~/Content/assets/global/plugins/counterup/jquery.waypoints.min.js",
                /*BEGIN DatePicker*/
                "~/Content/assets/global/plugins/moment.min.js",
                "~/Content/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.js",
                /*END DatePicker*/
                /*amcharts*/
                "~/Content/assets/global/plugins/amcharts/amcharts/amcharts.js",
                "~/Content/assets/global/plugins/amcharts/amcharts/serial.js",
                "~/Content/assets/global/plugins/amcharts/amcharts/pie.js",
                "~/Content/assets/global/plugins/amcharts/amcharts/radar.js",
                "~/Content/assets/global/plugins/amcharts/amcharts/themes/light.js",
                "~/Content/assets/global/plugins/amcharts/amcharts/themes/patterns.js",
                "~/Content/assets/global/plugins/amcharts/amcharts/themes/chalk.js",
                "~/Content/assets/global/plugins/amcharts/ammap/ammap.js",
                "~/Content/assets/global/plugins/amcharts/ammap/maps/js/worldLow.js",
                "~/Content/assets/global/plugins/amcharts/amstockcharts/amstock.js",
                /*timeline gantt*/
                "~/Content/assets/global/plugins/horizontal-timeline/horozontal-timeline.min.js",
                /*flot chart*/
                "~/Content/assets/global/plugins/flot/jquery.flot.min.js",
                "~/Content/assets/global/plugins/flot/jquery.flot.resize.min.js",
                "~/Content/assets/global/plugins/flot/jquery.flot.categories.min.js",
                /*easypiechart*/
                "~/Content/assets/global/plugins/jquery-easypiechart/jquery.easypiechart.min.js",
                /*sparkline*/
                "~/Content/assets/global/plugins/jquery.sparkline.min.js"
                ));
                /*MAP*/
                bundles.Add(new ScriptBundle("~/bundles/MAP").Include(
                "~/Content/assets/global/plugins/jqvmap/jqvmap/jquery.vmap.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js",
                      "~/Content/assets/global/plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js"
                
                ));
            //<!-- END PAGE LEVEL SCRIPTS -->
            //<!-- BEGIN THEME LAYOUT SCRIPTS -->
            bundles.Add(new ScriptBundle("~/bundles/LAYOUT").Include(
                "~/Content/assets/global/scripts/metronic.js",
                "~/Content/assets/admin/layout/scripts/layout.js",
                "~/Content/assets/admin/layout/scripts/quick-sidebar.js",
                "~/Content/assets/admin/layout/scripts/demo.js",
                "~/Content/assets/admin/pages/scripts/index.js",
                "~/Content/assets/admin/pages/scripts/tasks.js"
                ));
            //<!-- END THEME LAYOUT SCRIPTS -->

            /*BEGIN Css*/
            //<!-- BEGIN GLOBAL MANDATORY STYLES -->
            bundles.Add(new StyleBundle("~/Content/MANDATORY").Include(
                "~/Content/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                "~/Content/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                "~/Content/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                "~/Content/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
                ));
            //<!-- END PAGE LEVEL PLUGINS -->
            //<!-- BEGIN THEME GLOBAL STYLES -->
            bundles.Add(new StyleBundle("~/Content/THEME").Include(
                "~/Content/assets/global/css/components.min.css",
                "~/Content/assets/global/css/plugins.min.css"
                ));
            //<!-- END THEME GLOBAL STYLES -->
            //<!-- BEGIN PAGE LEVEL PLUGINS -->
            bundles.Add(new StyleBundle("~/Content/PAGE").Include(
                "~/Content/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css",
                "~/Content/assets/admin/pages/css/tasks.css"
                ));
            //<!-- END PAGE LEVEL PLUGINS -->
            //<!-- BEGIN THEME LAYOUT STYLES -->
            bundles.Add(new StyleBundle("~/Content/LAYOUT").Include(
                "~/Content/assets/admin/layout/css/layout.min.css",
                "~/Content/assets/admin/layout/css/themes/darkblue.min.css",
                "~/Content/assets/admin/layout/css/custom.min.css"
                ));
            //<!-- END THEME LAYOUT STYLES -->
            /*END Css*/







            /*
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
            ));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                "~/Content/assets/global/scripts/metronic.js"
                "~/Content/assets/admin/layout/scripts/layout.js",
                "~/Content/assets/admin/layout/scripts/quick-sidebar.js",
                "~/Content/assets/admin/layout/scripts/demo.js",
                "~/Content/assets/admin/pages/scripts/index.js",
                "~/Content/assets/admin/pages/scripts/tasks.js"
            ));
            */

            /*
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
            */
        }
    }
}
