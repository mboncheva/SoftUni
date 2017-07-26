using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.HandsofCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var playerValue = new Dictionary<string, HashSet<string>>();

            while (input != "JOKER")
            {
                var currentInput = input.Split(':');
                var name = currentInput[0].Trim();
                var cards = currentInput[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!playerValue.ContainsKey(name))
                {
                    playerValue[name] = new HashSet<string>();
                }
                foreach (var item in cards)
                {
                    playerValue[name].Add(item);
                }
                input = Console.ReadLine();
            }

            foreach (var item in playerValue)
            {
                long sum = 0;
                foreach (var value in item.Value)
                {
                    var first=string.Empty;
                    char second;
                    if (value.Length > 2)
                    {
                       first = value[0].ToString() + value[1].ToString();
                        second = value[2];
                    }
                    else
                    {
                        first = value[0].ToString();
                        second = value[1];
                    }
                   
                  var sumCard = SumCard(first, second);
                    sum += sumCard;
                }
                Console.WriteLine($"{item.Key}: {sum}");
            }
        }

        private static long SumCard(string first, char second)
        {
            var sum = 0;
            switch (first)
            {
                case "J": sum = 11; 
                    break;
                case "Q": sum = 12;
                    break;
                case "K": sum = 13;
                    break;
                case "A": sum = 14;
                    break;
            }
            int num;
            if (int.TryParse(first,out num))
            {
                sum = num;
            }
            switch (second)
            {
                case 'S': sum *= 4;
                    break;
                case 'H':sum *= 3;
                    break;
                case 'D': sum *= 2;
                    break;
                case 'C': sum *= 1;
                    break;
            }

            return sum;
        }
    }
}
