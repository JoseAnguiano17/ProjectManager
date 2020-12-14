using System.Web;
using System.Web.Optimization;

namespace PA2_Final
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/vendor/bootstrap.js",
                        "~/Scripts/vendor/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/4.0/bootstrap.min.css",
                        "~/Content/4.0/bootstrap.css",
                        "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/bundles/js-popper").Include(
                        "~/Scripts/vendor/popper.min.js"));
            bundles.Add(new StyleBundle("~/bundles/js-holder").Include(
                        "~/Scripts/vendor/holder.min.js"));
        }
    }
}
