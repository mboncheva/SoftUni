namespace CakesWebApp.Controllers
{
    using CakesWebApp.ViewModels.User;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;

    public class UserController : BaseController
    {
        [HttpGet("/user/profile")]
        public IHttpResponse Profile()
        {
            var viewModel = this.Db.Users.Where(x => x.Username == this.User)
                .Select(x => new ProfileViewModel
                {
                    Username = x.Username,
                    RegisterOn = x.DateOfRegistration,
                    OrdersCount = x.Orders.Count()
                })
                .FirstOrDefault();

            if (viewModel == null)
            {
                return this.BadRequestError("Profile page not accessible for this user.");
            }

            if (viewModel.OrdersCount > 0)
            {
                viewModel.OrdersCount--;
            }

            return this.View("Profile", viewModel);
        }
    }
}
