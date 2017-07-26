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

namespace _03.JSONParse
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);


            var studentNew = new Student();
          
            for (int i = 0; i < input.Length; i++)
            {
                var list = new List<int>();
                var firstElement = input[i];

                if ((firstElement == ",") || (firstElement == "[") || (firstElement == "]"))
                {
                    continue;
                }

                var nums = firstElement.Split(new[] { ' ', '"', ',', ':', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

                studentNew.Name = nums[1];
                studentNew.Age = int.Parse(nums[3]);

                for (int j = nums.Length - 1; j > 0; j--)
                {
                    int num;
                    var number = int.TryParse(nums[j], out num);

                    if (number)
                    {
                        list.Add(num);
                    }
                    else
                    {
                        break;
                    }
                }
                list.Reverse();
                studentNew.Grades = list;

                if (studentNew.Grades.Count == 0)
                {
                    Console.WriteLine("{0} : {1} -> None", studentNew.Name, studentNew.Age);

                }
                else
                {
                    Console.WriteLine("{0} : {1} -> {2}", studentNew.Name, studentNew.Age, string.Join(", ", studentNew.Grades));

                }
                
            }
        }
    }
}