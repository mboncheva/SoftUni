using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int k = numbers.Length / 4;

            var firstElements = numbers
                .Take(k)
                .Reverse()
                .ToArray();

            var secondElements = numbers
                .Reverse()
                .Take(k)
                .ToArray();

            var firstAndSecond = firstElements.Concat(secondElements).ToArray();
            var skipElements = numbers
                .Skip(k)
                .Take(2 * k)
                .ToArray();
            var sum = firstAndSecond.Select((x, index) => x + skipElements[index]);
            Console.WriteLine(string.Join(" ",sum));

        }
    }
}
