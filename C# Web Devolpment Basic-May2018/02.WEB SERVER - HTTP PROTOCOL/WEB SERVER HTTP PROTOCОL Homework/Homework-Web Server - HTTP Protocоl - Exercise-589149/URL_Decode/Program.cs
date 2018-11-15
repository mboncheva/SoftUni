namespace URL_Decode
{
    using System;
    using System.Net;

    public class Program
    {
        public static void Main()
        {
            var url = Console.ReadLine();
            var decodedUrl = WebUtility.UrlDecode(url);
            Console.WriteLine(decodedUrl);
        }
    }
}
