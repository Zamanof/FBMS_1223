using System.Net;
using System.Net.Sockets;

var client = new TcpClient();
client.Connect(IPAddress.Loopback, 27001);

var stream = client.GetStream();
var bw = new BinaryWriter(stream);
var br = new BinaryReader(stream);

var message = string.Empty;
var answer = string.Empty;

while (true)
{
    message = Console.ReadLine();
    bw.Write(message);
    answer = br.ReadString();
    Console.WriteLine(answer);
}