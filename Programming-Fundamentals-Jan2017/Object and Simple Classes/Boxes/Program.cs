using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Box
{
    public Point UpperLeft { get; set; }

    public Point UpperRight { get; set; }

    public Point BottomLeft { get; set; }

    public Point BottomRight { get; set; }

    public static int CalculatePerimeter(int width, int height)
    {
        return 2 * width + 2 * height;
    }
      public static int CalculateArea(int width, int height)
    {
        return width * height;
    }

}

class Point
{
    public int X { get; set; }

    public int Y { get; set; }

    public static int CalcDistance(Point p1, Point p2)
    {
        int pointX = p2.X - p1.X;
        int pointY =p2.Y - p1.Y;

        return (int)Math.Sqrt(pointX * pointX + pointY * pointY);
    }
}

namespace _5.Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var boxes = new List<Box>();

            while (input != "end")
            {
                var currentInput = input
                    .Split(new[] { ' ', '|', ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var boxNew = new Box
                {
                    UpperLeft = ReadCoordinati(currentInput[0],currentInput[1]),
                    UpperRight=ReadCoordinati(currentInput[2],currentInput[3]),
                    BottomLeft = ReadCoordinati(currentInput[4], currentInput[5]),
                    BottomRight = ReadCoordinati(currentInput[6], currentInput[7])

                };

                boxes.Add(boxNew);

                input = Console.ReadLine();

            }

            foreach (var box in boxes)
            {
                var width = Point.CalcDistance(box.UpperLeft, box.UpperRight);
                var height = Point.CalcDistance(box.UpperLeft, box.BottomLeft);

                Console.WriteLine($"Box: {width}, {height}");
                Console.WriteLine($"Perimeter: {Box.CalculatePerimeter(width, height)}");
                Console.WriteLine($"Area: {Box.CalculateArea(width, height)}");

            }
        }

        private static Point ReadCoordinati(int p1,int p2)
        {
            var point = new Point
            {
                X = p1,
                Y = p2
            };

            return point;
        }
    }
}
