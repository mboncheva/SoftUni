using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .ToLower()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                

            var result = new Dictionary<string, int>();

            foreach (var word in text)
            {
                if (!result.ContainsKey(word))
                {
                    result[word] = 0;
                }

                result[word]++;
            }

            var oddNumbers = new List<string>();

            foreach (var item in result)
            {
                if (item.Value % 2 != 0)
                {
                    oddNumbers.Add(item.Key);
                }
            }
            Console.WriteLine(string.Join(", ",oddNumbers));
        }
    }
}
