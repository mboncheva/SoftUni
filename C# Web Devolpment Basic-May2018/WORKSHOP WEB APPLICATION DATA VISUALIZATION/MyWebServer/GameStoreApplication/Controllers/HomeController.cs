namespace MyWebServer.GameStoreApplication.Controllers
{
    using Server.HTTP.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IHttpRequest request)
            :base(request)
        {
        }

        public IHttpResponse Index()
        {
            return this.FileViewResponse(@"home\index");
        }
    }
}
