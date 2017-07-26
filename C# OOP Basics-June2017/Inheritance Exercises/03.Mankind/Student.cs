using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Student : Human
{
    private string facultyNumber;

    public Student(string facultyNumber,string firstName,string lastName) : base(firstName,lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        private set
        {
            if (value.Length < 5 || value.Length > 10 || !value.All(character => char.IsLetterOrDigit(character)))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(base.ToString())
          .Append($"Faculty number: {this.FacultyNumber}");

        return sb.ToString();
    }
}