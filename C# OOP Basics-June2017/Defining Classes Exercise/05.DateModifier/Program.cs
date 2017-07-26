using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var date1 = Console.ReadLine();
        var date2 = Console.ReadLine();

        var result = DateModifier.DifferentBetweenTwoDates(date1, date2);
        Console.WriteLine(result);
    }
}

