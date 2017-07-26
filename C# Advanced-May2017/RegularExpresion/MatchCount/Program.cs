using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.MatchCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();

            var regex = new Regex(word);
            var count = regex.Matches(text).Count;
            Console.WriteLine(count);
        }
    }
}
