using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new Dictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                var currentInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var ip = currentInput[0].Split(new string[] { "IP="},StringSplitOptions.RemoveEmptyEntries);
                var user = currentInput[2].Split(new string[] { "user=" }, StringSplitOptions.RemoveEmptyEntries);

                if (!result.ContainsKey(user[0]))
                {
                    result[user[0]] = new Dictionary<string, int>();
                }
                if (!result[user[0]].ContainsKey(ip[0]))
                {
                    result[user[0]][ip[0]] = 0;
                }
                result[user[0]][ip[0]]++;

                input = Console.ReadLine();
            }
            result = result
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: ");
                Console.WriteLine("{0}.",string.Join(", ",item.Value.Select(a => $"{a.Key} => {a.Value}")));
            }
        }
    }
}
