using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RegisterUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var userRegister = new Dictionary<string, DateTime>();

            while (input != "end")
            {
                var currentInput=input.Split(new[] { '-', '>', ' '}, StringSplitOptions.RemoveEmptyEntries);
                var userName = currentInput[0];
                DateTime regysterDate = DateTime.ParseExact(currentInput[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                userRegister.Add(userName, regysterDate);

                input = Console.ReadLine();
            }

            var result = userRegister
                .Reverse()
                .OrderBy(x => x.Value)
                .Take(5)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
