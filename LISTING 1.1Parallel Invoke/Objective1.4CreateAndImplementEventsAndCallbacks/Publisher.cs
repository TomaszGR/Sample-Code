using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
      public event EventHandler<MyArgs> OnChange = delegate { };
      //public event Action OnChange = delegate { };
      //public Action OnChange { get; set; }
 
      public void Raise()
      {
         //OnChange(this, e: new MyArgs(2345));

         var exceptions = new List<Exception>();
         foreach (Delegate handler in OnChange.GetInvocationList())
         {
            try
            {
               handler.DynamicInvoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
               exceptions.Add(ex);
            }
         }
         if (exceptions.Any())
         {
            throw new AggregateException(exceptions);
         }
      }
   
   
   }
}
