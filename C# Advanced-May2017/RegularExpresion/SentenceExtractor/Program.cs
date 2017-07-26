using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.SentenceExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();
            var regexText = new Regex(@"[^\.|\?!\t\n]+[\!|\?|\.]");
            var regexWord = new Regex($@"\b{word}\b");

            var matchSentence = regexText.Matches(text);
            foreach (Match sentence in matchSentence)
            {
                var match = regexWord.Match(sentence.Value);
                if (match.Success)
                {
                    Console.WriteLine(sentence);
                }

            }
        }
    }
}