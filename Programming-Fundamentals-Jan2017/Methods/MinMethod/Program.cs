using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MinMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                int n = int.Parse(Console.ReadLine());
                min = GetMin(n,min);
            }
            Console.WriteLine(min);
            
        }

        private static int GetMin(int n,int min)
        {
             if (n < min)
            {
                min = n;
            }
            return min;
        }
    }
}
