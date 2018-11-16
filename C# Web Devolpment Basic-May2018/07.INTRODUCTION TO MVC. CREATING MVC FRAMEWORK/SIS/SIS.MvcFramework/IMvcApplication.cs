namespace SIS.MvcFramework
{
    using SIS.WebServer.Routing;

    public interface IMvcApplication
    {
        void Configure();

        void ConfigureServices();
    }
}
