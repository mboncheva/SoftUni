using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.ReplaceATag
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"<a href=.*?>.*?<\/a>");
            var pattern = @"<a href=(.*?)>(.*?)<\/a>";
            var replacePattern=@"[URL href=$1]$2[/URL]";

            var input = Console.ReadLine();
            while (input != "end")
            {
               Console.WriteLine(Regex.Replace(input, pattern,replacePattern));
                input = Console.ReadLine();
            }
        }
    }
}
