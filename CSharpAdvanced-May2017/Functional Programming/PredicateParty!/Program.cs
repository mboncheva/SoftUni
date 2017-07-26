using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var command = Console.ReadLine();
            while (command != "Party!")
            {
                var currentCommand = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var asked = currentCommand[0];
                var criteria = currentCommand[1];
                var whatString = currentCommand[2];

                Predicate<string> nameStarting = n => n.StartsWith(whatString);
                Predicate<string> nameEnding = n => n.EndsWith(whatString);
                Predicate<string> nameLenght = n => n.Length==int.Parse(whatString);


                if (asked == "Remove")
                {
                    switch (criteria)
                    {
                        case "StartsWith":
                            people.RemoveAll(nameStarting);
                            break;
                        case "EndsWith":
                            people.RemoveAll(nameEnding);
                            break;
                        case "Length":
                            people.RemoveAll(nameLenght);
                            break;
                    }
                }
                else if (asked == "Double")
                {
                    var doublePeople = new List<string>();

                    switch (criteria)
                    {
                        case "StartsWith":
                            doublePeople = people.FindAll(nameStarting);
                            people.AddRange(doublePeople);
                            break;

                        case "EndsWith":
                            doublePeople = people.FindAll(nameEnding);
                            people.AddRange(doublePeople);
                            break;
                        case "Length":
                            doublePeople = people.FindAll(nameLenght);
                            people.AddRange(doublePeople);
                            break;
                    }
                }

                command = Console.ReadLine();
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                people = people.OrderBy(n => n).ToList();
                Console.WriteLine("{0} are going to the party!", string.Join(", ",people));
            }
        }
    }
}
