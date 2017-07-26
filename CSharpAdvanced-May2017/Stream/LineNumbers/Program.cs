using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var rider=new StreamReader(@"..\..\text.txt"))
            {
                using (var writer=new StreamWriter(@"..\..\textResult.txt"))
                {
                    var line = rider.ReadLine();
                    var count = 1;
                    while (line != null)
                    {
                        writer.WriteLine("{0}. {1}",count,line);
                        count++;
                        line = rider.ReadLine();
                    }
                }
            }
        }
    }
}
