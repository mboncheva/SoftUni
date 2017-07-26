using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.NonDigitCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"\D");

            var match = regex.Matches(input);
            Console.WriteLine($"Non-digits: {match.Count}");
        }
    }
}
