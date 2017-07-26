using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine();

            while (command!="end")
            {
                switch (command)
                {
                    case "add":
                     numbers = numbers.Select(n => n += 1).ToList();
                        break;
                    case "multiply":
                     numbers = numbers.Select(n => n *= 2).ToList();
                        break;
                    case "subtract":
                     numbers = numbers.Select(n => n -= 1).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    default: break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
