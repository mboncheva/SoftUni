namespace CakesWebApp.Controllers
{
    using SIS.HTTP.Requests.Interfaces;
    using SIS.HTTP.Responses.Interfaces;

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            return this.View("Index");
        }
    }
}
