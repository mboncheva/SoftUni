namespace PandaWebApp.Controllers
{
    using System.Linq;
    using PandaWebApp.Models;
    using PandaWebApp.ViewModels.Home;
    using PandaWebApp.ViewModels.Package;
    using SIS.HTTP.Responses;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var viewModel = this.CreateIndexViewModel();
                return this.View("/Home/LoggedIn-Index", viewModel);
            }
            return this.View();
        }

        private UserIndexViewModel CreateIndexViewModel()
        {
            var pendings = this.Db.Packages.
                 Where(x => x.User.Username == this.User.Username && x.Status == Status.Pending)
                 .Select(x => new PackageIndexViewModel
                 {
                     Id = x.Id,
                     Description = x.Description
                 })
                 .ToArray();

            var shippings = this.Db.Packages.
                Where(x => x.User.Username == this.User.Username && x.Status == Status.Shipped)
                 .Select(x => new PackageIndexViewModel
                 {
                     Id = x.Id,
                     Description = x.Description
                 })
                .ToArray();

            var deliverds = this.Db.Packages.
                    Where(x => x.User.Username == this.User.Username && x.Status == Status.Delivered)
                     .Select(x => new PackageIndexViewModel
                     {
                         Id = x.Id,
                         Description = x.Description
                     })
                    .ToArray();

            var viewModel = new UserIndexViewModel
            {
                Pendings = pendings,
                Shippeds = shippings,
                Delivereds = deliverds
            };

            return viewModel;
        }
    }
}
