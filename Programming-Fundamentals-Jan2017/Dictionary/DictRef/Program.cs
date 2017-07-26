using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DictRef
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dictRef = new Dictionary<string, int>();

            while (input != "end")
            {
                var inputRef=input.Split(new[] { '=', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = inputRef[0];
                var value =inputRef[1];

                int number = 0;
                if (int.TryParse(value,out number))
                {
                    dictRef[name] = number;
                }
                else
                {
                    if (dictRef.ContainsKey(value))
                    {
                        var referenceValue = dictRef[value];
                        dictRef[name] = referenceValue;
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var item in dictRef)
            {
                Console.WriteLine("{0} === {1}",item.Key,item.Value);
            }
        }
    }
}
