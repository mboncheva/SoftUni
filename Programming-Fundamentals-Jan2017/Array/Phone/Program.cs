using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine()
                .Split(' ');

            string[] names = Console.ReadLine()
                .Split(' ');

            string[] command = Console.ReadLine().Split(' ');

            while (command[0] != "done")
            {
                if (command[0] == "call")
                {
                    FindCall(command, phones, names);

                }
                else if (command[0] == "message")
                {
                    FindMessage(command, phones, names);
                }
                command = Console.ReadLine().Split(' ');
            }
        }

        private static void FindCall(string[] command, string[] phones, string[] names)
        {
            int sumOfDigits = 0;

            for (int i = 0; i < phones.Length; i++)
            {
                if (command[1] == phones[i])
                {
                    var digit = phones[i].ToCharArray();
                    foreach (var item in digit)
                    {
                        if (item >= 48 && item <= 57)
                        {
                            sumOfDigits += item - '0';
                        }
                    }
                    Console.WriteLine("calling {0}...", names[i]);

                    if (sumOfDigits % 2 == 0)
                    {
                        Console.WriteLine("call ended. duration: {0:D2}:{1:D2}", sumOfDigits / 60, sumOfDigits % 60);
                    }
                    else
                    {
                        Console.WriteLine("no answer");
                    }
                }
                else if (command[1] == names[i])
                {
                    var digit = phones[i].ToCharArray();
                    foreach (var item in digit)
                    {
                        if (item >= 48 && item <= 57)
                        {
                            sumOfDigits += item - '0';
                        }
                    }
                    Console.WriteLine("calling {0}...", phones[i]);

                    if (sumOfDigits % 2 == 0)
                    {
                        Console.WriteLine("call ended. duration: {0:D2}:{1:D2}", sumOfDigits / 60, sumOfDigits % 60);
                    }
                    else
                    {
                        Console.WriteLine("no answer");
                    }
                   
                }
            }
        }

        private static void FindMessage(string[] command, string[] phones, string[] names)
        {
            int sumOfDigits = 0;

            for (int i = 0; i < phones.Length; i++)
            {
                if (command[1] == phones[i])
                {
                    var digit = phones[i].ToCharArray();
                    foreach (var item in digit)
                    {
                        if (item >= 48 && item <= 57)
                        {
                            sumOfDigits += item - '0';
                        }
                    }
                    Console.WriteLine("sending sms to {0}...", names[i]);
                    if (sumOfDigits % 2 == 0)
                    {
                        Console.WriteLine("meet me there");
                    }
                    else
                    {
                        Console.WriteLine("busy");
                    }
                }
                else if (command[1] == names[i])
                {
                    var digit = phones[i].ToCharArray();
                    foreach (var item in digit)
                    {
                        if (item >= 48 && item <= 57)
                        {
                            sumOfDigits += item - '0';
                        }
                    }
                    Console.WriteLine("sending sms to {0}...", phones[i]);
                    if (sumOfDigits % 2 == 0)
                    {
                        Console.WriteLine("meet me there");
                    }
                    else
                    {
                        Console.WriteLine("busy");
                    }
                }
            }
        }
    }
}