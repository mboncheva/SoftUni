namespace ChushkaWebApp.Controllers
{
    using ChushkaWebApp.Models;
    using ChushkaWebApp.ViewModels.Products;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Linq;

    public class ProductsController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var model = this.Db.Products
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                    Type = x.Type
                })
                .FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                return this.BadRequestError("Invalid product id.");
            }

            return this.View(model);

        }


        [Authorize]
        public IHttpResponse Order(int id)
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (user == null)
            {
                return this.BadRequestError("Invalid user.");
            }
            var order = new Order
            {
                OrderedOn = DateTime.UtcNow,
                ProductId = id,
                UserId = user.Id,
            };
            this.Db.Orders.Add(order);
            this.Db.SaveChanges();
            return this.Redirect("/");
        }

        [Authorize(roleName:nameof(Role.Admin))]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize(roleName:nameof(Role.Admin))]
        [HttpPost]
        public IHttpResponse Create(CreateProductInputModel model)
        {
            if (!Enum.TryParse(model.Type, true, out ProductType type))
            {
                return this.BadRequestErrorWithView("Invalid channel type.");
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Type = type
            };

            this.Db.Products.Add(product);
            this.Db.SaveChanges();

            return this.Redirect("/products/details?id=" + product.Id);
        }

        [Authorize(roleName: nameof(Role.Admin))]
        public IHttpResponse Edit(int id)
        {
            var viewModel = this.Db.Products
                .Select(x => new UpdateDeleteProductInputModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                    Type = x.Type.ToString()
                })
                .FirstOrDefault(x => x.Id == id);

            if (viewModel == null)
            {
                return this.BadRequestError("Invalid product id.");
            }

            return this.View(viewModel);
        }

        [Authorize(roleName: nameof(Role.Admin))]
        [HttpPost]
        public IHttpResponse Edit(UpdateDeleteProductInputModel model)
        {
            var product = this.Db.Products.FirstOrDefault(x => x.Id == model.Id);
            if (product == null)
            {
                return this.BadRequestError("Product not found.");
            }
            if (!Enum.TryParse(model.Type, out ProductType type))
            {
                return this.BadRequestError("Invalid product type.");
            }
            product.Type = type;
            product.Description = model.Description;
            product.Name = model.Name;
            product.Price = model.Price;
            this.Db.SaveChanges();

            return this.Redirect("/products/details?id=" + product.Id);
        }

        [Authorize(roleName: nameof(Role.Admin))]
        public IHttpResponse Delete(int id)
        {
            var viewModel = this.Db.Products
                .Select(x => new UpdateDeleteProductInputModel()
                {
                    Type = x.Type.ToString(),
                    Name = x.Name,
                    Id = x.Id,
                    Price = x.Price,
                    Description = x.Description,
                })
                .FirstOrDefault(x => x.Id == id);
            if (viewModel == null)
            {
                return this.BadRequestError("Invalid product id.");
            }
            return this.View(viewModel);
        }

        [Authorize(roleName: nameof(Role.Admin))]
        [HttpPost]
        public IHttpResponse Delete(int id, string name)
        {
            var product = this.Db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return this.Redirect("/");
            }
            this.Db.Remove(product);
            this.Db.SaveChanges();
            return this.Redirect("/");
        }

    }
}
