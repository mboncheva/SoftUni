using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var studentInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var studentFirstName = studentInfo[0];
        var studentLastName = studentInfo[1];
        var studentFacultyNumber = studentInfo[2];

        var workerInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var workerFirstName = workerInfo[0];
        var workerLastName = workerInfo[1];
        var workerWeekSalary = decimal.Parse(workerInfo[2]);
        var workerHourPerDay = decimal.Parse(workerInfo[3]);

        try
        {
            var student = new Student(studentFacultyNumber, studentFirstName, studentLastName);
            var worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerHourPerDay);

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
}