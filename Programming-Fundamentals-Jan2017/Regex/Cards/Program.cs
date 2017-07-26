using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var pattern = "([1]?[0-9AKJQ])([SHDC])";
           
            var regex = new Regex(pattern);
            var result = regex.Matches(text);

            var list = new List<string>();

            foreach (Match item in result)
            {
                int num;
               
                if (int.TryParse(item.Groups[1].Value, out num))
                {
                    if (num < 2 || num > 10)
                    {
                        continue;
                    }
                }

                list.Add(item.Value);
            }

            Console.WriteLine(string.Join(", ",list));
        }
    }
}
