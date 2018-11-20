namespace SIS.MvcFramework
{
    using SIS.MvcFramework.Services;

    public interface IMvcApplication
    {
        void Configure();

        void ConfigureServices(IServiceCollection collection);
    }
}
