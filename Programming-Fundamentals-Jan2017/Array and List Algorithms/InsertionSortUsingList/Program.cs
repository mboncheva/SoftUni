using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.InsertionSortUsingList
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numbers = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var inserted = false;
                var curentElement = nums[i];
                for (int j = 0; j < numbers.Count; j++)
                {
                    var curentListElement = numbers[j];
                    if (curentElement <= curentListElement)
                    {
                        inserted = true;
                        numbers.Insert(Math.Max(0, j), curentElement);
                        break;
                    }
                }
                if (!inserted)
                {
                    numbers.Add(curentElement);
                }
            }
            
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
