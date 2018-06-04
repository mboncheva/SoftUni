namespace MyWebServer.Application.Controllers
{
    using Server.Enums;
    using Server.HTTP.Contracts;
    using Server.HTTP.Responce;
    using Application.Views;
  
    public class HomeController
    {
        // GET /
        public IHttpResponse Index()
        {
            ViewResponse response = new ViewResponse(HttpStatusCode.OK, new HomeIndexView());

            //response.Cookies.Add(new HttpCookie("lang", "en"));

            return response;
        }

        // GET /about
        //public IHttpResponse About()
        //{
        //    ViewResponse response = new ViewResponse(HttpStatusCode.OK, new AboutView());

        //  //  response.Cookies.Add(new HttpCookie("lang", "en"));

        //    return response;
        //}

    }
}