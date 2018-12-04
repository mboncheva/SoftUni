namespace CakesWebApp.Controllers
{
    using CakesWebApp.Models;
    using CakesWebApp.ViewModels.Cakes;
    using CakesWebApp.ViewModels.Orders;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;

    public class OrdersController : BaseController
    {
        [HttpPost("/orders/add")]
        public IHttpResponse Add(int productId)
        {
            var userId = this.Db.Users.FirstOrDefault(x => x.Username == this.User)?.Id;

            if (userId == null)
            {
                return this.BadRequestError("Please, login first.");
            }

            var lastUserOrder = this.Db.Orders
                .Where(x => x.User.Username == this.User)
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            if (lastUserOrder == null)
            {
                lastUserOrder = new Order
                {
                    UserId = userId.Value
                };

                this.Db.Orders.Add(lastUserOrder);
                this.Db.SaveChanges();
            }

            var orderProduct = new OrderProduct
            {
                OrderId = lastUserOrder.Id,
                ProductId = productId
            };

            this.Db.OrderProducts.Add(orderProduct);
            this.Db.SaveChanges();

            return this.Redirect("/orders/byId?id=" + lastUserOrder.Id);
        }

        [HttpGet("/orders/byId")]
        public IHttpResponse GetById(int id)
        {
            var order = this.Db.Orders.FirstOrDefault(x => x.Id == id && x.User.Username == this.User);

            if (order == null)
            {
                return this.BadRequestError("Invalid order id.");
            }

            var lastOrderId = this.Db.Orders.Where(x => x.User.Username == this.User)
                .OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();

            var orderViewModel = new GetByIdViewModel();
            orderViewModel.Id = order.Id;
            orderViewModel.Products = this.Db.OrderProducts.Where(x => x.OrderId == order.Id)
               .Select(x => new CakeViewModel
               {
                   Id = x.Product.Id,
                   Name = x.Product.Name,
                   ImageUrl = x.Product.ImageUrl,
                   Price = x.Product.Price,
               }).ToList();
            orderViewModel.IsShoppingCart = lastOrderId == order.Id;

            return this.View("OrderById", orderViewModel);
        }
    }
}
