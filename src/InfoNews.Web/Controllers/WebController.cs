namespace InfoNews.Web.Controllers
{
    using AttributeRouting.Web.Mvc;
    using InfoNews.Web.Infrastructure;
    using System.Web.Mvc;

    /// <summary>
    /// Contiene contenido común a todos los usuarios
    /// </summary>
    public class WebController : BaseController
    {
        /// <summary>
        /// Pantalla de inicio.
        /// </summary>
        /// <returns>Vista index.</returns>
        [GET("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}