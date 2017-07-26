using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CountofCapitalLettersinArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int counter = 0;
            
            for (int i = 0; i < text.Length; i++)
            {
                string currentWord = text[i];
                if (currentWord.Length == 1)
                {
                    char symbol = currentWord[0];
                    if (symbol >= 'A' && symbol <= 'Z')
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
