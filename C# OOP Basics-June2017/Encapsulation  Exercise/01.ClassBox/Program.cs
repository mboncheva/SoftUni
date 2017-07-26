using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        var lenght = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        try
        {
            var box = new Box(lenght, width, height);
            Console.WriteLine($"{box.GetSurfaceArea()}\n{box.GetLateralSurfaceArea()}\n{box.GetVolume()}");

        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }

}