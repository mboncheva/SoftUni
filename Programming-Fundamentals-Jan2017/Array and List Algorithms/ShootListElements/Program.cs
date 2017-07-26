using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ShootListElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();

            var sum = 0;
            double averageSum = 0;
            var lastElement = 0;

            var command = Console.ReadLine();
            while (command != "stop")
            {
                if (command == "bang")
                {
                    if (list.Count == 0)
                    {
                        Console.WriteLine("nobody left to shoot! last one was {0}", lastElement);
                        return;
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        sum += list[i];
                    }
                    averageSum =(double)sum / list.Count;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] <= averageSum)
                        {
                            lastElement = list[i];
                            list.RemoveAt(i);
                            Console.WriteLine("shot {0}",lastElement);
                            break;
                        }
                    }

                    for (int j = 0; j < list.Count; j++)
                    {
                        list[j]--;
                    }
                    sum = 0;
                    averageSum = 0.0;

                }
                else
                {
                    int number = int.Parse(command);
                    list.Insert(0,number);
                }
             
                command = Console.ReadLine();
            }

            if (list.Count == 0)
            {
                Console.WriteLine("you shot them all. last one was {0}",lastElement);
            }
            else
            {
                Console.WriteLine("survivors: {0}",string.Join(" ",list));
            }
        }
    }
}
