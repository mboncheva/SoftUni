using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.IncreasingCrisis
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            
            for (int i = 0; i < n - 1; i++)
            {
                var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                int numsCount = nums.Count;
                int index = 0;
                int curentIndex = 0;
                while(numsCount >= 0)
                {
                    if(nums[index] >= numbers[curentIndex] && nums[index] <= numbers[curentIndex + 1])
                    {
                        numbers.Insert(curentIndex + 1, nums[index]);
                        index++;
                    }
                    curentIndex++;
                    numsCount--;
                   
                }
            }
            
        }
    }
}
