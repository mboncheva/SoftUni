using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinEvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Where(n => n % 2 == 0)
                .ToList();

            if (input.Count > 0)
            {
                var min = input.Min();
                Console.WriteLine("{0:f2}",min);
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
