using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.StringRepeater
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
           string wordNew = GetString(word,num);
            Console.WriteLine(wordNew);
        }

        private static string GetString(string word, int num)
        {
            string repeatedString = string.Empty;
            for (int i = 0; i < num; i++)
            {
                repeatedString += word;
            }
            return repeatedString;
        }
    }
}
