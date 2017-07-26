using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CharityMarathon
{
    class Program
    {
        static void Main(string[] args)
        {
            var maratonDays = decimal.Parse(Console.ReadLine());
            var runurs = decimal.Parse(Console.ReadLine());
            var lapsOfRuners = decimal.Parse(Console.ReadLine());
            var lenghtTrack = decimal.Parse(Console.ReadLine());
            var capacityTrack = decimal.Parse(Console.ReadLine());
            var moneyKilometyr = decimal.Parse(Console.ReadLine());

            var totalRuners = maratonDays * capacityTrack;
            runurs = Math.Min(totalRuners, runurs);
            var totalMeters = runurs * lapsOfRuners * lenghtTrack;
            var totalKilometyrs = totalMeters / 1000;
            var money = totalKilometyrs * moneyKilometyr;

            Console.WriteLine("Money raised: {0:f2}",money);
        }
    }
}
