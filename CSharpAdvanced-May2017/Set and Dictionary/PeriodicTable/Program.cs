using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var result = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in elements)
                {
                    result.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ",result.OrderBy(x=> x)));
        }
    }
}
