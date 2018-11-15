﻿namespace SIS.HTTP.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Interfaces;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Extensions;
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

        private bool IsValidRequestLine(string[] requestLine)
        {
            return requestLine.Length == 3
                    && requestLine[2].ToLower()
                    != GlobalConstants.HttpOneProtocolFragment;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            return !(string.IsNullOrEmpty(queryString) || queryParameters.Length < 1);
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var parseResult = Enum.TryParse<HttpRequestMethod>(requestLine[0].Capitalize(), out var parsedRequestMethod);

            if (!parseResult)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = parsedRequestMethod;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url?.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private void ParseHeaders(string[] requestContent)
        {
            int currentIndex = 0;

            while (!string.IsNullOrEmpty(requestContent[currentIndex]))
            {
                string[] headerArguments = requestContent[currentIndex++].Split(": ");

                this.Headers.Add(new HttpHeader(headerArguments[0], headerArguments[1]));
            }

            if (!this.Headers.ContainsHeader(GlobalConstants.HostHeaderKey))
            {
                throw new BadRequestException();
            }
        }

        private void ParseQueryParameters()
        {
            if (!this.Url.Contains('?'))
            {
                return;
            }

            string queryString = this.Url
                .Split(new[] { '?', '#' }, StringSplitOptions.None)[1];

            if (string.IsNullOrWhiteSpace(queryString))
            {
                return;
            }

            string[] queryParameters = queryString.Split('&');

            if (!this.IsValidRequestQueryString(queryString, queryParameters))
            {
                throw new BadRequestException();
            }

            foreach (var queryParameter in queryParameters)
            {
                string[] parameterArguments = queryParameter
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                this.QueryData.Add(parameterArguments[0], parameterArguments[1]);
            }

        }

        private void ParseFormDataParameters(string formData)
        {
            if (string.IsNullOrEmpty(formData))
            {
                return;
            }

            string[] formDataParams = formData.Split('&');

            foreach (var formDataParameter in formDataParams)
            {
                string[] parameterArguments = formDataParameter
                    .Split('=');

                this.FormData.Add(parameterArguments[0], parameterArguments[1]);
            }
        }

        private void ParseRequestParameters(string formData)
        {
            this.ParseQueryParameters();
            this.ParseFormDataParameters(formData);
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader(HttpHeader.Cookie)) return;

            string cookiesString = this.Headers.GetHeader(HttpHeader.Cookie).Value;

            if (string.IsNullOrEmpty(cookiesString)) return;

            string[] splitCookies = cookiesString.Split("; ");

            foreach (var splitCookie in splitCookies)
            {
                string[] cookieParts = splitCookie.Split('=', 2, StringSplitOptions.RemoveEmptyEntries);

                if (cookieParts.Length != 2) continue;

                string key = cookieParts[0];
                string value = cookieParts[1];

                this.Cookies.Add(new HttpCookie(key, value, false));
            }
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                 .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim().
                Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();

            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);

        }

        
    }
}
