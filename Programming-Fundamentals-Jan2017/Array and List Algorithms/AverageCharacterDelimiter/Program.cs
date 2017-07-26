using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ShootListElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToList();
            var sum = 0;
            var count = 0;
            var average = 0.0;
            
            foreach (var word in input)
            {
                var character = word.ToCharArray();
                foreach (var item in character)
                {
                    sum += item;
                    count++;
                }
                average = sum / count; 
            }
            char averageToChar = (char)average;
            char upper = char.ToUpper(averageToChar);
            

            Console.WriteLine(string.Join($"{upper}",input));
        }
    }
}
