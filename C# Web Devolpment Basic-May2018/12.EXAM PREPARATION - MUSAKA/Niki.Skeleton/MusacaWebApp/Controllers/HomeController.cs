namespace MusacaWebApp.Controllers
{
    using MusacaWebApp.Models;
    using MusacaWebApp.Models.Enums;
    using MusacaWebApp.ViewModels.Home;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var activeOrders = this.Db.Orders
                    .Where(x => x.Status == Status.Active && x.Cashier.Username == this.User.Username)
                    .Select(x => new ActiveOrdersViewModel
                    {
                        ProductName = x.Product.Name,
                        Quantity = x.Quantity,
                        Price = x.Quantity * x.Product.Price,
                    }).ToArray();

                decimal totalPrice = 0;
                if (activeOrders.Length > 0)
                {
                    totalPrice = activeOrders.Sum(x => x.Price);
                }

                var viewModel = new OrdersViewModel
                {
                    Orders = activeOrders,
                    TotalPrice = totalPrice
                };

                return this.View("/Home/LoggedIn-Index", viewModel);
            }

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IHttpResponse Order(OrderInputModel model)
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);

            if (user == null)
            {
                return this.Redirect("/users/login");
            }

            var product = this.Db.Products
                .FirstOrDefault(x => x.Barcode == model.Barcode);

            if (product == null)
            {
                return BadRequestError("No product with this barcode.");
            }
            
            var order = new Order
            {
                Quantity = model.Quantity,
                ProductId = product.Id,
                CashierId = user.Id,
                Status = Status.Active,
            };

            this.Db.Orders.Add(order);
            this.Db.SaveChanges();

            return this.Redirect("/home/index");
        }
    }
}