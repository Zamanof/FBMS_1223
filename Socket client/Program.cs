using System.Net;
using System.Net.Sockets;
using System.Text;

var ipAdress = IPAddress.Parse("10.1.16.1");
var port = 27001;

Socket listener = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp
    );

var endPoint = new IPEndPoint(ipAdress, port);
listener.Bind(endPoint);
var backlog = 1;

Console.WriteLine("Listener listen...");
listener.Listen(backlog);

var length = 0;

var bytes = new byte[1024];
var message = string.Empty;

Socket client = null;

while (true)
{
    Console.WriteLine($"Listening on {listener.LocalEndPoint}");
    client = listener.Accept();
    Task.Run(() =>
    {
        do
        {
            length = client.Receive(bytes);
            message = Encoding.Default.GetString(bytes, 0, length);
            Console.WriteLine($"{client.RemoteEndPoint}: {message}");
            if (message.ToLower() == "exit")
            {
                client.Shutdown(SocketShutdown.Both);
                client.Dispose();
                break;

            }
        } while (true);

    });
}

