using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Files
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var inputData = new Dictionary<string, Dictionary<string, long>>();
            var inputExtension = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                var files = Console.ReadLine().Split(new[] { '\\'});
                var root = files[0];

                var filesData = files.Last().Split(new[] { ';'});
                var fileFullName = filesData[0];
                var filesize = long.Parse(filesData[1]);

                var fileExten = fileFullName.Split(new[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var fileName = fileFullName.Trim();
                var extension = fileExten.Last().Trim();

                if (!inputData.ContainsKey(root))
                {
                    inputData[root] = new Dictionary<string, long>();
                }
                inputData[root][fileFullName] = filesize;
                inputExtension[fileName] = extension;
            }

            var query = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var queryExtension = query[0];
            var queryRoot = query[2];

            var result = new Dictionary<string, long>();

            if (inputData.ContainsKey(queryRoot))
            {
                foreach (var file in inputData[queryRoot])
                {
                    if (inputExtension[file.Key] == queryExtension)
                    {
                        result.Add(file.Key, file.Value);
                    }
                }
            }
            if (result.Count > 0)
            {
                foreach (var item in result.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key} - {item.Value} KB");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
