using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortArrayUsingBubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var swapped = false;

            do
            {
                swapped = false;
                for (int i = 0; i < nums.Length-1; i++)
                {
                    var temp = nums[i];
                    if (nums[i+1] < nums[i])
                    {
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;

                        swapped = true;
                    }
                }
            } while (swapped);

            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
