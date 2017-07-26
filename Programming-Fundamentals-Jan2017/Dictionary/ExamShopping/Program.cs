using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ExamShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var shop = new Dictionary<string, int>();

            while (input != "shopping time")
            {
                var curentInput = input.Split(' ');
                var product = curentInput[1];
                var quantity = int.Parse(curentInput[2]);

                if (!shop.ContainsKey(product))
                {
                    shop[product] = quantity;
                }
                else
                {
                    shop[product] += quantity;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "exam time")
            {
                var curentInput = input.Split(' ');
                var product = curentInput[1];
                var quantity = int.Parse(curentInput[2]);

                if (shop.ContainsKey(product))
                {
                    if (shop[product] == 0)
                    {
                        Console.WriteLine("{0} out of stock", product);
                    }
                    else
                    {
                        shop[product] -= quantity;
                        if (shop[product] < 0)
                        {
                            shop[product] = 0;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("{0} doesn't exist", product);
                }
                input = Console.ReadLine();
            }

            foreach (var item in shop)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine("{0} -> {1}",item.Key,item.Value);
                }
            }
        }
    }
}
