namespace MyWebServer.ByTheCakeApplication.Services
{
    using Data;
    using Data.Models;
    using MyWebServer.ByTheCakeApplication.ViewModels.Shopping;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingService : IShoppingService
    {
        public void CreateOrder(int userId, IEnumerable<int> productIds)
        {
            using (var db = new ByTheCakeDbContext())
            {
                var order = new Order
                {
                    UserId = userId,
                    CreationDate = DateTime.UtcNow,
                    Products = productIds
                        .Select(id => new OrderProduct
                        {
                            ProductId = id
                        })
                        .ToList()
                };

                db.Add(order);
                db.SaveChanges();
            }
        }

        public OrderDetailsByIdViewModel Find(int id)
        {
            using (var db = new ByTheCakeDbContext())
            {
                return db.Orders
                    .Where(o => o.Id == id)
                    .Select(o => new OrderDetailsByIdViewModel
                    {
                        Id = o.Id,
                        CreatedOn = o.CreationDate,
                        Products = o.Products
                            .Where(p => p.OrderId == o.Id)
                            .Select(p => new OrderProductsDetailsViewModel
                            {
                                Id = p.ProductId,
                                Name = p.Product.Name,
                                Price = p.Product.Price
                            })
                    })
                    .FirstOrDefault();
            }
        }

        public IEnumerable<OrderDetailsViewModel> GetOrders(int userId)
        {
            using (var db = new ByTheCakeDbContext())
            {
                return db.Orders
                    .Where(o => o.UserId == userId)
                    .Select(o => new OrderDetailsViewModel
                    {
                        Id = o.Id,
                        CreatedOn = o.CreationDate,
                        Sum = o.Products.Sum(p => p.Product.Price)
                    })
                    .OrderByDescending(o => o.CreatedOn)
                    .ToList();
            }
        }
    }
}
