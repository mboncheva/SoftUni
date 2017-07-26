using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDistricts
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var minPopulation = long.Parse(Console.ReadLine());

            var citiesPopulation = new Dictionary<string, List<long>>();

            foreach (var item in input)
            {
                var populationCity = item.Split(new[] { ':' });
                var city = populationCity[0];
                var population = long.Parse(populationCity[1]);

                if (!citiesPopulation.ContainsKey(city))
                {
                    citiesPopulation[city] = new List<long>();
                }
                citiesPopulation[city].Add(population);
            }

            var result = citiesPopulation
                .Where(p => p.Value.Sum() > minPopulation)
                .OrderByDescending(p => p.Value.Sum());

            foreach (var item in result)
            {
                Console.WriteLine("{0}: {1}",
                    item.Key,
                    string.Join(" ",item.Value.OrderByDescending(p=>p).Take(5)));
            }


        }
    }
}
