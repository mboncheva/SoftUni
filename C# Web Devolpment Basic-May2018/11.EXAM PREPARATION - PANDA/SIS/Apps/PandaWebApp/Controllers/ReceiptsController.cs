namespace PandaWebApp.Controllers
{
    using PandaWebApp.ViewModels.Receipt;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;

    public class ReceiptsController:BaseController
    {
        [Authorize]
        public IHttpResponse Index()
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);

            var receipts = this.Db.Receipts
                .Where(x => x.UserId == user.Id)
              .Select(x => new ReceiptIndexViewModel
              {
                  Id = x.Id,
                  Fee = x.Fee,
                  IssuedOn = x.IssuedOn,
                  Username = x.User.Username
              }).ToArray();

            return this.View(receipts);
        }
           

        [Authorize]
        public IHttpResponse Details(int id)
        {
            var viewModel = this.Db.Receipts
                .Where(x => x.Id == id)
                .Select(x => new ReceiptDetailViewModel
                {
                    Id = x.Id,
                    Fee = x.Fee,
                    IssuedOn = x.IssuedOn,
                    Username = x.User.Username,
                    Weight = x.Package.Weight,
                    Description = x.Package.Description,
                    ShippingAddress = x.Package.ShippingAddress
                })
                .FirstOrDefault();

            if (viewModel == null)
            {
                return this.BadRequestError("Invalid package id.");
            }

            return this.View(viewModel);
        }
    }
}
