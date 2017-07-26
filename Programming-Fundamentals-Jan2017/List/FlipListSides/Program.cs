using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FlipListSides
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var num = new List<int>();
           
            for (int i = 0; i < numbers.Count-2; i++)
            {
                num.Add(numbers[i + 1]);
            }
           
            num.Reverse();
            num.Insert(0,numbers[0]);
            num.Add(numbers[numbers.Count - 1]);
            Console.WriteLine(string.Join(" ",num));
        }
    }
}
