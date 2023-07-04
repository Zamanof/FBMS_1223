#region Albahari Tricks
// lambda expression and shared memory problem
//for (int i = 0; i < 10; i++)
//{
//    new Thread(()
//        => Console.WriteLine(i))
//        .Start();
//}


// Solution - local temp variable;
//for (int i = 0; i < 10; i++)
//{
//   int tmp = i;
//    new Thread(()
//        => Console.WriteLine(tmp))
//        .Start();
//}

//string text = "Nadir";
//Thread thread1 = new Thread(() => Console.WriteLine(text));

//text = "Albahari";
//Thread thread2 = new Thread(() => Console.WriteLine(text));
//thread2.Start();
//thread1.Start();


#endregion

// Critical section

#region class Interlocked 
//Thread[] threads = new Thread[5];
//for (int i = 0; i < 5; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            // Critical section problem
//            // ++ operation not atomary (read, change, write memory)
//            //Counter.Count++;

//            Interlocked.Increment(ref Counter.Count);
//            if (Counter.Count % 2 != 0)
//            {
//                Interlocked.Increment(ref Counter.CountOdd);
//            }
//        }
//    });
//}
//foreach (Thread thread in threads)
//{
//    thread.Start();
//}

////Console.WriteLine($"Main thread without join {Counter.Count}");
//foreach (Thread thread in threads)
//{
//    thread.Join();
//}
//Console.WriteLine($"Main thread with join Count = {Counter.Count}");
//Console.WriteLine($"Main thread with join CountOdd = {Counter.CountOdd}");
#endregion

// class Monitor 
// lock - syntax sugar
#region Monitor
//Thread[] threads = new Thread[5];
//object obj = new object();


//for (int i = 0; i < 5; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {

//            Monitor.Enter(obj);
//            try
//            {
//                Counter.Count++;
//                if (Counter.Count % 2 != 0)
//                {
//                    Counter.CountOdd++;
//                }
//            }
//            finally
//            {

//                Monitor.Exit(obj);
//            }

//        }
//    });
//}
//foreach (Thread thread in threads)
//{
//    thread.Start();
//}

////Console.WriteLine($"Main thread without join {Counter.Count}");
//foreach (Thread thread in threads)
//{
//    thread.Join();
//}
//Console.WriteLine($"Main thread with join Count = {Counter.Count}");
//Console.WriteLine($"Main thread with join CountOdd = {Counter.CountOdd}");
#endregion

#region lock
Thread[] threads = new Thread[5];
object obj = new object();


for (int i = 0; i < 5; i++)
{
    threads[i] = new Thread(() =>
    {
        for (int j = 0; j < 1000000; j++)
        {

            lock (obj)
            {
                Counter.Count++;
                if (Counter.Count % 2 != 0)
                {
                    Counter.CountOdd++;
                }
            }



        }
    });
}
foreach (Thread thread in threads)
{
    thread.Start();
}

//Console.WriteLine($"Main thread without join {Counter.Count}");
foreach (Thread thread in threads)
{
    thread.Join();
}
Console.WriteLine($"Main thread with join Count = {Counter.Count}");
Console.WriteLine($"Main thread with join CountOdd = {Counter.CountOdd}");
#endregion
class Counter
{
    public static int Count = 0;
    public static int CountOdd = 0;

}