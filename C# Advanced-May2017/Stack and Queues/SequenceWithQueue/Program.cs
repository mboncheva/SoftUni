using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = long.Parse(Console.ReadLine());

            var result = new Queue<long>();

            result.Enqueue(number);
            Console.Write("{0} ", number);
            var count = 1;

            while (count < 50)
            {
                number = result.Dequeue();
                Console.Write("{0} ", number + 1);
                result.Enqueue(number + 1);
                count++;
                if (count < 50)
                {
                    Console.Write("{0} ", 2 * number + 1);
                    result.Enqueue(2 * number + 1);
                    count++;
                }
                else
                {
                    break;
                }
                if (count < 50)
                {

                    Console.Write("{0} ", number + 2);
                    result.Enqueue(number + 2);
                    count++;
                }
                else
                {
                    break;
                }


            }

        }
    }
}
