using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Event 
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<string> Patricipant { get; set; }

}
namespace _04.RoliTheCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var result = new List<Event>();
            var dictionary = new Dictionary<int, Event>();

            while (input != "Time for Code")
            {
                var currentInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var eventId = 0;
                if (!int.TryParse(currentInput[0],out eventId))
                {
                    continue;
                }

                string eventName = string.Empty;
                if (currentInput.Length > 1 && currentInput[1].StartsWith("#"))
                {
                    eventName = currentInput[1].Trim('#');
                }
                else
                {
                    continue;
                }

                var participans = new List<string>();

                if (currentInput.Length > 2)
                {
                    participans = currentInput.Skip(2).ToList();

                    if (!participans.All(p => p.StartsWith("@")))
                    {
                        continue;
                    }
                }

                if (dictionary.ContainsKey(eventId))
                { 
                    if (dictionary[eventId].Name == eventName)
                    {
                        var existingEvents = dictionary[eventId];
                        existingEvents.Patricipant.AddRange(participans);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                   var events= new Event
                    {
                        Id = eventId,
                        Name = eventName,
                        Patricipant = participans.OrderBy(p => p).ToList()
                    };

                    result.Add(events);
                    dictionary.Add(eventId, events);
                }
               
                input = Console.ReadLine();
            }

            var sortedEvents = result
                .OrderByDescending(x => x.Patricipant.Distinct().Count())
                .ThenBy(n => n.Name);

            foreach (var item in sortedEvents)
            {
                var itemDistinct = item.Patricipant.Distinct().ToList();
                Console.WriteLine($"{item.Name} - {itemDistinct.Count}");
                
                foreach (var patr in itemDistinct.OrderBy(x => x))
                {
                    Console.WriteLine(patr);
                }
            }
        }
    }
}
