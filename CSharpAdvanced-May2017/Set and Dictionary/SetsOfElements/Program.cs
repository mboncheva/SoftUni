using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var lenght = input[0] + input[1];

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < lenght; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (i < input[0])
                {
                    firstSet.Add(num);
                }
                else
                {
                    secondSet.Add(num);
                }
            }
           
            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write("{0} ",item);
                }
            }
        }
    }
}
