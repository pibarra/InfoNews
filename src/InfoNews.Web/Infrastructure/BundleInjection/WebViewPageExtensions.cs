namespace System.Web.Mvc
{
    using System.IO;
    using System.Web;
    using System.Web.Optimization;

    public static class WebViewPageExtensions
    {
        /// <summary>
        /// Renders any view specific script bundle for the current page.
        /// </summary>
        /// <param name="page">The page to render scripts for.</param>
        /// <returns>A HTML string containing the link tag or tags for the bundle.</returns>
        public static IHtmlString RenderViewScriptBundle(this WebViewPage page)
        {
            return page.RenderViewScriptBundle(false);
        }

        /// <summary>
        /// Renders any view specific script bundle for the current page.
        /// </summary>
        /// <param name="page">The page to render scripts for.</param>
        /// <param name="force_bundle">true to force render bundle; otherwise, false.</param>
        /// <returns>A HTML string containing the link tag or tags for the bundle.</returns>
        public static IHtmlString RenderViewScriptBundle(this WebViewPage page, bool force_bundle)
        {
            //get the view path:
            string viewPath = ((BuildManagerCompiledView)page.ViewContext.View).ViewPath;

            //get the controller:
            string controller = (new DirectoryInfo(Path.GetDirectoryName(viewPath)).Name);

            //get the view name:
            string view = Path.GetFileNameWithoutExtension(viewPath);

            //create the script bundle virtual path:
            string bundleVirtualPath = "~/ViewScripts/" + controller + "/" + view;

            //locate any available bundle:
            string bundle = BundleTable.Bundles.ResolveBundleUrl(bundleVirtualPath, true);

            if (bundle != null) //if bundle exists
                return Scripts.Render(force_bundle ? bundle : bundleVirtualPath);

            return MvcHtmlString.Empty;
        }

        /// <summary>
        /// Renders any view specific style bundle for the current page.
        /// </summary>
        /// <param name="page">The page to render styles for.</param>
        /// <returns>A HTML string containing the link tag or tags for the bundle.</returns>
        public static IHtmlString RenderViewStyleBundle(this WebViewPage page)
        {
            return page.RenderViewStyleBundle(false);
        }

        /// <summary>
        /// Renders any view specific style bundle for the current page.
        /// </summary>
        /// <param name="page">The page to render styles for.</param>
        /// <param name="force_bundle">true to force render bundle; otherwise, false.</param>
        /// <returns>A HTML string containing the link tag or tags for the bundle.</returns>
        public static IHtmlString RenderViewStyleBundle(this WebViewPage page, bool force_bundle)
        {
            //get the view path:
            string viewPath = ((BuildManagerCompiledView)page.ViewContext.View).ViewPath;

            //get the controller:
            string controller = (new DirectoryInfo(Path.GetDirectoryName(viewPath)).Name);

            //get the view name:
            string view = Path.GetFileNameWithoutExtension(viewPath);

            //create the style bundle virtual path:
            string bundleVirtualPath = "~/Content/Assets/" + controller + "/" + view;

            //locate any available bundle:
            string bundle = BundleTable.Bundles.ResolveBundleUrl(bundleVirtualPath, true);

            if (bundle != null) //if bundle exists
                return Styles.Render(force_bundle ? bundle : bundleVirtualPath);

            return MvcHtmlString.Empty;
        }
    }
}
