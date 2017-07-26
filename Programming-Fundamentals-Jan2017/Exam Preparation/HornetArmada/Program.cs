using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace _04.HornetArmada
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"(\d+) = (.+) -> (.+):(\d+)");

            var dictionary = new Dictionary<string, Dictionary<string, long>>();
            var activities = new Dictionary<string, long>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var matches = regex.Match(line);

                var lastActivity = int.Parse(matches.Groups[1].Value);
                var legionName = matches.Groups[2].Value;
                var soldier = matches.Groups[3].Value;
                var soldierCount = int.Parse(matches.Groups[4].Value);

                if (!dictionary.ContainsKey(legionName))
                {
                    dictionary[legionName] = new Dictionary<string, long>();
                }
                if (!dictionary[legionName].ContainsKey(soldier))
                {
                    dictionary[legionName][soldier] = 0;
                }
                dictionary[legionName][soldier] += soldierCount;


                if (!activities.ContainsKey(legionName) || activities[legionName] < lastActivity)
                {
                    activities[legionName] = lastActivity;
                }
            }

            var command = Console.ReadLine().Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            if (command.Length > 1)
            {
                var num = int.Parse(command[0]);
                var solder = command[1];

                foreach (var legionEntry in dictionary
                    .Where(legion => legion.Value.ContainsKey(solder))
                    .OrderByDescending(legion => legion.Value[solder]))
                {
                    if (activities[legionEntry.Key] < num)
                    {
                        Console.WriteLine("{0} -> {1}", legionEntry.Key, dictionary[legionEntry.Key][solder]);
                    }
                }
            }
            else
            {
                var solderType = command[0];
                var result = activities.OrderByDescending(v => v.Value);
                foreach (var item in result)
                {
                    if (dictionary[item.Key].ContainsKey(solderType))
                    {
                        Console.WriteLine($"{item.Value} : {item.Key}");
                    }
                }

            }
        }
    }
}
