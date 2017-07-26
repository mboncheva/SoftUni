using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sale
{
    public string Town { get; set; }

    public string Product { get; set; }

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

}

namespace _07.SalesReport
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var townSales = new SortedDictionary<string, decimal>();
           

            for (int i = 0; i < n; i++)
            {
                var sales = ReadSeales();

                var town = sales.Town;
                var totalSales = sales.Quantity * sales.Price;

                if (!townSales.ContainsKey(town))
                {
                    townSales[town] = 0;
                }
                townSales[town] += totalSales;
            }

            foreach (var town in townSales)
            {
                Console.WriteLine("{0} -> {1:f2}",town.Key,town.Value);
            }
        }

        private static Sale ReadSeales()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var sales = new Sale
            {
                Town = input[0],
                Product = input[1],
                Quantity = decimal.Parse(input[2]),
                Price = decimal.Parse(input[3])
            };
            return sales;
        }
    }
}
