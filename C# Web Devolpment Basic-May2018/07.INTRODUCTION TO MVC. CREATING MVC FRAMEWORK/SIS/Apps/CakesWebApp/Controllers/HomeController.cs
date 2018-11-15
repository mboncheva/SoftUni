namespace CakesWebApp.Controllers
{
    using SIS.HTTP.Responses;
    using System.Collections.Generic;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View("Index");
        }

        public IHttpResponse HelloUser()
        {
            return this.View("HelloUser",new Dictionary<string, string>
            {
                { "Username", this.GetUsername()}
            });
        }
    }
}
