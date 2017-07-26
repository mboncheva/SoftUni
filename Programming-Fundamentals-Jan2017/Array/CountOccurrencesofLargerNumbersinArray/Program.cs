using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountOccurrencesofLargerNumbersinArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double n = double.Parse(Console.ReadLine());
            int biggerCount = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > n)
                {
                    biggerCount++;
                }
            }
            Console.WriteLine(biggerCount);
        }
    }
}
