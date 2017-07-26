﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"[A-Z][a-z]+ [A-Z][a-z]+");
            var input = Console.ReadLine();

            while (input != "end")
            {
                if (regex.IsMatch(input))
                {
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
