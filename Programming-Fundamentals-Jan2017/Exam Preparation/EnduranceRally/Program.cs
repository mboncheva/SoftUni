using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.EnduranceRally
{
    class Program
    {
        static void Main(string[] args)
        {
            var drivers = Console.ReadLine().Split(' ');
            var zones = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


            foreach (var driver in drivers)
            {
                var character = driver.ToCharArray();
                double driverFuel = character[0];

                for (int i = 0; i < zones.Length; i++)
                {
                    var fuelZone = zones[i];
                    var checkPoint = indexes.Contains(i);

                    if (checkPoint)
                    {
                        driverFuel += fuelZone;
                    }
                    else
                    {
                        driverFuel -= fuelZone;
                    }

                    if (driverFuel <= 0)
                    {
                        Console.WriteLine("{0} - reached {1}",driver,i);
                        break;
                    }
                }
                if (driverFuel > 0)
                {
                    Console.WriteLine("{0} - fuel left {1:f2}", driver, driverFuel);
                }
                
                
            }
        }
    }
}
