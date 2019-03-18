namespace PandaWebApp.Controllers
{
    using PandaWebApp.Models;
    using PandaWebApp.ViewModels.Package;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;

    public class PackagesController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var viewModel = this.Db.Packages
                .Where(x=>x.Id == id)
                .Select(x => new PackageDetailViewModel
                {
                    Username = x.User.Username,
                    Description = x.Description,
                    ShippingAddress = x.ShippingAddress,
                    Status = x.Status.ToString(),
                    Weight = x.Weight,
                    EstimatedDeliveryDate = x.EstimatedDeliveryDate

                }).FirstOrDefault();

            if (viewModel == null)
            {
                return this.BadRequestError("Invalid package id.");
            }

            return this.View(viewModel);
        }

        [Authorize(roleName:nameof(Role.Admin))]
        public IHttpResponse Create()
        {
            var users = this.Db.Users.Select(x =>x.Username).ToArray();
            return this.View(users);
        }

        [Authorize(roleName: nameof(Role.Admin))]
        [HttpPost]
        public IHttpResponse Create(PackageViewModel model)
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == model.Username);
            if (user == null)
            {
                return this.BadRequestError("Pleace, select recipient");
            }

            var package = new Package
            {
                Description = model.Description,
                Status = Status.Pending,
                Weight = model.Weight,
                ShippingAddress = model.ShippingAddress,
                EstimatedDeliveryDate = null,
                UserId = user.Id
            };

            this.Db.Packages.Add(package);
            this.Db.SaveChanges();

            return this.Redirect("/");
        }


        [Authorize(roleName: nameof(Role.Admin))]
        public IHttpResponse Pending()
        {
            var users = this.Db.Packages
                .Where(x => x.Status == Status.Pending).ToArray();
            return this.View(users);         
        }

        [Authorize(roleName: nameof(Role.Admin))]
        public IHttpResponse Shipped()
        {
            var users = this.Db.Packages
                .Where(x => x.Status == Status.Shipped).ToArray();
            return this.View(users);
        }

        [Authorize(roleName: nameof(Role.Admin))]
        public IHttpResponse Delivered()
        {
            var users = this.Db.Packages
                .Where(x => x.Status == Status.Shipped || x.Status == Status.Acquired).ToArray();
            return this.View(users);
        }



    }
}
