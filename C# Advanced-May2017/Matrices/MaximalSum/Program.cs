using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new long[size[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }

            var maxSum=long.MinValue;
            var maxRow = 0;
            var maxCol = 0;
            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                   var sumOne = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2];
                   var sumTwo = matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2];
                   var sumThree = matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row +2][col + 2];
                    var sum = sumOne + sumTwo + sumThree;

                    if (sum > maxSum)
                    {
                        maxRow = row;
                        maxCol = col;
                        maxSum = sum;
                    }
                }
            }
            Console.WriteLine("Sum = {0}",maxSum);

            Console.WriteLine("{0} {1} {2}",
                matrix[maxRow][maxCol], matrix[maxRow][maxCol + 1],matrix[maxRow][maxCol + 2]);
            Console.WriteLine("{0} {1} {2}",
                matrix[maxRow + 1][maxCol], matrix[maxRow + 1][maxCol + 1],matrix[maxRow + 1][maxCol + 2]);
            Console.WriteLine("{0} {1} {2}", 
                matrix[maxRow + 2][maxCol], matrix[maxRow + 2][maxCol + 1] ,matrix[maxRow + 2][maxCol + 2]);
          
        }

    }
}
