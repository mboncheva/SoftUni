﻿namespace SIS.MvcFramework
{
    using SIS.WebServer;
    using SIS.WebServer.Routing;
    using System.Reflection;
    using System.Linq;
    using System;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Requests;
    using SIS.WebServer.Results;
    using SIS.HTTP.Enums;
    using SIS.MvcFramework.Services;
    using System.Collections.Generic;
    using System.Threading;
    using System.Globalization;

    public static class WebHost
    {
        public static void Start(IMvcApplication application)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var dependencyContainer = new ServiceCollection();
            application.ConfigureServices(dependencyContainer);

            var serverRoutingTable = new ServerRoutingTable();
            AutoRegisterRoutes(serverRoutingTable, application, dependencyContainer);
            application.Configure();

            var server = new Server(80, serverRoutingTable);
            server.Run();
        }

        private static void AutoRegisterRoutes(ServerRoutingTable routingTable,
            IMvcApplication application, IServiceCollection serviceCollection)
        {
            var controllers = application.GetType().Assembly.GetTypes()
                .Where(myType => myType.IsClass
                                 && !myType.IsAbstract
                                 && myType.IsSubclassOf(typeof(Controller)));

            foreach (var controller in controllers)
            {
                var getMethods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(
                    method => method.CustomAttributes.Any(
                        ca => ca.AttributeType.IsSubclassOf(typeof(HttpAttribute))));
                foreach (var methodInfo in getMethods)
                {
                    var httpAttribute = (HttpAttribute)methodInfo.GetCustomAttributes(true)
                        .FirstOrDefault(ca =>
                            ca.GetType().IsSubclassOf(typeof(HttpAttribute)));
                    if (httpAttribute == null)
                    {
                        continue;
                    }
                    routingTable.Add(httpAttribute.Method, httpAttribute.Path,
                       (request) => ExecuteAction(controller, methodInfo, request, serviceCollection));
                    Console.WriteLine($"Route registered: {controller.Name}.{methodInfo.Name} => {httpAttribute.Method} => {httpAttribute.Path}");
                }
            }
        }

        private static IHttpResponse ExecuteAction(Type controllerType,
           MethodInfo methodInfo, IHttpRequest request,
           IServiceCollection serviceCollection)
        {
            var controllerInstance = serviceCollection.CreateInstance(controllerType) as Controller;
            if (controllerInstance == null)
            {
                return new TextResult("Controller not found.",
                    HttpResponseStatusCode.InternalServerError);
            }

            controllerInstance.Request = request;
            controllerInstance.UserCookieService = serviceCollection.CreateInstance<IUserCookieService>();

            var actionParametersObject = GetActionParameterObjects(methodInfo, request, serviceCollection);

            var httpResponse = methodInfo.Invoke(controllerInstance, actionParametersObject.ToArray()) as IHttpResponse;
            return httpResponse;
        }

        private static List<object> GetActionParameterObjects(MethodInfo methodInfo, IHttpRequest request, IServiceCollection serviceCollection)
        {
            var actionParameters = methodInfo.GetParameters();
            var actionParametersObject = new List<object>();

            foreach (var actionParameter in actionParameters)
            {
                var instance = serviceCollection.CreateInstance(actionParameter.ParameterType);

                var properties = actionParameter.ParameterType.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    var key = propertyInfo.Name.ToLower();
                    string stringValue = null;

                    if (request.FormData.Any(x => x.Key.ToLower() == key))
                    {
                        stringValue = request.FormData.First(x => x.Key.ToLower() == key).Value.ToString().UrlDecode();
                    }
                    else if (request.QueryData.Any(x => x.Key.ToLower() == key))
                    {
                        stringValue = request.QueryData.First(x => x.Key.ToLower() == key).Value.ToString().UrlDecode();
                    }

                    var typeCode = Type.GetTypeCode(propertyInfo.PropertyType);
                    var value = TryParse(stringValue, typeCode);

                    propertyInfo.SetMethod.Invoke(instance, new object[] { value });
                }

                actionParametersObject.Add(instance);
            }

            return actionParametersObject;
        }

        private static object TryParse(string stringValue, TypeCode typeCode)
        {
            object value = stringValue;
            switch (typeCode)
            {
                case TypeCode.Int32:
                    if (int.TryParse(stringValue, out var intValue)) value = intValue;
                    break;
                case TypeCode.Char:
                    if (char.TryParse(stringValue, out var charValue)) value = charValue;
                    break;
                case TypeCode.Int64:
                    if (long.TryParse(stringValue, out var longValue)) value = longValue;
                    break;
                case TypeCode.Double:
                    if (double.TryParse(stringValue, out var doubleValue)) value = doubleValue;
                    break;
                case TypeCode.Decimal:
                    if (decimal.TryParse(stringValue, out var decimalValue)) value = decimalValue;
                    break;
                case TypeCode.DateTime:
                    if (DateTime.TryParse(stringValue, out var dateTimeValue)) value = dateTimeValue;
                    break;
            }

            return value;
        }
    }
}
   