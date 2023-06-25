//ThreadPool.GetAvailableThreads(out int workerCount, out int complCount);
//Console.WriteLine(workerCount);
//Console.WriteLine(complCount);

//Console.WriteLine("Main method start ...");
//ThreadPool.QueueUserWorkItem(AsyncOperation, "Salam");
//ThreadPool.QueueUserWorkItem(_ =>
//{
//    OtherAsyncOperation();
//});
//Console.WriteLine("Main method end ...");


void AsyncOperation(object state)
{
    Console.WriteLine("AsyncOperation method start ...");
    Console.WriteLine(state.ToString());
    //Thread.Sleep(1000);
    Console.WriteLine($"AsyncOperation Worker thread Id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"AsyncOperation Worker thread isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"AsyncOperation Worker thread IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("AsyncOperation method end");
}

void OtherAsyncOperation()
{
    Console.WriteLine("OtherAsyncOperation method start ...");
    //Thread.Sleep(1000);
    Console.WriteLine($"OtherAsyncOperation Worker thread Id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"OtherAsyncOperation Worker thread isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"OtherAsyncOperation Worker thread IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("OtherAsyncOperation method end");
}
