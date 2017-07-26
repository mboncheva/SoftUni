using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double xCoord;
    private double yCoord;

    public string ID { get { return this.id; } set { this.id = value; } }
    public double Width { get { return this.width; } set { this.width = value; } }
    public double Height { get { return this.height; } set { this.height = value; } }
    public double XCoord { get { return this.xCoord; } set { this.xCoord = value; } }
    public double YCoord { get { return this.yCoord; } set { this.yCoord = value; } }

    public void IsIntersect(string rectangleName1, string rectangleName2, List<Rectangle> listOfRectangle)
    {
        Rectangle rectangle1 = listOfRectangle.Where(x => x.ID == rectangleName1).First();
        Rectangle rectangle2 = listOfRectangle.Where(x => x.ID == rectangleName2).First();

        double x1 = rectangle1.XCoord;
        double x2 = rectangle2.XCoord;
        double y1 = rectangle1.YCoord;
        double y2 = rectangle2.YCoord;
        double w1 = rectangle1.Width;
        double w2 = rectangle2.Width;
        double h1 = rectangle1.Height;
        double h2 = rectangle2.Height;

        if ((x1 + w1) < x2 || (x2 + w2) < x1 || (y1 + h1) < y2 || (y2 + h2) < y1)
        {
            Console.WriteLine("false");
        }
        else
        {
            Console.WriteLine("true");
        }
    }
}