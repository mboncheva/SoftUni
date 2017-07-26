using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FlattenDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Dictionary<string, string>>();

            var input = Console.ReadLine();

            while (input != "end")
            {
                var currentDictionary = input.Split(' ');
                if (currentDictionary[0] != "flatten")
                {
                    var key = currentDictionary[0];
                    var innerKey = currentDictionary[1];
                    var innerValue = currentDictionary[2];

                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary[key] = new Dictionary<string, string>();
                    }
                      dictionary[key][innerKey] = innerValue;
                 
                }
                else
                {
                    string key = currentDictionary[1];
                    dictionary[key] = dictionary[key]
                        .ToDictionary(x => x.Key + x.Value, x => "flattened");
                }
                input = Console.ReadLine();
            }

            var order = dictionary
                .OrderByDescending(x => x.Key.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in order)
            {
                Console.WriteLine("{0}",item.Key);
                int count = 1;

                var orderInnerDictonary = item.Value
                    .Where(x => x.Value != "flattened")
                    .OrderBy(x => x.Key.Length)
                    .ToDictionary(x => x.Key, x => x.Value);

                var flattenDictonary = item.Value
                    .Where(x => x.Value == "flattened")
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var inner in orderInnerDictonary)
                {
                    Console.WriteLine("{0}. {1} - {2}",count,inner.Key,inner.Value);
                    count++;
                }
                foreach (var flatten in flattenDictonary)
                {
                    Console.WriteLine("{0}. {1}",count,flatten.Key);
                    count++;
                }
            }

        }
    }
}
