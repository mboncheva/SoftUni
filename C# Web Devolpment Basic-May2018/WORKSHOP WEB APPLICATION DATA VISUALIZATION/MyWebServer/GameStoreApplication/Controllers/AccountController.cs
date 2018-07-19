namespace MyWebServer.GameStoreApplication.Controllers
{
    using ViewModels.Account;
    using Services.Contracts;
    using Services;
    using MyWebServer.Server.HTTP;
    using Server.HTTP.Contracts;

    public class AccountController : BaseController
    {
        private const string RegisterView = @"account/register";
        private const string LoginView = @"account/login";

        private readonly IUserService users;

        public AccountController(IHttpRequest request)
            :base(request)
        {
            this.users = new UserService();
        }

        public IHttpResponse Register()
        {
            return FileViewResponse(RegisterView);
        }

        public IHttpResponse Register(RegisterViewModel model)
        {
            if (!this.ValidateModel(model))
            {
                return this.Register();
            }

            var succsess = this.users.Create(model.Email, model.FullName, model.Password);


            if (succsess)
            {
                this.LoginUser(model.Email); 

                return this.RedirectResponce(HomePath);  
            }
            else
            {
                this.ShowError("E-mail is taken.");

                return this.Register();
            }
        }

        public IHttpResponse Login()
        {
            return this.FileViewResponse(LoginView);
        }

        public IHttpResponse Login(LoginViewModel model)
        {
            if (!this.ValidateModel(model))
            {
                return this.Login();
            }

            var success = this.users.Find(model.Email, model.Password);

            if (success)
            {
                this.LoginUser(model.Email);

               return this.RedirectResponce(HomePath);
            }
            else
            {
                this.ShowError("Invalid user details");

                return this.Login();
            }
        }

        public IHttpResponse Logout()
        {
            this.httpRequest.Session.Clear();
            return this.RedirectResponce(HomePath);
        }

        private void LoginUser(string email)
        {
            this.httpRequest.Session.Add(SessionStore.CurrentUserKey, email);
        }
    }
}
