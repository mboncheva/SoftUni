using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CommandInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();


            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                var currentInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = currentInput[0];
                
                    switch (command)
                    {
                        case "rollLeft":
                        var leftCount = int.Parse(currentInput[1]);
                        if (leftCount >= 0)
                        {
                            RollLeft(array, leftCount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;

                        case "rollRight":
                        var rightCount = int.Parse(currentInput[1]);
                        if (rightCount >= 0)
                        {
                            RollRight(array, rightCount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");

                        }
                        
                            break;

                    case "reverse":
                        int start = int.Parse(currentInput[2]);
                        int count = int.Parse(currentInput[4]);
                        bool resReverse = start >= 0 && start < array.Count && count >= 0 && (count + start) <= array.Count;
                        if (resReverse)
                        {
                            array.Reverse(start, count);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;
                    case "sort":
                        int sortStart = int.Parse(currentInput[2]);
                        int sortCount = int.Parse(currentInput[4]);

                        bool resSort = sortStart >= 0 && sortStart < array.Count && sortCount >= 0 
                            && (sortCount + sortStart) <= array.Count;
                        if (resSort)
                        {
                            array.Sort(sortStart, sortCount,null);
               
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }

                        break;

                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", array));

        }

        private static void RollLeft(List<string> array, int count)
        {
            // za da ne povtarqm vurteneteto na masiva
            var rotation = count % array.Count;
            for (int i = 0; i < rotation; i++)
            {
                var firstElement = array[0];

                for (int j = 0; j < array.Count - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Count - 1] = firstElement;
            }

        }

        private static void RollRight(List<string> array, int count)
        {
            var rotation = count % array.Count;
            for (int i = 0; i < rotation; i++)
            {
                var lastElement = array[array.Count - 1];

                for (int j = array.Count - 1; j > 0; j--)
                {
                    array[j] = array[j - 1];
                }

                array[0] = lastElement;
            }
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace _01.Zad
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var input = Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();

//            while (true)
//            {
//                var command = Console.ReadLine();
//                if (command == "end")
//                {
//                    break;
//                }
//                var currentCommand = command.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

//                var firstCommand = currentCommand[0];
//                switch (firstCommand)
//                {
//                    case "reverse":
//                        var reverseStart = int.Parse(currentCommand[2]);
//                        var reverseCount = int.Parse(currentCommand[4]);
//                        if (reverseCount < 0 || reverseStart >= input.Length || reverseStart + reverseCount > input.Length
//                            || reverseStart < 0)
//                        {
//                            Console.WriteLine("Invalid input parameters.");
//                            continue; ;
//                        }
//                        GetReverseArr(input, reverseStart, reverseCount);
//                        break;

//                    case "sort":
//                        var startSort = int.Parse(currentCommand[2]);
//                        var sortCount = int.Parse(currentCommand[4]);
//                        if (sortCount < 0 || startSort > input.Length || startSort < 0 || startSort + sortCount > input.Length)
//                        {
//                            Console.WriteLine("Invalid input parameters.");
//                            continue; ;
//                        }
//                        GetSortArr(input, startSort, sortCount);
//                        break;

//                    case "rollLeft":
//                        var leftCount = int.Parse(currentCommand[1]);
//                        if (leftCount >= 0)
//                        {
//                            GetRollLeft(input, leftCount);
//                        }
//                        else
//                        {
//                            Console.WriteLine("Invalid input parameters.");
//                        }

//                        break;

//                    case "rollRight":
//                        var rightCount = int.Parse(currentCommand[1]);
//                        if (rightCount >= 0)
//                        {
//                            GetRollRight(input, rightCount);
//                        }
//                        else
//                        {
//                            Console.WriteLine("Invalid input parameters.");
//                        }


//                        break;

//                }

//            }
//            Console.WriteLine("[{0}]",string.Join(", ",input));
//        }

//        private static void GetReverseArr(string[] input, int reverseStart, int reverseCount)
//        {
//            Array.Reverse(input, reverseStart, reverseCount);

//        }

//        private static void GetSortArr(string[] input, int startSort, int sortCount)
//        {
//            Array.Sort(input, startSort, sortCount);

//        }

//        private static void GetRollRight(string[] input, int rightCount)
//        {
//            var roll = rightCount % input.Length;
//            for (int i = 0; i < roll; i++)
//            {
//                var last = input[input.Length - 1];
//                for (int j = input.Length - 1; j > 0; j--)
//                {
//                    input[j] = input[j - 1];
//                }
//                input[0] = last;

//            }

//        }

//        private static void GetRollLeft(string[] input, int leftCount)
//        {
//            var roll = leftCount % input.Length;
//            for (int i = 0; i < roll; i++)
//            {
//                var first = input[0];
//                for (int j = 0; j < input.Length - 1; j++)
//                {
//                    input[j] = input[j + 1];
//                }
//                input[input.Length - 1] = first;

//            }

//        }
//    }
//}