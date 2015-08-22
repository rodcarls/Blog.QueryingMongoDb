using System.Web;
using System.Web.Optimization;

namespace Blog.QueryingMongoDb
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Description/css").Include("~/Description/site.css"));

            bundles.Add(new StyleBundle("~/Conte/themes/base/css").Include(
                        "~/Description/themes/base/jquery.ui.core.css",
                        "~/Description/themes/base/jquery.ui.resizable.css",
                        "~/Description/themes/base/jquery.ui.selectable.css",
                        "~/Description/themes/base/jquery.ui.accordion.css",
                        "~/Description/themes/base/jquery.ui.autocomplete.css",
                        "~/Description/themes/base/jquery.ui.button.css",
                        "~/Description/themes/base/jquery.ui.dialog.css",
                        "~/Description/themes/base/jquery.ui.slider.css",
                        "~/Description/themes/base/jquery.ui.tabs.css",
                        "~/Description/themes/base/jquery.ui.datepicker.css",
                        "~/Description/themes/base/jquery.ui.progressbar.css",
                        "~/Description/themes/base/jquery.ui.theme.css"));
        }
    }
}