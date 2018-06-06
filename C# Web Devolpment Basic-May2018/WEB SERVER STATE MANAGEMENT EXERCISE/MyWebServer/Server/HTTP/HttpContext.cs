namespace MyWebServer.Server.HTTP
{
    using Contracts;
    using Server.Common;

    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(string requestText)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestText, nameof(requestText));

            this.request = new HttpRequest(requestText);
        }

        public HttpContext(IHttpRequest request)
        {
            CoreValidator.ThrowIfNull(request, nameof(request));

            this.request = request;
        }

        public IHttpRequest Request => this.request;

    }
}