using System.Web;
using System.Web.Optimization;

namespace e_Welfare
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Content/js/e-WelfarePopups.js",
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.validate*",
                  "~/Scripts/jquery.unobtrusive*",
                   "~/Content/js/bootstrap/bootstrap.min.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            //"~/Scripts/jquery.unobtrusive*",
            //            //"~/Scripts/jquery.validate*",
            //            "~/Content/js/bootstrap/bootstrap.min.js",
            //               "~/Content/scripts/jquery.validate.js",
            //           "~/Content/scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/css/bootstrap-dialog.min.css",
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/css/plugins/datepicker/datepicker3.min.css",
                      "~/Content/css/plugins/datepicker/datepicker.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jscripts").Include(
                
                 "~/Content/js/bootstrap-dialog.min.js",
            "~/Content/js/plugins/flot/jquery.float.js",
   "~/Content/js/plugins/flot/jquery.float.resize.js",
   "~/Content/js/plugins/flot/jquery.float.tooltip.min.js",
          //"~/Content/js/plugins/morris/morris-data.js",
          //"~/Content/js/plugins/morris/morris.js",
          //"~/Content/js/plugins/morris/morris.min.js",
          "~/Content/js/plugins/datepicker/moment.min.js",
      "~/Content/js/plugins/datepicker/bootstrap-datepicker.min.js"
           //"~/Content/bootstrap.js",
           //"~/Content/bootstrap.min.js"

           ));

        }
    }
}
