Console.WriteLine("Main thread start");


Thread thread = new Thread(() =>
{
	Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} start");
	for (int i = 0; i < 50; i++)
	{
		Console.WriteLine(i);
		Thread.Sleep(100);
	}
	Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} end");
});
thread.IsBackground = true;
thread.Start();
//Console.ReadKey();
Console.WriteLine("Main thread end");
thread.Join();