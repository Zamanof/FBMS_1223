#region Mutex
//Mutex mutex = new();
//int numb = 1;

//for (int i = 0; i < 5; i++)
//{
//	Thread thread = new Thread(Count);
//	thread.Name = $"Thread № {i}";
//	thread.Start();
//	//Count();
//}

//void Count()
//{
//	mutex.WaitOne();
//    numb = 1;
//	for (int i = 0; i < 10; i++)
//	{
//		Console.WriteLine($"{Thread.CurrentThread.Name} : {numb}");
//		numb++;
//	}
//	mutex.ReleaseMutex();
//}
#endregion

#region Mutex Global

//string mutexName = "Watcher";

//using (var mutex = new Mutex(false, mutexName))
//{
//    if (!mutex.WaitOne(30000))
//    {
//        Console.WriteLine("Other instance is running!");
//        Thread.Sleep(1000);
//        return;
//    }
//    else
//    {
//        Console.WriteLine("My code is running");
//        Console.ReadKey();
//        Thread.Sleep(100);
//        mutex.ReleaseMutex();
//    }
//}

#endregion

#region Semaphore
//Semaphore semaphore = new Semaphore(3, 3, "mySemaphore");

//for (int i = 0; i < 15; i++)
//{
//    ThreadPool.QueueUserWorkItem(Some, semaphore);
//}
//Console.ReadKey();
//Console.WriteLine("End of code");

//void Some(object state)
//{
//    var s = state as Semaphore;
//    bool st = false;
//    Random rnd = new Random();
//    while (!st)
//    {
//        if (s.WaitOne(1500))
//        {
//            try
//            {
//                Console.WriteLine($"Mr. {Thread.CurrentThread.ManagedThreadId} take key!");
//                Thread.Sleep(rnd.Next(2000, 10000));
//            }
//            finally
//            {
//                st = true;
//                Console.WriteLine($"Mr. {Thread.CurrentThread.ManagedThreadId} return key!");
//                s.Release();

//            }
//        }
//        else
//        {
//            Console.WriteLine($"Mr. {Thread.CurrentThread.ManagedThreadId} - sorry cabinets not access!");
//        }
//    }
//}


#endregion


#region SemaphoreSlim
SemaphoreSlim semaphoreSlim = new SemaphoreSlim(2);
for (int i = 0; i < 10; i++)
{
    var name = $"Thread - {i}";
    int seconds = 2 + 2 * i;
    Thread thread = new Thread(() => {
        AccessDataBase(name, seconds);
    });
    thread.Start();
}
void AccessDataBase(string name, int seconds)
{
    Console.WriteLine($"{name} wait for access");
    semaphoreSlim.Wait();
    Console.WriteLine($"{name} is working {seconds} seconds on database...");
    Thread.Sleep(seconds * 1000);
    Console.WriteLine($"{name} is complet works on database...");
    semaphoreSlim.Release();
}
#endregion