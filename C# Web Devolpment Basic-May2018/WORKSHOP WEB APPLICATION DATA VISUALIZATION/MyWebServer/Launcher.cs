namespace MyWebServer
{
    using Application;
    using ByTheCakeApplication;
    using GameStoreApplication;
    using Server;
    using Server.Routing;

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
            //var mainApplication = new ByTheCakeApp();
            var mainApplication = new GameStoreApp();
           mainApplication.InitializeDatabase();

            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            this.webServer = new WebServer(1442, appRouteConfig);

            this.webServer.Run();
        }
    }
}
