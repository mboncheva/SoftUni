using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToLower();

            var word = Console.ReadLine().ToLower();

            var count = 0;
            var n = 0;
            while (true)
            {
                var indexStart = text.IndexOf(word, n);
                if (indexStart > -1)
                {
                    count++;
                    n = indexStart + 1;
                }
                else
                {
                    break;
                }
                
            }
            Console.WriteLine(count);
        }
    }
}
