namespace RequestParser
{
    using System.Text;

    public class HttpResponse
    {
        private string statusCode;
        private int contentLength;
        private string message;

        public HttpResponse(bool isValid)
        {
            if (isValid)
            {
                this.statusCode = "200 OK";
                this.contentLength = 2;
                this.message = "OK";
            }
            else
            {
                this.statusCode = "404 NotFound";
                this.contentLength = 9;
                this.message = "Not Found";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {this.statusCode}");
            result.AppendLine($"Content-Length: {this.contentLength}");
            result.AppendLine("Content-Type: text/plain");
            result.AppendLine();
            result.AppendLine(this.message);

            return result.ToString().Trim();
        }
    }
}
