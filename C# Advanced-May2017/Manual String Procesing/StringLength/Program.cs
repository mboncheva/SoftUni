using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StringLength
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (input.Length < 20)
            {
                Console.WriteLine(input + new string('*',20 - input.Length));
            }
            else
            {
                var text = input.Substring(0, 20);
                Console.WriteLine(text);
            }
        }
    }
}
