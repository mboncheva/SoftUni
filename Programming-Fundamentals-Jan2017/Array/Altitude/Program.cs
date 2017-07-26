using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Altitude
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double hight = double.Parse(arr[0]);

            for (int i = 1; i < arr.Length - 1; i+=2)
            {
                if (arr[i] == "up")
                {
                    hight += int.Parse(arr[i + 1]);
                }
                else if (arr[i] == "down")
                {
                    hight -= int.Parse(arr[i + 1]);
                }
                if (hight <= 0)
                {
                    Console.WriteLine("crashed");
                    break;
                }
            }
            if (hight > 0)
            {
                Console.WriteLine($"got through safely. current altitude: {hight}m");
            }
        }
    }
}
