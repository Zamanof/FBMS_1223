using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Asynchronous_methods
{
    internal class Program
    {
        delegate void SomeDelegate();
        static void Main(string[] args)
        {
            var deleg = new SomeDelegate(Some);
            var result = deleg.BeginInvoke(null, null);
            Console.WriteLine($"Main method thread Id {Thread.CurrentThread.ManagedThreadId}");
            deleg.EndInvoke(result);
            Console.WriteLine($"Main method thread is background {Thread.CurrentThread.IsBackground}"); 


        }
        static void Some()
        {
            Console.WriteLine($"Some method thread Id {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
            Console.WriteLine($"Some method thread is background {Thread.CurrentThread.IsBackground}");
            Console.WriteLine($"Worker thread IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
        }
    }
}
