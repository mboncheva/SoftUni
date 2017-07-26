using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.EqualSumAfterExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            var listNum1 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var listNum2 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var sumList1 = 0;
            var sumList2 = 0;

            for (int i = 0; i < listNum1.Count; i++)
            {
                for (int j = 0; j < listNum2.Count; j++)
                {
                    if (listNum1[i] != listNum2[j])
                    {
                        listNum2.Remove(listNum1[i]);
                    }
                }
            }
            foreach (var num in listNum1)
            {
                sumList1 += num;
            }
            foreach (var num in listNum2)
            {
                sumList2 += num;
            }
            if (sumList1 == sumList2)
            {
                Console.WriteLine("Yes. Sum: {0}",sumList1);
            }
            else
            {
                Console.WriteLine("No. Diff: {0}",Math.Abs(sumList1-sumList2));
            }
           


        }
    }
}
