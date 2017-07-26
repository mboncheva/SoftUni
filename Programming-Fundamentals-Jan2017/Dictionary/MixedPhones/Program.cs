using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MixedPhones
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var result = new SortedDictionary<string, long>();

            while (text != "Over")
            {
                var curentText = text.Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                var name = curentText[0];
                var phoneNumber = curentText[1];

                long number = 0;
                if (long.TryParse(phoneNumber,out number))
                {
                    result[name] = number;
                }
                else
                {
                    long num = 0;
                    long.TryParse(name, out num);
                    result[phoneNumber] = num;
                }
                
                text = Console.ReadLine();
            }
            foreach (var item in result)
            {
                Console.WriteLine("{0} -> {1}",item.Key,item.Value);
            }
        }
    }
}
