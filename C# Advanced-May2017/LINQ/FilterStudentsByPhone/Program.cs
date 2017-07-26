using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterStudentsByPhone
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine();

            var studentsPhones = new List<string[]>();

            while (names != "END")
            {
                var currentNames = names.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (currentNames[2].StartsWith("02") || currentNames[2].StartsWith("+3592"))
                {
                    studentsPhones.Add(currentNames);
                }

                names = Console.ReadLine();
            }
            foreach (var item in studentsPhones)
            {
                Console.WriteLine($"{item[0]} {item[1]}");
            }
        }
    }
}
