using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ArraySymmetry
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string result = string.Empty;

            for (int i = 0; i < words.Length / 2; i++)
            {
                if (words[i] == words[words.Length-1- i])
                {
                    result = "Yes";
                }
                else
                {
                    result = "No";
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
