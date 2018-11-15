namespace CakesWebApp
{
    using CakesWebApp.Controllers;
    using SIS.HTTP.Enums;
    using SIS.MvcFramework;
    using SIS.WebServer.Routing;

    public class StartUp : IMvcApplication
    {
        public void Configure(ServerRoutingTable serverRoutingTable)
        {
            // {controller}/{action}/{id}
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request =>
                new HomeController() { Request = request }.Index();
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/register"] = request =>
                new AccountController() { Request = request }.Register();
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/login"] = request =>
                new AccountController() { Request = request }.Login();
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/register"] = request =>
                new AccountController() { Request = request }.DoRegister();
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/login"] = request =>
                new AccountController() { Request = request }.DoLogin();
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/hello"] = request =>
                new HomeController() { Request = request }.HelloUser();
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/logout"] = request =>
                new AccountController() { Request = request }.Logout();
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/cakes/add"] = request =>
                new CakesController() { Request = request }.AddCakes();
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/cakes/add"] = request =>
                new CakesController() { Request = request }.DoAddCakes();
            // cakes/view?id=1
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/cakes/view"] = request =>
                new CakesController() { Request = request }.ById();

        }

        public void ConfigureServices()
        {
           //TODO Implement Ioc/DI container
        }
    }
}
