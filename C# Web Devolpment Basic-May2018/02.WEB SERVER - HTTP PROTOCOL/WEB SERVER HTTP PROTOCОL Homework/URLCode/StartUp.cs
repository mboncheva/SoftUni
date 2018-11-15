using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace URLCode
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var url = Console.ReadLine();
            var decodeUrl = WebUtility.UrlDecode(url);
            Console.WriteLine(decodeUrl);
        }
    }
}
