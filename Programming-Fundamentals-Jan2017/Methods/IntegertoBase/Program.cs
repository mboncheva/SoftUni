using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.IntegertoBase
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int toBase = int.Parse(Console.ReadLine());

            var result = IntegerToBase(number, toBase);
            Console.WriteLine(result);
        }

        private static string IntegerToBase(int number, int toBase)
        {
            var result = string.Empty;
            while (number > 0)
            {
                var remainder = number % toBase;
                result = remainder + result;
                number /= toBase;
            }
            return result;
        }
    }
}
