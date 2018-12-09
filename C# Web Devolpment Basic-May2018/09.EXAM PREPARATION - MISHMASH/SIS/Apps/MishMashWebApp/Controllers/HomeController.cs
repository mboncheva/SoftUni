namespace MishMashWebApp.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;

    public class HomeController : BaseController
    { 
        [HttpGet("/home/index")]
        public IHttpResponse Index()
        {
            if (this.User != null)
            {
                //TODO prepare  view model
                return this.View("Home/LoggedInIndex");
            }
            else
            {
                return this.View("Home/Index");
            }
        }

        [HttpGet("/")]
        public IHttpResponse RootIndex()
        {
            return this.Index();
        }
    }
}
