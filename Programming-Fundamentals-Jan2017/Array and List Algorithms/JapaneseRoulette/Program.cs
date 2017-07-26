using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.JapaneseRoulette
{
    class Program
    {
        static void Main(string[] args)
        {
            var cylinder = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var command = Console.ReadLine().Split(' ').ToList();

            int muzzel = 0;
            var endPosition = 0;

            for (int i = 0; i < cylinder.Count; i++)
            {
                if (cylinder[i] == 1)
                {
                    muzzel = i;
                }
            }

            bool isFound = false;

            for (int i = 0; i < command.Count; i++)
            {
                isFound = false;
                var curentCommand = command[i].Split(',').ToArray();
                int value = int.Parse(curentCommand[0]);
                string direction = curentCommand[1];

                switch (direction)
                {
                    case "Right":
                        endPosition = (muzzel + value) % cylinder.Count;
                        muzzel = endPosition;
                        break;
                    case "Left":
                        endPosition = (muzzel - value) % cylinder.Count;
                        if (endPosition < 0)
                        {
                            endPosition += cylinder.Count;
                        }
                        muzzel = endPosition;
                        break;
                }
                if (endPosition == 2)
                {
                    Console.WriteLine("Game over! Player {0} is dead.", i);
                    isFound = true;
                    break;
                }
                muzzel++;
            }
            if (!isFound)
            {
                Console.WriteLine("Everybody got lucky!");
            }
        }
    }
}