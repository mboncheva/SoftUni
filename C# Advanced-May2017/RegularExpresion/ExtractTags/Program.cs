using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.ExtractTags
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                var regex = new Regex(@"(<.+?>)");

                if (regex.IsMatch(input))
                {
                    var match = regex.Matches(input);
                    foreach (Match item in match)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
