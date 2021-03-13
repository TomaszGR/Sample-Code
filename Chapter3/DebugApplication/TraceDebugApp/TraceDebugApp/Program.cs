using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceDebugApp
{
   #region TraceSource

   //class Program
   //{
   //   static TraceSource ts = new TraceSource("TraceTest");
   //   [SwitchAttribute("SourceSwitch", typeof(SourceSwitch))]
   //   static void Main(string[] args)
   //   {
   //      ///
   //      //Stream outputFile = File.Create("tracefile.txt");
   //      //TextWriterTraceListener textWriterTraceListener = new TextWriterTraceListener(outputFile);
   //      //TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
   //      //traceSource.Listeners.Clear();
   //      //traceSource.Listeners.Add(textWriterTraceListener);
   //      //traceSource.TraceInformation("sample message");
   //      //
   //      //traceSource.Flush();
   //      //traceSource.Close();

   //      //Configfile

   //      SourceSwitch sourceSwitch = new SourceSwitch("SourceSwitch", "Verbose");
   //      ts.Switch = sourceSwitch;
   //      int idxConsole = ts.Listeners.Add(new System.Diagnostics.ConsoleTraceListener());
   //      ts.Listeners[idxConsole].Name = "console";

   //      ts.TraceEvent(TraceEventType.Warning, 2, "File Test not found");
   //      ts.TraceEvent(TraceEventType.Verbose, 2, "File Test not found2");
   //      ts.TraceEvent(TraceEventType.Information, 2, "File Test not ii");
   //      ts.Flush();
   //      ts.Close();


   //      Console.WriteLine("end");
   //      Console.ReadLine();
   //   }
   //}
   #endregion
   #region writing data to event log
   //class Program
   //{
   //   public static void Main()
   //   {
   //      //if (!EventLog.SourceExists("MySource"))
   //      //{
   //      //   EventLog.CreateEventSource("MySource", "MyNewLog");
   //      //   Console.WriteLine("Created event source");
   //      //   Console.WriteLine("Please restar");
   //      //   Console.ReadKey();
   //      //   return;
   //      //}
   //      //
   //      //EventLog eventLog = new EventLog();
   //      //eventLog.Source = "MySource";
   //      //eventLog.WriteEntry("Log event!");
   //      EventLog applicationLog = new EventLog("Application", ".", "testEventLogEvent");
   //      applicationLog.EntryWritten += (sender, e) =>
   //      {
   //         Console.WriteLine(e.Entry.Message);
   //      };
   //      applicationLog.EnableRaisingEvents = true;
   //      applicationLog.WriteEntry("Test message", EventLogEntryType.Information);
   //      Console.ReadKey();
   //   }
   //}
   #endregion

   //class Program
   //{
   //
   //   const int numberOfIterations = 100000;
   //   static void Main(string[] args)
   //   {
   //      Stopwatch sw = new Stopwatch();
   //      sw.Start();
   //      Algorithm1();
   //      sw.Stop();
   //      Console.WriteLine(sw.Elapsed.TotalSeconds);
   //      sw.Reset();
   //
   //      sw.Start();
   //      Algorithm2();
   //      sw.Stop();
   //      Console.WriteLine(sw.Elapsed.TotalSeconds);
   //      Console.WriteLine("Ready…");
   //      Console.ReadLine();
   //   }
   //
   //   private static void Algorithm2()
   //   {
   //      string result = "";
   //      for (int x = 0; x < numberOfIterations; x++)
   //      {
   //         result += 'a';
   //      }
   //
   //   }
   //   private static void Algorithm1()
   //   {
   //      StringBuilder sb = new StringBuilder();
   //      for (int x = 0; x < numberOfIterations; x++)
   //      {
   //         sb.Append('a');
   //      }
   //      string result = sb.ToString();
   //   }
   //}

   #region Performancecounter

   class Program
   {
      static void Main(string[] args)
      {
         if (CreatePerformanceCounters())
         {
            Console.WriteLine("Created performance counters");
            Console.WriteLine("Please restart application");
            Console.ReadKey();
            return;
         }
         var totalOperationsCounter = new PerformanceCounter("MyCategory", "# operations executed","", false);
         var operationsPerSecondCounter = new PerformanceCounter("MyCategory","# operations / sec","",
         false);
         totalOperationsCounter.Increment();
         operationsPerSecondCounter.Increment();
      }
      private static bool CreatePerformanceCounters()
      {
         if (!PerformanceCounterCategory.Exists("MyCategory"))
         {
            CounterCreationDataCollection counters =
            new CounterCreationDataCollection
            {
               new CounterCreationData("# operations executed","Total number of operations executed",PerformanceCounterType.NumberOfItems32),
               new CounterCreationData("# operations / sec","Number of operations executed per second",PerformanceCounterType.RateOfCountsPerSecond32)
            };
            PerformanceCounterCategory.Create("MyCategory",            "Sample category for Codeproject", counters);
            return true;
         }
         return false;
      }
   }
   #endregion
}
