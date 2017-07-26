using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            var numSqrt = new List<int>();
            foreach (var num in numbers)
            {
                if (Math.Sqrt(num) == (int)Math.Sqrt(num))
                {
                    numSqrt.Add(num);
                }
            }
            numSqrt.Sort();
            numSqrt.Reverse();
            Console.WriteLine(string.Join(" ",numSqrt));
        }
    }
}
