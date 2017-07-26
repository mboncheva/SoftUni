using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.UnunionLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (list.Contains(numbers[j]))
                    {
                        list.RemoveAll(item => item == numbers[j]);
                    }
                    else
                    {
                        list.Add(numbers[j]);
                    }
                }

            }
            list.Sort();
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
