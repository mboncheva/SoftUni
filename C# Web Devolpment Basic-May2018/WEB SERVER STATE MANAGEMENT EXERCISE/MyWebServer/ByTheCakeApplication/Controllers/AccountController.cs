﻿namespace MyWebServer.ByTheCakeApplication
{
    using System;
    using Infrastructure;
    using Models;
    using Server.HTTP;
    using Server.HTTP.Responce;
    using Server.HTTP.Contracts;

    public class AccountController : Controller
    {
        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\login");
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            const string formNameKey = "name";
            const string formPasswordKey = "password";

            if (!req.FormData.ContainsKey(formNameKey)
                || !req.FormData.ContainsKey(formPasswordKey))
            {
                return new BadRequestResponse();
            }

            var name = req.FormData[formNameKey];
            var password = req.FormData[formPasswordKey];

            if (string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(password))
            {
                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";

                return this.FileViewResponse(@"account\login");
            }

           req.Session.Add(SessionStore.CurrentUserKey, name);
           req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            return new RedirectResponse("/"); // REDIRECT TO HOME PAGE
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/login");
        }
    }
}
