using System.Net;
using System.Net.Sockets;

var ipAdress = IPAddress.Parse("127.0.0.1");
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

Socket 

