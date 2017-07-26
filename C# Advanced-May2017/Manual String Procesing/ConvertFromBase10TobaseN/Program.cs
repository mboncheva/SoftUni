using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _04.ConvertFromBase10TobaseN
{
    class Program
    {
        static void Main(string[] args)
        {
           var input = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            var n = input[0];
            var decNumber = input[1];

            StringBuilder rs = new StringBuilder();

            while (decNumber > 0)
            {
                BigInteger rem = decNumber % n;
                rs.Append(rem);
                decNumber = decNumber / n;
            }

            string str = rs.ToString();

            StringBuilder result = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                result.Append(str[i]);
            }

            Console.WriteLine(result.ToString());
           
        }
    }
}