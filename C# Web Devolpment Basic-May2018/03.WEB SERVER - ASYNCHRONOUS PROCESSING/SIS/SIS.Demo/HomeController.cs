namespace SIS.Demo
{
    using SIS.HTTP.Responses;
    using SIS.WebServer.Results;
    using System.Net;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            var content = "<h1>Hello World!</h1>";
            return new HtmlResult(content, HttpStatusCode.OK);
        }
    }
}
