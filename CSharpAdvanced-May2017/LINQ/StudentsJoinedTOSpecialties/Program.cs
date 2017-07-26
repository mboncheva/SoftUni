using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StudentsSpecialty
{
    public string SpecialName { get; set; }
    public string FacultyNumber { get; set; }
}

class Student
{
    public string StudentName { get; set; }
    public string FacultyNumber { get; set; }
}

namespace StudentsJoinedTOSpecialties
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var specSudents = new List<StudentsSpecialty>();

            while (input != "Students:")
            {
                var currentInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var specialty = currentInput[0] + " " + currentInput[1];
                var facultyNumber = currentInput[2];

                var student = new StudentsSpecialty
                {
                    SpecialName = specialty,
                    FacultyNumber = facultyNumber
                };

                specSudents.Add(student);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            var nameStudents = new List<Student>();

            while (input != "END")
            {
                var currentInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var facultyNumber = currentInput[0];
                var name = currentInput[1] + " " + currentInput[2];

                var student = new Student
                {
                    StudentName = name,
                    FacultyNumber = facultyNumber
                };

                nameStudents.Add(student);

                input = Console.ReadLine();
            }

            var result = nameStudents.Join(specSudents, student => student.FacultyNumber, specialty => specialty.FacultyNumber, (student, specialty) => new { student.StudentName, student.FacultyNumber, specialty.SpecialName }).OrderBy(student => student.StudentName);

            foreach (var item in result)
            {

                Console.WriteLine($"{item.StudentName} {item.FacultyNumber} {item.SpecialName}");
            }
        }
    }
}
