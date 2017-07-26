using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var result = new SortedDictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!result.ContainsKey(input[i]))
                {
                    result[input[i]] = 0;
                }
                result[input[i]]++;
            }

            foreach (var item in result)
            {
                Console.WriteLine("{0} - {1} times",item.Key,item.Value);
            }
        }
    }
}
