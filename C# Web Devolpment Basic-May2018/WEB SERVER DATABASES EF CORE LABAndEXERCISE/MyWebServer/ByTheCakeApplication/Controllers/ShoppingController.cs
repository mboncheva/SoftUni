namespace MyWebServer.ByTheCakeApplication
{
    using ViewModels;
    using Infrastructure;
    using System.Linq;
    using Server.HTTP.Responce;
    using Server.HTTP.Contracts;
    using Services;
    using Server.HTTP;
    using System;

    public class ShoppingController : Controller
    {
        private readonly IUserService users;
        private readonly IProductService products;
        private readonly IShoppingService shopping;

        public ShoppingController()
        {
            this.users = new UserService();
            this.products = new ProductService();
            this.shopping = new ShoppingService();
        }
        public IHttpResponse AddToCart(IHttpRequest req)
        {
            var id = int.Parse(req.UrlParameters["id"]);

            var productExits = this.products.Exists(id);

            if (!productExits)
            {
                return new NotFoundResponse();
            }

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);
            if (!shoppingCart.ProductIds.Contains(id))
            {
                shoppingCart.ProductIds.Add(id);
            }
          //  shoppingCart.ProductIds.Add(id);

            var redirectUrl = "/search";

            const string searchTermKey = "searchTerm";
             
            if (req.UrlParameters.ContainsKey(searchTermKey))
            {
                redirectUrl = $"{redirectUrl}?{searchTermKey}={req.UrlParameters[searchTermKey]}";
            }

            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse ShowCart(IHttpRequest req)
        {
              var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (!shoppingCart.ProductIds.Any())
            {
                this.ViewData["cartItems"] = "No items in your cart";
                this.ViewData["totalCost"] = "0.00";
            }
            else
            {
                var productsInCard = this.products.FindProductsInCart(shoppingCart.ProductIds);

                var items = productsInCard
                    .Select(pr => $"<div>{pr.Name} - ${pr.Price:F2}</div><br />");

                var totalPrice = productsInCard
                    .Sum(pr => pr.Price);

                this.ViewData["cartItems"] = string.Join(string.Empty, items);
                this.ViewData["totalCost"] = $"{totalPrice:F2}";
            }

            return this.FileViewResponse(@"shopping\cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            var userName = req.Session.Get<string>(SessionStore.CurrentUserKey);
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            var userId = this.users.GetUserId(userName);

            if (userId == null)
            {
                throw new InvalidOperationException($"User {userName} does not exist");
            }
            var productIds = shoppingCart.ProductIds;

            if (!productIds.Any())
            {
                return new RedirectResponse("/");
            }

            this.shopping.CreateOrder(userId.Value, productIds);

            shoppingCart.ProductIds.Clear();

            return this.FileViewResponse(@"shopping\finish-order");
        }

        public IHttpResponse GetOrdersDetails(IHttpRequest request)
        {
            var userName = request.Session.Get<string>(SessionStore.CurrentUserKey);

            var userId = this.users.GetUserId(userName);

            if (userId == null)
            {
                throw new InvalidOperationException($"User {userName} does not exist");
            }

            var ordersDetails = this.shopping.GetOrders(userId.Value);
            if (!ordersDetails.Any())
            {
                return new RedirectResponse("/");
            }

            // Generate table with orders
            var ordersDetailsToHtml = ordersDetails
                .OrderBy(o => o.Id)
                .Select(o => $@"<tr><td><a href=""/order/{o.Id}"">{o.Id}</a></td><td>{o.CreatedOn.ToShortDateString()}</td><td>${o.Sum:F2}</td></tr>");

            var resultToHtml = string.Join(Environment.NewLine, ordersDetailsToHtml);

            this.ViewData["contentTable"] = resultToHtml;

            return this.FileViewResponse(@"shopping\orders");
        }



        public IHttpResponse GetOrderDetailsById(int orderId)
        {
            var order = this.shopping.Find(orderId);

            if (order == null)
            {
                return new NotFoundResponse();
            }

            var allProductsbyOrder = order.Products;

            // Generate selected order details
            var productsToHtml = allProductsbyOrder
                .Select(p => $@"<tr><td><a href=""/cakes/{p.Id}"">{p.Name}</a></td><td>{p.Price:F2}</td></tr>");

            var resultForHtml = string.Join(Environment.NewLine, productsToHtml);

            this.ViewData["orderId"] = order.Id.ToString();
            this.ViewData["contentTable"] = resultForHtml;
            this.ViewData["createdDate"] = order.CreatedOn.ToShortDateString();
            return this.FileViewResponse(@"shopping/order-details");
        }
    }
}
