using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var result = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                var userName = Console.ReadLine();
                result.Add(userName);
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
