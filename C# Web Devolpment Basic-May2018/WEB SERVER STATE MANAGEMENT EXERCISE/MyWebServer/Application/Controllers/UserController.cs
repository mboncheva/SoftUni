namespace MyWebServer.Application.Controllers
{
    using Application.Views;
    using Server;
    using Server.Enums;
    using Server.HTTP.Contracts;
    using Server.HTTP.Responce;

    public class UserController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new RegisterView());
        }


        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }


        public IHttpResponse Details(string name)
        {
            Model model = new Model { ["name"] = name };
            return new ViewResponse(HttpStatusCode.OK, new UserDetailsView(model));
        }

    }
}
