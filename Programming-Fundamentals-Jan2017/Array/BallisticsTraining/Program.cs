using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.BallisticsTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersPlane = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var comands = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double x = 0.00;
            double y = 0.00;

            double xPlane = numbersPlane[0];
            double yPlane = numbersPlane[1];

            for (int i = 0; i < comands.Length; i+=2)
            {
                if (comands[i] == "left")
                {
                    x -= double.Parse(comands[i + 1]);
                }
                else if (comands[i] == "right")
                {
                    x += double.Parse(comands[i + 1]);
                }
                else if (comands[i] == "up")
                {
                    y += double.Parse(comands[i + 1]);
                }
                else if (comands[i] == "down")
                {
                    y -= double.Parse(comands[i + 1]);
                }
            }

            if (x == xPlane && y == yPlane)
            {
                Console.WriteLine($"firing at [{x}, {y}]");
                    Console.WriteLine("got 'em!");
            }
            else
            {
                Console.WriteLine($"firing at [{x}, {y}]");
                Console.WriteLine("better luck next time...");
            }
        }
    }
}
