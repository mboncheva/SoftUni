using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SentenceSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "end")
            {
                var currentInput = input.Split(new[] { '.', ',', '!', '?', ':', ';', '-', '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var words = new List<string>();
                for (int i = 0; i < currentInput.Length; i++)
                {
                    var word = currentInput[i];
                    var w =  char.ToUpper(word[0]) + word.Substring(1).ToLower();
                    words.Add(w);
                }
                Console.WriteLine(string.Join(", ",words));

                input = Console.ReadLine();
            }
        }
    }
}
