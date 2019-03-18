namespace ChushkaWebApp.ViewModels.Products
{
    using ChushkaWebApp.Models;

    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
