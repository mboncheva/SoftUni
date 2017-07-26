using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Batteries
{
    class Program
    {
        static void Main(string[] args)
        {
            var capacitiesOnBatery = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var usagePerHour = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double hour = double.Parse(Console.ReadLine());

            var usedBatery = 0.0;
            var statusBatery = 0.0;
            int count = 0;

            for (int i = 0; i < capacitiesOnBatery.Length; i++)
            {
                usedBatery = usagePerHour[i] * hour;
                statusBatery = capacitiesOnBatery[i] - usedBatery;

                if (statusBatery <= 0)
                {
                    bool negative = true;
                    while (negative)
                    {
                        negative = false;
                        if (capacitiesOnBatery[i] > 0)
                        {
                            capacitiesOnBatery[i] -= usagePerHour[i];
                            count++;
                            negative = true;
                        }
                      
                    }
                    Console.WriteLine("Battery {0}: dead (lasted {1} hours)",i+1,count);
                    count = 0;
                }
                else
                {
                    double percentage = (statusBatery * 100.0) / capacitiesOnBatery[i];
                    Console.WriteLine("Battery {0}: {1:f2} mAh ({2:f2})%",i+1,Math.Abs(statusBatery),percentage);
                }

            }
        }
    }
}
