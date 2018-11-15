namespace SIS.HTTP.Cookies
{
    using SIS.HTTP.Cookies.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie httpCookie)
        {
            if (httpCookie == null)
            {
                throw new ArgumentException();
            }

            // TODO:
            //if (this.ContainsCookie(httpCookie.Key))
            //{
            //    throw new Exception();
            //}

            this.cookies[httpCookie.Key] = httpCookie;
        }

        public bool ContainsCookie(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            if (!this.ContainsCookie(key))
            {
                return null;
            }

            return this.cookies[key];
        }

        public bool HasCookies()
        {
            return this.cookies.Any();
        }

        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }
    }
}
