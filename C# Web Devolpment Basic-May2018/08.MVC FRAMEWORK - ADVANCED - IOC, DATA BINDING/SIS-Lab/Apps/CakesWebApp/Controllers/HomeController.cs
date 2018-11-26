namespace CakesWebApp.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;

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
            return this.View("HelloUser", new HelloUserViewModel { Username = this.User });
        }

        public class HelloUserViewModel
        {
            public string Username { get; set; }
        }
    }
}
