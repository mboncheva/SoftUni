using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DefaultValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var words = new Dictionary<string, string>();

            while (input != "end")
            {
                var currentInput = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var word1 = currentInput[0];
                var word2 = currentInput[1];

                words[word1] = word2;

                input = Console.ReadLine();
            }

            var defaultValue = Console.ReadLine();

            var dontChangeValue = words
                 .Where(x => x.Value != "null")
                 .OrderByDescending(x => x.Value.Length)
                 .ToDictionary(x => x.Key, x => x.Value);

            var changeValue = words
                .Where(x => x.Value == "null")
                .ToDictionary(x => x.Key, x => defaultValue);

            foreach (var item in dontChangeValue)
            {
                Console.WriteLine("{0} <-> {1}",item.Key,item.Value);
            }

            foreach (var item in changeValue)
            {
                Console.WriteLine("{0} <-> {1}", item.Key, item.Value);
            }
        }
    }
}
