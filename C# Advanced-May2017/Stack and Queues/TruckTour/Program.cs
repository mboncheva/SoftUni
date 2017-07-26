using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var res = new Queue<int>();
            var min = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int amountPetrol = input[0];
                var distance = input[1];

                if (amountPetrol < min)
                {
                    min = amountPetrol;
                    if (res.Count == 1)
                    {
                        res.Dequeue();
                    }
                    res.Enqueue(min);
                }
            }
            Console.WriteLine(res.Dequeue());
        }
    }
}
