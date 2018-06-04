using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SliceFile
{

    class StartUp
    {
        public static List<Task> tasks = new List<Task>();

        static void Main()
        {
            var videoPath = Console.ReadLine();
            var destination = Console.ReadLine();
            var parts = int.Parse(Console.ReadLine());

            SliceAsinc(videoPath, destination, parts);

            Task.WaitAll(tasks.ToArray());
        }

        private static void SliceAsinc(string videoPath, string destination, int parts)
        {
            var task = Task.Run(() =>
             {
                 Slice(videoPath, destination, parts);
             });
            tasks.Add(task);
        }

        private static void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (Directory.Exists(destinationPath))
            {
                Directory.Delete(destinationPath, true);
            }

            Directory.CreateDirectory(destinationPath);

            using(var source = new FileStream(sourceFile,FileMode.Open))
            {
                var fileInfo = new FileInfo(sourceFile);

                long partLenght = source.Length / parts + 1;
                long currentByte = 0;

                for (int i = 1; i <= parts; i++)
                {
                    var filePath = string.Format($"{destinationPath}/Part-{i}{fileInfo.Extension}");

                    using (var destination = new FileStream(filePath,FileMode.Create))
                    {
                        var buffer = new byte[4096];
                        while (currentByte <= partLenght * i)
                        {
                            var readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }
            }

            Console.WriteLine("Slice complete.");
        }
    }
}
