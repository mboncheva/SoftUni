using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var matrix = new string[nums[0],nums[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var count = row;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = alphabet[row].ToString() + alphabet[count].ToString() + alphabet[row].ToString();
                    count++;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ",matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
