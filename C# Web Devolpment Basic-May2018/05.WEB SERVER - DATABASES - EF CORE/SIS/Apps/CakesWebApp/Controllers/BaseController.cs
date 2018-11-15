using CakesWebApp.Data;
using CakesWebApp.Services;
using SIS.HTTP.Cookies;
using SIS.HTTP.Requests.Interfaces;
using SIS.HTTP.Responses.Interfaces;
using SIS.WebServer.Results;
using System.IO;
using System.Net;

namespace CakesWebApp.Controllers
{
    public abstract class BaseController
    {
        protected CakesDbContext Db { get; }
        protected IUserCookieService userCookieService { get; }

        protected BaseController()
        {
            this.Db = new CakesDbContext();
            this.userCookieService = new UserCookieService();

        }

        protected string GetUsername(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return null;
            }

            var cookie = request.Cookies.GetCookie(".auth-cakes");
            var cookieContent = cookie.Value;
            var username = this.userCookieService.GetUserData(cookieContent);
            return username;
        }

        protected IHttpResponse View(string viewName)
        {
            var content = File.ReadAllText("Views/" + viewName + ".html");

            return new HtmlResult(content, HttpStatusCode.OK);
        }

        protected void SignInUser(string username, IHttpResponse response)
        {
            var cookieContent = this.userCookieService.GetUserCookie(username);
            var cookie = new HttpCookie(".auth-cakes", cookieContent);
            cookie.HttpOnly = true;
            response.Cookies.Add(cookie);
        }

        protected IHttpResponse BadRequestError(string errorMessage)
        {
            return new HtmlResult($"<h1>{errorMessage}</h1>", HttpStatusCode.BadRequest);
        }

        protected IHttpResponse ServerError(string errorMessage)
        {
            return new HtmlResult($"<h1>{errorMessage}</h1>", HttpStatusCode.InternalServerError);
        }

    }
}
