
namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Name)} cannot be empty");
                }

                this.name = value;
            }
        }
        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Money)} cannot be negative");
                }
                this.money = value;
            }
        }

        public void BuyProducts(Product product)
        {
            if (this.Money < product.Price)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }
            this.bagOfProducts.Add(product);
            this.Money -= product.Price;
        }

        public IList<Product> GetProduct()
        {
            return this.bagOfProducts.AsReadOnly();
        }
    }
}