using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestParser
{
    class StartUp
    {
        static void Main()
        {
            var validUrls = new Dictionary<string,HashSet<string>>();

            var input = Console.ReadLine();
            while (input != "END")
            {
                var urlParth = input.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                var path = $"/{urlParth[0]}";
                var method = urlParth[1];
                if (!validUrls.ContainsKey(path))
                {
                    validUrls[path] = new HashSet<string>();
                }

                validUrls[path].Add(method);

                input = Console.ReadLine();
            }

            var request = Console.ReadLine().Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries);
            var requestMethod = request[0];
            var requestPath = request[1];
            var requestProtocol = request[2];

            var responseStatus = 404;
            var responseStatusText = "Not Found";

            if (validUrls.ContainsKey(requestPath) && validUrls[requestPath].Contains(requestMethod.ToLower()))
            {
                responseStatus = 200;
                responseStatusText = "OK";
            }

            Console.WriteLine($"{requestProtocol} {responseStatus} {responseStatusText}");
            Console.WriteLine($"Content-Lenght:{responseStatusText.Length}");
            Console.WriteLine($"Content-Type:text/plain {Environment.NewLine}");
            Console.WriteLine($"{responseStatusText}");

        }
    }
}
