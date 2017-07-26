using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Rectangle
{
    public double Left { get; set; }

    public double Top { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Right
    {
        get
        {
            return Left + Width;
        }
    }

    public double Bottom
    {
        get
        {
            return Top + Height;
        }
    }

    public double Area()
    {
        return Height * Width;
    }

}

namespace _06.RectanglePosition
{
    class Program
    {
        static void Main(string[] args)
        {
            var rectangleFirst = RectangleRead();
            var rectangleSecond = RectangleRead();
            var result = IsInside(rectangleFirst,rectangleSecond);
            if (result)
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
           
        }

        private static bool IsInside(Rectangle rectangleFirst, Rectangle rectangleSecond)
        {
            return
                ((rectangleFirst.Left >= rectangleSecond.Left) 
                && (rectangleFirst.Right <= rectangleSecond.Right)
                && (rectangleFirst.Top >= rectangleSecond.Top) 
                && (rectangleFirst.Bottom <= rectangleSecond.Bottom));

        }

        private static Rectangle RectangleRead()
        {
            var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var points = new Rectangle
            {
                Left = input[0],
                Top = input[1],
                Width = input[2],
                Height = input[3]
            };
            return points;
        }
    }
}
