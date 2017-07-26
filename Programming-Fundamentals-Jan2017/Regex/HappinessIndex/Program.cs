using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.HappinessIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var happyCount = 0;
            var sadCount = 0.0;
            double happyIndex = 0.0;

            var pattern = @"([:;][)}\]D*])|([(*c[][:;])|([:;][([{c])|([D)\]][:;])";

            var regex = new Regex(pattern);
            var match = regex.IsMatch(text);

            if (match)
            {
                var matches = regex.Matches(text);

                foreach (Match item in matches)
                {
                    if (item.Value == item.Groups[1].Value || item.Value == item.Groups[2].Value)
                    {
                        happyCount++;
                    }
                    else if(item.Value == item.Groups[3].Value || item.Value == item.Groups[4].Value)
                    {
                        sadCount++;
                    }
                }
               happyIndex = happyCount / sadCount;
            }

            if (happyIndex >= 2)
            {
                Console.WriteLine("Happiness index: {0:f2} :D",happyIndex);
                Console.WriteLine("[Happy count: {0}, Sad count: {1}]",happyCount,sadCount);
            }
            else if (happyIndex > 1)
            {
                Console.WriteLine("Happiness index: {0:f2} :)", happyIndex);
                Console.WriteLine("[Happy count: {0}, Sad count: {1}]", happyCount, sadCount);
            }
            else if (happyIndex == 1)
            {
                Console.WriteLine("Happiness index: {0:f2} :|", happyIndex);
                Console.WriteLine("[Happy count: {0}, Sad count: {1}]", happyCount, sadCount);
            }
            else
            {
                Console.WriteLine("Happiness index: {0:f2} :(", happyIndex);
                Console.WriteLine("[Happy count: {0}, Sad count: {1}]", happyCount, sadCount);
            }
        }
    }
}
