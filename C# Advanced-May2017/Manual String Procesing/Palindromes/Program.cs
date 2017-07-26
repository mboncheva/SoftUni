using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ','.',',','!', '?', '<', '>','(',')','-','{','}','|','/','\\','\'','"'}
                ,StringSplitOptions.RemoveEmptyEntries).ToArray();

            var result = new List<string>();

            foreach (var item in input)
            {
                var count = item.Length - 1;
                var isTrue = true;
                for (int i = 0; i < item.Length / 2; i++)
                {
                    if (item[i] != item[count])
                    {
                        isTrue = false;
                        break;
                    }
                    count--;
                }
                if (isTrue && !result.Contains(item))
                {
                    result.Add(item);
                }
            }
            result.Sort();
            Console.WriteLine("[{0}]",string.Join(", ",result));
        }
    }
}
