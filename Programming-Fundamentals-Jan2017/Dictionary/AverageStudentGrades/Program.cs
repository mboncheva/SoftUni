using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var result = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var name = input[0];
                var grade = double.Parse(input[1]);

                GetGrade(result, name, grade);
            }

            foreach (var item in result)
            {
                Console.Write("{0} -> ",item.Key);

                foreach (var value in item.Value)
                {
                    Console.Write("{0:f2} ",value);
                }

                Console.WriteLine("(avg: {0:f2})",item.Value.Average());
            }
        }

        private static void GetGrade(Dictionary<string, List<double>> result, string name, double grade)
        {
            if (!result.ContainsKey(name))
            {
                result[name] = new List<double>();
            }
            result[name].Add(grade);
        }
    }
}
