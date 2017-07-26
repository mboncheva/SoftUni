using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Hello_Name_
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            GetName(name);
        }

        private static void GetName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
