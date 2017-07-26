using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = @"..\..\result.jpg";
            var imageFile = @"..\..\kitty.jpg";

            using (var stream=new FileStream(imageFile, FileMode.Open))
            {
                using (var destination=new FileStream(fileName, FileMode.Create))
                {
                    byte[] buffer = new byte[imageFile.Length];
                    while (true)
                    {
                        var reader = stream.Read(buffer, 0, buffer.Length);

                        if (reader == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, reader);
                    }
                }
            }
            System.Diagnostics.Process.Start(@"..\..\result.jpg");
        }
    }
}
