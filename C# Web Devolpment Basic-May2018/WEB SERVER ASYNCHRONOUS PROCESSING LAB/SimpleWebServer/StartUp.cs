using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer
{
    class StartUp
    {
        static void Main()
        {
            var port = 1444;
            var ipAddress = IPAddress.Parse("127.0.0.1");

            var tcpListener = new TcpListener(ipAddress, port);

            tcpListener.Start();

            Task.Run(async() =>
            {
               await Connect(tcpListener);
            })
            .GetAwaiter()
            .GetResult(); 
        }

        public static async Task Connect(TcpListener tcpListener)
        {
            while (true)
            {
                using (var client = await tcpListener.AcceptTcpClientAsync())
                {
                    var buffer = new byte[1024];

                  await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
                 var clientMessage = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine(clientMessage.Trim());

                    var responseMessage = $"HTTP/1.1 200 OK{Environment.NewLine}Content-Type: text/plain{Environment.NewLine}{Environment.NewLine}Hello from server!";
                   var data = Encoding.UTF8.GetBytes(responseMessage);

                    await client.GetStream().WriteAsync(data, 0, data.Length);
                }

            }
        }
    }
}
