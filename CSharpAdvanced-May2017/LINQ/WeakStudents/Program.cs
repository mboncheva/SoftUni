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
namespace WeakStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var weakStudents = new List<Students>();

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
                weakStudents.Add(student);

                input = Console.ReadLine();
            }

            var res = weakStudents.Where(st => st.Mark.Count(s=> s <= 3) >= 2).ToList();
            foreach (var item in res)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    }
}
