using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SinoTheWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            string timeFormat = @"hh\:mm\:ss";
            var timeLeaving = TimeSpan.ParseExact(Console.ReadLine(), timeFormat, CultureInfo.InvariantCulture);

            var stepsNeeded = int.Parse(Console.ReadLine());
            var secondsPerStep = int.Parse(Console.ReadLine());

            var secondsOfDay = 60 * 60 * 24;
            var tottalSeconds = (int)(((double)stepsNeeded * secondsPerStep) % secondsOfDay);

            //var time = timeLeaving.AddSeconds(tottalSeconds); Reshenie s DateTime

            var time = timeLeaving.Add(new TimeSpan(0, 0, tottalSeconds));
            Console.WriteLine("Time Arrival: {0}",time.ToString(timeFormat));
           
        }
    }
}
