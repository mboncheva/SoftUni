using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.AMiner_sTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new Dictionary<string, long>();

            while (input != "Stop")
            {

                if (result.ContainsKey(input))
                {
                    result[input] += long.Parse(Console.ReadLine());
                }
                else
                {
                    result[input] = long.Parse(Console.ReadLine());
                }
                input = Console.ReadLine();
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
