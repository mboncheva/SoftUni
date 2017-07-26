using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n",Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => n.First().ToString() == n.First().ToString().ToUpper()).ToList()));

        }
    }
}
