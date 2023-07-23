using System.Net;
using System.Net.Sockets;
using System.Text;

var server = new UdpClient();

var connectEP = new IPEndPoint(IPAddress.Loopback, 27001);

var str = string.Empty;

while (true)
{

    str = Console.ReadLine();
    var bytes = Encoding.Default.GetBytes(str);
    server.Send(bytes, bytes.Length, connectEP);

}
