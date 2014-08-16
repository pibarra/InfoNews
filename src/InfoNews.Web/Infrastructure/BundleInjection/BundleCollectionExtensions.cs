namespace System.Web.Optimization
{
    using System.IO;
    using System.Web.Hosting;

    public static class BundleCollectionExtensions
    {
        /// <summary>
        /// Registers script bundles for views.
        /// </summary>
        /// <param name="bundle">The BundleCollection to add script bundles to.</param>
        public static void RegisterViewScriptBundles(this BundleCollection bundle)
        {
            bundle.RegisterViewBundles(".js");
        }

        /// <summary>
        /// Registers style bundles for views.
        /// </summary>
        /// <param name="bundle">The BundleCollection to add style bundles to.</param>
        public static void RegisterViewStyleBundles(this BundleCollection bundle)
        {
            bundle.RegisterViewBundles(".css");
        }

        /// <summary>
        /// Registers script or style bundles for views.
        /// </summary>
        /// <param name="bundle">The BundleCollection to add script or style bundles to.</param>
        /// <param name="extension">The file extension to use to add files.</param>
        /// <exception cref="ArgumentException"></exception>
        private static void RegisterViewBundles(this BundleCollection bundle, string extension)
        {
            //defines a path to the assets folder:
            const string virtualPath = "~/ViewScripts/";

            bool java;
            switch (extension.ToLower())
            {
                case ".js": //JavaScript file
                    java = true;
                    break;
                case ".css": //Cascading Style Sheet file
                    java = false;
                    break;
                default:
                    throw new ArgumentException("Invalid extension specified: '" + extension + "'.");
            }

            string path = HostingEnvironment.MapPath(virtualPath); //get file path of asset folder

            if (Directory.Exists(path)) //if asset folder exists
            {
                string viewsDirectory = HostingEnvironment.MapPath("~/Views"); //get views directory
                
                foreach (string viewPath in Directory.GetDirectories(path)) //get all asset controller file paths
                {
                    string controllerName = (new DirectoryInfo(viewPath)).Name; //get the controller name
                    string controllerDirectory = Path.Combine(viewsDirectory, controllerName); //create the controller directory containing views

                    if (Directory.Exists(controllerDirectory)) //if controller directory exists
                    {
                        //validate each JavaScript or CSS file looking for a corresponding view
                        foreach (string filePath in Directory.GetFiles(viewPath, "*" + extension)) //get all java or css files for the view
                        {
                            string viewFileName = Path.GetFileName(filePath); //get view file name
                            string viewName = Path.GetFileNameWithoutExtension(viewFileName); //get view name
                            string viewFilePath = Path.Combine(controllerDirectory, viewName); //get view file path

                            if (File.Exists(viewFilePath + ".cshtml") || File.Exists(viewFilePath + ".aspx")) //if view file exists
                            {
                                string actualVirtualPropPath = virtualPath + "/" + controllerName + "/" + viewFileName; //setup virtual path to asset

                                if (java) //if java, register ScriptBundle
                                    bundle.Add(new ScriptBundle("~/ViewScripts/" + controllerName + "/" + viewName).Include(actualVirtualPropPath));
                                else //otherwise register StyleBundle
                                    bundle.Add(new StyleBundle("~/Content/Assets/" + controllerName + "/" + viewName).Include(actualVirtualPropPath));
                            }
                        }
                    }
                }
            }
        }
    }
}
