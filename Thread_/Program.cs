//Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

Thread thread1 = new Thread(() =>
{
	for (int i = 0; i < 100; i++)
	{
		Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {i} - {Thread.CurrentThread.IsBackground}");
	}
});
ParameterizedThreadStart parameterized = Some;
Thread thread2 = new(Some);
thread1.IsBackground = true;
thread2.IsBackground = true;
thread1.Start();
thread2.Start();
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"\t\t{Thread.CurrentThread.ManagedThreadId} - {i} - {Thread.CurrentThread.IsBackground}");
}


void Some(object obj)
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"\t{Thread.CurrentThread.ManagedThreadId} - {i} - {Thread.CurrentThread.IsBackground}");
    }
}
