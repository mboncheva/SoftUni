using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09.QueryMess
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var regexPair = new Regex(@"([^&=?]*)=([^&=]*)");
            var regexValue = @"(%20|\+)+";
            var result = new Dictionary<string, List<string>>();

            while (input != "END")
            {
                var match = regexPair.Matches(input);

                foreach (Match pair in match)
                {
                    var field = pair.Groups[1].Value;
                    field = Regex.Replace(field, regexValue, f => " ").Trim();

                    var value = pair.Groups[2].Value;
                    value = Regex.Replace(value, regexValue, v => " ").Trim();

                    if (!result.ContainsKey(field))
                    {
                        result[field] = new List<string>();
                    }
                    result[field].Add(value);
                }

                foreach (var item in result)
                {
                    Console.Write("{0}=", item.Key);
                    Console.Write("[{0}]", string.Join(", ", item.Value));
                }
                Console.WriteLine();
                result = new Dictionary<string, List<string>>();
                input = Console.ReadLine();
            }
           
        }
    }
}
