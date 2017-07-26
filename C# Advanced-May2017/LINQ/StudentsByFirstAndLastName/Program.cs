using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsByFirstAndLastName
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

           var res= group.Where(n => n[0].CompareTo(n[1]) < 0).ToList();
            foreach (var item in res)
            {
                Console.WriteLine($"{item[0]} {item[1]}");
            }
        }
    }
}
