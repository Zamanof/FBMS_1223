// TPL - Task Parallel Library

#region Task Creating
//var task1 = new Task(() => { TaskMethod("Task 1"); });
//var task2 = new Task(() => { TaskMethod("Task 2"); });
//var task3 = Task.Run(() => { TaskMethod("Task 3"); });

//var task4 = Task.Factory.StartNew(() => { TaskMethod("Task 4"); });

//var task5 = Task.Factory.StartNew(() => { TaskMethod("Task 5"); }, 
//    TaskCreationOptions.LongRunning);

//task1.Start();
//task2.Start();

//Console.ReadLine();
//Console.WriteLine("End of code");
//void TaskMethod(string name)
//{
//    Console.WriteLine($"Thread {name} is running. " +
//        $"Id = {Thread.CurrentThread.ManagedThreadId}. " +
//        $"IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}. " +
//        $"IsBackground = {Thread.CurrentThread.IsBackground}");
//}
#endregion

#region WorkWithTask


//Task<int> task1 = new Task<int>(() => TaskMethod("Task 1"));
//task1.Start();
//var taskResult = task1.Result;
//Console.WriteLine($"Task Thread result = {taskResult}");

//Task<int> task2 = new Task<int>(() => TaskMethod("Task 2"));
//task2.RunSynchronously();
//task2.Start();
//Console.WriteLine(task2.Result);
//var result = TaskMethod("Main Thread");
//Console.WriteLine($"Main Thread result = {result}");

var task3 = new Task<int>(() => TaskMethod("Task 3"));
var isStarted = false;
while (!task3.IsCompleted)
{
    Console.WriteLine(task3.Status);
    Console.WriteLine("Waiting... ");
    Thread.Sleep(500);
    if (!isStarted)
    {
        task3.Start();
        isStarted = true;
    }
}
Console.WriteLine(task3.Status);
Console.WriteLine("End of Code");
int TaskMethod (string name)
{
    Console.WriteLine($"Thread {name} is running. " +
        $"Id = {Thread.CurrentThread.ManagedThreadId}. " +
        $"IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}. " +
        $"IsBackground = {Thread.CurrentThread.IsBackground}");

    Thread.Sleep(2000);
    return 13;
}

#endregion