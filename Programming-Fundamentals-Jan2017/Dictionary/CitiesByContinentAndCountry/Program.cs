using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            // premahvane na grada
            // population["Bulgaria"].Remove("Plovdiv");

            // premahvane na durjavata
            //population.Remove("Makedonia");

            int n = int.Parse(Console.ReadLine());

            var result = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var text = Console.ReadLine().Split(' ');
                var continents = text[0];
                var country = text[1];
                var city = text[2];

                GetCityCountryCont(result, continents, country, city);

            }

            foreach (var continents in result)
            {
                Console.WriteLine("{0}:",continents.Key);

                var countries = result[continents.Key];
                foreach (var country in countries)
                    {
                        Console.Write("  {0} -> ", country.Key);
                        Console.WriteLine(string.Join(", ",country.Value));
                    }
            }
        }

        private static void GetCityCountryCont(Dictionary<string, Dictionary<string, List<string>>> result,
            string continents,
            string country,
            string city)
        {
            if (!result.ContainsKey(continents))
            {
                result[continents] = new Dictionary<string, List<string>>();
            }
            if (!result[continents].ContainsKey(country))
            { 
                result[continents][country] = new List<string>();
            }
            result[continents][country].Add(city);
        }
    }
}