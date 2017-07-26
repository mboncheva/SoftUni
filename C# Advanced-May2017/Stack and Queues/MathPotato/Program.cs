using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MathPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(Console.ReadLine());

            var result = new Queue<string>(input);

            int cycle = 1;
            while (result.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    result.Enqueue(result.Dequeue());
                }
                if (PrimeTool.IsPrime(cycle))
                {
                    Console.WriteLine("Prime {0}", result.Peek());
                }
                else
                {
                    Console.WriteLine("Removed {0}", result.Dequeue());
                }
                cycle++;
            }

            Console.WriteLine("Last is {0}",result.Dequeue());
        }
        public static class PrimeTool
        {
            public static bool IsPrime(int candidate)
            {
                // Test whether the parameter is a prime number.
                if ((candidate & 1) == 0)
                {
                    if (candidate == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // Note:
                // ... This version was changed to test the square.
                // ... Original version tested against the square root.
                // ... Also we exclude 1 at the end.
                for (int i = 3; (i * i) <= candidate; i += 2)
                {
                    if ((candidate % i) == 0)
                    {
                        return false;
                    }
                }
                return candidate != 1;
            }
        }
    }
}
