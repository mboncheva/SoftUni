namespace ValidateURL
{
    using System;
    using System.Text;

    public class FullUrl
    {
        private const string EXCEPTION_MESSAGE = "Invalid URL";
        private string port;

        public FullUrl(string protocol, string host, string port, string path, string query, string fragment)
        {
            this.Protocol = protocol;
            this.Host = host;
            this.Port = port;
            this.Path = path;
            this.Query = query;
            this.Fragment = fragment;
        }

        public string Protocol { get; set; }
        public string Host { get; set; }
        public string Port
        {
            get => this.port;
            set
            {
                if (this.Protocol == "http")
                {
                    if (value != "80" && !string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException(EXCEPTION_MESSAGE);
                    }
                }

                if (this.Protocol == "https")
                {
                    if (value != "443" && !string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException(EXCEPTION_MESSAGE);
                    }
                }

                this.port = value;
            }
        }
        public string Path { get; set; }
        public string Query { get; set; }
        public string Fragment { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Protocol: {this.Protocol}");
            result.AppendLine($"Host: {this.Host}");

            if (this.Protocol == "http")
            {
                result.AppendLine($"Port: 80");
            }
            else
            {
                result.AppendLine("Port: 443");
            }

            result.AppendLine($"Path: {this.Path}");

            if (!string.IsNullOrEmpty(this.Query))
            {
                result.AppendLine($"Query: {this.Query}");
            }

            if (!string.IsNullOrEmpty(this.Fragment))
            {
                result.AppendLine($"Fragment: {this.Fragment}");
            }

            return result.ToString();
        }
    }
}
