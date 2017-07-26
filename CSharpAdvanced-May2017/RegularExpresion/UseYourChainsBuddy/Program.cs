using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10.UseYourChainsBuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var letters = "abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();

            var regexAll = new Regex(@"<p>(.*?)<\/p>");
            var pattern = @"[^a-z0-9]+";

            var matches = regexAll.Matches(input);
            var result = new StringBuilder();

            foreach (Match item in matches)
            {
                var text = item.Groups[1].Value;
                text = Regex.Replace(text, pattern, t => " ");
                var endText = text.ToCharArray();

                for (int i = 0; i < endText.Length; i++)
                {

                    if ( endText[i] >= 'a' && endText[i] <= 'z')
                    {
                        if (endText[i] <= 'm')
                        {
                            endText[i] = (char)(endText[i] + 13);
                        }
                        else if (endText[i] >= 'm')
                        {
                            endText[i] = (char)(endText[i] - 13);
                        }
                    }
                }

                result.Append(endText);
            }
            Console.WriteLine(result.ToString());
        }
    }
}
