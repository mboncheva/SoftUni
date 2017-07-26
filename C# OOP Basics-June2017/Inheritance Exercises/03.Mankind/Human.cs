using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName,string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        protected set
        {
            if (!char.IsLetter(value[0]) || !char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        protected set
        {
            if (!char.IsLetter(value[0]) || !char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            this.lastName = value;
        }  
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"First Name: {this.FirstName}\n");
        sb.Append($"Last Name: {this.LastName}\n");
        return sb.ToString();
    }
}
