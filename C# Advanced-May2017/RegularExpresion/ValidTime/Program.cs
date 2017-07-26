using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^(0[0-9]|1[012]):[0-5][0-9]:[0-5][0-9] [AP]M$");
            var input = Console.ReadLine();

            while (input != "END")
            {
                if (regex.IsMatch(input))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                input = Console.ReadLine();
            }
        }
    }
}
