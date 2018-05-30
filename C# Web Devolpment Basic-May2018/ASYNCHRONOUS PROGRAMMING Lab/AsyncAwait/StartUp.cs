using System;
using System.Collections.Generic;


namespace AsyncAwait
{
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    class StartUp
    {
        static void Main(string[] args)
        {
            //    Method 01
            Task.Run(async () =>
            {
                await DownLoadFileAsync();

            })
            .GetAwaiter()
            .GetResult();

            //  Method 02  
            Task.Run(async () =>
           {
               await GetHeaders("https://softuni.bg");

           })
           .GetAwaiter()
           .GetResult();
        }

        public static async Task DownLoadFileAsync()
        {
            var webClient = new WebClient();
           
            Console.WriteLine("Downloading....");
            var currentDirectory = Directory.GetCurrentDirectory();

            const string FolderDownloadFile = "DownloadFile";

            if (Directory.Exists(FolderDownloadFile))
            {
                Directory.Delete(FolderDownloadFile,true);
            }

            Directory.CreateDirectory(FolderDownloadFile);

            var downloadFile = "https://www.youtube.com/watch?v=fX62PJ_wv20&feature=youtu.be";
            var fileName = $"{currentDirectory}\\{FolderDownloadFile}\\index.html";

            await webClient.DownloadFileTaskAsync(downloadFile, fileName);

            Console.WriteLine("Finished!");
        }

        public static async Task GetHeaders(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var headers = response.Headers;

                foreach (var header in headers)
                {
                    Console.WriteLine(header.Key + ": " + String.Join(", ",header.Value));
                }

                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);
              
            }
        }
    }
}
