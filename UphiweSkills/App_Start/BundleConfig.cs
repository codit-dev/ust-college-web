using System.Web;
using System.Web.Optimization;

namespace UphiweSkills
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                       "~/Scripts/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/slick").Include(
                       "~/Scripts/Slick/slick*"));


            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/Slick/slick.css",
                      "~/Content/Slick/slick-theme.css",
                      "~/Content/PagedList.css",
                      "~/Scripts/flexslider/flexslider.css",
                      "~/Scripts/pretty-photo/css/prettyPhoto.css",
                      "~/Content/styles.css",
                      "~/Content/my-styles.css"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/Scripts/back-to-top.js",
                      "~/Scripts/jquery-placeholder/jquery.placeholder.js",
                      "~/Scripts/pretty-photo/js/jquery.prettyPhoto.js",
                      "~/Scripts/flexslider/jquery.flexslider-min.js",
                      "~/Scripts/jflickrfeed/jflickrfeed.min.js",
                      "~/Scripts/main.js"));
        }
    }
}
