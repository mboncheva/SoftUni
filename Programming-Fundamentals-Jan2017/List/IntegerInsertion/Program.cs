using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IntegerInsertion
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command = Console.ReadLine();
           
            while (command != "end")
            {
                char[] numsCommand = command.ToCharArray();
                char num = numsCommand[0];
                int digit = (int)(num - '0');

                int number;
                int.TryParse(command, out number);

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (digit == i)
                    {
                        numbers.Insert(i, number);
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
