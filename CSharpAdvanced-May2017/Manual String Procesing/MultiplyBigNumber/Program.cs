using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = Console.ReadLine();
            var secondNumber = int.Parse(Console.ReadLine());

            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }
            var result = new StringBuilder();
            var sum = 0;
            var rem = 0;

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                var num1 = int.Parse(firstNumber[i].ToString());

                sum = (num1 * secondNumber) + rem;
                rem = sum / 10;

                var resultString = sum.ToString();
                result.Append(resultString.Last());
            }
            if (rem != 0)
            {
                result.Append(rem);
            }
            var res = result.ToString().Reverse().ToArray();
            foreach (var item in res)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}