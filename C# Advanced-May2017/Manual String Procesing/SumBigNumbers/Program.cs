using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = Console.ReadLine();
            var secondNumber = Console.ReadLine();

            if (firstNumber.Length >= secondNumber.Length)
            {
                secondNumber = new string('0', firstNumber.Length - secondNumber.Length) + secondNumber;
            }
            else
            {
                firstNumber = new string('0', secondNumber.Length - firstNumber.Length) + firstNumber;
            }

            SumOfNumbers(firstNumber, secondNumber);
        }

        private static void SumOfNumbers(string firstNumber, string secondNumber)
        {
            var result = new StringBuilder();

            var sum = 0;
            var rem = 0;
            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                var num1 = int.Parse(firstNumber[i].ToString());
                var num2 = int.Parse(secondNumber[i].ToString());
                sum = num1 + num2 + rem;
                rem = sum / 10;
                var resultString = sum.ToString();
                result.Append(resultString.Last());
            }
            if (rem != 0)
            {
                result.Append(rem);
            }
            var res= result.ToString().Reverse().ToArray();
            foreach (var item in res)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
