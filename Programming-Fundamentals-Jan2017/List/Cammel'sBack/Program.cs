using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Cammel_sBack
{
    class Program
    {
        static void Main(string[] args)
        {
            var buildings = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var camelBackSize = int.Parse(Console.ReadLine());

            if (buildings.Count == camelBackSize)
            {
                Console.Write("already stable: ");
                Console.WriteLine(string.Join(" ",buildings));
            }
            else
            {
                FindRemaining(buildings,camelBackSize);
            }

        }

        private static void FindRemaining(List<int> buildings, int camelBackSize)
        {
            int count = 0;
           
            while (buildings.Count > camelBackSize)
            {
                buildings.RemoveAt(0);
                buildings.RemoveAt(buildings.Count-1);
                count++;
            }
            Console.WriteLine($"{count} rounds");
            Console.Write("remaining: ");
            Console.WriteLine(string.Join(" ",buildings));
        }
    }
}
