using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.HornetAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            var messages = new List<string>();
            var broadcasts = new List<string>();

            var regexMessage = new Regex(@"^(\d+) <-> ([a-zA-Z0-9]+)$");
            var regexBroadcast = new Regex(@"^(\D+) <-> ([a-zA-Z0-9]+)$");

            var input = Console.ReadLine();

            while (input != "Hornet is Green")
            {
                if (regexMessage.IsMatch(input))
                {
                    var matc = regexMessage.Match(input);
                    var recipient = string.Join("", matc.Groups[1].Value.Reverse());
                    var message = matc.Groups[2].Value;

                    messages.Add(recipient + " -> " + message);
                }

                if (regexBroadcast.IsMatch(input))
                {
                    var match = regexBroadcast.Match(input);
                    var frequency = match.Groups[2].Value;
                    var word = new StringBuilder();
                    foreach (var item in frequency)
                    {
                        if (item >= 'a' && item <= 'z')
                        {
                            var letter = item.ToString().ToUpper();
                            word.Append(letter);
                        }
                        else if (item >= 'A' && item <= 'Z')
                        {
                            var letter = item.ToString().ToLower();
                            word.Append(letter);
                        }
                        else
                        {
                            word.Append(item);
                        }
                    }
                    var res = word.ToString();
                    var message = match.Groups[1].Value;
                    broadcasts.Add(res + " -> " + message);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine(string.Join("\n", broadcasts));
            }
            Console.WriteLine("Messages:");
            if (messages.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine(string.Join("\n", messages));
            }
        }
    }
}
