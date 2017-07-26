using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.VowelCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"[AEIOUYaeiouy]");

            var match = regex.Matches(text);
            var count = match.Count;
            Console.WriteLine($"Vowels: {count}");
        }
    }
}
