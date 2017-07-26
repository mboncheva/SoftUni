using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    result.Push(i);
                }

                if (input[i] == ')')
                {
                    var index = result.Pop();
                    var rem = input.Substring(index, i - index+1);
                    Console.WriteLine(rem);
                }
            }
        }
    }
}
