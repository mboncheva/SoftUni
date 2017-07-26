using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CountofOddNumbersinArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int result = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] % 2 != 0)
                {
                    result++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
