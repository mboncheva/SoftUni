using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var students = new List<string[]>();

            while (input != "END")
            {
                var currentInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                students.Add(currentInput);
                input = Console.ReadLine();
            }

            var res = students.Where(n => int.Parse(n[2]) >= 18 && int.Parse(n[2]) <= 24).ToList();
            foreach (var item in res)
            {
                Console.WriteLine($"{item[0]} {item[1]} {item[2]}");
            }
        }
    }
}
