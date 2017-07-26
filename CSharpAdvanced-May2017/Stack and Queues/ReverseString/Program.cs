using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var stack = new Stack<string>();

            stack.Push(text);
            foreach (var item in stack)
            {
               var word = item.Reverse();
                foreach (var w in word)
                {
                    Console.Write(w);
                }
                Console.WriteLine();
            }

        }
    }
}
