﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = input[0];
            var s = input[1];
            var x = input[2];

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                var min = int.MaxValue;

                while (stack.Count > 0)
                {
                    var minNum = stack.Pop();
                    if (minNum < min)
                    {
                        min = minNum;
                    }
                }
                Console.WriteLine(min);
            }
        }
    }
}
