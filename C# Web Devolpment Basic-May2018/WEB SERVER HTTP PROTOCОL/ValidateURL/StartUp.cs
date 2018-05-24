using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ValidateURL
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var url = Console.ReadLine();

            var decodeUrl = WebUtility.UrlDecode(url);

            var parsedUrl = new Uri(decodeUrl);

            var protocol = parsedUrl.Scheme;
            var host = parsedUrl.Host;
            var port = parsedUrl.Port;
            var path = parsedUrl.AbsolutePath;
            var query = parsedUrl.Query;
            var fragment = parsedUrl.Fragment;

            if (string.IsNullOrEmpty(protocol) || string.IsNullOrEmpty(host) ||
                  (port != 80 && protocol == "http") || (port != 443 && protocol == "https"))
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                Console.WriteLine($"Protocol: {protocol}");
                Console.WriteLine($"Host: {host}");
                Console.WriteLine($"Port: {port}");
                Console.WriteLine($"Path: {path}");
                if (!string.IsNullOrEmpty(query))
                {
                    Console.WriteLine($"Query: {query}");

                }
                if (!string.IsNullOrEmpty(fragment))
                {
                    Console.WriteLine($"Fragment: {fragment}");
                }
            }

        }
    }
}
