using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();

            var allPeople = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var allProducts = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {

                foreach (var peopl in allPeople)
                {
                    var personInfo = peopl.Split('=');
                    var person = new Person(personInfo[0], decimal.Parse(personInfo[1]));
                    people.Add(person);
                }

                foreach (var produc in allProducts)
                {
                    var productInfo = produc.Split('=');
                    var product = new Product(productInfo[0], decimal.Parse(productInfo[1]));
                    products.Add(product);
                }

                string purchase;
                while ((purchase=Console.ReadLine()) !="END")
                {
                    var purchaseInfo = purchase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var purchaseName = purchaseInfo[0];
                    var purchaseProduct = purchaseInfo[1];

                    var buyer = people.FirstOrDefault(b => b.Name == purchaseName);
                    var productToBuy = products.FirstOrDefault(p => p.Name == purchaseProduct);
                    try
                    {
                        buyer.BuyProducts(productToBuy);
                        Console.WriteLine($"{buyer.Name} bought {purchaseProduct}");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    
                }

                foreach (var item in people)
                {
                  var boughtProducts=  item.GetProduct();
                    var result = boughtProducts.Any() ? string.Join(", ", boughtProducts.Select(n => n.Name).ToList()) : "Nothing bought";
                    Console.WriteLine($"{item.Name} - {result}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}