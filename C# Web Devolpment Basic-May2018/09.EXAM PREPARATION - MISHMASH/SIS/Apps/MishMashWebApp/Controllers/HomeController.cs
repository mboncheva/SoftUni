namespace MishMashWebApp.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;

    public class HomeController : BaseController
    { 
        [HttpGet("/home/index")]
        public IHttpResponse Index()
        {
            return this.View("Home/Index");
        }

        [HttpGet("/")]
        public IHttpResponse RootIndex()
        {
            return this.View("Home/Index");
        }
    }
}
