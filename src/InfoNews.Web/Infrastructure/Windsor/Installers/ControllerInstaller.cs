

namespace InfoNews.Web.Infrastructure.Windsor.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Castle Windsor Controller responsible for registering classes managed by
    /// the IoC container.
    /// 
    /// This implementation registers all MVC Controllers (IController).
    /// </summary>
    public class ControllerInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                     Classes.FromThisAssembly()
                     .BasedOn(typeof(BaseController))
                     .LifestyleTransient());
        }
    }



}