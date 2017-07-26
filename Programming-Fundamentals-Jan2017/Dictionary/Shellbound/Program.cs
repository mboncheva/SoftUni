using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shellbound
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var result = new Dictionary<string, List<int>>();

            while (input != "Aggregate")
            {
                var currentInput = input.Split(' ');
                var region = currentInput[0];
                var size = int.Parse(currentInput[1]);

                if (!result.ContainsKey(region))
                {
                    result[region] = new List<int>();
                }
                if (!result[region].Contains(size))
                {
                    result[region].Add(size);
                }
                
                input = Console.ReadLine();
            }
            var sum = 0;
            var giantShell = 0;
            foreach (var item in result)
            {
                foreach (var col in item.Value)
                {
                    sum += col;
                }
                giantShell = sum - (sum / item.Value.Count);
                Console.WriteLine("{0} -> {1} ({2})",item.Key,string.Join(", ",item.Value),giantShell);
                sum = 0;
            }
        }
    }
}
