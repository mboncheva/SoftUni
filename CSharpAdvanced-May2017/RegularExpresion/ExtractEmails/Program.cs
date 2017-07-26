﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"(?<=\s)[a-zA-Z0-9]+([\.|\-|_)*[a-zA-z0-9]+@[A-Za-z0-9]+([\-\.][a-zA-Z]+)*(\.[a-zA-z]+))");
            
            var matches = regex.Matches(input);
            foreach (Match item in matches)
            {
                Console.WriteLine(item);
            }

        }
    }
}
