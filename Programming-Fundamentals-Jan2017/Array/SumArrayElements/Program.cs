using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumArrayElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] num = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                num[i] = int.Parse(Console.ReadLine());
                sum += num[i];
            }
            Console.WriteLine(sum);

        }
    }
}
