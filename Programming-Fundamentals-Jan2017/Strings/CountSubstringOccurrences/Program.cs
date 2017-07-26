using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToLower();
            var word = Console.ReadLine().ToLower();

            var count = 0;
            var index = -1;

            while (true)
            {
                index = text.IndexOf(word, index+1);

                if (index < 0)
                {
                    break;
                }
                count++;

            }
            Console.WriteLine(count);
        }
    }
}
