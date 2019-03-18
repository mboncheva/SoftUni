namespace ChushkaWebApp.Controllers
{
    using ChushkaWebApp.Data;
    using SIS.MvcFramework;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new ChushkaDbContext();
        }

        protected ChushkaDbContext Db { get; }
    }
}
