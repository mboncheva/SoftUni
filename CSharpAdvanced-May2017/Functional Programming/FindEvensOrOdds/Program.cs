using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var bound = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var evenOrOdd = Console.ReadLine();
            var lower = bound[0];
            var upper = bound[1];
            PrintNumbers(lower,upper, evenOrOdd);

        }

        private static void PrintNumbers(int lower,int upper, string evenOrOdd)
        {
            var numbers = new List<int>();
            for (int i = lower; i <= upper; i++)
            {
                numbers.Add(i);
            }

            if (evenOrOdd == "even")
            {
                Console.WriteLine(string.Join(" ",numbers.Where(n => n % 2 == 0)));
            }
            else if (evenOrOdd == "odd")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0)));
            }
        }
    }
}
