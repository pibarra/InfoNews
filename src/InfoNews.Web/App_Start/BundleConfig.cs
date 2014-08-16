namespace InfoNews.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Basic").Include(
                            "~/Scripts/jquery-{version}.js",
                            "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/Theme").Include(
                    "~/Content/Bootstrap/bootstrap.css"));


            //register page scripts:
            bundles.RegisterViewScriptBundles();
            //register page styles:
            //bundles.RegisterViewStyleBundles();

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            //BundleTable.EnableOptimizations = true;
        }
    }
}
