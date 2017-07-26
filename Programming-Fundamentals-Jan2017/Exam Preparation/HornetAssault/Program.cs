using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.HornetAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            var beehives = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToArray();

            var hornest = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var powerHornest = hornest.Sum();
            var hornestCount = 0;

            var resultBeehives = new List<long>();

            for (int i = 0; i < beehives.Length; i++)
            {
                if (beehives[i] < powerHornest)
                {
                    beehives[i] = 0;
                }
                else if (beehives[i] == powerHornest)
                {
                    beehives[i] = 0;

                    if (hornestCount < hornest.Length)
                    {
                        powerHornest -= hornest[hornestCount];
                        hornest[hornestCount] = 0;
                        hornestCount++;
                    }
                    
                }
                else if (beehives[i] > powerHornest)
                {
                    beehives[i] -= powerHornest;
                    if (hornestCount < hornest.Length)
                    {
                        powerHornest -= hornest[hornestCount];
                        hornest[hornestCount] = 0;
                        hornestCount++;
                    }
                    if (beehives[i] < 0)
                    {
                        beehives[i] = 0;
                        continue;
                    }
                  
                }
            }

            if (beehives.Any(b => b > 0))
            {
                var result = beehives.Where(b => b > 0);
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                var result = hornest.Where(h => h > 0);
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}