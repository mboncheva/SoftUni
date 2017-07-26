using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Stateless
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new Dictionary<string,string>();

            while (input != "collapse")
            {
               var input2 = Console.ReadLine();

                if (input2 == "collapse")
                {
                    break;
                }

                while (true)
                {
                    int index = input.IndexOf(input2);

                    if (index >= 0)
                    {
                        input = input.Remove(index, input2.Length);
                    }
                    else
                    {
                        input2 = input2.Remove(0, 1);
                        if (input2.Length == 0)
                        {
                            break;
                        }

                        input2 = input2.Remove(input2.Length - 1, 1);
                        if (input2.Length == 0)
                        {
                            break;
                        }

                    }
                }
                result[input] = input2;
                input = Console.ReadLine();

            }
            foreach (var item in result)
            {
                if (item.Value == "" && item.Key == "")
                {
                    Console.WriteLine("(void)");
                }
                else
                {
                    Console.WriteLine(item.Key.Trim());
                }
            }
        }
    }
}
