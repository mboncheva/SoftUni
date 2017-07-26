using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.LargestNElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var n = int.Parse(Console.ReadLine());

            nums.Sort();
            nums.Reverse();

            var num = new List<int>();

            //var num = nums.Take(n);

            for (int i = 0; i < n; i++)
            {
                num.Add(nums[i]);
            }
            Console.WriteLine(string.Join(" ",num));

        }
    }
}
