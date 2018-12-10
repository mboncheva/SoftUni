namespace SIS.MvcFramework
{
    using System;
    using SIS.HTTP.Enums;

    public abstract class HttpAttribute : Attribute
    {
        protected HttpAttribute(string path)
        {
            this.Path = path;
        }

        public string Path { get; }

        public abstract HttpRequestMethod Method { get; }
    }
}
