using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.SeriesOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new StringBuilder();
            result.Append(input[0]);
            for (int i = 0; i < input.Length- 1; i++)
            {
                var first = input[i];
                var second = input[i + 1];
                if (first == second)
                {
                    continue;  
                }
                result.Append(second);
            }
            Console.WriteLine(result.ToString());
        }
    }
}
