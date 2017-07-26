using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var listOfEmployee = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ');
            var name = input[0];
            var salary = double.Parse(input[1]);
            var position = input[2];
            var department = input[3];
            var email = "n/a";
            var age = -1;

            if (input.Length == 6)
            {
                email = input[4];
                age = int.Parse(input[5]);
            }
            if (input.Length == 5)
            {
                int num;
                if (int.TryParse(input[4],out num))
                {
                    age = num;
                }
                else
                {
                    email = input[4];
                }
            }

            var employee = new Employee()
            {
                Name = name,
                Salary = salary,
            Position=position,
            Department=department,
            Email=email,
            Age=age
            };

            listOfEmployee.Add(employee);
        }


     var hightDepartment= listOfEmployee.GroupBy(x => x.Department, x => x.Salary).OrderByDescending(x => x.Average()).First().Key;
        var result = listOfEmployee.GroupBy(x => x.Department).Where(x => x.Key == hightDepartment).ToList()[0];
        Console.WriteLine($"Highest Average Salary: {hightDepartment}");
        foreach (var item in result.OrderByDescending(x=>x.Salary))
        {
            Console.WriteLine($"{item.Name} {item.Salary:f2} {item.Email} {item.Age}");
        }
    }
}