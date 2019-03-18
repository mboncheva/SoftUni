namespace ChushkaWebApp.Controllers
{
    using ChushkaWebApp.ViewModels.Home;
    using SIS.HTTP.Responses;
    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var products = this.Db.Products.Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                });

                var viewModel = new IndexViewModel
                {
                    Products = products
                };

                return this.View("/Home/LoggedIn-Index", viewModel);
            }

            return this.View();
        }
    }
}