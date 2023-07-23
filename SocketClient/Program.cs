using System.Net.Sockets;
using System.Net;
using System.Text;

var ipAdress = IPAddress.Parse("10.1.16.1");
var port = 27001;

Socket client = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp
    );
IPEndPoint endPoint = new IPEndPoint(ipAdress, port);
var message = string.Empty;

try
{
    client.Connect(endPoint);
    if (client.Connected)
    {
        Console.WriteLine("Connected to server...");
        while (true)
        {
            message = Console.ReadLine();
            var bytes = Encoding.Default.GetBytes(message);
            client.Send(bytes);
        }
    }
    else
    {
        Console.WriteLine("Can not connected to server...");
    }

}
catch (Exception ex)
{
    Console.WriteLine("Can not connected to server...");
    Console.WriteLine();
}
