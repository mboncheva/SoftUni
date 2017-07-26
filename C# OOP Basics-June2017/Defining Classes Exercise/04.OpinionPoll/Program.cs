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

        var people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ');
            var name = input[0];
            var age = int.Parse(input[1]);

            var person = new Person();
            person.Name = name;
            person.Age = age;
            people.Add(person);
        }

        var result = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} - {item.Age}");
        }
    }
}