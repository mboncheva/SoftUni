using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BankSystem
{
    public string BankName { get; set; }

    public string AccountName { get; set; }

    public decimal AccountBalance { get; set; }

}

namespace _02.OptimizedBankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var users = new List<BankSystem>();

            while (input != "end")
            {
                var currentInput = input.Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                var nameBank = currentInput[0];
                var nameUser = currentInput[1];
                var balance = decimal.Parse(currentInput[2]);

                var bankNew = new BankSystem
                {
                    BankName = nameBank,
                    AccountName = nameUser,
                    AccountBalance = balance
                };

                users.Add(bankNew);
                

                input = Console.ReadLine();
            }

            var userOrder = users
                .OrderByDescending(x => x.AccountBalance)
                .ThenBy(x => x.BankName.Length);

            foreach (var user in userOrder)
            {
                Console.WriteLine("{0} -> {1} ({2})",user.AccountName,user.AccountBalance,user.BankName);
            }
        }
    }
}
