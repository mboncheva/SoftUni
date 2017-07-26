using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RotateArrayofStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .Split(' ');
        
            var result = new string[text.Length];
            result[0] = text[text.Length - 1];

            for (int i = 0; i < text.Length - 1; i++)
            {
                result[i + 1] = text[i];
            }

            Console.WriteLine(string.Join(" ",result));

        }
    }
}
