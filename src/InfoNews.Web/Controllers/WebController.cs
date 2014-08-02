namespace InfoNews.Web.Controllers
{
    using AttributeRouting.Web.Mvc;
    using InfoNews.Web.Infrastructure;

    public class WebController : BaseController
    {
        [GET("")]
        public string Index()
        {
            return "Prueba";
        }
    }
}