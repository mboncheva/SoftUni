namespace MyWebServer.Server.Handlers
{
    using System;
    using System.Text.RegularExpressions;
    using Contracts;
    using HTTP.Contracts;
    using Common;
    using Enums;
    using HTTP.Responce;
    using Routing.Contracts;
    using Server.HTTP;
    using System.Linq;

    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            CoreValidator.ThrowIfNull(serverRouteConfig, nameof(serverRouteConfig));

            this.serverRouteConfig = serverRouteConfig;
        }


        public IHttpResponse Handle(IHttpContext context)
        {
            //const string StylesFolder = "/Styles";
            //const string ScriptsFolder = "/Scripts";
        
            try
            {
                // Chek if user is authenticated
          
                var anonymousPaths = this.serverRouteConfig.AnonymousPaths;

               // var allowFolders = new[] { StylesFolder, ScriptsFolder };

                //string dataType = null;
                //if (allowFolders.Any(f => context.Request.Path.StartsWith(f)))
                //{
                //    return new FileResponse(context.Request.Path);
                //}


                if (!anonymousPaths.Contains(context.Request.Path) &&
                    //!allowFolders.Contains(dataType) &&
                     (context.Request.Session == null ||
                    !context.Request.Session.Contains(SessionStore.CurrentUserKey)))
                {
                    return new RedirectResponse(anonymousPaths.First());
                }

                var requestMethod = context.Request.Method;
                var requestPath = context.Request.Path;
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
                        context.Request.AddUrlParameter(parameter, parameterValue);
                    }

                    return routingContext.Handler.Handle(context);
                }
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }

            return new NotFoundResponse();
        }
    }
}