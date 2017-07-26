using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SweetDessert
{
    class Program
    {
        static void Main(string[] args)
        {
            var cash = decimal.Parse(Console.ReadLine());
            var guests = int.Parse(Console.ReadLine());
            var priceOfBananas = decimal.Parse(Console.ReadLine());
            var priceOfEgss = decimal.Parse(Console.ReadLine());
            var priceOfBerriers = decimal.Parse(Console.ReadLine());

            var sets = Math.Ceiling(guests / 6m);
            var neededBannas = sets * (2 * priceOfBananas);
            var neededEggs = sets * (4 * priceOfEgss);
            var neededBerries = sets * (0.2m * priceOfBerriers);

            var productsMoney = neededBannas + neededBerries + neededEggs;

            var money =Math.Abs(cash - productsMoney);

            if (productsMoney <= cash)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:f2}lv.",productsMoney);
            }
            else
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:f2}lv more.",money);
            }


        }
    }
}
