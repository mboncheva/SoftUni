using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPhone = Console.ReadLine();

            var phonebook = new Dictionary<string, string>();

            while (inputPhone != "search")
            {
                var currentInputPhone=inputPhone.Split(new[] { '-' });

                if (!phonebook.ContainsKey(currentInputPhone[0]))
                {
                    phonebook[currentInputPhone[0]] = string.Empty;
                }
                phonebook[currentInputPhone[0]] = currentInputPhone[1];

                inputPhone = Console.ReadLine();
            }
            var command = Console.ReadLine();

            while (command != "stop")
            {
                if (phonebook.ContainsKey(command))
                {
                    Console.WriteLine("{0} -> {1}",command,phonebook[command]);
                }
                else
                {
                    Console.WriteLine($"Contact {command} does not exist.");
                }

                command = Console.ReadLine();
            }
        }
    }
}
