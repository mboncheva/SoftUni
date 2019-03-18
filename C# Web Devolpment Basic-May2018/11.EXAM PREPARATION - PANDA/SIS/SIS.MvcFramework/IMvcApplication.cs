namespace SIS.MvcFramework
{
    using SIS.MvcFramework.Services;

    public interface IMvcApplication
    {
        MvcFrameworkSettings Configure();

        void ConfigureServices(IServiceCollection collection);
    }
}
