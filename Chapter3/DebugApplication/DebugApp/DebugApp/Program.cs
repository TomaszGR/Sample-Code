using System;
using System.Diagnostics;
using System.Threading;

namespace DebugApp
{
   //   class Program
   //   {
   //      public static void Main()
   //      {
   //#if DEBUG
   //         Console.WriteLine("debug mode");
   //#else
   //         Console.WriteLine("relese mode");
   //#endif
   //
   //         //#line 999
   //         //         throw new Exception();
   //         //#line default
   //         //         throw new Exception();
   //         //#line hidden
   //         //         throw new Exception();
   //
   //         Timer t = new Timer(TimerCallback, null, 0, 2000);
   //         Timer t2 = new Timer(_ => Console.WriteLine($"lal"), null, 0, 2000);
   //
   //#pragma warning disable 0162, CS0168
   //         int jjj;
   //#pragma warning restore 0162
   //         while (false)
   //         {
   //            int fff;
   //         }
   //#pragma warning restore
   //
   //         Log("foo");
   //         
   //         Console.WriteLine("end ");
   //         Console.ReadLine();
   //      }
   //
   //      [Conditional("DEBUG")]
   //      public static void Log(string s)
   //      {
   //         Console.WriteLine("Log: " + s);
   //      }
   //
   //      private static void TimerCallback(Object o)
   //      {
   //         Console.WriteLine("In TimerCallback: " + DateTime.Now);
   //         GC.Collect();
   //      }
   //
   //      private static void TimerCallback2(Object o)
   //      {
   //         Console.WriteLine("In TimerCallback2: " + DateTime.Now);
   //      }
   //   }

   #region 3.5 Implementdiagnostics in an application

   class Program
   {
      static void Main()
      {
         Debug.WriteLine("debug line");
         Debug.Indent();

         int i = 4;
         //Debug.Assert(i==6);
         Debug.WriteLineIf(i > 2, $"i greater then 2");

         TraceSource traceSource = new TraceSource("myTraceSource");
         traceSource.TraceEvent(TraceEventType.Critical, 3, "Message event source");
         traceSource.TraceData(TraceEventType.Information, 5, new object[] { "a", "c" });
         traceSource.Flush();
         traceSource.Close();

         Console.WriteLine("end");
         Console.ReadLine();
      }

   }

   #endregion
}
