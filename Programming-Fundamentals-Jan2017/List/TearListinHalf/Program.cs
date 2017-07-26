using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.TearListinHalf
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var leftNums = new List<int>();
            var rightNums = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                leftNums.Add(numbers[i]);
            }
            for (int i = numbers.Count; i > numbers.Count / 2; i--)
            {
                rightNums.Add(numbers[i-1]);
            }
            rightNums.Reverse();

            var listDigit = new List<int>();

            for (int i = 0; i < rightNums.Count; i++)
            {
                listDigit.Add(rightNums[i] / 10);
                listDigit.Add(rightNums[i] % 10);
                
            }
            var n = 0;
            for (int i = 1; i < leftNums.Count * 3 - 1; i+=3)
            {
               
                listDigit.Insert(i, leftNums[n]);
                n++;
            }
            Console.WriteLine(string.Join(" ",listDigit));
           


        }
    }
}
