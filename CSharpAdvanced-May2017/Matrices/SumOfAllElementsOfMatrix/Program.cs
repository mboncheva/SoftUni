using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumOfAllElementsOfMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var cow = size[0];
            var row = size[1];

            var matrix = new int[cow, row];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var inputRows = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = inputRows[c];
                }
            }
            var sum = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    sum += matrix[r, c];
                }
            }
            Console.WriteLine(cow);
            Console.WriteLine(row);
            Console.WriteLine(sum);
        }
    }
}

// VTORI NACHIN
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var size = Console.ReadLine()
//               .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
//               .Select(int.Parse)
//               .ToArray();

//            var row = size[0];
//            var cow = size[1];

//            var matrix = new int[row][];

//            for (int r = 0; r < matrix.Length; r++)
//            {
//                matrix[r] = Console.ReadLine()
//               .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
//               .Select(int.Parse)
//               .ToArray();
//            }
//            var sum = 0;

//            for (int r = 0; r < matrix.Length; r++)
//            {
//                for (int c = 0; c < matrix[r].Length; c++)
//                {
//                    sum += matrix[r][c];
//                }
//            }
//            Console.WriteLine(row);
//            Console.WriteLine(cow);
//            Console.WriteLine(sum);

//        }
//    }
//}
