namespace MishMashWebApp
{
    using SIS.MvcFramework;

    public class Program
    {
        public static void Main(string[] args)
        {
            var mvcApplication = new StartUp();
            WebHost.Start(mvcApplication);
        }
    }
}
