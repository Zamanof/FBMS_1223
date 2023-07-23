using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using TCP_MANAGER_CLIENT;

var ip = IPAddress.Loopback;
var port = 27001;
var client = new TcpClient();
client.Connect(ip, port);

var stream = client.GetStream();
var br = new BinaryReader(stream);
var bw = new BinaryWriter(stream);
Command command = null;
string response = null;

while (true)
{
    Console.WriteLine("Write command or HELP: ");
    var str = Console.ReadLine().ToUpper();
    if (str == "HELP")
    {
        Console.WriteLine();
        Console.WriteLine("Command list: ");
        Console.WriteLine(Command.ProcessList);
        Console.WriteLine($"{Command.Run} <process_name>");
        Console.WriteLine($"{Command.Kill} <process_name>");
        Console.WriteLine("HELP");
        Console.ReadLine();
        Console.Clear();
        continue;
    }
    var input = str.Split(' ');
    switch (input[0])
    {
        case Command.ProcessList:
            command = new Command { Text = input[0] };
            bw.Write(JsonSerializer.Serialize(command));
            response = br.ReadString();
            var processList = JsonSerializer.Deserialize<string[]>(response);
            foreach(var processName in processList)
            {
                Console.WriteLine($"    {processName}");
            }
            Console.ReadLine();
            Console.Clear();
            break;
        default:
            break;
    }
}