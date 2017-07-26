using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.FootballStandings
{
    class Program
    {
        static void Main(string[] args)
        {
            var teamsScore = new Dictionary<string, int>();
            var topTeams = new Dictionary<string, int>();

            var key = Console.ReadLine();
            key = Regex.Escape(key);
            var regex = new Regex($@"{key}(.*?){key}");

            while (true)
            {
                var footballMatch = Console.ReadLine();
                if (footballMatch == "final")
                {
                    break;
                }

                var currentFootballMatch = footballMatch.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var team1 = currentFootballMatch[0];
                var team2 = currentFootballMatch[1];
                var goals = currentFootballMatch[2].Split(':');

                var teamName1 = regex.Match(team1).Groups[1].Value;
                var teamName2 = regex.Match(team2).Groups[1].Value;
                
                // moje i sus: string.Join("",name.ToUpper().Reverse())
                var firstTeamName = String.Concat(teamName1.ToUpper().Reverse());
                var secondTeamName = String.Concat(teamName2.ToUpper().Reverse());

                var firstTeamScore = int.Parse(goals[0]);
                var secondTeamScore = int.Parse(goals[1]);

                AddTeamScore(teamsScore, firstTeamName, secondTeamName, firstTeamScore, secondTeamScore);
                AddTopTeam(topTeams, firstTeamName,secondTeamName,firstTeamScore,secondTeamScore);
                
            }

            var resultScore = teamsScore
                 .OrderByDescending(v => v.Value)
                 .ThenBy(n => n.Key);

            var resultTopTeams = topTeams
                .OrderByDescending(v => v.Value)
                .ThenBy(n => n.Key)
                .Take(3);

            var num = 1;
            Console.WriteLine("League standings:");
            foreach (var scores in resultScore)
            {
                Console.WriteLine($"{num}. {scores.Key} {scores.Value}");
                num++;
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach (var top in resultTopTeams)
            {
                Console.WriteLine($"- {top.Key} -> {top.Value}");
            }
        }

        private static void AddTeamScore(Dictionary<string, int> teamScore, 
            string firstTeamName, string secondTeamName,
            int firstTeamScore, int secondTeamScore)
        {
            var pointFirst = 0;
            var pointSecond = 0;

            if (firstTeamScore > secondTeamScore)
            {
                pointFirst = 3;
                pointSecond = 0;
            }
            else if (secondTeamScore > firstTeamScore)
            {
                pointSecond = 3;
                pointFirst = 0;
            }
            else 
            {
                pointFirst = 1;
                pointSecond = 1;
            }

            if (!teamScore.ContainsKey(firstTeamName))
            {
                teamScore[firstTeamName] = 0;
            }
            teamScore[firstTeamName] += pointFirst;
            if (!teamScore.ContainsKey(secondTeamName))
            {
                teamScore[secondTeamName] = 0;
            }
            teamScore[secondTeamName] += pointSecond;
        }

        private static void AddTopTeam(Dictionary<string, int> topTeam, 
            string firstTeamName, string secondTeamName,
            int firstTeamScore, int secondTeamScore)
        {
            if (!topTeam.ContainsKey(firstTeamName))
            {
                topTeam[firstTeamName] = 0;
            }
            topTeam[firstTeamName] += firstTeamScore;

            if (!topTeam.ContainsKey(secondTeamName))
            {
                topTeam[secondTeamName] = 0;
            }
            topTeam[secondTeamName] += secondTeamScore;
        }
    }
}
