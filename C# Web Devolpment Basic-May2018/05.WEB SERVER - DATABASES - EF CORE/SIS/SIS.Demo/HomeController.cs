namespace SIS.Demo
{
    using SIS.HTTP.Requests.Interfaces;
    using SIS.HTTP.Responses.Interfaces;
    using SIS.WebServer.Results;
    using System.Net;

    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            var content = "<h1>Hello World!</h1>";
            return new HtmlResult(content, HttpStatusCode.OK);
        }
    }
}
