using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SpecialWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var specialWords = Console.ReadLine().Split(' ');

            var text = Console.ReadLine().Split(new[] { ',', '(', ')', '[', ']', '<', '>', '-', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var result = new Dictionary<string, int>();

            foreach (var item in specialWords)
            {
                result[item] = 0;
            }

            foreach (var item in text)
            {
                if (result.ContainsKey(item))
                {
                    result[item]++;
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine("{0} - {1}",item.Key,item.Value);
            }
        }
    }
}
