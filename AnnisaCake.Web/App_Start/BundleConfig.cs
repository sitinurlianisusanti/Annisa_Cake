using System.Web;
using System.Web.Optimization;

namespace AnnisaCake.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        { 
            ////< !--Bootstrap-- >
            //bundles.Add(new ScriptBundle("~/Content/css/").Include(
            //    "~/Content/vendors/bootstrap/dist/css/bootstrap*"));
            ////   < !--Font Awesome-- >
            //bundles.Add(new ScriptBundle("~/Content/css/").Include(
            //   "~/Content/vendors/font-awesome/css/font-awesome.min.css"));
            ////      < !--NProgress-- >

            //bundles.Add(new ScriptBundle("~/Content/css/").Include(
            //               "~/Content/vendors/nprogress/nprogress.css"));
            ////         < !--iCheck-- >

            //bundles.Add(new ScriptBundle("~/Content/css/").Include(
            //               "~/Content/vendors/iCheck/skins/flat/green.css"));
            ////            < !--bootstrap - progressbar-- >

            //bundles.Add(new ScriptBundle("~/Content/css/").Include(
            //               "~/Content/vendors/bootstrap-progressbar/css/bootstrap-*"));
            ////               < !--JQVMap-- >

            //bundles.Add(new ScriptBundle("~/Content/css/").Include(
            //               "~/Content/vendors/jqvmap/dist/jqvmap.min.css"));
            ////                  < !--bootstrap - daterangepicker-- >

            //bundles.Add(new ScriptBundle("~/Content/css/").Include(
            //               "~/Content/vendors/bootstrap-daterangepicker/daterangepicker.css"));

            ////                     < !--Custom Theme Style -->

            //bundles.Add(new ScriptBundle("~/Content/css/").Include(
            //               "~/Content/build/css/custom.min.css"));

            // default
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
