using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterStudentsByEmailDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var names = new List<string[]>();

            while (input != "END")
            {
                var currentInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (currentInput[2].Contains("@gmail.com"))
                {
                    names.Add(currentInput);
                }
             
                input = Console.ReadLine();
            }
            foreach (var item in names)
            {
                Console.WriteLine($"{item[0]} {item[1]}");
            }
        }
    }
}
