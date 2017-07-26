using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HornetWings
{
    class Program
    {
        static void Main(string[] args)
        {
            var wingFlaps = int.Parse(Console.ReadLine());
            var distanceInMeters = double.Parse(Console.ReadLine());
            var endurance = int.Parse(Console.ReadLine());

            var distance = (wingFlaps / 1000) * distanceInMeters;

            var flapSeconds = wingFlaps / 100;
            var rest = (wingFlaps / endurance) * 5.0;
            var time = flapSeconds + rest;

            Console.WriteLine("{0:f2} m.",distance);
            Console.WriteLine("{0} s.",time);
        }
    }
}
