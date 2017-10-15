using System.Web;
using System.Web.Optimization;

namespace CoachLancer.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/styles.css"));

            bundles.Add(new StyleBundle("~/Content/css/register").Include(
                "~/Content/register_form.css"));

            bundles.Add(new StyleBundle("~/Content/css/admin").Include(
                "~/Content/bootstrap.css",
                "~/Content/admin.css",
                "~/Content/metisMenu.css",
                "~/Content/jquery-ui.css",
                "~/Content/themes/base/all.css",
                "~/Content/themes/base/datepicker.css",
                "~/Content/DataTables/css/dataTables.bootstrap.css",
                "~/Content/DataTables/css/responsive.bootstrap.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                "~/Scripts/admin.js",
                "~/Scripts/metisMenu.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js",
                "~/Scripts/DataTables/responsive.bootstrap.js",
                "~/Scripts/DataTables/dataTables.responsive.js"));
        }
    }
}
