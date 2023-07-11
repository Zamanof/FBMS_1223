var firstTask = new Task<int>(() =>TaskMethod("First Task", 3));

var secondTask = new Task<int>(() => TaskMethod("Second Task", 2));

//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine($@"Task result: {5}.
//Id: {Thread.CurrentThread.ManagedThreadId}
//Is ThreadPool: {Thread.CurrentThread.IsThreadPoolThread}
//{new string('_', 35)}
//");
//}, TaskContinuationOptions.OnlyOnRanToCompletion);

//firstTask.ContinueWith((t) =>
//{
//    OtherMethod();
////    Console.WriteLine($@"Task result: {5}.
////Id: {Thread.CurrentThread.ManagedThreadId}
////Is ThreadPool: {Thread.CurrentThread.IsThreadPoolThread}
////{new string('_', 35)}
////");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.LongRunning);


//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine($@"First Task inner task.
//Id: {Thread.CurrentThread.ManagedThreadId}
//Is ThreadPool: {Thread.CurrentThread.IsThreadPoolThread}
//{new string('_', 35)}
//");
//}, TaskContinuationOptions.OnlyOnRanToCompletion);

//var contin = secondTask.ContinueWith((t) => {
//    Console.WriteLine($@"Second Task inner task.
//Id: {Thread.CurrentThread.ManagedThreadId}
//Is ThreadPool: {Thread.CurrentThread.IsThreadPoolThread}
//{new string('_', 35)}
//");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);



//firstTask.Start();
//secondTask.Start();
//Console.WriteLine(firstTask.Result);
//Console.WriteLine(secondTask.Result);

//for (int i = 0; i < 100; i++)
//{
//    Console.WriteLine(i);
//    Thread.Sleep(100);
//}
//Task.WaitAll(firstTask, secondTask);
//Task.WaitAny(firstTask, secondTask);




var grandParentTask = new Task<int>(() =>
{
    var parentTask = Task.Factory.StartNew(() => { TaskMethod("Parent Task", 5); }, 
        TaskCreationOptions.AttachedToParent);
    parentTask.ContinueWith((t) => { TaskMethod("Child Task", 2); },
        TaskContinuationOptions.AttachedToParent);
    return TaskMethod("Grand Parent Task", 3);

});


grandParentTask.Start();
grandParentTask.Wait();
//Console.ReadKey();
Console.WriteLine("End");

int TaskMethod(string name, int seconds)
{
    Console.WriteLine($@"Task {name} is running.
Id: {Thread.CurrentThread.ManagedThreadId}
Is ThreadPool: {Thread.CurrentThread.IsThreadPoolThread}
{new string('_', 35)}
");
    Thread.Sleep(TimeSpan.FromSeconds(seconds));
    Console.WriteLine($"\n{name} return some value!\n");
    return 13 * seconds;
}

void OtherMethod()
{
    Console.WriteLine("Other method is running");
    Console.WriteLine($"Is ThreadPool thread: {Thread.CurrentThread.IsThreadPoolThread}");
}
