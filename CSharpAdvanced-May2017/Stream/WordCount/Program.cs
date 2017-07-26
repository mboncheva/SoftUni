using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var words=new StreamReader(@"..\..\words.txt"))
            {
                using (var text=new StreamReader(@"..\..\text.txt"))
                {
                    using (var result=new StreamWriter(@"..\..\result.txt"))
                    {
                        var word = words.ReadLine();
                        var allText = text.ReadToEnd().ToLower()
                            .Split(new[] { ' ', '-', '.', ',', ':', ';', '\\', '/', '(', ')', '>', '<', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                        while (word != null)
                        {
                            var count = 0;
                            word = word.ToLower();
                            foreach (var item in allText)
                            {
                                if (item == word)
                                {
                                    count++;
                                }
                            }
                            //int index = allText.IndexOf(word, 0);
                            //while (index != -1)
                            //{
                            //    count++;
                            //    index = allText.IndexOf(word, index + 1);
                            //}
                            result.WriteLine("{0} - {1}", word, count);
                            word = words.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
