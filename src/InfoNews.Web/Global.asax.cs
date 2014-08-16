namespace InfoNews.Web
{
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using InfoNews.Web.Infrastructure.Windsor.Installers;
    using InfoNews.Web.Windsor;
    using System;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class Global : HttpApplication
    {
        private static IWindsorContainer _container;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InjectContainer();
        }

        
        /// <summary>
        /// Controller for Castle Windsor IoC container
        /// </summary>
        private static void InjectContainer()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());
            _container.Install(new ControllerInstaller());
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        /// <summary>
        /// Destroy Castle Windsor IoC container
        /// </summary>
        protected void Application_End()
        {
            _container.Dispose();
        }
    
    }
}