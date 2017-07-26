using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ParseTags
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var openTag = "<upcase>";
            var closeTag = "</upcase>";

            var startIndex = text.IndexOf(openTag);

            while (startIndex != -1)
            {
                var closeIndex = text.IndexOf(closeTag);
                if (closeIndex == -1)
                {
                    break;
                }
                var toBeReplace = text.Substring(startIndex, closeIndex + closeTag.Length -startIndex);
                var replaceText = toBeReplace.Replace(openTag, string.Empty).Replace(closeTag, string.Empty).ToUpper();

                text = text.Replace(toBeReplace, replaceText);
                startIndex = text.IndexOf(openTag);
            }
            Console.WriteLine(text);
        }
    }
}
