using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Point
{
    public double X { get; set; }

    public double Y { get; set; }

    //public string Result()
    //{
    //    return $"({X}, {Y})";
    //}
}

namespace _05.ClosestTwoPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var points = new List<Point>();

            for (int i = 0; i < n; i++)
            {
                var currentPoints = ReadPoint();
                points.Add(currentPoints);
            }

            var minimum = double.MaxValue;
            Point firstPointResult = null;
            Point secondPointResult = null;

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i+1; j < points.Count; j++)
                {
                    var firstPoint = points[i];
                    var secondPoint = points[j];
                    var distance = CalculateDistance(firstPoint,secondPoint);

                    if (distance< minimum)
                    {
                        minimum = distance;
                        firstPointResult = firstPoint;
                        secondPointResult = secondPoint;
                    }
                }
            }

            Console.WriteLine("{0:f3}",minimum);
            Console.WriteLine("({0}, {1})",firstPointResult.X,firstPointResult.Y);
            Console.WriteLine("({0}, {1})", secondPointResult.X,secondPointResult.Y);

            //Console.WriteLine(firstPointResult.Result());
           // Console.WriteLine(secondPointResult.Result());
            
        }

        private static double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            var a = firstPoint.X - secondPoint.X;
            var b = firstPoint.Y - secondPoint.Y;
            var c = a * a + b * b;
            var distance = Math.Sqrt(c);
            return distance;
        }

        private static Point ReadPoint()
        {
            var point = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var p = new Point
            {
                X = point[0],
                Y = point[1]
            };
            return p;
        }

    }
}
