namespace SIS.HTTP.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Interfaces;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Interfaces;
    using SIS.HTTP.Requests.Interfaces;
    using SIS.HTTP.Sessions.Interfaces;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpCookieCollection Cookies { get; }

        public IHttpSession Session { get; set; }

        //Methods

        private bool ValidteRequestLine(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            if (requestLine.Length == 3 &&
                requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }

            return false;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            return true;
        }

        private void ParseRequestMethod(string[] requestLine)
        {

            var parseResult = Enum.TryParse<HttpRequestMethod>(requestLine[0],true, out var parsedRequestMethod);

            if (!parseResult)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = parsedRequestMethod;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (string.IsNullOrEmpty(requestLine[1]))
            {
                throw new BadRequestException();
            }

            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            var path = this.Url?.Split('?').FirstOrDefault();
            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }

        private void ParseHeaders(string[] requestHeaders)
        {
            if (!requestHeaders.Any())
            {
                throw new BadRequestException();
            }

            foreach (var requestHeader in requestHeaders)
            {
                if (string.IsNullOrEmpty(requestHeader))
                {
                    return;
                }

                var splitRequestHeader = requestHeader.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var requestHeaderKey = splitRequestHeader[0];
                var requestHeaderValue = splitRequestHeader[1];

                this.Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        private void ParseQueryParameters(string url)
        {
            var queryParameters = this.Url?.Split(new[] { '#', '?' }).Skip(1).ToArray()[0];

            if (string.IsNullOrEmpty(queryParameters))
            {
                throw new BadRequestException();
            }

            var queryKeyValuePairs = queryParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            ExtractRequestParameters(queryKeyValuePairs, this.QueryData);

        }

        private void ParseFormDataParameters(string formData)
        {
            var formDataKeyValuePairs = formData.Split('&', StringSplitOptions.RemoveEmptyEntries);
            ExtractRequestParameters(formDataKeyValuePairs,this.FormData);
        }

        private void ParseRequestParameters(string bodyParameters, bool requestHasBody)
        {
            if (this.Url.Contains("?"))
            {
                this.ParseQueryParameters(this.Url);
            }

            if (requestHasBody)
            {
                this.ParseFormDataParameters(bodyParameters);
            }
        }

        private void ExtractRequestParameters(string[] parameterKeyValuePairs,
           Dictionary<string, object> parametersCollection)
        {
            foreach (var parameterKeyValuePair in parameterKeyValuePairs)
            {
                var keyValuePair = parameterKeyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (keyValuePair.Length != GlobalConstants.MandatoryNumberOfParametersInRequestParameterKeyValuePair)
                {
                    throw new BadRequestException();
                }

                var parameterKey = keyValuePair[0];
                var parameterValue = keyValuePair[1];

                parametersCollection[parameterKey] = parameterValue;
            }
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader(GlobalConstants.CookieRequestHeaderName))
            {
                return;
            }

            var cookiesRaw = this.Headers.GetHeader(GlobalConstants.CookieRequestHeaderName).Value;
            var cookies = cookiesRaw.Split("; ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var cookie in cookies)
            {
                var cookieKeyValuePair = cookie.Split("=",2);

                if (cookieKeyValuePair.Length != GlobalConstants.MandatoryNumberOfParametersInRequestParameterKeyValuePair)
                {
                    throw new BadRequestException();
                }

                var cookieName = cookieKeyValuePair[0];
                var cookieValue = cookieKeyValuePair[1];

                this.Cookies.Add(new HttpCookie(cookieName, cookieValue));
            }
        }

        private void ParseRequest(string requestString)
        {
            var splitRequestContent = requestString
                .Split(Environment.NewLine);

            var requestLine = splitRequestContent[0].Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.ValidteRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();

            bool requestHasBody = splitRequestContent.Length > 1;
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1],requestHasBody);

        }

        
    }
}
