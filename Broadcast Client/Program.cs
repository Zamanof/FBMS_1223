using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();

var endPoint = new IPEndPoint(IPAddress.Broadcast, 27001);

while (true)
{
    var data = Encoding.Default.GetBytes(Console.ReadLine()!);
    client.Send(data, endPoint);
}
