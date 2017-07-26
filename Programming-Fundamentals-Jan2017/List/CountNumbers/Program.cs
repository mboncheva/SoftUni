using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var counts = new int[1001];

            foreach (var num in numbers)
            {
                counts[num]++;
            }
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] != 0)
                {
                    Console.WriteLine($"{i} -> {counts[i]}");
                }
                
            }

        }
    }
}
