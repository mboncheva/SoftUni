using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpperStrings
{
    class Program
    {
        static void Main(string[] args)
        {
           var input= Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var result = input.Select(n => n.ToUpper()).ToList();
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
