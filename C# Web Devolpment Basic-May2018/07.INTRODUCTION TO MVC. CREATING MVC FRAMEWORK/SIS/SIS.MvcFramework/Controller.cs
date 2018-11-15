﻿namespace SIS.MvcFramework
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework.Services;
    using SIS.WebServer.Results;
    using System.Collections.Generic;
    using System.IO;

    public class Controller
    {
        public IHttpRequest Request { get; set; }

        protected IUserCookieService UserCookieService { get; }

        public Controller()
        {
            this.UserCookieService = new UserCookieService();
        }

        protected string GetUsername()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return null;
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-cakes");
            var cookieContent = cookie.Value;
            var userName = this.UserCookieService.GetUserData(cookieContent);
            return userName;

        }

        protected IHttpResponse View(string viewName, IDictionary<string, string> viewBag = null)
        {
            if (viewBag == null)
            {
                viewBag = new Dictionary<string, string>();
            }

            var allContent = this.GetViewContent(viewName, viewBag);
            return new HtmlResult(allContent, HttpResponseStatusCode.Ok);
        }

        protected IHttpResponse BadRequestError(string errorMessage)
        {
            var viewBag = new Dictionary<string, string>();
            viewBag.Add("Error", errorMessage);
            var allContent = this.GetViewContent("Error", viewBag);

            return new HtmlResult(allContent, HttpResponseStatusCode.BadRequest);
        }

        protected IHttpResponse ServerError(string errorMessage)
        {
            var viewBag = new Dictionary<string, string>();
            viewBag.Add("Error", errorMessage);
            var allContent = this.GetViewContent("Error", viewBag);

            return new HtmlResult(allContent, HttpResponseStatusCode.InternalServerError);
        }

        private string GetViewContent(string viewName,
            IDictionary<string, string> viewBag)
        {
            var layoutContent = File.ReadAllText("Views/_Layout.html");
            var content = File.ReadAllText("Views/" + viewName + ".html");
            foreach (var item in viewBag)
            {
                content = content.Replace("@Model." + item.Key, item.Value);
            }

            var allContent = layoutContent.Replace("@RenderBody()", content);
            return allContent;
        }
    }
}
