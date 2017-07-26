using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.CubicsMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            while (line != "Over!")
            {
                var count = int.Parse(Console.ReadLine());

                var regex = new Regex($@"(^\d+)([a-zA-Z]{{{count}}})([^a-zA-Z]*)$");
                var match = regex.Match(line);

                if (match.Success)
                {
                    var left = match.Groups[1].Value;
                    var message = match.Groups[2].Value;
                    var right = match.Groups[3].Value;

                    var indexes = string.Concat(left, right)
                        .Where(char.IsDigit)
                        .Select(s => s - '0');

                    var result = new StringBuilder();

                    foreach (var item in indexes)
                    {
                        if (item >= 0 && item < message.Length)
                        {
                            result.Append(message[item]);
                        }
                        else
                        {
                            result.Append(' ');
                        }

                    }
                    Console.WriteLine($"{message} == {result}");
                }

                line = Console.ReadLine();
            }
        }
    }
}
