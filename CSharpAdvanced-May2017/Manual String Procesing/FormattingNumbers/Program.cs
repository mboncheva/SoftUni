using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FormattingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ' ', '\t', '\n'},StringSplitOptions.RemoveEmptyEntries).ToArray();

            var num1 = int.Parse(numbers[0]);
            var numToHex = num1.ToString("X");
            var numToBinary = Convert.ToString(num1, 2);
            var num2 = double.Parse(numbers[1]);
            var num3 = double.Parse(numbers[2]);

            if (numToBinary.Length < 10)
            {
                numToBinary = new string('0', 10 - numToBinary.Length) + numToBinary;
                Console.WriteLine("|{0,-10}|{1,10}|{2,10:f2}|{3,-10:f3}|", numToHex, numToBinary, num2, num3);

            }else
            {
                Console.WriteLine("|{0,-10}|{1,10}|{2,10:f2}|{3,-10:f3}|", numToHex, numToBinary.Substring(0,10), num2, num3);

            }
        }
    }
}
