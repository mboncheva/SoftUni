﻿namespace MyWebServer.Server.Routing.Contracts
{
    using Enums;
    using Handlers;
    using HTTP.Contracts;
    using System;
    using System.Collections.Generic;

    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes { get; }

        void Get(string route, Func<IHttpRequest, IHttpResponse> handler);

        void Post(string route, Func<IHttpRequest, IHttpResponse> handler);

        void AddRoute(string route, RequestHandler handler);

        void AddRoute(string route, HttpRequestMethod method, RequestHandler handler);

    }
}