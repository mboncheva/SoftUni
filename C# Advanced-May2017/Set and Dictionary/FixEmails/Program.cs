using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var email = new Dictionary<string, string>();

            while (input != "stop")
            {
               var mail = Console.ReadLine();
                var domain = mail.Split(new[] { '.', ' '},StringSplitOptions.RemoveEmptyEntries);
                if (!email.ContainsKey(input) && domain[domain.Length - 1] == "bg")
                {
                    email[input] = mail;
                }
                input = Console.ReadLine();
            }
            foreach (var item in email)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
