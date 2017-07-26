using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.UserLogins
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var userLogin = new Dictionary<string, string>();
            
            while (input != "login")
            {
                var curentInput = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var user = curentInput[0];
                var password = curentInput[1];

                if (!userLogin.ContainsKey(user))
                {
                    userLogin[user] = string.Empty;
                }

                userLogin[user] = password;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            int count = 0;

            while (input != "end")
            {
                var curentInput = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var user = curentInput[0];
                var password = curentInput[1];
               
                if (userLogin.ContainsKey(user) && userLogin.ContainsValue(password))
                {
                    Console.WriteLine("{0}: logged in successfully",user);
                }
                else
                {
                    Console.WriteLine("{0}: login failed",user);
                    count++;
                }


                input = Console.ReadLine();
            }
            Console.WriteLine("unsuccessful login attempts: {0}",count);
        }
    }
}
