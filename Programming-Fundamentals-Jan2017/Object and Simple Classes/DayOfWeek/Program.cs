using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var date = Console.ReadLine();

            DateTime dateOfWeek = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(dateOfWeek.DayOfWeek);
            
        }
    }
}
