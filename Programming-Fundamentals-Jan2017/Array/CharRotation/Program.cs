using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CharRotation
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string textConvert = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    textConvert += (char)(text[i]-numbers[i]);
                }
                else
                {
                    textConvert += (char)(text[i] + numbers[i]);
                }
            }
           
            Console.WriteLine(textConvert);
            
        }
    }
}
