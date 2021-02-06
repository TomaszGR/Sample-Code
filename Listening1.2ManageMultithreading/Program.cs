using System;
using System.Threading;
using System.Threading.Tasks;

namespace Listing1._2ManageMultithreading
{
   class Program
   {

      #region Lock

      //object lockA = new object();
      //object lockB = new object();
      //var up = Task.Run(() =>
      //{
      //   lock (lockA)
      //   {
      //      Thread.Sleep(5000);
      //      lock (lockB)
      //      {
      //         Console.WriteLine("Locked A and B");
      //      }
      //   }
      //});
      //lock (lockB)
      //{
      //   lock (lockA)
      //   {
      //      Console.WriteLine("Locked A and B");
      //   }
      //}
      //up.Wait();
      //
      //Console.WriteLine("finish");
      //Console.ReadKey();
      #endregion

      #region CancelingTasksWithCatchExeption
      //static void Main(string[] args)
      //{
      //   CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
      //   CancellationToken token = cancellationTokenSource.Token;
      //   Task task = Task.Run(() =>
      //   {
      //      while (!token.IsCancellationRequested)
      //      {
      //         Console.Write("*");
      //         Console.WriteLine($"token : {token.IsCancellationRequested}");
      //         Thread.Sleep(1000);
      //      }
      //      token.ThrowIfCancellationRequested();
      //   }, token);
      //
      //   try
      //   {
      //      Console.WriteLine($"token : {token.IsCancellationRequested}");
      //      Console.WriteLine("Press enter to stop the task");
      //      Console.ReadLine();
      //      cancellationTokenSource.Cancel();
      //      task.Wait();
      //      Console.WriteLine($"token : {token.IsCancellationRequested}");
      //   }
      //   catch (AggregateException e)
      //   {
      //      Console.WriteLine(e.InnerExceptions[0].Message);
      //   }
      //   Console.WriteLine("Press enter to end the application");
      //   Console.ReadLine();
      //}
      #endregion

      #region CancelingTasksWithContinuing
      static void Main(string[] args)
      {
         CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
         CancellationToken token = cancellationTokenSource.Token;
        
         Task task = Task.Run(() =>
        {
           while (!token.IsCancellationRequested)
           {
              Console.Write("*");
              Thread.Sleep(1000);
           }
        }, token).ContinueWith((t) =>
           {
              Console.WriteLine("task was canceled");
              t.Exception.Handle((e) => true);
              Console.WriteLine("task was canceled");
           }, TaskContinuationOptions.OnlyOnCanceled);


         //Task longRunning = Task.Run(() =>
         //{
         //   Thread.Sleep(10000);
         //});
         //int index = Task.WaitAny(new[] { longRunning }, 5000);
         //if (index == -1)
         //{
         //   Console.WriteLine("Task timed out");
         //}

         Console.WriteLine($"token : {token.IsCancellationRequested}");
         Console.ReadLine();
         cancellationTokenSource.Cancel();
         Console.WriteLine($"token : {token.IsCancellationRequested}");

         Console.WriteLine("Press enter to end the application");
         Console.ReadLine();
      }
      #endregion
   }
}
