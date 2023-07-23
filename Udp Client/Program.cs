using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp
    );

IPAddress.TryParse("10.1.16.1", out var ip);
var connectEP = new IPEndPoint(ip, 27001);

var message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam blandit id mauris vitae mattis. Cras magna purus, ullamcorper id molestie pellentesque, auctor eget ipsum. Fusce tellus augue, ultrices eget nisi ac, molestie mattis turpis. Ut id risus quis magna pretium dapibus. Vivamus dictum eget ligula ac ullamcorper. Integer aliquam ex quis ipsum porttitor, et dapibus felis lacinia. Donec congue velit vitae aliquam vulputate. Vivamus posuere ac ipsum at finibus. Aliquam erat volutpat. Vivamus vel euismod arcu.\r\n\r\nSed lacinia et ligula in commodo. Praesent viverra risus fermentum, faucibus nisi id, molestie urna. Quisque eu ultrices enim, nec tristique lectus. Sed hendrerit, erat et consectetur venenatis, turpis urna rutrum diam, et congue ex mauris sit amet mi. Proin a elementum nisi. Integer tempus sem sit amet bibendum laoreet. Aenean rhoncus tempus neque sit amet sodales. Donec gravida lectus non massa egestas, molestie cursus ipsum egestas. Donec convallis, lectus et porta vehicula, nisl justo mattis elit, vehicula semper nisi ligula in quam. Etiam interdum egestas diam, convallis rutrum justo mattis vel.\r\n\r\nPhasellus et elit laoreet, facilisis nibh eu, scelerisque orci. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sit amet turpis viverra, semper lacus nec, efficitur turpis. Integer sit amet dui id enim sagittis vestibulum eu at orci. Proin egestas, augue nec convallis commodo, orci nisl dignissim enim, sed suscipit magna neque id ex. Donec malesuada orci id sem pulvinar rutrum. Suspendisse potenti. Suspendisse in orci felis. Suspendisse tortor lorem, eleifend dictum odio eget, vulputate vehicula justo. Pellentesque sit amet aliquam nisl. Quisque convallis leo eget erat rhoncus mollis. Suspendisse ut tempor felis. Aliquam erat volutpat. Nullam consequat maximus euismod. Suspendisse tristique nisl eu suscipit volutpat.\r\n\r\nEtiam id libero metus. Fusce malesuada eu augue nec blandit. Maecenas massa sem, pulvinar ut nulla ac, tempor fringilla ipsum. Curabitur in vestibulum dolor. Sed vel efficitur purus. Nullam laoreet turpis nec sem laoreet egestas. Interdum et malesuada fames ac ante ipsum primis in faucibus. Proin blandit sapien nisl, a laoreet ex posuere vitae. Suspendisse porttitor volutpat ante. Aliquam sit amet egestas urna, sit amet vehicula mi. Pellentesque ornare quis massa in aliquam. Proin bibendum fringilla ligula, a egestas felis facilisis a. Nulla convallis, ante ut pharetra dignissim, lacus risus tristique massa, eget varius mi nisl ac sapien. Phasellus semper augue et turpis elementum, ut gravida eros finibus.\r\n\r\nNulla dapibus massa risus, quis molestie mauris vehicula lacinia. Aenean sodales porttitor purus varius mollis. In ac magna a lectus scelerisque blandit. Suspendisse rutrum faucibus elementum. Duis a quam id nisl cursus placerat. Aliquam ac velit congue, maximus orci sed, tempus felis. Aliquam feugiat, lectus in tempus blandit, diam orci tincidunt erat, in tempus sapien orci in turpis. Praesent ornare dolor sit amet tortor consequat, nec sagittis lacus vulputate. Pellentesque ut tellus vitae dui sodales dictum. Aenean dignissim lorem libero. Aliquam nec varius turpis, at facilisis nisi. Nam sit amet efficitur libero. Nunc vehicula ligula eget odio aliquet, et bibendum quam congue. Quisque fermentum, metus ut tempus placerat, tortor leo pulvinar sapien, vel gravida diam magna quis mi.";

int count = 0;
//Console.WriteLine(message.Length);
while (true)
{
    var bytes = Encoding.Default.GetBytes(message[count++ % message.Length].ToString());
    Thread.Sleep(100);
    client.SendTo(bytes, connectEP);
}