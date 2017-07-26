using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Wormhole
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var steps = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 0)
                {
                    steps++;
                    continue;
                }
                else
                {
                    var index = input[i];
                    input[i] = 0;
                    i = index;
                }
                steps++;
            }
            Console.WriteLine(steps);
        }
    }
}
