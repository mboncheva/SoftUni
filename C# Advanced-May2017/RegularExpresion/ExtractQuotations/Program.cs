using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.ExtractQuotations
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@""".+?""|'.+?'");

            var input = Console.ReadLine();

            var match = regex.Matches(input);
            foreach (Match item in match)
            {
                var word = item.Value.Substring(1, item.Value.Length - 2);
                Console.WriteLine(word);
            }
        }
    }
}
