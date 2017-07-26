using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ArrayContainsElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var n = int.Parse(Console.ReadLine());

            bool isFound = false;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == n)
                {
                    isFound = true;
                    Console.WriteLine("yes");
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }

        }
    }
}
