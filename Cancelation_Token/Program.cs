#region Thread interrupt
//Thread thread = new Thread(Download);
//thread.Start();
//Console.ReadLine();
//if (thread.IsAlive)
//{
//    thread.Interrupt();
//    Console.WriteLine("Downloading Cancel...");

//}
//Console.WriteLine("End of code");
#endregion

using (CancellationTokenSource cancellationToken = new())
{

    ThreadPool.QueueUserWorkItem((o) =>
    {
        try
        {
            DownloadToken(cancellationToken.Token);
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine(ex.Message);
        }
    });
    Thread.Sleep(2000);
    if (Console.ReadKey().Key == ConsoleKey.Enter)
    {
        cancellationToken.Cancel();
    }
}
Thread.Sleep(100);
Console.ReadLine();
Console.WriteLine("Main End");


void Download()
{
    Console.WriteLine("Downloading start...");
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"Download {i / 1.0}%");
        Thread.Sleep(1);
        Console.Clear();
    }
    Console.WriteLine("Downloading finish...");
}


void DownloadToken(CancellationToken token)
{
    Console.WriteLine("Downloading start...");
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"Download {i / 1.0}%");
        Thread.Sleep(1);
        Console.Clear();
        // Soft cancel
        //if (token.IsCancellationRequested)
        //{
        //    Console.WriteLine("Downloading Cancel...");
        //    return;
        //}

        // Hard cancel
        token.ThrowIfCancellationRequested();
    }
    Console.WriteLine("Downloading finish...");
}