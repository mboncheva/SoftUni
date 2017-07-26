using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(new[] { ' ', '.', ',', '!', '?' , ':'}, StringSplitOptions.RemoveEmptyEntries);

            var palindromes = new List<string>();

            foreach (var word in text)
            {
                var wordReverse = new string(word.Reverse().ToArray());

                if (wordReverse == word)
                {
                    palindromes.Add(wordReverse);
                }
            }

            palindromes.Sort();
            Console.WriteLine(string.Join(", ",palindromes));
        }
    }
}
