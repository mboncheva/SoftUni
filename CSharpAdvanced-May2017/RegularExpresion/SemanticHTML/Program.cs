using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _11.SemanticHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var words = new string[] { "main", "header", "nav", "article", "section", "aside", "footer" };

            var patternOpenTag = @"<div\s*.*?((id|class)\s*=\s*""(.*?)"").*?>";
            var patternCloseTag = @"<\/div>\s.*?(\w+)\s*-->";

            var regexOpenTag = new Regex(patternOpenTag);
            var regexCloseTag = new Regex(patternCloseTag);

            while (input != "END")
            {
                var matches = regexOpenTag.Match(input);
                if (regexOpenTag.IsMatch(input))
                {
                    PrintOpenTag(matches, input, words);
                }
                else if (regexCloseTag.IsMatch(input))
                {
                    PrintCloseTag(matches, input, words);
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintCloseTag(Match matches, string input, string[] words)
        {
          
                string commentValue = matches.Groups[1].Value;

                if (words.Contains(commentValue))

                {

                    input = Regex.Replace(input, matches.ToString(), String.Format("</" + commentValue + ">"));

                }
            Console.WriteLine(input);
        }

        private static void PrintOpenTag(Match matches, string input, string[] words)
        {
            var tag = matches.Groups[1].Value;
            var word = matches.Groups[3].Value;
            
            if (words.Contains(word))
            {
                input = Regex.Replace(input,"div",word);
                input = Regex.Replace(input, tag, "");
                input = Regex.Replace(input, "\\s>", ">");
            }
            Console.WriteLine(input);
        }
    }
}

            
     