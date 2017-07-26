using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var ladyBugsIndexes = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToArray();

            var field = new int[size];

            foreach (var item in ladyBugsIndexes)
            {
                if (item < 0 || item >= size)
                {
                    continue;
                }
                field[item] = 1;
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                var currentCommand = command.Split(' ').ToList();

                var ladybugIndex = int.Parse(currentCommand[0]);
                var direction = currentCommand[1];
                var flyLenght = int.Parse(currentCommand[2]);

                if (ladybugIndex < 0 || ladybugIndex >= size)
                {
                    continue;
                }
                
                if (field[ladybugIndex] == 0)
                {
                    continue;
                }

                field[ladybugIndex] = 0;
                var position = ladybugIndex;

                while (true)
                {
                    if (direction == "right")
                    {
                        position += flyLenght;
                    }

                    else if (direction == "left")
                    {
                        position -= flyLenght;
                    }

                    if (position < 0 || position >= size)
                    {
                        break;
                    }

                    if (field[position] == 1)
                    {
                        continue;
                    }
                    else
                    {
                        field[position] = 1;
                        break;
                    }
                  
                }
            }

            Console.WriteLine(string.Join(" ",field));
        }
    }
}
