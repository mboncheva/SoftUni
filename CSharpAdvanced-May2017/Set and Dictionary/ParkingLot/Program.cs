using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new SortedSet<string>();

            while (input != "END")
            {
                var currentInput=input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (currentInput[0] == "IN")
                {
                    result.Add(currentInput[1]);
                }
                else
                {
                    if (result.Contains(currentInput[1]))
                    {
                        result.Remove(currentInput[1]);
                    }
                }

                input = Console.ReadLine();
            }

            if (result.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
