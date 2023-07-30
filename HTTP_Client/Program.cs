using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
#region Deprecated WebClient class
// HTTP + FTP
//var webClient = new WebClient();
//Console.WriteLine(webClient.DownloadString(@"https://www.google.com"));
#endregion


#region HttpClient

//var client = new HttpClient(); 
//var message = new HttpRequestMessage 
//{
//    Method = HttpMethod.Get,
//    RequestUri =new Uri(@"https://www.google.com/")
//};
//message.Headers.Add("Accept", "text/html");

//var response = await client.SendAsync(message);
//Console.WriteLine(response);
//Console.WriteLine(response.Headers);
//Console.WriteLine(response.StatusCode);
//Console.WriteLine(response.Content);
//Console.WriteLine(response.RequestMessage);



// .GetAsync(), .PostAsync(), .DeleteAsync() ...
//var result = await client.GetAsync(@"https://www.google.com/");
//Console.WriteLine(result);
//Console.WriteLine(result.RequestMessage.Method);

//var page = await response.Content.ReadAsStringAsync();
//Console.WriteLine(page);


#endregion


var postClient = new HttpClient();
var msg = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri(@"https://jsonplaceholder.typicode.com/posts")
};

var response = postClient.SendAsync(msg).Result;
//Console.WriteLine(response);
var json = await response.Content.ReadAsStringAsync();
//Console.WriteLine(json);
var posts = JsonSerializer.Deserialize<Post[]>(json);
foreach (var post in posts)
{
    Console.WriteLine($@"{post.Id}
Sender:  {post.UserId}
                {post.Title}

{post.Text}


");

}

class Post
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("body")]
    public string Text { get; set; }

}

