using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Exercise
{
    public string Topic { get; set; }

    public string CourseName { get; set; }

    public string JudgeContestLink { get; set; }

    public List<string> Problems { get; set; }
}

namespace _01.Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var exercises = new List<Exercise>();

            while (input != "go go go")
            {
                var currentInput = input.Split(new[] { ' ', ',', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var topic = currentInput[0];
                var courseName = currentInput[1];
                var judgeContestLink = currentInput[2];
                var problem = currentInput.Skip(3).ToList();

                var exerciseNew = new Exercise()
                {
                    Topic = topic,
                    CourseName = courseName,
                    JudgeContestLink = judgeContestLink,
                    Problems = problem
                };

                exercises.Add(exerciseNew);
                input = Console.ReadLine();
            }

            foreach (var exersise in exercises)
            {
                var i = 1;
                Console.WriteLine("Exercises: {0}",exersise.Topic);
                Console.WriteLine("Problems for exercises and homework for the \"{0}\" course @ SoftUni.",exersise.CourseName);
                Console.WriteLine("Check your solutions here: {0}",exersise.JudgeContestLink);

                var problems = exersise.Problems;

                foreach (var problem in problems)
                {
                    Console.WriteLine("{0}. {1}",i,problem);
                    i++;
                }
            }
        }
    }
}
