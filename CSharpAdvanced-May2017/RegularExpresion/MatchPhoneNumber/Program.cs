using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var regexOne = new Regex(@"^\+359-2-\d{3}-\d{4}$");
            var regexTwo = new Regex(@"^\+359 2 \d{3} \d{4}$");

            var input = Console.ReadLine();

            while (input != "end")
            {
                if (regexOne.IsMatch(input) || regexTwo.IsMatch(input))
                {
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
