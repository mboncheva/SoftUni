using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShortWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .Split(new[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' '},StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            var words = text
                .Where(w => w.Length < 5)
                .Select(w => w.ToLower())
                .Distinct()
                .OrderBy(w => w);
       
            Console.WriteLine(string.Join(", ",words));
        }
    }
}
