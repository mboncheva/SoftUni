using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LetterRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var result = new Dictionary<char, int>();

            foreach (var character in text)
            {
                var curentChar = character;

                if (!result.ContainsKey(curentChar))
                {
                    result[curentChar] = 0;
                }
                result[curentChar]++;

            }

            foreach (var item in result)
            {
                Console.WriteLine("{0} -> {1}",item.Key,item.Value);
            }
        }
    }
}
