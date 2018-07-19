namespace MyWebServer.Server.HTTP.Responce
{
    using Enums;
    using System.IO;

    public class FileResponse : HttpResponse
    {
        public FileResponse(string path)
        {
            this.StatusCode = HttpStatusCode.OK;

            using (var streamReader = new StreamReader(@"../../../../MyWebServer/ByTheCakeApplication" + path))
            {
                var fileContent = streamReader.ReadToEnd();
                this.Content = fileContent;
            }
        }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}{this.Content}";
        }
    }
}
