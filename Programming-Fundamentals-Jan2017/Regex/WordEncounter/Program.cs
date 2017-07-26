using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.WordEncounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            var letter = input[0];
            int num = input[1] - '0';
           
            var result = new List<string>();

            var command = Console.ReadLine();

            while (command != "end")
            {
                var regex = new Regex("[A-Z].*?[!?.]");

                if (regex.IsMatch(command))
                {
                    var res = regex.Matches(command);

                    foreach (Match item in res)
                    {
                        var text = item.Value
                         .Split(new[]
                         { ',', ':', ';', ')', '(', '.', '?', '!', '/', '\\','"','\'',
                             ' ' },StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < text.Length; i++)
                        {
                            var count = 0;
                            var word = text[i].ToCharArray();
                            for (int j = 0; j < word.Length; j++)
                            {
                                if (word[j] == letter)
                                {
                                    count++;
                                }
                            }
                            if (count >= num)
                            {
                                result.Add(text[i]);
                            }
                        }
                    }
                }
               
                command = Console.ReadLine();
            }

            if (result.Count > 0)
            {
                Console.WriteLine(string.Join(", ", result));
            }
            
        }
    }
}
