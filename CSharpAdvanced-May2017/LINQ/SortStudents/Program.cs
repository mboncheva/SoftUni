using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine();

            var orderNames = new List<string[]>();

            while (names != "END")
            {
                var currentNames=names.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                orderNames.Add(currentNames);
                names = Console.ReadLine();
            }
            orderNames
                .OrderBy(n => n[1])
                .ThenByDescending(n => n[0])
                .ToList()
                .ForEach(n => Console.WriteLine($"{n[0]} {n[1]}"));
        }
    }
}
