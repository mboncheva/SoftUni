using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.WormIpsum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "Worm Ipsum")
            {
                var currentInput = input.Split('.');

                var sentence = currentInput[0];
                var letter = sentence[0];
                if (currentInput.Length == 2 && letter >= 'A' && letter <= 'Z')
                {
                    var currentsentence = sentence.Split(new[] { ' ', ','},StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in currentsentence)
                    {
                        var res = new Dictionary<char, int>();
                        foreach (var letters in word)
                        {
                            if (!res.ContainsKey(letters))
                            {
                                res[letters] = 0;
                            }
                            res[letters]++;
                        }

                      var max= res.Values.Max();
                        if (max > 1)
                        {
                            var maxChar = res.Where(p => p.Value == max).Select(p => p.Key);
                            foreach (var item in maxChar)
                            {
                                sentence = sentence.Replace(word, new string(item, word.Length));

                            }
                        }
                    }
                    Console.WriteLine("{0}.", string.Join(" ", sentence));
                }
                
                input = Console.ReadLine();
            }
        }
    }
}
