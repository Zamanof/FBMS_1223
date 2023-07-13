using System.Collections.Concurrent;
using System.Net;

namespace AsyncIn
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World!");
        //}

        static async Task Main(string[] args)
        {
            string url = @"https://turbo.az/";
            WebClient webClient = new();
            Console.WriteLine(await webClient.DownloadStringTaskAsync(url));
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            
        }
    }
}