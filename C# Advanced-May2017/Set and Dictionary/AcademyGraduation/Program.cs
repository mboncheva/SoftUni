using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AcademyGraduation
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var result = new SortedDictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var score = Console.ReadLine()
                    .Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                var scoreAverage = score.Average();

                if (!result.ContainsKey(name))
                {
                    result[name] = 0;
                }
                result[name] += scoreAverage;
            }
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} is graduated with {item.Value}");
            }
        }
    }
}
