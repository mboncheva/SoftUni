using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var result = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var ip = input[0];
                var user = input[1];
                var duration=long.Parse(input[2]);

                if (!result.ContainsKey(user))
                {
                    result[user] = new Dictionary<string, long>();
                }
                if (!result[user].ContainsKey(ip))
                {
                    result[user][ip] = 0;
                }
                result[user][ip] += duration;
            }

            foreach (var item in result.OrderBy(x => x.Key))
            {
                var order = item.Value.OrderBy(x => x.Key).ToDictionary(x=>x.Key,x=>x.Value);
                Console.WriteLine("{0}: {1} [{2}]",item.Key,item.Value.Values.Sum(),string.Join(", ",order.Keys));
            }
        }
    }
}
