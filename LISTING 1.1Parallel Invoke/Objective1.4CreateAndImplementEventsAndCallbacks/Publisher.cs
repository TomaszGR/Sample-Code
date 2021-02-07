using System;
using System.Collections.Generic;
using System.Linq;

namespace Objective1._4CreateAndImplementEventsAndCallbacks
{
   public class MyArgs : EventArgs
   {
      public int Value { get; set; }
      public MyArgs(int value)
      {
         Value = value;
      }
   }

   public class Publisher
   {
      public event EventHandler<MyArgs> OnChange;

      public void Raise(MyArgs myArgs)
      {
         Console.WriteLine($"Start pulishing");
         OnRise(myArgs);
      }

      protected virtual void OnRise(MyArgs myArgs)
      {
         Console.WriteLine($"OnRise protected method fire Invoke");

         List<Exception> exeptions = new List<Exception>();

         foreach (Delegate @delegate in OnChange.GetInvocationList())
         {
            try
            {
               @delegate.DynamicInvoke(this, myArgs);
            }
            catch (Exception e)
            {
               exeptions.Add(e);
            }
         }

         if (exeptions.Any())
         {
            throw new AggregateException(exeptions);
         }

      }
   }
}
