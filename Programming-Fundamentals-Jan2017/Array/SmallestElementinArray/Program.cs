﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SmallestElementinArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int min = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            Console.WriteLine(min);
        }
    }
}
