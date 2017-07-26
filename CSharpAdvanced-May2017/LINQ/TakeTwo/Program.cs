using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var result = input.Where(n => n >= 10 && n <= 20)
                .Distinct()
                .Take(2)
                .ToList();
            
                Console.WriteLine(string.Join(" ", result));

            
        }
    }
}
