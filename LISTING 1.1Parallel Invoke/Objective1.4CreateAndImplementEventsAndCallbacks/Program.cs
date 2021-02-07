using System;
using System.IO;

namespace Objective1._4CreateAndImplementEventsAndCallbacks
{
   #region Delegate

   // class MyClass
   // {
   //
   //    public delegate int Calculate2(int x, int y);
   // }
   // class Program
   // {
   //    public void MethodOne()
   //    {
   //       Console.WriteLine("MethodOne");
   //    }
   //    public void MethodTwo()
   //    {
   //       Console.WriteLine("MethodTwo");
   //    }
   //    public delegate void Del();
   //    public void Multicast()
   //    {
   //       Del d = MethodOne;
   //       d += MethodTwo;
   //       d();
   //    }
   //
   //    public delegate int Calculate(int x, int y);
   //
   //    public delegate TextWriter CovarianceDel();
   //    public StreamWriter MethodStream() { return null; }
   //    public StringWriter MethodString() { return null; }
   //
   //    public delegate void ContravarianceDel(StreamWriter tw);
   //
   //    public int Add(int x, int y)
   //    {
   //       return x + y;
   //    }
   //    public int Multiply(int x, int y)
   //    {
   //       return x * y;
   //    }
   //
   //    public void UseDelegate()
   //    {
   //       Calculate calculate = Add;
   //       Calculate calculate3 = (x,y) => { return x + y; };
   //
   //       Action<int, int> calcA = (x, y) =>
   //       {
   //          Console.WriteLine($"calcA: {x + y}");
   //       };
   //       calcA(3, 4);
   //
   //       
   //       MyClass.Calculate2 calculate2 = Add;
   //       Console.WriteLine($"{calculate(5,6)}");
   //       Console.WriteLine($"calc2: {calculate2(5,6)}");
   //       Console.WriteLine($"calc3: {calculate3(555555555,6)}");
   //       calculate = Multiply;
   //       Console.WriteLine($"{calculate(5,6)}");
   //    }
   //
   //    public delegate string calculateAgeEraFunctionPointer(int year);
   //    public delegate string changeTitleFunctionPointer(string name);
   //    public delegate void showTwoStringsPointer(string p1, string p2);
   //    static void Main(string[] args)
   //    {
   //       Program p = new Program();
   //       p.UseDelegate();
   //       
   //       MyClass.Calculate2 calc2 = p.Add;
   //       calc2(8,8);
   //       Console.WriteLine($"calc2 {calc2(7,334)}");
   //       p.Multicast();
   //
   //       Console.WriteLine($"//////////////////////");
   //       var methods = new Methods();
   //       Func<int, string> calculateAgeEraDel = methods.CalculateAgeEra;
   //       calculateAgeEraFunctionPointer calculateAgeEraFunctionPointer = methods.CalculateAgeEra;
   //       Console.WriteLine($"calculateAgeEraFunctionPointer: {calculateAgeEraFunctionPointer(2013)}");
   //       Console.WriteLine($"calculateAgeEraDel: {calculateAgeEraDel(2020)}");
   //       changeTitleFunctionPointer changeTitleFunctionPointer;
   //       changeTitleFunctionPointer = methods.UpperCaseName;
   //       changeTitleFunctionPointer = methods.LowerCaseName;
   //       Console.WriteLine($"changeTitleFunctionPointer: {changeTitleFunctionPointer("lalaLALAL")}");
   //
   //       Func<int, int, int> multiFunc = p.Multiply;
   //       Console.WriteLine($"multiFunc: {multiFunc(345,345)}");
   //
   //
   //       Console.WriteLine($"stop");
   //    }
   // }
   #endregion
   #region Delegate func lambda events

   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //      //Func<int, int, int> funcDelAdd = (int x, int y) => x + y;
   //      //Action<string> actionWriteTxt = (string t) =>
   //      //{
   //      //   Console.WriteLine($"{t}");
   //      //};
   //      //
   //      //Console.WriteLine($"Func delegate Add: {funcDelAdd(5,6)}");
   //      //actionWriteTxt("tekst do wypisania przez delegate ActionWriteText");

   //      Program p = new Program();
   //      p.CreateAndRaise();


   //      Console.WriteLine($"end");
   //      Console.ReadLine();
   //   }

   //   public void CreateAndRaise()
   //   {
   //      //Pub pub = new Pub();
   //      ////pub.OnChange += () => Console.WriteLine($" event raised to method 1");
   //      //pub.OnChange += (sender, e) => Console.WriteLine($"EventHendler1: {e.Value}");
   //      //pub.OnChange += (sender, e) => { throw new Exception(); };
   //      //pub.OnChange += (sender, e) => Console.WriteLine($"EventHendler2: {e.Value}");
   //      //pub.Raise();

   //      Publisher p = new Publisher();
   //      p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");
   //      p.OnChange += (sender, e) => { throw new Exception(); };
   //      p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");
   //      try
   //      {
   //         p.Raise();
   //      }
   //      catch (AggregateException ex)
   //      {
   //         Console.WriteLine(ex.InnerExceptions.Count);
   //      }

   //   }

   // }
   #endregion
   #region EventHendler
   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //      var per = new Person() { FirstName = "Tom", Surname = "Kowal" };
   //      var publisher = new ProcessBusinessLogic();
   //      //publisher.ProcessCompleted += () => Console.WriteLine($"Foo");
   //      publisher.ProcessCompleted += EventHendlerMethod;
   //      publisher.ProcessCompleted += (object o, EventArgs e) => Console.WriteLine("aa");
   //      publisher.StartProcess();

   //      Console.WriteLine($"end");
   //   }

   //   //eventhendler method
   //   public static void EventHendlerMethod(object sender, EventArgs e)
   //   {
   //      Console.WriteLine($"HendlerMethod insted of Labmda");
   //   }

   //}
   #endregion
   #region EventHandler<TEventArgs> Delegat
   //class Program
   //{
   //   static void Main(string[] args)
   //   {
   //      var per = new Person() { FirstName = "Tom", Surname = "Kowal" };
   //      var publisher = new ProcessBusinessLogic();
   //      publisher.ProcessCompleted2 += EventHendlerMethodPrintName;
   //      publisher.StartProcessPrintName(per);
   //      Console.WriteLine($"end");
   //   }

   //   //EventHendler method
   //   // METODA która pasuje do KONTAKTU, spełnia warunki delegaty
   //   public static void EventHendlerMethodPrintName(object sender, Person e)
   //   {
   //      Console.WriteLine($"EventHendlerMethodPrintName insted of Labmda {e.FirstName} surname: {e.Surname}");
   //   }
   //}
   #endregion

   #region EventHendler exeption

   class Program
   {
      static void Main(string[] args)
      {
         Program p = new Program();
         Publisher publisher = new Publisher();
         MyArgs myArgs = new MyArgs(12345);
         publisher.OnChange += Publisher_OnChange;
         publisher.OnChange += Publisher_OnChangeEx;
         publisher.OnChange += Publisher_OnChange;
         publisher.Raise(myArgs);

      //   p.CreateAndRaise();

         Console.WriteLine($"end");
         Console.ReadLine();
      }
      private static void Publisher_OnChange(object sender, MyArgs e)
      {
         Console.WriteLine($"PublisherOnChange method value equals: {e.Value}");
      }

      private static void Publisher_OnChangeEx(object sender, MyArgs e)
      {
         throw new Exception("foo");
      }


      //public void CreateAndRaise()
      //{
      //   //Pub pub = new Pub();
      //   ////pub.OnChange += () => Console.WriteLine($" event raised to method 1");
      //   //pub.OnChange += (sender, e) => Console.WriteLine($"EventHendler1: {e.Value}");
      //   //pub.OnChange += (sender, e) => { throw new Exception(); };
      //   //pub.OnChange += (sender, e) => Console.WriteLine($"EventHendler2: {e.Value}");
      //   //pub.Raise();

      //   Publisher p = new Publisher();
      //   p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");
      //   p.OnChange += (sender, e) => { throw new Exception(); };
      //   p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");
      //   try
      //   {
      //      p.Raise();
      //   }
      //   catch (AggregateException ex)
      //   {
      //      Console.WriteLine(ex.InnerExceptions.Count);
      //   }

      //}

   }
   #endregion

}
