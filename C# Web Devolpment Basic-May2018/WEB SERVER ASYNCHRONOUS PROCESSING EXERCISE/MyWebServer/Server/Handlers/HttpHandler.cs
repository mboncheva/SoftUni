namespace MyWebServer.Server.Handlers
{
    using System.Text.RegularExpressions;
    using Contracts;
    using HTTP.Contracts;
    using Common;
    using Enums;
    using HTTP.Responce;
    using Routing.Contracts;

    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            CoreValidator.ThrowIfNull(serverRouteConfig, nameof(serverRouteConfig));

            this.serverRouteConfig = serverRouteConfig;
        }


        public IHttpResponse Handle(IHttpContext httpContext)
        {
            HttpRequestMethod requestMethod = httpContext.Request.Method;
            string requestPath = httpContext.Request.Path;
            var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

            foreach (var registeredRoute in registeredRoutes)
            {
                // will return   ^/users/(?<name>[a-z]+)$
                var routePattern = registeredRoute.Key;
                var routingContext = registeredRoute.Value;

                Regex routeRegex = new Regex(routePattern);
                Match match = routeRegex.Match(requestPath);

                if (!match.Success)
                {
                    continue;
                }

                //  ^/users/(?<name>[a-z]+)$   ->  name
                var parameters = routingContext.Parameters;

                // extract value for <name>
                foreach (string parameter in parameters)
                {
                    // if we have named group in the regex
                    string parameterValue = match.Groups[parameter].Value;
                    httpContext.Request.AddUrlParameter(parameter, parameterValue);
                }

                return routingContext.Handler.Handle(httpContext);
            }


            //return new ViewResponse(HttpStatusCode.NotFound, new PageNotFoundView());
            return new NotFoundResponse();
        }
    }
}