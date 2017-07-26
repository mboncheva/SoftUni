using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAndSumIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var nums = input.Where((i, n) => int.TryParse(i, out n))
                .ToList();

            if (nums.Count > 0)
            {
                var sum = nums.Select(long.Parse).Sum();
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
