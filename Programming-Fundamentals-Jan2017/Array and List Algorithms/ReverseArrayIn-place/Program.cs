using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ReverseArrayIn_place
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < nums.Length / 2; i++)
            {
                var temp = nums[i];
                nums[i] = nums[nums.Length - 1-i];
                nums[nums.Length - 1-i] = temp;

            }
            Console.WriteLine(string.Join(" ",nums));

        }
    }
}
