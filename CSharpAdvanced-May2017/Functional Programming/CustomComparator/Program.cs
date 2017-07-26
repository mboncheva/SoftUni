using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var numEven = numbers.Where(n => n % 2 == 0).OrderBy(n => n).ToArray();
            var numOdd = numbers.Where(n => n % 2 != 0).OrderBy(n => n).ToArray();
            var nums = numEven.Concat(numOdd).ToArray();
            Console.WriteLine(string.Join(" ",nums));

        }
    }
}
