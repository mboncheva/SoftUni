using MusacaWebApp.Models;
using MusacaWebApp.Models.Enums;
using MusacaWebApp.ViewModels.Products;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.IO;
using System.Linq;

namespace MusacaWebApp.Controllers
{
    public class ProductsController : BaseController
    {
        [Authorize]
        public IHttpResponse All()
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (user == null)
            {
                return this.Redirect("/users/login");
            }

            var allProducts = this.Db.Products
                .Select(x => new ProductViewModel
                {
                    Name = x.Name,
                    Barcode = x.Barcode,
                    Price = x.Price,
                    PictureUrl = x.Picture
                })
           .ToArray();

            var viewModel = new AllProductsViewModel
            {
                Products = allProducts
            };

            return this.View(viewModel);
           }

        [Authorize(roleName: nameof(Role.Admin))]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize(roleName: nameof(Role.Admin))]
        [HttpPost]
        public IHttpResponse Create(CreateProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Barcode = model.Barcode,
                Picture = model.PictureUrl
            };
            
            this.Db.Products.Add(product);
            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError(e.Message);
            }

            return this.Redirect("/products/all");
        }


    }
}
