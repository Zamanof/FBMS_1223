using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new UdpClient(27001);
listener.EnableBroadcast = true;

var from = new IPEndPoint(IPAddress.Any, 0);

while (true)
{
    var receiveBuffer = listener.Receive(ref from);
    Console.WriteLine(Encoding.Default.GetString(receiveBuffer));
    Thread.Sleep(40);
    Console.Clear();
}