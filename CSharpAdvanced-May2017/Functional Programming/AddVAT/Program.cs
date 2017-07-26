using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
                 Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n *= 1.2)
                .ToList()
                .ForEach(n=>Console.WriteLine("{0:f2}",n));
        }
    }
}
