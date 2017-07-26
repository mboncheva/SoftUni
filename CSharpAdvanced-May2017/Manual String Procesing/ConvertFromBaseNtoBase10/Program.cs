using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _05.ConvertFromBaseNtoBase10
{
    class Program
    {
        static void Main(string[] args)
        {
           var input = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            var n = input[0];
            var baseNnumber = input[1];

            string strBaseNnumber = baseNnumber.ToString();

            BigInteger result = 0;

            for (int i = strBaseNnumber.Length - 1, j = 0; i >= 0; i--, j++)
            {
                BigInteger num = BigInteger.Parse(strBaseNnumber[i].ToString());
                BigInteger pow = 1;

                for (int k = 1; k <= j; k++)
                {
                    pow *= n;
                }

                result += num * pow;
            }

            Console.WriteLine(result);
        }
    }
}