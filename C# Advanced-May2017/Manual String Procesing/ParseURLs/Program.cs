using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ParseURLs
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = Console.ReadLine().Split(new[] { "://"},StringSplitOptions.RemoveEmptyEntries);

            if (url.Length != 2 || url[1].IndexOf('/') == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            else
            {
                var protocol = url[0];
                var index = url[1].IndexOf('/');
                var server = url[1].Substring(0, index);
                var resource = url[1].Substring(index+1);

                Console.WriteLine("Protocol = {0}",protocol);
                Console.WriteLine("Server = {0}",server);
                Console.WriteLine("Resources = {0}",resource);


            }

        }
    }
}
