using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ArrayHistogram
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(' ').ToArray();

            var words = new List<string>();
            var counter = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                var curentWord = text[i];
                if (!words.Contains(curentWord))
                {
                    words.Add(curentWord);
                    counter.Add(1);
                    
                }
                else
                {
                    int textIndex = words.IndexOf(curentWord);
                    counter[textIndex]++;
                    
                }
            }

            bool swapped = true;

            while (swapped)
            {
                swapped = false; 
                for (int i = 0; i < counter.Count - 1; i++)
                {
                    if (counter[i] < counter[i + 1])
                    {
                        var tempCount = counter[i];
                        counter[i] = counter[i + 1];
                        counter[i + 1] = tempCount;

                        string tempWord = words[i];
                        words[i] = words[i + 1];
                        words[i + 1] = tempWord;

                        swapped = true;
                    }
                }
            }
              
            for (int i = 0; i < words.Count; i++)
            {
                double percentage = (counter[i] * 100.0) / text.Length;
                Console.WriteLine("{0} -> {1} times ({2:f2}%)",words[i],counter[i],percentage);

            }
            
        }
    }
}
