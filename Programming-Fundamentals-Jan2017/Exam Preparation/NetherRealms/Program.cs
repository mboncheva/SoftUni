using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Demon
{
    public string Name { get; set; }

    public int Health { get; set; }

    public double Damage { get; set; }
}

namespace _03.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new SortedDictionary<string, Demon>();

            foreach (var word in text)
            {
                var health = 0;
                var damage = 0.0;

                var character = word.ToCharArray();
                foreach (var item in character)
                {
                    int num;
                    if (int.TryParse(item.ToString(), out num))
                    {
                        continue;
                    }
                    if (item != '-' && item != '+' && item != '*' && item != '/' && item != '.')
                    {
                        health += item;
                    }
                }

                var pattern = @"-?\d+\.?\d*";
                var regex = new Regex(pattern);

                var match = regex.Matches(word);

                foreach (Match num in match)
                {
                    double number = double.Parse(num.Value);
                    damage += number;
                }

                var symbol = word.Where(s => s == '*' || s == '/');

                foreach (var sym in symbol)
                {
                    if (sym == '*')
                    {
                        damage *= 2;
                    }
                    else if(sym == '/')
                    {
                        damage /= 2;
                    }
                }
                var demon = new Demon
                {
                    Name = word,
                    Health = health,
                    Damage = damage
                };

                result.Add(word, demon);
            }

            foreach (var item in result)
            {
                var demonResult = item.Value;
                Console.WriteLine("{0} - {1} health, {2:f2} damage",demonResult.Name,demonResult.Health,demonResult.Damage);
            }
        }
    }
}
