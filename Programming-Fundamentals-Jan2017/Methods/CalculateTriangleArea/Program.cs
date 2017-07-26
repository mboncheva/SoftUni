using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CalculateTriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

           double area= PrintArea(width,height);
            Console.WriteLine(area);
        }

        private static double PrintArea(double width, double height)
        {
            double area = width * height / 2;
            return area;
        }
    }
}
