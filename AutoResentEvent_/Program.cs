AutoResetEvent _workerEvent = new AutoResetEvent(false);
AutoResetEvent _mainEvent = new AutoResetEvent(false);

Thread thread = new Thread(() =>
{
    SomeProccess(10);
});
thread.Start();
Console.WriteLine("Waiting for SomeProccess method signal.");

_workerEvent.WaitOne();

Console.WriteLine("Starting some Main operations");
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Main thread {i}");
    Thread.Sleep(TimeSpan.FromSeconds(1));
}
_mainEvent.Set();


Console.WriteLine("Worker thread continue doing some job...");

_workerEvent.WaitOne();

Console.WriteLine("Complete");

void SomeProccess(int seconds)
{

    Console.WriteLine("Starting some SomeProccess operations");
    Thread.Sleep(TimeSpan.FromSeconds(seconds));
    Console.WriteLine("O.K.");


    _workerEvent.Set(); 
  
    Console.WriteLine("Main Thread is start working. ");
    _mainEvent.WaitOne();

    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Some process {i}");
        Thread.Sleep(TimeSpan.FromSeconds(1));
    }
    _workerEvent.Set();
} 
