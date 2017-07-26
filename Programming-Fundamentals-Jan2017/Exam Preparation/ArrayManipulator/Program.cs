using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var command = Console.ReadLine();

            while (command != "end")
            {
                var currentCommand = command.Split(' ');

                var firstCommand = currentCommand[0];
                switch (firstCommand)
                {
                    case "exchange": var index = int.Parse(currentCommand[1]);
                       array = ExchangeArr(array, index);
                        break;

                    case "max": 
                    case "min":
                        var maxOrMin = currentCommand[1];
                        MaxOrMin(array,firstCommand, maxOrMin);
                        break;

                    case "first":
                    case "last":
                        var count = int.Parse(currentCommand[1]);
                        var firstOrLast = currentCommand[2];
                        if (count > array.Length)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }
                        FirsOrlast(array, firstCommand, count, firstOrLast);
                        break;

                }


                command = Console.ReadLine();
            }
            Console.WriteLine("[{0}]",string.Join(", ",array));
        }

        
        private static int[] ExchangeArr(int[] array, int index)
        {
            var isValid = index >= 0 && index < array.Length;

            if (!isValid)
            {
                Console.WriteLine("Invalid index");
                return array;
            }

            var leftRight = array.Take(index + 1);
            var rightPart = array.Skip(index + 1);
            var arr = rightPart.Concat(leftRight).ToArray();
            return arr;
        }

        private static void MaxOrMin(int[] array,string firstCommand,string secondCommand)
        {
            if (secondCommand == "even")
            {
                var evenElements = new List<int>();
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                    {
                        evenElements.Add(array[i]);
                    }
                }
                if (evenElements.Count == 0)
                {
                    Console.WriteLine("No matches");
                    return;
                }
                if (firstCommand == "max")
                {
                    int max = evenElements.Max();
                    Console.WriteLine(Array.LastIndexOf(array,max));
                }
                else if (firstCommand == "min")
                {
                    int min = evenElements.Min();
                    Console.WriteLine(Array.LastIndexOf(array, min));
                }
            }
            else if (secondCommand == "odd")
            {
                var oddElements = new List<int>();
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0)
                    {
                        oddElements.Add(array[i]);
                    }
                }
                if (oddElements.Count == 0)
                {
                    Console.WriteLine("No matches");
                    return;
                }
                if (firstCommand == "max")
                {
                    int max = oddElements.Max();
                    Console.WriteLine(Array.LastIndexOf(array, max));
                }
                else if (firstCommand == "min")
                {
                    int min = oddElements.Min();
                    Console.WriteLine(Array.LastIndexOf(array, min));
                }

            }
        }

        private static void FirsOrlast(int[] array, string firstCommand, int count, string firstOrLast)
        {
            if (firstOrLast == "even")
            {
                var evenElements = new List<int>();
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                    {
                        evenElements.Add(array[i]);
                    }
                }
                if (evenElements.Count == 0)
                {
                    Console.WriteLine("[]");
                    return;
                }
                if (firstCommand == "first")
                {
                    var firstElements = evenElements.Take(count).ToArray();
                    Console.WriteLine("[{0}]",string.Join(", ",firstElements));
                    return;
                }
                else if (firstCommand == "last")
                {
                    var lastElements = evenElements.ToArray().Reverse().Take(count).Reverse().ToArray();
                    Console.WriteLine("[{0}]", string.Join(", ", lastElements));
                    return;
                }
                
            }
            else if (firstOrLast == "odd")
            {
                var oddElements = new List<int>();
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0)
                    {
                        oddElements.Add(array[i]);
                    }
                }
                if (oddElements.Count == 0)
                {
                    Console.WriteLine("[]");
                    return;
                }
                if (firstCommand == "first")
                {
                    var firstElements = oddElements.Take(count).ToArray();
                    Console.WriteLine("[{0}]", string.Join(", ", firstElements));
                    return;
                }
                else if (firstCommand == "last")
                {
                    var lastElements = oddElements.ToArray().Reverse().Take(count).Reverse().ToArray();
                    Console.WriteLine("[{0}]", string.Join(", ", lastElements));
                    return;
                }
            }
           
        }
    }
}
