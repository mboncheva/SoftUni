using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SplitbyWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .Split(new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\\', '/', '[', ']', ' ', '\'' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var lowerCaseWord = new List<string>();
            var upperCaseWord = new List<string>();
            var mixedCaseWord = new List<string>();

            var upper = 0;
            var lower = 0;

            for (int i = 0; i < text.Count; i++)
            {
                var word = text[i];
                foreach (var w in word)
                {
                    if (char.IsUpper(w))
                    {
                        upper++;
                    }
                    if(char.IsLower(w))
                    {
                        lower++;
                    }
                }
                if (upper == word.Length)
                {
                    upperCaseWord.Add(word);
                }
                else if (lower == word.Length)
                {
                    lowerCaseWord.Add(word);
                }
                else
                {
                    mixedCaseWord.Add(word);
                }
                upper = 0;
                lower = 0;
            }
            
            Console.Write("Lower-case: ");
            Console.WriteLine(string.Join(", ",lowerCaseWord));
            Console.Write("Mixed-case: ");
            Console.WriteLine(string.Join(", ",mixedCaseWord));
            Console.Write("Upper-case: ");
            Console.WriteLine(string.Join(", ",upperCaseWord));
            
        }
    }
}
