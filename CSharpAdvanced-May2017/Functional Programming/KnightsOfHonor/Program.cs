using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => "Sir" + " " + n)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}
