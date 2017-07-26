using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Student
{
    public string Name { get; set; }

    public int Age { get; set; }

    public List<int> Grades { get; set; }

}
namespace _02.JSONStringify
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();


            var students = new List<Student>();

            while (input != "stringify")
            {
                var currentInput = input.Split(new[] { '>', '-', ':', ',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                var name = currentInput[0];
                var age = int.Parse(currentInput[1]);
                var grade = currentInput.Skip(2).Select(int.Parse).ToList();
                
                var student = new Student();
                student.Name = name;
                student.Age = age;
                student.Grades = grade;

                students.Add(student);
                input = Console.ReadLine();
            }

            var output = string.Empty;
            output += "[";
            var count = 0;

            foreach (var student in students)
            {
               output += string.Format("{{name:\"{0}\",age:{1},grades:[{2}]}}",student.Name,student.Age,
                    string.Join(", ",student.Grades));
                count++;

                if (count < students.Count)
                {
                    output += ",";
                }
            }
            output += "]";
            Console.WriteLine(output);
            
        }
    }
}
