using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Extract_IntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var regex = new Regex(@"\d+");
            var match = regex.Matches(text);

            if (match.Count > 0)
            {
                foreach (Match item in match)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
