using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(new[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var text = Console.ReadLine();

            foreach (var item in words)
            {
                text = text.Replace(item, new string('*', item.Length));
            }
            Console.WriteLine(text);
        }
    }
}
