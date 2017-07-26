using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SoftuniCoffeeOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            decimal totalSum = 0;
            
            for (int i = 0; i < n; i++)
            {
                var pricePerCapsule = decimal.Parse(Console.ReadLine());

                string timeFormat = @"d/M/yyyy";
                var timeLeaving = DateTime.ParseExact(Console.ReadLine(), timeFormat, CultureInfo.InvariantCulture);
                var capsulesCount = int.Parse(Console.ReadLine());

                var daysMonth = DateTime.DaysInMonth(timeLeaving.Year, timeLeaving.Month);
                var orderPrice = daysMonth * pricePerCapsule * (decimal)capsulesCount;
                Console.WriteLine("The price for the coffee is: ${0:f2}",orderPrice);
                totalSum += orderPrice;
            }
            Console.WriteLine("Total: ${0:f2}",totalSum);

        }
    }
}
