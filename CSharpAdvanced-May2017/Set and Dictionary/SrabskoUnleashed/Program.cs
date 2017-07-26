using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.SrabskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var result = new Dictionary<string, Dictionary<string, long>>();

            while (input != "End")
            {
                var currentInput = input.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

                if (currentInput.Length < 4 || currentInput.Length > 8 || !input.Contains(" @"))
                {
                    input = Console.ReadLine();
                    continue;
                }
                var singer = string.Empty;
                var venues = string.Empty;

                for (int i = 1; i < currentInput.Length - 2; i++)
                {
                    if (currentInput[i].Contains("@"))
                    {
                        for (int j = 0; j < i; j++)
                        {
                            singer += currentInput[j] + " ";
                        }
                        for (int k = i; k < currentInput.Length-2; k++)
                        {
                            venues += currentInput[k] + " ";
                        }
                        break;
                    }
                }
                singer = singer.Trim();
                venues = venues.Trim('@');
                venues = venues.Trim();

                long ticketPrice = 0;
                long ticketCount = 0;

                try
                {
                    ticketPrice = long.Parse(currentInput[currentInput.Length - 2]);
                    ticketCount = long.Parse(currentInput[currentInput.Length - 1]);
                }
                catch (Exception)
                {
                    input = Console.ReadLine();
                    continue;
                }

                var totalPrice = ticketPrice * ticketCount;

                if (!result.ContainsKey(venues))
                {
                    result[venues] = new Dictionary<string, long>();
                }
                if (!result[venues].ContainsKey(singer))
                {
                    result[venues][singer] = 0;
                }
                result[venues][singer] += totalPrice;

                input = Console.ReadLine();
            }

            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
                var sorted = item.Value.OrderByDescending(x => x.Value);
                foreach (var value in sorted)
                {
                    Console.WriteLine($"#  {value.Key} -> {value.Value}");
                }
            }
        }
    }
}
