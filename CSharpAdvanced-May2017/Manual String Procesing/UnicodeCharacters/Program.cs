using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new StringBuilder();
            foreach (var item in input)
            {
                result.Append("\\u");
                result.Append(String.Format("{0:x4}", (int)item));
            }
            Console.WriteLine(result.ToString());
        }
    }
}
