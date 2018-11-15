namespace RequestParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpRequest
    {
        private Dictionary<string, List<string>> PathsAndMethods;

        public HttpRequest()
        {
            this.PathsAndMethods = new Dictionary<string, List<string>>();
        }        

        public void AddInfo(string input)
        {
            var tokens = input
                .Split('/')
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();

            var path = "/" + tokens[0];
            var method = tokens[1];

            if (!this.PathsAndMethods.ContainsKey(path))
            {
                this.PathsAndMethods.Add(path, new List<string>());
            }

            this.PathsAndMethods[path].Add(method);
        }

        public bool ProccessData(string finalInput)
        {
            var tokens = finalInput
                .Split()
                .ToArray();

            var method = tokens[0].ToLower();
            var path = tokens[1];

            if (!this.PathsAndMethods.ContainsKey(path))
            {
                return false;
            }

            if (!this.PathsAndMethods[path].Contains(method))
            {
                return false;
            }

            return true;
        }
    }
}
