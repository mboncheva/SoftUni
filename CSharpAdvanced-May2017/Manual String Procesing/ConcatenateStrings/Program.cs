using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ConcatenateStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                var wordAppend = word + " ";
                result.Append(wordAppend);
            }

            Console.WriteLine(result.ToString());
        }
    }
}
