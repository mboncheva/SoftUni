using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new char[nums[0]][];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var letters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                matrix[i] = letters;
            }
            var count = 0;
            for (int row = 0; row < matrix.Length -1; row++)
            {
                for (int col = 0; col < matrix[row].Length -1; col++)
                {
                    var firstLetter = matrix[row][col];
                    var secondLetter = matrix[row][col + 1];
                    var tirthLetter = matrix[row + 1][col];
                    var fourthLetter = matrix[row + 1][col + 1];

                    if (firstLetter == secondLetter && firstLetter == tirthLetter && firstLetter == fourthLetter)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
