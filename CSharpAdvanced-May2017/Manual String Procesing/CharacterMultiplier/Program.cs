using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var firstWord = input[0];
            var secondWord = input[1];

            MultiplateSum(firstWord, secondWord);
           
        }

        private static void MultiplateSum(string firstWord, string secondWord)
        {
            double sum = 0;

            if (firstWord.Length == secondWord.Length)
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    var mul = firstWord[i] * secondWord[i];
                    sum += mul;
                }
            }

            if (firstWord.Length > secondWord.Length)
            {
                for (int i = 0; i < secondWord.Length; i++)
                {
                    var mul = firstWord[i] * secondWord[i];
                    sum += mul;
                }
                for (int i = secondWord.Length; i < firstWord.Length; i++)
                {
                    sum += firstWord[i];
                }
            }

            if (secondWord.Length > firstWord.Length)
            { 
                for (int i = 0; i < firstWord.Length; i++)
                {
                    var mul = firstWord[i] * secondWord[i];
                    sum += mul;
                }
                for (int i = firstWord.Length; i < secondWord.Length; i++)
                {
                    sum += secondWord[i];
                }

            }
            Console.WriteLine(sum);
        }
    }
}
