using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FilterBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var ageDict = new Dictionary<string, int>();
            var salaryDict = new Dictionary<string, double>();
            var positionDict = new Dictionary<string, string>();

            while (input != "filter base")
            {
                var curentInput = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var name = curentInput[0];
                var command = curentInput[1];

                int number = 0;
                double num = 0;

                if (int.TryParse(command,out number))
                {
                    ageDict[name] = number;
                }
                else if (double.TryParse(command,out num))
                {
                    salaryDict[name] = num;
                }
                else
                {
                    positionDict[name] = command;
                }


                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            if (input == "Age")
            {
                foreach (var age in ageDict)
                {
                    Console.WriteLine("Name: {0}",age.Key);
                    Console.WriteLine("Age: {0}",age.Value);
                    Console.WriteLine("====================");
                }
            }
            else if (input == "Salary")
            {
                foreach (var salary in salaryDict)
                {
                    Console.WriteLine("Name: {0}", salary.Key);
                    Console.WriteLine("Salary: {0:f2}", salary.Value);
                    Console.WriteLine("====================");
                }
            }
            else if (input == "Position")
            {
                foreach (var position in positionDict)
                {
                    Console.WriteLine("Name: {0}", position.Key);
                    Console.WriteLine("Position: {0}", position.Value);
                    Console.WriteLine("====================");
                }
            }
                
        }
    }
}
