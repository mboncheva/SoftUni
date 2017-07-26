using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(n => Console.WriteLine(n));


        }
    }
}
