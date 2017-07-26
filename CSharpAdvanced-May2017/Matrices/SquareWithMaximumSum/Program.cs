using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
               .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var r = size[0];
            var c = size[1];

            var matrix = new int[r][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row]= Console.ReadLine()
               .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            }

            var bestSum = int.MinValue;
            var bestRow=0;
            var bestCow = 0;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int cow = 0; cow < matrix[row].Length - 1; cow++)
                {
                    int sum = matrix[row][cow] + matrix[row][cow + 1] + matrix[row + 1][cow] + matrix[row + 1][cow + 1];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCow = cow;
                    }
                }
            }
            Console.WriteLine("{0} {1}",matrix[bestRow][bestCow],matrix[bestRow][bestCow + 1]);
            Console.WriteLine("{0} {1}",matrix[bestRow + 1][bestCow],matrix[bestRow + 1][bestCow + 1]);
            Console.WriteLine(bestSum);
        }
    }
}
