using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SmallestElementinArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var smallest = int.MaxValue;

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] < smallest)
                {
                    smallest = nums[i];
                }
            }
            Console.WriteLine(smallest);
        }
    }
}
