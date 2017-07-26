using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.FishStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            var fish = Console.ReadLine();

            var pattern = @"(>*)<(\(+)(['x-])>";
            var regex = new Regex(pattern);


            if (regex.IsMatch(fish))
            {
                var maches=regex.Matches(fish);
                var count = 1;

                foreach (Match item in maches)
                {
                    var tail = item.Groups[1].Value;
                    var body = item.Groups[2].Value;
                    var status = item.Groups[3].Value;

                    int tailLenght = tail.Length * 2;
                    int bodyLenght = body.Length * 2;

                    Console.WriteLine("Fish {0}: {1}", count, item.Value);

                    if (tail.Length < 1)
                    {
                        Console.WriteLine("Tail type: None");
                    }
                    else 
                    {
                        if (tail.Length == 1)
                        {
                            Console.WriteLine("  Tail type: Short ({0} cm)",tailLenght);
                        }
                        else if(tail.Length > 1 && tail.Length <= 5)
                        {
                            Console.WriteLine("  Tail type: Medium ({0} cm)", tailLenght);
                        }
                        else if (tail.Length > 5)
                        {
                            Console.WriteLine("  Tail type: Long ({0} cm)", tailLenght);
                        }

                    }

                    if (body.Length > 10)
                    {
                        Console.WriteLine("  Body type: Long ({0} cm)", bodyLenght);
                    }
                    else if (body.Length > 5)
                    {
                        Console.WriteLine("  Body type: Medium ({0} cm)", bodyLenght);
                    }
                    else
                    {
                        Console.WriteLine("  Body type: Short ({0} cm)", bodyLenght);
                    }
                    

                    switch (status)
                    {
                        case "'": Console.WriteLine("Status: Awake");
                            break;
                        case "-": Console.WriteLine("Status: Asleep");
                            break;
                        case "x": Console.WriteLine("Status: Dead");
                            break;
                    }

                    count++;
                }
            }
            else
            {
                Console.WriteLine("No fish found.");
            }
        }
    }
}
