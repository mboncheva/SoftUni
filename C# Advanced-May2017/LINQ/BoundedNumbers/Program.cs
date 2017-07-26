using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoundedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(n => n)
                .ToList();

            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n >= input[0] && n <= input[1])
                .ToList();

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ",numbers));
            }
           
        }
    }
}
