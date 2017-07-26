using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SortArrayUsingInsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 1; i < nums.Length-1; i++)
            {
                var j = i + 1;
                while (j > 0)
                {
                    if (nums[j] < nums[j-1])
                    {
                        var temp = nums[j];
                        nums[j] = nums[j - 1];
                        nums[j - 1] = temp;
                    }

                    j--;
                }
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
