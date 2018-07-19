namespace MyWebServer.GameStoreApplication
{
    using Data;
    using Controllers;
    using ViewModels.Account;
    using ViewModels.Admin;
    using Server.Contracts;
    using Server.Routing.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;

    public class GameStoreApp : IApplication
    {
        public void InitializeDatabase()
        {
            using (var db = new GameStoreDbContext())
            {
                db.Database.Migrate();
            }
        }

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AnonymousPaths.Add("/");
            appRouteConfig.AnonymousPaths.Add("/register");
            appRouteConfig.AnonymousPaths.Add("/login");

            appRouteConfig.Get("/", req => new HomeController(req).Index());

            appRouteConfig.Get("/register", req => new AccountController(req).Register());

            appRouteConfig
                .Post("/register", req => new AccountController(req).Register(
                    new RegisterViewModel
                    {
                        FullName = req.FormData["full-name"],
                        Email = req.FormData["email"],
                        Password = req.FormData["password"],
                        ConfirmPassword = req.FormData["confirm-password"]
                    }
                ));

            appRouteConfig.Get("/login", req => new AccountController(req).Login());

            appRouteConfig.Post("/login", req => new AccountController(req).Login(
                 new LoginViewModel
                 {
                     Email = req.FormData["email"],
                     Password = req.FormData["password"]
                 }));

            appRouteConfig.Get("/logout", req => new AccountController(req).Logout());

            appRouteConfig.Get("/admin/games/add", req => new AdminController(req).Add());

            appRouteConfig.Post("/admin/games/add", req => new AdminController(req).Add(
                 new AdminAddGameViewModel
                 {
                     Title = req.FormData["title"],
                     Description = req.FormData["description"],
                     ImageUrl = req.FormData["thumbnail"],
                     Price = decimal.Parse(req.FormData["price"]),
                     Size = double.Parse(req.FormData["size"]),
                     VideoId = req.FormData["video-id"],
                     ReleaseDate = DateTime.ParseExact(
                         req.FormData["release-date"],
                         "yyyy-MM-dd",
                         CultureInfo.InvariantCulture)
                 }));

            appRouteConfig.Get("/admin/games/list", req => new AdminController(req).List());

            appRouteConfig.Get("/admin/games/edit/{(?<id>[0-9]+)}", req => new AdminController(req).Edit());

            appRouteConfig.Post("/admin/games/edit/{(?<id>[0-9]+)}", req => new AdminController(req).Edit(
                 new AdminEditGameViewModel
                 {
                      Id= int.Parse(req.UrlParameters["id"]),
                     Title = req.FormData["title"],
                     Description = req.FormData["description"],
                     ImageUrl = req.FormData["thumbnail"],
                     VideoId = req.FormData["video-id"],
                     Price = decimal.Parse(req.FormData["price"]),
                     Size = double.Parse(req.FormData["size"]),
                     ReleaseDate = DateTime.ParseExact(
                         req.FormData["release-date"],
                         "yyyy-MM-dd",
                         CultureInfo.InvariantCulture)

                 }));

            appRouteConfig.Get("/admin/games/delete/{(?<id>[0-9]+)}", req => new AdminController(req).Delete());

            appRouteConfig.Post("/admin/games/delete/{(?<id>[0-9]+)}", req => new AdminController(req)
                 .Delete(int.Parse(req.UrlParameters["id"])));
        }
    }
}
