namespace MyWebServer.GameStoreApplication.Controllers
{
    using ViewModels.Admin;
    using Server.HTTP.Contracts;
    using Services.Contracts;
    using Services;
    using System.Linq;
    using System;

    public class AdminController : BaseController
    {
        private const string AddGameView = @"admin/add-game";
        private const string ListGamesView = @"admin/list-games";
        private const string EditGameView = @"admin/edit-game";
        private const string DeleteGameView = @"admin/delete-game";

        private readonly IGameService games;

        public AdminController(IHttpRequest request)
            : base(request)
        {
            this.games = new GameService();
        }

        public IHttpResponse Add()
        {
            if (this.authentication.IsAdmin)
            {
                return this.FileViewResponse(AddGameView);
            }
            else
            {
                return this.RedirectResponce(HomePath);
            }
        }

        public IHttpResponse Add(AdminAddGameViewModel model)
        {
            if (!this.authentication.IsAdmin)
            {
                return this.RedirectResponce(HomePath);
            }

            if (!ValidateModel(model))
            {
                return this.Add();
            }

            this.games.Create(
                model.Title,
                model.Description,
                model.ImageUrl,
                model.Price,
                model.Size,
                model.VideoId,
                model.ReleaseDate.Value);

            return this.RedirectResponce("/admin/games/list");
        }

        public IHttpResponse List()
        {
            if (!this.authentication.IsAdmin)
            {
                return this.RedirectResponce(HomePath);
            }

            var games = this.games.All()
                .Select(g => $"<tr><th scope=\"row\">{g.Id}</th><td>{g.Name}</td><td>{g.Size:F1} GB</td><td>{g.Price:F2} &euro;</td><td><a href=\"/admin/games/edit/{g.Id}\" class=\"btn btn-warning btn-sm\" style=\"margin: auto 4px;\">Edit</a><a href=\"/admin/games/delete/{g.Id}\" class=\"btn btn-danger btn-sm\" style=\"margin: auto 4px;\">Delete</a></td></tr>");

            var gamesAsHtml = string.Join(Environment.NewLine, games);

            this.ViewData["games"] = gamesAsHtml;

            return this.FileViewResponse(ListGamesView);
        }

        public IHttpResponse Edit()
        {
            if (!this.authentication.IsAdmin)
            {
                return this.RedirectResponce(HomePath);
            }
            var id = int.Parse(this.httpRequest.UrlParameters["id"]);

            var game = games.Find(id);

            if (game == null)
            {
                this.ShowError("Game not found!");

                return this.List();
            }
         
                this.ViewData["title"] = game.Title;
                this.ViewData["description"] = game.Description;
                this.ViewData["thumbnail"] = game.ImageUrl;
                this.ViewData["price"] = game.Price.ToString("F2");
                this.ViewData["size"] = game.Size.ToString("F1");
                this.ViewData["video-id"] = game.VideoId;
                this.ViewData["release-date"] = game.ReleaseDate.ToString("yyyy-MM-dd");

                return this.FileViewResponse(EditGameView);
        }

        public IHttpResponse Edit(AdminEditGameViewModel model)
        {
            if (!this.authentication.IsAdmin)
            {
                return this.RedirectResponce(HomePath);
            }

            if (!ValidateModel(model))
            {
                return this.Edit();
            }

          var isEditGame = this.games.Edit(
              model.Id,
              model.Title,
              model.Description,
              model.ImageUrl,
              model.Price,
              model.Size,
              model.VideoId,
              model.ReleaseDate.Value);

            if (isEditGame)
            {
                return this.List();
            }
            else
            {
                return this.Edit();
            }
        }

        public IHttpResponse Delete()
        {
            if (!this.authentication.IsAdmin)
            {
                return this.RedirectResponce(HomePath);
            }

            var id = int.Parse(this.httpRequest.UrlParameters["id"]);

            var game = this.games.Find(id);

            if (game == null)
            {
                this.ShowError("Game not found.");

                return this.List();
            }
            else
            {
                this.ViewData["title"] = game.Title;
                this.ViewData["description"] = game.Description;
                this.ViewData["thumbnail"] = game.ImageUrl;
                this.ViewData["price"] = game.Price.ToString("F2");
                this.ViewData["size"] = game.Size.ToString("F1");
                this.ViewData["video-id"] = game.VideoId;
                this.ViewData["release-date"] = game.ReleaseDate.ToString("yyyy-MM-dd");

                return this.FileViewResponse(DeleteGameView);
            }

        }

        public IHttpResponse Delete(int id)
        {
            if (!this.authentication.IsAdmin)
            {
                return this.RedirectResponce(HomePath);
            }

            var game = this.games.Find(id);

            if (game == null)
            {
                this.ShowError("Game not found");

                return this.List();
            }

            var isDeleted = this.games.Delete(id);

            if (!isDeleted)
            {
                this.ShowError("Game not found");

                return this.Delete();
            }

            return this.List();
        }
    }
}
