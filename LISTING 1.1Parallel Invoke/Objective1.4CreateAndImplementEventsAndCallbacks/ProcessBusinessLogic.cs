using System;
using System.Collections.Generic;
using System.Text;

namespace Objective1._4CreateAndImplementEventsAndCallbacks
{
   public class Person : EventArgs
   {
      public string FirstName { get; set; }
      public string Surname { get; set; }
   }
   public class ProcessBusinessLogic
   {
      // declaring an event using built-in EventHandler!!
      // TO jest KONTRAKT pomiędzy Subskrybentem a Nadawcą
      public event EventHandler ProcessCompleted;
      public event EventHandler<Person> ProcessCompleted2;

      public void StartProcess()
      {
         Console.WriteLine($"process start...");
         //Some code
         OnProcessStart(EventArgs.Empty); // brak argumentó
         Console.WriteLine($"process end...");
      }

      public void StartProcessPrintName(Person person)
      {
         Console.WriteLine($"process print name start...");
         //Some code
         OnProcessStartPrintName(person); // brak argumentów
         Console.WriteLine($"process print name end...");
      }

      protected virtual void OnProcessStart(EventArgs e)
      {
         ProcessCompleted?.Invoke(this, e);
      }

      protected virtual void OnProcessStartPrintName(Person e)
      {
         Console.WriteLine($" Person first name is: {e.FirstName}");
         ProcessCompleted2?.Invoke(this, e);
      }


   }
}
