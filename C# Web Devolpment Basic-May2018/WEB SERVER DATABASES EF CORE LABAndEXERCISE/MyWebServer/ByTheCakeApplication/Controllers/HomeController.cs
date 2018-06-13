﻿namespace MyWebServer.ByTheCakeApplication
{
    using Infrastructure;
    using Server.HTTP.Contracts;

    public class HomeController : Controller
    {
        public IHttpResponse Index() => this.FileViewResponse(@"home\index");


        public IHttpResponse About() => this.FileViewResponse(@"home\about");
    }
}
