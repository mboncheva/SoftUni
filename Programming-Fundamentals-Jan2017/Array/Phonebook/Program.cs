using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine()
                .Split(' ');

            string[] names = Console.ReadLine()
                .Split(' ');

            string personName = Console.ReadLine();

            while (personName != "done")
            {
                for (int i = 0; i < names.Length; i++)
                {
                    if (personName == names[i])
                    {
                        Console.WriteLine($"{personName} -> {phones}");
                    }
                }
                personName = Console.ReadLine();
            }

        }
    }
}
