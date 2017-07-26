using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.OrderedBankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var bankSystem = new Dictionary<string, Dictionary<string, decimal>>();

            while (input != "end")
            {
                var currentInput = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var bank = currentInput[0];
                var acount = currentInput[1];
                var balance = decimal.Parse(currentInput[2]);

                if (!bankSystem.ContainsKey(bank))
                { 
                    bankSystem[bank] = new Dictionary<string, decimal>();
                }
                if (!bankSystem[bank].ContainsKey(acount))
                {
                    bankSystem[bank].Add(acount, 0);
                }
                bankSystem[bank][acount] += balance;


                input = Console.ReadLine();
            }

          var bankSys =  bankSystem
                .OrderByDescending(x => x.Value.Sum(acount => acount.Value))
                .ThenByDescending(bank => bank.Value.Max(acount => acount.Value))
                .ToDictionary(x=> x.Key,x=>x.Value);

            foreach (var bank in bankSys)
            {
                foreach (var item in bank.Value)
                {
                    Console.WriteLine("{0} -> {1} ({2})", item.Key, item.Value,bank.Key);
                }
                
            }
        }
    }
}
