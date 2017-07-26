using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            var binaryNum = new Stack<int>();
            if (number == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (number > 0)
                {
                    var rem = number % 2;
                    number = number / 2;
                    binaryNum.Push(rem);
                }
            }

            foreach (var item in binaryNum)
            {
                Console.Write(item);
            }
           
        }
    }
}
