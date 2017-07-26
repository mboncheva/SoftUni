using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DrawaFilledSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintHeader(n);
            for (int i = 0; i < n-2; i++)
            {
                PrintMiddle(n);
            }
            
            PrintHeader(n);
        }

        private static void PrintMiddle(int n)
        {
            Console.Write("-");
            for (int i = 1; i < n; i++)
            {
                Console.Write(@"\/");
            }
            
            Console.WriteLine("-");
        }

        private static void PrintHeader(int n)
        {
            Console.WriteLine(new string('-',n*2));
        }
    }
}
