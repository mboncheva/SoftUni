using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Placeholders
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "end")
            {
                var currentInput = input.Split(new[] { '>', '-', }, StringSplitOptions.RemoveEmptyEntries);
                var words = currentInput[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < words.Length; i++)
                {
                    string placeholder = "{" + i + "}";

                    currentInput[0] = currentInput[0].Replace(placeholder,words[i]);
                }

                Console.WriteLine(currentInput[0]);
                input = Console.ReadLine();
            }
        }

    }
}