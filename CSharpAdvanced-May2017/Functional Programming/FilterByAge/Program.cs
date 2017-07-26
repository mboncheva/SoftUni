using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var person = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
              
                people.Add(person[0], int.Parse(person[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

           Func<int,bool> peoplePair =  GetConditionAndAge(condition, age, people);
            Action<KeyValuePair<string, int>> result = Print(format);
            PrinterResult(people, peoplePair, result);
        }

        private static void PrinterResult(Dictionary<string, int> people, 
            Func<int, bool> peoplePair, 
            Action<KeyValuePair<string, int>> result)
        {
            foreach (var person in people)
            {
                if (peoplePair(person.Value))
                {
                    result(person);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> Print(string format)
        {
            switch (format)
            {
                case "name":
                    return r => Console.WriteLine(r.Key);
                    break;
                case "age":
                    return r => Console.WriteLine(r.Value);
                    break;
                case "name age":
                    return r => Console.WriteLine($"{r.Key} - {r.Value}");
                    break;
                default:  return null;
            }
        }

        private static Func<int, bool> GetConditionAndAge(string condition, int age, Dictionary<string, int> people)
        {
            if (condition == "younger")
            {
                return n => n < age;
            }
            else
            {
                return n => n >= age;
            }
            
        }
    }
}
