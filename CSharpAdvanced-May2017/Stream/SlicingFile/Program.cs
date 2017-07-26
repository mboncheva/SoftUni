using System;
using System.Collections.Generic;
using System.IO;

namespace _5.SlicingFile
{
    class SlicingFileStatic
    {
        static void Main()
        {
            var fileName = @"..\..\source.txt";
            using (FileStream source = new FileStream(fileName, FileMode.Open))
            {
                long n = long.Parse(Console.ReadLine());
                var part = source.Length / n + source.Length % n;
                Slice(source,part,n);
                Assemble(part);
            }

        }

        private static void Assemble(long part)
        {
            var files = new List<string>();

            for (int i = 1; i < part + 1; i++)
            {
                files.Add($@"..\..\sourse{i}.txt");
            }

            using (var resultFile = new FileStream(@"..\..\result.txt", FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using (var partSource=new FileStream(files[i], FileMode.Open))
                    {
                        var buffer = new byte[part];
                        var reader = partSource.Read(buffer, 0, buffer.Length);
                        resultFile.Write(buffer, 0, reader);
                    }
                }
            }
        }

        private static void Slice(FileStream source,long part,long n)
        {

            for (int i = 1; i < n+1; i++)
            {
                using (var destination = new FileStream($@"..\..\destination{i}.txt", FileMode.Create))
                {
                    var buffer = new byte[part];
                    var reader = source.Read(buffer, 0, buffer.Length);
                    destination.Write(buffer, 0, reader);
                }
            }
        }
    }
}