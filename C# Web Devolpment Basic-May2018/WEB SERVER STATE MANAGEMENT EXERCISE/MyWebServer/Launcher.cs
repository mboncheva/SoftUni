namespace MyWebServer
{
    using Application;
    using ByTheCakeApplication;
    using Server;
    using Server.Contracts;
    using Server.Routing;
    using Server.Routing.Contracts;

    public class Launcher
    {
        private WebServer webServer;

        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            // var app = new MainApplication();
            var app = new ByTheCakeApp();
            var appRouteConfig = new AppRouteConfig();
            app.Start(appRouteConfig);

            this.webServer = new WebServer(1442, appRouteConfig);

            this.webServer.Run();
        }
    }
}
