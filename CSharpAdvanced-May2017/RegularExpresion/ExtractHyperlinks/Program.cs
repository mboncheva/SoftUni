using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.ExtractHyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"<a[\s\S]*?\s+href\s*={0,1}\s*([""'])?([\s\S]*?)(?:>|\1|class)[\s\S]*?<\/a>");
            var text = new StringBuilder();

            while (input != "END")
            {
                text.Append(input);
                input = Console.ReadLine();
            }
            var matches = regex.Matches(text.ToString());
            foreach (Match item in matches)
            {
                Console.WriteLine(item.Groups[2].Value);
            }
        }
    }

}