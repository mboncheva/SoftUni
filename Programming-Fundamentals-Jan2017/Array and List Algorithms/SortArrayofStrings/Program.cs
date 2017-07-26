using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SortArrayofStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToList();

            var swapped = false;
            do
            {
                swapped = false;
                for (int i = 0; i < input.Count - 1; i++)
                {
                    var temp = input[i];
                    var res = input[i + 1].CompareTo(input[i]);
                    if (res < 0)
                    {
                        input[i] = input[i + 1];
                        input[i + 1] = temp;
                        swapped = true;
                    }

                }


            } while (swapped);

            Console.WriteLine(string.Join(" ",input));
       }
    }
}
