using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Point
{
    public double X { get; set; }

    public double Y { get; set; }
}

namespace _04.DistanceBetweenPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            var coord = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var coordinati = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            var p1 = new Point
            {
                X = coord[0],
                Y = coord[1]
            };
            
            var p2 = new Point
            {
                X = coordinati[0],
                Y = coordinati[1]
            };

            var a = p1.X - p2.X;
            var b = p1.Y - p2.Y;
            var c = a * a + b * b;
            var distance = Math.Sqrt(c);
            Console.WriteLine("{0:f3}",distance);
        }
    }
}
