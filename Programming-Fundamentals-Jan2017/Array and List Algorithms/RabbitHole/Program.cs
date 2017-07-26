using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RabbitHole
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCommand = Console.ReadLine().Split(' ').ToList();
            int energy = int.Parse(Console.ReadLine());
            int index = 0;
            bool lastBomb = false;

            while (energy > 0)
            {
                string[] command = inputCommand[index].Split('|').ToArray();
                    string CurentCommand = command[0];

                if (CurentCommand == "RabbitHole")
                {
                    Console.WriteLine("You have 5 years to save Kennedy!");
                    break;
                }
                    int value = int.Parse(command[1]);
                    lastBomb = false;
                switch (CurentCommand)
                    {
                        case "Left":
                        index = Math.Abs(index - value) % inputCommand.Count;
                        energy -= value;
                            break;

                        case "Right":
                        index = (index + value) % inputCommand.Count;
                        energy -= value;
                            break;

                        case "Bomb":
                        inputCommand.RemoveAt(index);
                        index = 0;
                        energy -= value;
                        lastBomb = true;
                            break;
                    }

                if (inputCommand[inputCommand.Count - 1] != "RabbitHole")
                {
                    inputCommand.RemoveAt(inputCommand.Count - 1);
                }
                inputCommand.Add("Bomb|" + energy);

                if (energy <=0 && lastBomb)
                {
                    Console.WriteLine("You are dead due to bomb explosion!");
                }
                else if (energy <= 0 && !lastBomb)
                {
                    Console.WriteLine("You are tired. You can't continue the mission.");
                }
            }
        }
    }
}
