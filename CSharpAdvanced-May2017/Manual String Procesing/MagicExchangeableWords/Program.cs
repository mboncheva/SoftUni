using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var firstWord = input[0];
            var secondWord = input[1];
            
           var result = GetMagixWord(firstWord, secondWord);
            if (result == false)
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine("true");
            }
        }

        private static bool GetMagixWord(string firstWord, string secondWord)
        {
            var magixWord = new Dictionary<char, char>();
            bool isMagix = true;
           
            var lenMin = Math.Min(firstWord.Length, secondWord.Length);
            for (int i = 0; i < lenMin; i++)
            {
                if (!magixWord.ContainsKey(firstWord[i]) && !magixWord.ContainsValue(secondWord[i]))
                {
                    magixWord[firstWord[i]] = secondWord[i];
                }
                else
                {
                    if (magixWord.ContainsKey(firstWord[i]))
                    {
                        if (magixWord[firstWord[i]] != secondWord[i])
                        {
                            isMagix = false;
                            return isMagix;
                        }
                    }
                    else if (magixWord.ContainsValue(secondWord[i]))
                    {
                        isMagix = false;
                        return isMagix;
                    }
                }
            }

            if (firstWord.Length >= secondWord.Length)
            {
                foreach (var item in firstWord)
                {
                    if (!magixWord.ContainsKey(item))
                    {
                        isMagix = false;
                        return isMagix;
                    }
                }
            }
            else
            {
                foreach (var item in secondWord)
                {
                    if (magixWord.ContainsValue(item))
                    {
                        isMagix = false;
                        return isMagix;
                    }
                }
            }
            return isMagix;
        }
       
    }
}
