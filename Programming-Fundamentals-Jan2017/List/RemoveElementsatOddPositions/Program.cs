using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RemoveElementsatOddPositions
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(' ').ToList();
            var word = new List<string>();
            for (int i = 1; i <= words.Count; i++)
            {
                if (i % 2 == 0)
                {
                    word.Add(words[i-1]);
                }
            }
            Console.WriteLine(string.Join("",word));

           

        }
    }
}
                

         
        
