namespace MyWebServer.Server.Handlers
{
    using System;
    using HTTP.Contracts;

    class PostHandler : RequestHandler
    {
        public PostHandler(Func<IHttpRequest, IHttpResponse> handingFunc)
            :base(handingFunc)
        {
        }
    }
}