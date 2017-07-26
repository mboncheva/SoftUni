using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new StringBuilder();

            var regex = new Regex(@"(\D+)(\d+)");
            var match = regex.Matches(input);

            foreach (Match item in match)
            {
                var word = item.Groups[1].Value.ToUpper();
                var times = int.Parse(item.Groups[2].Value);

                for (int i = 0; i < times; i++)
                {
                    result.Append(word);
                }
            }

            var count = result.ToString().Distinct().Count();

            Console.WriteLine("Unique symbols used: {0}",count);
            Console.WriteLine(result);
        }
    }
}