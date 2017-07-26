using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Students
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public List<int> Mark { get; set; }

}
namespace ExcellentStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var excellentStudents = new List<Students>();

            while (input != "END")
            {
                var currentInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var student = new Students
                {
                    FirstName = currentInput[0],
                    LastName = currentInput[1],
                    Mark = new List<int>(),
                };

                student.Mark.AddRange(currentInput.Skip(2).Select(int.Parse));
                excellentStudents.Add(student);

                input = Console.ReadLine();
            }

            var result = excellentStudents.Where(st => st.Mark.Contains(6)).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
    }
}
