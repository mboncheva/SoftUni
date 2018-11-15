using SIS.HTTP.Sessions.Interfaces;
using System;
using System.Collections.Generic;

namespace SIS.HTTP.Sessions
{
    public class HttpSessions : IHttpSession
    {
        private readonly IDictionary<string, object> parameters;

        public HttpSessions(string id)
        {
            this.Id = id;
            this.parameters = new Dictionary<string, object>();
        }


        public string Id { get; }

        public void AddParameter(string name, object parameter)
        {
            if (ContainsParameter(name))
            {
                throw new ArgumentException();
            }

            this.parameters[name] = parameter;
        }

        public void ClearParameters()
        {
            this.parameters.Clear();
        }

        public bool ContainsParameter(string name)
        {
            return this.parameters.ContainsKey(name);
        }

        public object GetParameters(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }

            if (!this.ContainsParameter(name))
            {
                return null;
            }

            return this.parameters[name];
        }
    }
}
