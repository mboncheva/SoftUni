using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DictRefAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var dictionary = new Dictionary<string, List<int>>();

            while (input != "end")
            {
                var currentInput = input.Split(new[] { ' ', '-', '>', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var name = currentInput[0];

                int number;
                if (int.TryParse(currentInput[1], out number))
                {
                    if (!dictionary.ContainsKey(name))
                    {
                        dictionary[name] = new List<int>();
                    }
                    for (int i = 1; i < currentInput.Count; i++)
                    {
                        dictionary[name].Add(int.Parse(currentInput[i]));
                    }
                }
                else
                {
                    string otherKey = currentInput[1];
                    if (dictionary.ContainsKey(otherKey))
                    {
                        dictionary[name] =new List<int>(dictionary[otherKey]);
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} === {1}", item.Key, string.Join(", ", item.Value));
            }
        }
    }
}