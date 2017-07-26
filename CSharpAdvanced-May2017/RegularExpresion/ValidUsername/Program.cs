using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidUsername
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var users = string.Join(" ", input);

            var regex = new Regex(@"\b[a-zA-Z]\w{2,25}\b");

            var match = regex.Matches(users);

            var maxSum = int.MinValue;
            var firstUser = string.Empty;
            var secondUser = string.Empty;

            for (int i = 0; i < match.Count -1; i++)
            {
                var sumOfTwoUsers = match[i].Value.Length + match[i + 1].Value.Length;

                if (maxSum < sumOfTwoUsers)
                {
                    maxSum = sumOfTwoUsers;
                    firstUser = match[i].Value;
                    secondUser = match[i + 1].Value;
                }
            }

            Console.WriteLine(firstUser);
            Console.WriteLine(secondUser);
        }
    }
}
