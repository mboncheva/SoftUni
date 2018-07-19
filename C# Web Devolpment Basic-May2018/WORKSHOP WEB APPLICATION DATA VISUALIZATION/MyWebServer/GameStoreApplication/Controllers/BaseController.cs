namespace MyWebServer.GameStoreApplication.Controllers
{
    using Infrastructure;
    using Services.Contracts;
    using Services;
    using Common;
    using Server.HTTP;
    using Server.HTTP.Contracts;

    public abstract class BaseController : Controller
    {
        protected const string HomePath = "/";
        private readonly IUserService users;

        public BaseController(IHttpRequest req)
        {
            this.httpRequest = req;
            this.users = new UserService();
            this.authentication = new Authentication(false, false);
            this.ApplyAuthentication();
        }

        protected IHttpRequest httpRequest { get; private set; }

        protected Authentication authentication { get; private set; }

        protected override string ApplicationDirectory => "GameStoreApplication";

        private void ApplyAuthentication()
        {
            var anonymousDisplay = "flex";
            var authDisplay = "none";
            var adminDisplay = "none";

            var authentcatedUserEmail = this.httpRequest.Session.Get<string>(SessionStore.CurrentUserKey);

            if(authentcatedUserEmail != null)
            {
                anonymousDisplay = "none";
                authDisplay = "flex";

                var isAdmin = users.IsAdmin(authentcatedUserEmail);

                if (isAdmin)
                {
                    adminDisplay = "flex";
                }

                this.authentication = new Authentication(true, isAdmin);
            }

            this.ViewData["anonymousDisplay"] = anonymousDisplay;
            this.ViewData["authDisplay"] = authDisplay;
            this.ViewData["adminDisplay"] = adminDisplay;

        }

    }
}
