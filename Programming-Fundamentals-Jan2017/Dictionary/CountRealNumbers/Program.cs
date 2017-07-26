using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            var result = new SortedDictionary<double, int>();

            foreach (var num in numbers)
            {
                if (!result.ContainsKey(num))
                {
                    result[num] = 0;
                }

                result[num]++;
            }

            foreach (var item in result)
            {
                Console.WriteLine("{0} -> {1}",item.Key,item.Value);
            }
        }
    }
}
