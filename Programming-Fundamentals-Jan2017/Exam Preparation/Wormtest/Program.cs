using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Wormtest
{
    class Program
    {
        static void Main(string[] args)
        {
            var lenght = int.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());

            var lenghtInCm = lenght * 100;
            var remainder = lenghtInCm / width;
            var right = lenghtInCm % width;

            if (right > 0)
            {
                var result = remainder * 100.0;
                Console.WriteLine("{0:f2}%",result);
               
            }
            if (right == 0 || lenght == 0 || width == 0)
            {
                var result = lenghtInCm * width;
                Console.WriteLine("{0:f2}",result);
            }
        }
    }
}
