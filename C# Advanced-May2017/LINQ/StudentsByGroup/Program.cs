using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsByGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var group = new List<string[]>();

            while (input != "END")
            {
                var currentInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                group.Add(currentInput);
                input = Console.ReadLine();
            }

          var result=  group
                .Where(n => int.Parse(n[2]) == 2)
                .OrderBy(n => n[0])
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item[0]} {item[1]}");
            }
        }

    }
}
