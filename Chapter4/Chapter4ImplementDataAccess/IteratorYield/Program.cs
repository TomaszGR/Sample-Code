using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorYield
{
   public static class Dumps
   {
      public static void Dump(this object txt)
      {
         Console.WriteLine(txt);
      }
   }

   class Weeks
   {
      private readonly string[] weeks = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
      private readonly List<string> weeks2 = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

      public IEnumerable GetWeeksIterator()
      {
         return new WeeksIterator(weeks);
      }

      //zastosowanie yield powoduje że nie muszę mieć specjalnej clasy iteratora która trzyma stan iteracji
      //yield utrzymuje machine state
      public IEnumerable GetWorkDays()
      {
         for (int i = 0; i < weeks.Length - 2; i++)
         {
            yield return weeks[i];
         }
      }

      public IEnumerable GetWorkDays2()
      {
         for (int i = 0; i < weeks2.Count - 2; i++)
         {
            yield return weeks2[i];
         }
      }

      public IEnumerable GetWorkDays3()
      {
         for (int i = 0; i < weeks2.Count - 2; i++)
         {
            yield return weeks2;
         }
      }

   }

   //public interface IWeeksIterator
   //{
   //   string Current { get; }
   //   bool MoveNext();
   //}

   //class WeeksIterator : IWeeksIterator
   //{
   //   private readonly string[] weeks;
   //   private int position;
   //
   //   public WeeksIterator(string[] weeks)
   //   {
   //      this.weeks = weeks;
   //      this.position = -1;
   //   }
   //   public string Current => weeks[position];
   //   public bool MoveNext()
   //   {
   //      if (++position == weeks.Length)
   //      {
   //         return false;
   //      }
   //      return true;
   //   }
   //}

   class WeeksIterator : IEnumerator, IEnumerable
   {
      private readonly string[] weeks;
      private int position;

      public WeeksIterator(string[] weeks)
      {
         this.weeks = weeks;
         this.position = -1;
      }
      public object Current => weeks[position];

      public IEnumerator GetEnumerator()
      {
         return this;
      }

      public bool MoveNext()
      {
         if (++position == weeks.Length)
         {
            return false;
         }
         return true;
      }

      public void Reset()
      {
         this.position = -1;
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Weeks weeks = new Weeks();
         string[] weeks2 = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
         //IEnumerator itrator = weeks.GetWeeksIterator();

         //while (itrator.MoveNext())
         //{
         //   itrator.Current.Dump();
         //}

         foreach (var item in weeks.GetWeeksIterator())
         {
            item.Dump();
         }

         "//////////////////".Dump();
         foreach (var item in weeks.GetWorkDays())
         {
            item.Dump();
         }

         List<Books> books = new List<Books>();
         var books2 = new List<Books2>();
         books2.Where(x=>x.Title.Contains("asdf"));
         // ...
         books.Where(b=>b.Title.StartsWith("T"));
         var filteredBooks = books.Where(book => book.Title.StartsWith("R"))
             .OrderBy(book => book.Published.Year)
             .Select(book => book.Title);

         IEnumerable<int> list = new List<int> { 1, 2, 3 };
         IEnumerable list2 = new List<int> { 1, 2, 3 };
         IEnumerable<int> array = new[] { 1, 2, 3 };
         IEnumerable<int> set = new SortedSet<int> { 1, 2, 3 };

         var ll = new[] { 1, 2, 3, 4 }.Where(x => x > 2);

         Console.ReadKey();
         Console.WriteLine("end");
      }
   }

   internal class Books
   {
      public string Title { get; set; }
      public DateTime Published { get; set; }
   }

   internal class Books2
   {
      public string Title { get; set; }
      public DateTime Published { get; set; }
      IEnumerable<Books2> books = new List<Books2>();

      public IEnumerable<Books2> GetBooks()
      {
         return books;
      }
   }
}
