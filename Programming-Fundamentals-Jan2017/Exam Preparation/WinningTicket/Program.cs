using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            var tickets = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;

                }

                var left = new string(ticket.Take(10).ToArray());
                var right = new string(ticket.Skip(10).ToArray());

                //Vzima 1 ot elementite i (\1)- oshte 5 ili poveche ot sushtiq element
                var pattern = @"([#@$^])\1{5,}";
                var regex = new Regex(pattern);

                var isMachLeft = regex.Match(left);
                var isMatchRight = regex.Match(right);

                if (isMachLeft.Success && isMatchRight.Success)
                {
                    var symbolLeft = isMachLeft.Value.First();
                    var symbolRight = isMatchRight.Value.First();
                    if (symbolLeft == symbolRight)
                    {
                        if (isMachLeft.Length == 10 && isMatchRight.Length == 10)
                        {
                            Console.WriteLine("ticket \"{0}\" - 10{1} Jackpot!",ticket,symbolLeft);
                        }
                        else
                        {
                            if (isMachLeft.Length < isMatchRight.Length)
                            {
                                Console.WriteLine("ticket \"{0}\" - {1}{2}", ticket, isMachLeft.Length, symbolLeft);
                            }
                            else
                            {
                                Console.WriteLine("ticket \"{0}\" - {1}{2}", ticket, isMatchRight.Length, symbolLeft);
                            }
                           
                        }
                    }
                    else
                    {
                        Console.WriteLine("ticket \"{0}\" - no match", ticket);

                    }
                }
                else
                {
                    Console.WriteLine("ticket \"{0}\" - no match",ticket);
                }
            }
        }
    }
}