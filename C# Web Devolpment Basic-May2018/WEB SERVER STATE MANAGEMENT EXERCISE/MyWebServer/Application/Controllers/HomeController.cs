namespace MyWebServer.Application.Controllers
{
    using Server.Enums;
    using Server.HTTP.Contracts;
    using Server.HTTP.Responce;
    using Application.Views;
    using Server.HTTP;
    using System;

    public class HomeController
    {
        // GET /
        public IHttpResponse Index()
        {
            var response = new ViewResponse(HttpStatusCode.OK, new HomeIndexView());

            response.Cookies.Add(new HttpCookie("lang", "en"));

            return response;
        }

        public IHttpResponse SessionTest(IHttpRequest request)
        {
            var session = request.Session;

            const string sessionDateKey = "saved_date";

            if (session.Get(sessionDateKey) == null)
            {
                session.Add(sessionDateKey, DateTime.UtcNow);
            }

            return new ViewResponse(
                HttpStatusCode.OK,
                new SessionTestView(session.Get<DateTime>(sessionDateKey)));
        }

    }
}