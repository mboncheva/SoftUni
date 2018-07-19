namespace MyWebServer.ByTheCakeApplication.Controllers
{
    using Infrastructure;
    using Server.HTTP.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Index() => this.FileViewResponse(@"home\index");


        public IHttpResponse About() => this.FileViewResponse(@"home\about");
    }
}
