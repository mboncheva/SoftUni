using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Students
{
    public string YearStudent { get; set; }
    public List<int> Mark { get; set; }

}

namespace StudentsEnrolledIN2014OR2015
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var groupStudents = new List<Students>();

            while (input != "END")
            {
                var currentInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var student = new Students
                {
                    YearStudent = currentInput[0],
                    Mark = new List<int>(),
                };
               
                student.Mark.AddRange(currentInput.Skip(1).Select(int.Parse));
                groupStudents.Add(student);

                input = Console.ReadLine();
            }

            var result = groupStudents.Where(st => st.YearStudent.EndsWith("14") || st.YearStudent.EndsWith("15"));

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ",item.Mark));
            }
        }
    }
}
