using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Person
{
    public string Name { get; set; }
    public int Group { get; set; }
}
namespace GroupByGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new List<Person>();

            while (input != "END")
            {
                var currentInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var student = new Person
                {
                    Name = currentInput[0] + " " + currentInput[1],
                    Group = int.Parse(currentInput[2])
                };

                result.Add(student);

                input = Console.ReadLine();
            }

          var group=  result.GroupBy(s => s.Group, s => s.Name).OrderBy(s => s.Key).ToList();
            foreach (var item in group)
            {
                Console.WriteLine("{0} - {1}",item.Key,string.Join(", ",item));
            }
        }
    }
}
