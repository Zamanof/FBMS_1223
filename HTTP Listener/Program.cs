using System.Net;
using static System.Net.WebRequestMethods;

var listener = new HttpListener();

listener.Prefixes.Add(@"http://localhost:27001/");
//listener.Prefixes.Add(@"http://localhost:27003/");

listener.Start();

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;
    //Console.WriteLine(request.RawUrl);
    //foreach (string key in request.QueryString.Keys)
    //{
    //    Console.WriteLine($"{key} - {request.QueryString[key]}");
    //}
    //response.AddHeader("Content-Type", "text/plain");
    StreamWriter streamWriter = new StreamWriter(response.OutputStream);
    //streamWriter.WriteLine("Salam");

    streamWriter.WriteLine($"<h1 style='color: red;'>Hello world! Hello {request.QueryString["name"]}</h1>");
    var str = request.QueryString["name"];
    streamWriter.WriteLine($@"<a href='https:\\google.com\search?q={str}'>");
    streamWriter.WriteLine($@"<img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ2JtCC8VyLUo9MfRj4wAM8-aS0C4tpENQLTaEoiY348Q&s'/>");
    streamWriter.WriteLine($@"</a>");
    streamWriter.Close();

}

