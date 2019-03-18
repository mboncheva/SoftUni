namespace MusacaWebApp.Controllers
{
    using MusacaWebApp.Data;
    using SIS.MvcFramework;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new MusakaDbContext();
        }

        protected MusakaDbContext Db { get; }
    }
}
