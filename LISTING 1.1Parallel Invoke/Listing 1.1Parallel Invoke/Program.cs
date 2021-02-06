using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Listing_1._1Parallel_Invoke
{
   class Program
   {
      #region Task
      //static void Task1()
      //  {
      //      Console.WriteLine("Task 1 starting");
      //      Thread.Sleep(2000);
      //      Console.WriteLine("Task 1 ending");
      //  }
      //
      //  static void Task2()
      //  {
      //      Console.WriteLine("Task 2 starting");
      //      Thread.Sleep(1000);
      //      Console.WriteLine("Task 2 ending");
      //  }
      //
      //  static void Main(string[] args)
      //  {
      //      Parallel.Invoke(() => Task1(), () => Task2());
      //      Console.WriteLine("Finished processing. Press a key to end.");
      //      Console.ReadKey();
      //  }
      #endregion
      #region PLINQ
      //public static void Main()
      //{
      //   System.Collections.Generic.IEnumerable<int> numbers = Enumerable.Range(0, 10);
      //   var parallelResult = numbers
      //      .AsParallel()
      //      .AsOrdered()
      //      .Where(i => i % 2 == 0)
      //      .ToArray();
      //   foreach (int i in parallelResult)
      //   Console.WriteLine(i);
      //
      //   Console.WriteLine("-------------------------------");
      //
      //   var Result2 = numbers
      //      .Where(i => i % 2 == 0)
      //      .ToArray();
      //   
      //   foreach (int i in Result2)
      //   {
      //      Console.WriteLine(i);
      //   }
      //
      //   Console.WriteLine("-------------------------------");
      //
      //   var parallelResultAsSeq = numbers
      //      .AsParallel()
      //      .AsOrdered()
      //      .Where(i => i % 2 == 0)
      //      .AsSequential()
      //      .ToArray();
      //   foreach (int i in parallelResult.Take(20))
      //   Console.WriteLine(i);
      //
      //   Console.WriteLine("-------------------------------");
      //
      //   var forAll = numbers
      //      .AsParallel()
      //      .Where(i => i % 2 == 0);
      //
      //   forAll.ForAll( i => Console.WriteLine($"for all: {i}") );
      //
      //   Console.ReadKey();
      //}
      #endregion
      #region PLINQ AggregateException
      //public static void Main()
      //{
      //   var numbers = Enumerable.Range(0, 20);
      //   try
      //   {
      //      var parallelResult = numbers.AsParallel()
      //      .Where(i => IsEven(i));
      //      parallelResult.ForAll(e => Console.WriteLine(e));
      //   }
      //   catch (AggregateException e)
      //   {
      //      Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);
      //   }
      //
      //   Console.ReadKey();
      //}
      //
      //public static bool IsEven(int i)
      //{
      //   if (i % 10 == 0) throw new ArgumentException("i");
      //   return i % 2 == 0;
      //}
      //
      #endregion
      #region BlockingCollection
      //public static void Main()
      //{
      //   BlockingCollection<string> col = new BlockingCollection<string>();
      //   
      //   Task read = Task.Run(() =>
      //   {
      //      while (true)
      //      {
      //        //Console.WriteLine("remove");
      //        //Console.WriteLine(col.FirstOrDefault().ToString());
      //        // Console.WriteLine(col.Take());
      //
      //         foreach (string v in col.GetConsumingEnumerable())
      //            Console.WriteLine(v);
      //      }
      //   });
      //
      //   Task write = Task.Run(() =>
      //   {
      //      while (true)
      //      {
      //         string s = Console.ReadLine();
      //         string e = Console.ReadLine();
      //
      //         if (string.IsNullOrWhiteSpace(s))
      //         {
      //            break;
      //         }
      //
      //         col.Add(s);
      //         col.Add(e);
      //      }
      //   });
      //   write.Wait();
      //}
      //
      #endregion
      #region ConcurrentBug

      public static void Main()
      {
         ConcurrentBag<int> bag = new ConcurrentBag<int>();
         Task.Run(() =>
         {
            bag.Add(42);
            Thread.Sleep(1000);
            bag.Add(21);
         });
         Task.Run(() =>
         {
            foreach (int i in bag)
               Console.WriteLine(i);
         }).Wait();
         //////////////////////
         
         Console.WriteLine("ConcurentStack//////////////////////");
         ConcurrentStack<int> stack = new ConcurrentStack<int>();
         stack.Push(42);
         stack.Push(4992);
         stack.Push(555);
         int result;
         if (stack.TryPop(out result))
            Console.WriteLine("Popped: {0}", result);
         
         stack.PushRange(new int[] { 1, 2, 3 });
         int[] values = new int[2];
         stack.TryPopRange(values);
         foreach (int i in values)
            Console.WriteLine(i);

         Console.WriteLine("ConcurrentQueue//////////////////////");

         ConcurrentQueue<MyClass> queue = new ConcurrentQueue<MyClass>();
         queue.Enqueue(new MyClass() { MyProperty = 1, MyProperty2 = "dddddddddddddd" });
         queue.Enqueue(new MyClass() { MyProperty = 55, MyProperty2 = "ffffffffffff" });
         queue.Enqueue(new MyClass() { MyProperty = 66, MyProperty2 = "fgggggggggggggg" });
         MyClass resultq;
         if (queue.TryDequeue(out resultq))
            Console.WriteLine($"Dequeued: {resultq.MyProperty} {resultq.MyProperty2}");
         ///
         Console.WriteLine("ConcurrentDictionary//////////////////////");

         var dict = new ConcurrentDictionary<string, int>();
         if (dict.TryAdd("k1", 42))
         {
            Console.WriteLine("Added");
         }
         if (dict.TryUpdate("k1", 21, 42))
         {
            Console.WriteLine("42 updated to 21");
         }
         dict["k1"] = 42; // Overwrite unconditionally
         int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
         int r2 = dict.GetOrAdd("k2", 3);


         Console.ReadKey();
      }

      public class MyClass
      {
         public int MyProperty { get; set; }
         public string MyProperty2 { get; set; }
      }

      #endregion
   }
}
