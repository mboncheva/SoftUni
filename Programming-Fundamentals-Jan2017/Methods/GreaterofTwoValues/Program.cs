using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.GreaterofTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type.ToLower() == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int result=GetMax(a,b);
                Console.WriteLine(result);

            }
            else if(type.ToLower() == "string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                string result = GetMax(a, b);
                Console.WriteLine(result);
            }
            else if(type.ToLower() == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                char result = GetMax(a, b);
                Console.WriteLine(result);
            }
        }

        private static int GetMax(int a,int b)
        {
            if (a >b)
            {
                return a;
            }
            return b;
        }

        static string GetMax(string a,string b)
        {
            if (a.CompareTo(b) >=0)
            {
                return a;
            }
            return b;
        }

        static char GetMax(char a,char b)
        {
            if (a >b)
            {
                return a;
            }
            return b;
        }
    }
}
