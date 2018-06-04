namespace MyWebServer.Server.Handlers
{
    using System;
    using Contracts;
    using HTTP.Contracts;
    using MyWebServer.Server.Common;
    using MyWebServer.Server.HTTP;

    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> handlingFunc;

        public RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
        {
            CoreValidator.ThrowIfNull(handlingFunc, nameof(handlingFunc));

            this.handlingFunc = handlingFunc;
        }


        public IHttpResponse Handle(IHttpContext context)
        {
            IHttpResponse response = this.handlingFunc(context.Request);

            //    if (!context.Request.Cookies.ContainsKey(SessionStore.SessionCookieKey))
            //    {
            //        var sessionId = Guid.NewGuid().ToString();

            //        context.Request.Session = SessionStore.Get(sessionId);

            //        sessionIdToSend = sessionId;
            //    }


            //    if (sessionIdToSend != null)
            //    {
            //        response.Headers.Add(
            //            HttpHeader.SetCookie,
            //            $"{SessionStore.SessionCookieKey}={sessionIdToSend}; HttpOnly; path=/");
            //    }


            if (!response.Headers.ContainsKey(HttpHeader.ContentType))
            {
                response.Headers.Add(HttpHeader.ContentType, "text/plain");
            }


            //    foreach (var cookie in response.Cookies)
            //    {
            //        response.Headers.Add(HttpHeader.SetCookie, cookie.ToString());
            //    }



            return response;
        }


    }
}