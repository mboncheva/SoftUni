using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;
   
    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        protected set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    public decimal WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        protected set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHoursPerDay = value;
        }
    }

    public decimal MoneyPerHour
    {
        get { return this.CalculateMoneyPerHour(); }

    }

    private decimal CalculateMoneyPerHour()
    {
        var salaryPerHour = this.WeekSalary / (this.WorkHoursPerDay * 5);
        return salaryPerHour;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(base.ToString())
         .Append($"Week Salary: {this.WeekSalary:f2}\n")
         .Append($"Hours per day: {this.WorkHoursPerDay:f2}\n")
         .Append($"Salary per hour: {this.MoneyPerHour:f2}");


        return sb.ToString();
    }
}