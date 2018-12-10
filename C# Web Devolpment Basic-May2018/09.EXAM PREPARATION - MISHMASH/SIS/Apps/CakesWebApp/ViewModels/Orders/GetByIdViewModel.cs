namespace CakesWebApp.ViewModels.Orders
{
    using System.Collections.Generic;
    using CakesWebApp.ViewModels.Cakes;

    public class GetByIdViewModel
    {
        public int Id { get; set; }

        public bool IsShoppingCart { get; set; }

        public IEnumerable<CakeViewModel> Products { get; set; }
    }
}
