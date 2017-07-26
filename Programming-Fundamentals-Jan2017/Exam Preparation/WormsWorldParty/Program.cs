using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WormsWorldParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new Dictionary<string, Dictionary<string, int>>();
           
            while (input != "quit")
            {
                var currentInput = input.Split(new[] { '-', '>' }).ToList();
                var wormName = currentInput[0].Trim();
                var teamName = currentInput[2].Trim();
                var score = int.Parse(currentInput[4].Trim());

                
                if (!result.ContainsKey(teamName))
                {
                    result[teamName] = new Dictionary<string, int>();
                }

                bool isMatch = true;
                foreach (var team in result)
                {
                    var teamCont = team.Value;
                    if (teamCont.ContainsKey(wormName))
                    {
                        isMatch = false;
                        continue;
                    }

                }

                if (!result[teamName].ContainsKey(wormName))
                {
                    if (isMatch)
                    {
                        result[teamName][wormName] = score;
                    }
                    
                }
               
                input = Console.ReadLine();
            }

            result = result
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenByDescending(x => x.Value.Values.Sum() / x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            var count = 1;
            foreach (var team in result)
            {
                var nameOfTeam = team.Key;
                var teamInfo = team.Value.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                var sumTeamScore = team.Value.Sum(x => x.Value);


                Console.WriteLine($"{count}. Team: {nameOfTeam} - {sumTeamScore}");

                foreach (var worm in teamInfo)
                {
                    Console.WriteLine($"###{worm.Key} : {worm.Value}");
                }
                count++;
            }

        }
    }
}
