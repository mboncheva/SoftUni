using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TrackDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(' ')
                .ToList();

            var files = new List<string>();

            string command = Console.ReadLine();
           
            while (command != "end")
            {
                bool isInList = false;
                for (int i = 0; i < words.Count; i++)
                {
                    var word = words[i];
                    if (command.Contains(word))
                    {
                        isInList = true;
                        break;
                    }
                }
                if (!isInList)
                {
                    files.Add(command);
                }
               
                command = Console.ReadLine();
            }

            files.Sort();
            foreach (var item in files)
            {
                Console.WriteLine(item);
            }
            

        }
    }
}
