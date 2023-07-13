Console.WriteLine($"Main Begin - Id: {Thread.CurrentThread.ManagedThreadId}"); // 1
//SomeMethod();
SomeMethodAsync();
Console.ReadKey();


//void SomeMethod()
//{
//    Console.WriteLine($"someMethod Begin - Id: {Thread.CurrentThread.ManagedThreadId}"); // 1
//    Task.Run(() =>
//    {
//        Console.WriteLine($"someMethod Task Begin - Id: {Thread.CurrentThread.ManagedThreadId}"); // task id
//        Thread.Sleep(3000);
//        Console.WriteLine($"someMethod Task End - Id: {Thread.CurrentThread.ManagedThreadId}"); // same task id 
//    });
//    Console.WriteLine($"someMethod End - Id: {Thread.CurrentThread.ManagedThreadId}"); // 1
//}


async void SomeMethodAsync()
{
    Console.WriteLine($"someMethod Begin - Id: {Thread.CurrentThread.ManagedThreadId}"); // 1
    await Task.Run(() =>
    {
        Console.WriteLine($"someMethod Task Begin - Id: {Thread.CurrentThread.ManagedThreadId}"); // task id
        Thread.Sleep(3000);
        Console.WriteLine($"someMethod Task End - Id: {Thread.CurrentThread.ManagedThreadId}"); // same task id 
    });
    Console.WriteLine($"someMethod End - Id: {Thread.CurrentThread.ManagedThreadId}"); // 1
}

// Thread -> ThreadPool -> Task -> syntax sugar + LOVE = async await