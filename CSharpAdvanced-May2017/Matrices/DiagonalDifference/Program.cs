using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var inputNumbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = inputNumbers;
            }

            var sumFirstDiagonal = 0;
            var sumSecondDiagonal = 0;

                var countCol = matrix.Length;

                for (int col = 0; col < matrix.Length; col++)
                {
                    sumFirstDiagonal += matrix[col][col];
                    sumSecondDiagonal += matrix[countCol - 1][col];
                    countCol--;
                }
            var difference = Math.Abs(sumFirstDiagonal - sumSecondDiagonal);
            Console.WriteLine(difference);
        }
    }
}
