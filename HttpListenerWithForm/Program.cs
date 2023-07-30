using System.Net;

var listener = new HttpListener();

listener.Prefixes.Add(@"http://localhost:27001/");


listener.Start();

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;
    var username = request.QueryString["name"];
    var password = request.QueryString["password"];
    StreamWriter streamWriter = new(response.OutputStream);

    if (username == "admin" && password == "admin")
    {
        streamWriter.WriteLine($"<h1 style='color:magenta;'>Welcome {username}</h1>");
    }
    else
    {
        streamWriter.WriteLine($"<h1 style='color:red;'>Incorrect login or password</h1>");
    }
    streamWriter.Close();

}