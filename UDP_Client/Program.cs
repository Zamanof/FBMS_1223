using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient(27001);
var remoteEP = new IPEndPoint(IPAddress.Any, 0);
var str = string.Empty;

while (true)
{
        var bytes = client.Receive(ref remoteEP);
        str = Encoding.Default.GetString(bytes);
        Console.WriteLine($"{remoteEP.Address} - {remoteEP.Port}: {str}");
}
