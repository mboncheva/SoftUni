using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AppendLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                   .Split('|').ToList();

            input.Reverse();
            var result = new List<string>();
            foreach (var item in input)
            {
                var nums = item.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToList();
                result.AddRange(nums);
            }
            
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
