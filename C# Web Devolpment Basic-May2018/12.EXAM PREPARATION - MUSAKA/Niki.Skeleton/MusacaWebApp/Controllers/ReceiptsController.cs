using Microsoft.EntityFrameworkCore;
using MusacaWebApp.Models;
using MusacaWebApp.Models.Enums;
using MusacaWebApp.ViewModels.Receipts;
using MusacaWebApp.ViewModels.Users;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusacaWebApp.Controllers
{
    public class ReceiptsController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);

            if (user == null)
            {
                return this.Redirect("/users/login");
            }

            var receipt = this.Db.Receipts
               .Where(x => x.Id == id)
               .Include(x=>x.Cashier)
               .Include(x => x.Orders)
               .FirstOrDefault();

            if (receipt == null)
            {
                return this.BadRequestError("Invalid receipt id.");
            }
            //don't work without a ??
            var a = this.Db.Products.ToList();
            var model = new ReceiptDetailsViewModel
            {
                Cashier = receipt.Cashier.Username,
                Id = receipt.Id,
                IssuedOn = receipt.IssuedOn.ToShortDateString()
            };

            var orders = new List<ProductViewModel>();
            foreach (var order in receipt.Orders)
            {
                orders.Add(new ProductViewModel
                {
                    Name = order.Product.Name,
                    Quantity = order.Quantity,
                    Price = order.Product.Price * order.Quantity
                });
            }

            model.Orders = orders;
            model.Tottal = orders.Sum(x => x.Price);

            return this.View(model);
        }


        [Authorize(roleName: nameof(Role.Admin))]
        public IHttpResponse All()
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);

            if (user == null)
            {
                return this.Redirect("/users/login");
            }

            var receiptall = this.Db.Receipts
                .Include(x=>x.Cashier)
                .Include(x => x.Orders)
                .ToList();

            var products = this.Db.Products.ToList();

            var receiptModel = receiptall
               .Select(x => new ProfileViewModel
               {
                   Id = x.Id,
                   IssuedOn = x.IssuedOn.ToShortDateString(),
                   Cashier = x.Cashier.Username,
               }).ToArray();

            foreach (var receipt in receiptall)
            {
                decimal tottalSum = 0;
                foreach (var order in receipt.Orders)
                {
                    var productPrice = products.FirstOrDefault(x => x.Id == order.ProductId).Price;
                    tottalSum += productPrice * order.Quantity;
                }

                receiptModel.FirstOrDefault(x => x.Id == receipt.Id).Total = tottalSum;
            }

            var viewModel = new UserProfileViewModel
            {
                Receipts = receiptModel
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IHttpResponse Create()
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);

            if (user == null)
            {
                return this.Redirect("/users/login");
            }

            var orders = this.Db.Orders
                .Where(x => x.CashierId == user.Id && x.Status == Status.Active)
                .ToList();

            foreach (var order in orders)
            {
                order.Status = Status.Completed;
            }

            var receipt = new Receipt
            {
                CashierId = user.Id,
                Orders = orders
            };

            this.Db.Receipts.Add(receipt);
            this.Db.SaveChanges();

            return this.Redirect($"/receipts/details?id={receipt.Id}");
        }
    }
}

