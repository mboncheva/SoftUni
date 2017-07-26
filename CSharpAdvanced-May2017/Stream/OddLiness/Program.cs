using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OddLiness
{
    class Program
    {
        static void Main(string[] args)
        {
            var encoding = Encoding.GetEncoding(1251);
            Console.OutputEncoding = encoding;

            using (var stream = new StreamReader(@"..\..\result.txt",encoding))
            {
                var line = stream.ReadLine();
                var count = 0;
                while (line != null)
                {
                    if (count % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    count++;
                    line = stream.ReadLine();
                }
            }
        }
    }
}
