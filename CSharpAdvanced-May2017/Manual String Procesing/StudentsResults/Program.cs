using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentsResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { '-',' ',',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = input[0];
                var cadv = double.Parse(input[1]);
                var coop = double.Parse(input[2]);
                var advoop = double.Parse(input[3]);
                var average = (cadv + coop + advoop)/3;

                Console.WriteLine("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|",name,cadv,coop,advoop,average);

            }
        }
    }
}
