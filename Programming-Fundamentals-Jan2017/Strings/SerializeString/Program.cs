using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SerializeString
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dictonary = new Dictionary<char, List<int>>();

            for (int i = 0; i < input.Length; i++)
            {
                var character = input[i];
                if (!dictonary.ContainsKey(character))
                {
                    dictonary[character] = new List<int>();
                }

                dictonary[character].Add(i);
            }

            foreach (var item in dictonary)
            {
                Console.WriteLine("{0}:{1}",item.Key,string.Join("/",item.Value));
            }
        }
    }
}
