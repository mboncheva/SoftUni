using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.NthDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            var digit = FindNum(number,n);
            Console.WriteLine(digit);
        }

        private static int FindNum(long number, int n)
        {
            var currentIndex = 1;
            var digit = 0;
            while (number > 0)
            {
                if (currentIndex == n)
                {
                    digit = (int)(number % 10);
                }
                else
                {
                    number = number / 10;
                }
                currentIndex++;
            }
            return digit;
        }
    }
}
