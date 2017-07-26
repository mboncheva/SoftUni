using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUniKaraoke
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var songs = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var realySong = new List<string>();
            foreach (var item in songs)
            {
                realySong.Add(item.Trim());
            }

            var command = Console.ReadLine();

            var dictionary = new Dictionary<string, SortedSet<string>>();

            while (command != "dawn")
            {
                var currentCommand = command.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var person = currentCommand[0];
                var song = currentCommand[1].Trim();
                var award = currentCommand[2].Trim();

                if (people.Contains(person) && realySong.Contains(song))
                {
                    if (!dictionary.ContainsKey(person))
                    {
                        dictionary[person] = new SortedSet<string>();
                    }
                        dictionary[person].Add(award);
                    
                }
               
                command = Console.ReadLine();
            }
            if (dictionary.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            var result = dictionary
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key,x => x.Value);

            foreach (var item in result)
            {
                Console.WriteLine("{0}: {1} awards",item.Key,item.Value.Count);
                foreach (var award in item.Value)
                {
                    Console.WriteLine("--{0}",award);
                }
            }
        }
    }
}
