using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new Dictionary<char, int>();

            foreach (var item in input)
            {
                if (!result.ContainsKey(item))
                {
                    result[item] = 0;
                }
                result[item]++;
            }
            result = result
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");

            }
        }
    }
}
