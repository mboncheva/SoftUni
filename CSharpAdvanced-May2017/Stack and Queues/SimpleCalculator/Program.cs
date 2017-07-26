using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            var numbers = new Stack<string>(input.Reverse());

            while (numbers.Count > 1)
            {
                var firstNum = int.Parse(numbers.Pop());
                var symbol = numbers.Pop();
                var secondNum = int.Parse(numbers.Pop());

                if (symbol == "+")
                {
                   numbers.Push((firstNum + secondNum).ToString());
                }
                else if (symbol == "-")
                {
                    numbers.Push((firstNum - secondNum).ToString());
                }
            }

            Console.WriteLine(numbers.Pop());
        }
    }
}
