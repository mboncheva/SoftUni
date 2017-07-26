using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(' ').ToArray();

            var random = new Random();

            for (int i = 0; i < text.Length; i++)
            {
                var word = text[i];
                var randomPos = random.Next(0, text.Length);

                var temp = text[randomPos];
                text[randomPos] = word;
                text[i] = temp;
            }
            foreach (var item in text)
            {
                Console.WriteLine(item);
            }
        }
    }
}
