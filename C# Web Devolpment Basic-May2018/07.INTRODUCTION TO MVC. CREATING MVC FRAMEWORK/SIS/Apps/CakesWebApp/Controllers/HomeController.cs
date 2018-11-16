namespace CakesWebApp.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Collections.Generic;

    public class HomeController : BaseController
    {
        [HttpGet("/")]
        public IHttpResponse Index()
        {
            return this.View("Index");
        }

        [HttpGet("/hello")]
        public IHttpResponse HelloUser()
        {
            return this.View("HelloUser",new Dictionary<string, string>
            {
                { "Username", this.User}
            });
        }
    }
}
