using CakesWebApp.Data;
using CakesWebApp.Models;
using CakesWebApp.Services;
using SIS.HTTP.Cookies;
using SIS.HTTP.Requests.Interfaces;
using SIS.HTTP.Responses.Interfaces;
using SIS.WebServer.Results;
using System;
using System.Linq;
using System.Net;

namespace CakesWebApp.Controllers
{
    public class AccountController : BaseController
    {
        private IHashService hashService;


        public AccountController()
        {
            this.hashService = new HashService();
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            return this.View("Register");
        }

        public IHttpResponse DoRegister(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();

            if (string.IsNullOrWhiteSpace(username) || username.Length < 4)
            {
                return this.BadRequestError("Please, provide username with length of 4 or more characters");
            }

            if (this.Db.Users.Any(x=>x.Username == username))
            {
                return this.BadRequestError("User with the same name already exists!");
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                return this.BadRequestError("Please, provide password with length of 6 or more characters");
            }

            if (password != confirmPassword)
            {
                return this.BadRequestError("Password do not match!");
            }

            var passwordHash = this.hashService.Hash(password);
            var user = new User
            {
                Name=username,
                Username = username,
                Password = passwordHash
            };

            this.Db.Users.Add(user);

            try
            {
               this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                //TODO: Log error
                return this.ServerError(e.Message);
            }

            var response = new RedirectResult("/");
            this.SignInUser(user.Username, response);
            return response;
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            return this.View("Login");
        }

        public IHttpResponse DoLogin(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var passwordHash = this.hashService.Hash(password);

            var user = this.Db.Users.FirstOrDefault(x => x.Username == username && x.Password == passwordHash);
            if (user == null)
            {
               
                return this.BadRequestError("Invalid username or password!");
            }

            var response = new RedirectResult("/");
            this.SignInUser(user.Username, response);
            return response;

           
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return new RedirectResult("/");
            }

            var cookie = request.Cookies.GetCookie(".auth-cakes");
            cookie.Delete();
            var response = new RedirectResult("/");
            response.Cookies.Add(cookie);
            return response;
        }
    }
}
