using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            int num = int.Parse(Console.ReadLine());

            var result = new Queue<string>(input);

            while (result.Count > 1)
            {
                for (int i = 1; i < num; i++)
                {
                    result.Enqueue(result.Dequeue());
                }
                Console.WriteLine("Removed {0}",result.Dequeue());
            }
            Console.WriteLine("Last is {0}",result.Dequeue());
        }
    }
}
