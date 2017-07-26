using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Box
{
    private double lenght;
    private double width;
    private double height;

    private double Lenght
    {
        get { return this.lenght; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Lenght)} cannot be zero or negative.");
            }

            this.lenght = value;
        }
    }

    private double Width
    {
        get { return this.width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }

            this.width = value;
        }
    }
    private double Height
    {
        get { return this.height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public Box(double lenght, double width, double height)
    {
        this.Lenght = lenght;
        this.Width = width;
        this.Height = height;
    }

    public string GetSurfaceArea()
    {
        var result = 2 * (this.Lenght * this.Width + this.Lenght * this.Height + this.Width * this.Height);
       
        return $"Surface Area - {result:f2}";
    }

    public string GetLateralSurfaceArea()
    {
        var result=  2 * (this.Lenght * this.Height + this.Width * this.Height);
       
        return $"Lateral Surface Area - {result:f2}";
    }

    public string GetVolume()
    {
        var result= this.Lenght * this.Width * this.Height;
        return $"Volume - {result:f2}";
    }
}
