using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.NoteStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            var note = "C C# D D# E F F# G G# A A# B".Split(' ').ToList();

            var frequency = "261.63 277.18 293.66 311.13 329.63 349.23 369.99 392.00 415.30 440.00 466.16 493.88"
                .Split(' ').Select(double.Parse).ToList();

            var result = new List<string>();
            var sharps = new List<string>();
            var naturals = new List<string>();

            double naturalSum = 0;
            double sharpsSum = 0;

            foreach (var num in numbers)
            {
                result.Add(note[i]);

                if (num == frequency[i])
                    {
                       
                        if (note[i].Contains("#"))
                        {
                            sharps.Add(note[i]);
                            sharpsSum += frequency[i];
                        }
                        else
                        {
                            naturals.Add(note[i]);
                            naturalSum += frequency[i];
                        }
                        break;
                    }
                }
            }

            Console.WriteLine("Notes: {0}",string.Join(" ",result));
            Console.WriteLine("Naturals: {0}",string.Join(", ",naturals));
            Console.WriteLine("Sharps: {0}",string.Join(", ",sharps));
            Console.WriteLine("Naturals sum: {0}",naturalSum);
            Console.WriteLine("Sharps sum: {0}",sharpsSum);
            
        }
    }
}
