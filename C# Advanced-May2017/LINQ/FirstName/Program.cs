using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstName
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var letters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(l=>l)
                .ToList();

            var name = string.Empty;
            foreach (var letter in letters)
            {
                 name = names.Where(n => n.ToLower().StartsWith(letter.ToLower())).FirstOrDefault();
                if (name != null)
                {
                    Console.WriteLine(name);
                    break;
                }
            }
            if (name == null)
            {
                Console.WriteLine("No match");
            }

        }
    }
}
