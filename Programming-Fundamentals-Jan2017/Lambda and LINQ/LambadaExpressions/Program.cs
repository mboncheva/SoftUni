using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LambadaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dictionary = new Dictionary<string, Dictionary<string, string>>();

            while (input != "lambada")
            {
               
                var currentDictionary = input.Split(new[] { ' ', '=', '>', '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (currentDictionary.Length > 1)
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
                    dictionary = dictionary
                        .ToDictionary(x => x.Key, x => x.Value.ToDictionary(y => y.Key, y => y.Key + "." + y.Value));
                }

                input = Console.ReadLine();
            }

            foreach (var item in dictionary)
            {
                foreach (var value in item.Value)
                {
                    Console.WriteLine("{0} => {1}.{2}",item.Key,value.Key,value.Value);
                }
            }
        }
    }
}
