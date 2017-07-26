using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new Dictionary<string, Dictionary<string, long>>();

            while (input != "report")
            {
                var currentInput = input.Split('|');
                var city = currentInput[0];
                var country = currentInput[1];
                var population = int.Parse(currentInput[2]);

                if (!result.ContainsKey(country))
                {
                    result[country] = new Dictionary<string, long>();
                }
                if (!result[country].ContainsKey(city))
                {
                    result[country].Add(city, population);
                }

                input = Console.ReadLine();
            }

            var populat = result
                .OrderByDescending(x => x.Value.Values.Sum());
               

            foreach (var item in populat)
            {
                Console.WriteLine($"{item.Key} (total population: {item.Value.Values.Sum()})");
                var orderValue = item.Value.OrderByDescending(x => x.Value);
                foreach (var value in orderValue)
                {
                    Console.WriteLine("=>{0}: {1}",value.Key,value.Value);
                }
            }
        }
    }
}
