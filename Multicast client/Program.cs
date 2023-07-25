using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();
var ip = IPAddress.Parse("224.5.6.7");
client.JoinMulticastGroup(ip);
var endPoint = new IPEndPoint(ip, 27001);

while (true)
{
    var data = Encoding.Default.GetBytes("224.5.6.7");
    client.Send(data, data.Length, endPoint);
}