namespace ValidateURL
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var urlPattern = @"^((http|https):\/(\/[0-9a-zA-Z\-\.]+)(\:\d+)?)(\/([0-9a-zA-Z\-\.\/]+)*)?(\?[0-9a-zA-Z\-\.\=\+\&_]+)?(\#[0-9a-zA-Z\-\.]+)?$";
            var urlMatcher = new Regex(urlPattern);

            var inputUrl = Console.ReadLine();
            var matchedUrl = urlMatcher.Match(inputUrl);

            var matches = matchedUrl.Groups;
            var protocol = matches[2].ToString();
            var host = matches[3].ToString();
            host = host.Substring(1, host.Length - 1);
            var port = matches[4].ToString();
            if (!string.IsNullOrEmpty(port))
            {
                port = port.Substring(1, port.Length - 1);
            }
            var path = matches[5].ToString();
            var query = matches[7].ToString();
            if (!string.IsNullOrEmpty(query))
            {
                query = query.Substring(1, query.Length - 1);
            }
            var fragment = matches[8].ToString();
            if (!string.IsNullOrEmpty(fragment))
            {
                fragment = fragment.Substring(1, fragment.Length - 1);
            }

            try
            {
                var resultUrl = new FullUrl(protocol, host, port, path, query, fragment);
                Console.WriteLine(resultUrl);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }        
    }
}
