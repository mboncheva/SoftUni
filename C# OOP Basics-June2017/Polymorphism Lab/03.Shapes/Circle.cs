using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Circle : Shape
{
    private double radius;

public double Radius { get { return this.radius; } set { this.radius = value; } }

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public override double CalculateArea()
    {
        return this.Radius * this.Radius * Math.PI;
    }

    public override double CalculatePerimeter()
    {
        return Math.PI * 2 * this.Radius;
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}