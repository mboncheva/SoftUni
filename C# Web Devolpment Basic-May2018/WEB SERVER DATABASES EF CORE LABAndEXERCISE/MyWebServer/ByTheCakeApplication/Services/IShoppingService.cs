namespace MyWebServer.ByTheCakeApplication.Services
{
    using ViewModels.Shopping;
    using System.Collections.Generic;

    public interface IShoppingService
    {
       void CreateOrder(int userId, IEnumerable<int> productIds);

        IEnumerable<OrderDetailsViewModel> GetOrders(int userId);

        OrderDetailsByIdViewModel Find(int id);
    }
}
