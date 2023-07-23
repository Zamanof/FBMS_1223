using System.Net;
using System.Net.Sockets;

var ip = IPAddress.Loopback;
var port = 27001;

var listener = new TcpListener(ip, port);
listener.Start();


while (true)
{
    var client = listener.AcceptTcpClient();
    var stream = client.GetStream();
    var bw = new BinaryWriter(stream);
    var br = new BinaryReader(stream);

    while (true)
    {
        var data = br.ReadString();
        Console.WriteLine(data);
        bw.Write("Accept");
    }
}


