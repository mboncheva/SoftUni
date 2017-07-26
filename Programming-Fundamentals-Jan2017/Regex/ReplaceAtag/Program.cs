using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.ReplaceAtag
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var pattern = @"<a.*?href=(.*?)>(.*?)<\/a>";

            var regex = new Regex(pattern);
            var replace = @"[URL href=$1>$2[/URL]";

            var result = regex.Replace(text, replace);
            Console.WriteLine(result);
        }
    }
}
