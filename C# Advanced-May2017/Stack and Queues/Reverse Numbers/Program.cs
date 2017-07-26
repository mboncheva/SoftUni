using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var res = new Stack<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                res.Push(nums[i]);
            }

              for(int i=0;i<nums.Length;i++)
            {
                Console.Write("{0} ", res.Pop());
            }
        }
    }
}
